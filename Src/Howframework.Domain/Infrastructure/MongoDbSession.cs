using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace Howframework.Domain.Infrastructure
{
    public class MongoDbSession : IUnitOfWork
    {
        MongoServer mongoServer;

        MongoDatabase mongoDb;

        public IUnitOfWork StartSession()
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

        public void Dispose()
        {
            
        }
    }
}
