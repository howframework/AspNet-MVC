using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Howframework.Domain.Commands;

namespace Howframework.Domain.Infrastructure
{
    public class CommandBus :IBus
    {
        private IDictionary<Type, Action<dynamic>> handlers = new Dictionary<Type, Action<dynamic>>();

        public void RegisterHandlerCommand<TCommand>(Action<TCommand> cmd) where TCommand : ICommand
        {
            this.handlers.Add(typeof(TCommand), c => cmd((TCommand)c));
        }

        public void Send(ICommand cmd)
        {
            foreach (var e in this.handlers.Where(c => c.Key == cmd.GetType()))
            {
                e.Value(cmd);
            }
        }
    }
}
