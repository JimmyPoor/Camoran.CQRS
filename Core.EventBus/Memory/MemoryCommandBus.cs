using Camoran.CQRS.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Camoran.CQRS.Core.Bus
{
    public class MemoryCommandBus : ICommandBus
    {
        public ConcurrentDictionary<string, ICommandHandler<ICommand>> Commands => throw new NotImplementedException();

        public virtual void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (Commands.ContainsKey(command.Topic))
            {
                Commands[command.Topic].Send(command);
            }
        }

        public virtual Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (Commands.ContainsKey(command.Topic))
            {
                return Commands[command.Topic].Send(command);
            }

            return Task.FromResult(0);
        }

    }
}
