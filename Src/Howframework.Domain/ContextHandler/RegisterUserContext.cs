using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Howframework.Domain.Commands;
using Howframework.Domain.Infrastructure;
using Howframework.Domain.UserManagement;

namespace Howframework.Domain.ContextHandler
{
    public class RegisterUserContext:ICommandHandler<RegisterCommand>
    {
        public void Handle(RegisterCommand cmd)
        {

        }

        class Register
        {
            
        }
    }
}
