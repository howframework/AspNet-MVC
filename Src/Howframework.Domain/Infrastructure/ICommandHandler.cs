using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Howframework.Domain.Infrastructure
{
    public interface ICommandHandler<Command>
    {
        void Handle(Command cmd);
    }
}
