using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace Howframework.Domain
{
    public class Entity
    {
        public Entity()
        {

        }

        public virtual ObjectId Id { get; set; }
    }
}
