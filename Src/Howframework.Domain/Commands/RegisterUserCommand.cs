using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Howframework.Domain.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public string fullname { set; get; }
        public string username { set; get; }
        public string email { set; get; }
        public string password { set; get; }
    }
}
