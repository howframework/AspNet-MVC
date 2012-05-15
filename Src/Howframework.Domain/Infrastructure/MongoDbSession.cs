using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System.Configuration;

namespace Howframework.Domain.Infrastructure
{
    public class MongoDbSession : IUnitOfWork
    {
        MongoServer mongoServer;

        MongoDatabase mongoDb;
        protected IDictionary<Type,dynamic> entityUoW = new Dictionary<Type,dynamic>();

        public IUnitOfWork StartUnitOfWork()
        {
            var connectionString = GetMongoDbConnectionString();
            if (connectionString.Contains("localhost"))
            {
                mongoServer = MongoServer.Create(connectionString);
                mongoDb = mongoServer.GetDatabase("howframework");
            }
            else
            {
                mongoDb = MongoDatabase.Create(connectionString);
            }

            entityUoW.Clear();

            return this;
        }

        public void Save<T>(T entity)
        {
            //var s = mongoDb.GetCollection<T>(typeof(T).Name.ToLower());
            //s.Save<T>(entity);
            entityUoW.Add(typeof(T),entity);
        }

        public T GetById<T>(dynamic Id)
        {
            var s = mongoDb.GetCollection<T>(typeof(T).Name.ToLower());
            return s.FindOneById(Id);
        }

        public IQueryable<T> Query<T>()
        {
            var s = mongoDb.GetCollection<T>(typeof(T).Name.ToLower());
            return s.AsQueryable<T>();
        }

        public void Commit()
        {
            foreach (var entity in entityUoW)
            {
                var s = mongoDb.GetCollection(entity.Key, entity.Key.Name.ToLower());
                s.Save(entity.Key, entity.Value);
            }
        }

        public void Dispose()
        {
            
        }

        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOHQ_URL") ??
                ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                ConfigurationManager.AppSettings.Get("LOCAL_MONGODB_URI");
        }
    }
}
