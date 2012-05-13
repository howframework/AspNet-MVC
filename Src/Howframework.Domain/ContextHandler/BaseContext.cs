using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Howframework.Domain.Infrastructure;

namespace Howframework.Domain.ContextHandler
{
    public abstract class BaseContext
    {
        protected IUnitOfWork server;

        
        public BaseContext()
        {
            server = new MongoDbSession();
        }
    }
}
