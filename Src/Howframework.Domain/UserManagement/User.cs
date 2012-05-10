using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Howframework.Domain.UserManagement
{
    public class User : Entity
    {
        public User()
        {

        }

        public virtual string Name { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual string UserName { get; set; }

    }
}
