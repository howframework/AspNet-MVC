using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace Howframework.Domain.Infrastructure
{
    public class MongoDbSession : IUnitOfWork
    {
        MongoServer mongoServer;

        MongoDatabase mongoDb;

        public IUnitOfWork StartUnitOfWork()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            mongoServer = MongoServer.Create(connectionString);
            mongoDb = mongoServer.GetDatabase("howframework");
            return this;
        }

        public void Save<T>(T entity)
        {
            var s = mongoDb.GetCollection<T>(typeof(T).Name.ToLower());
            s.Save<T>(entity);
        }

        public T GetById<T>(dynamic Id)
        {
            var s = mongoDb.GetCollection<T>(typeof(T).Name.ToLower());
            return s.FindOneById(Id);
        }

        public void Dispose()
        {
            
        }
    }
}
