using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Howframework.Domain.Commands;
using Howframework.Domain.Infrastructure;
using Howframework.Domain.UserManagement;

namespace Howframework.Domain.ContextHandler
{
    public class RegisterUserContext:BaseContext,ICommandHandler<RegisterUserCommand>
    {
        public void Handle(RegisterUserCommand cmd)
        {
            using (var uow = server.StartUnitOfWork())
            {
                if (uow.Query<User>().Where(c => c.UserName == cmd.username).Count() > 0)
                    throw new Exception(string.Format("Username {0} already exist!.",cmd.username));

                uow.Save<User>(new User { Email = cmd.email, FullName = cmd.fullname, Password = cmd.password, UserName = cmd.username });

                uow.Commit();
            }

        }
    }
}
