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
        //MongoServer mongoServer;

        MongoDatabase mongoDb;

        public IUnitOfWork StartUnitOfWork()
        {
            var connectionString = System.Configuration.ConfigurationManager.AppSettings.Get("MONGOLAB_URI"); //AppSettings //"mongodb://localhost/?safe=true";
            mongoDb = MongoDatabase.Create(connectionString); //MongoServer.Create(connectionString);
            //MongoCredentials credentials = new MongoCredentials("howframework", "linuxpython");
            //mongoDb = mongoServer.GetDatabase("howframework");
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
