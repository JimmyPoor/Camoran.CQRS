using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core
{
    public interface ICommandBus
    {
       void  SendCommand<TCommand>(TCommand command) where TCommand:ICommand;
       Task  SendCommandAsync<TCommand>(TCommand command);

       ConcurrentDictionary<ICommand,ICommandHandler> Commands { get;}
    }   
}
