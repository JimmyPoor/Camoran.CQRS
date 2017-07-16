using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core
{
    public interface ICommandHandler<Command> where Command:ICommand
    {
        ICommandService<Command> Service { get; }

        Task Send(Command message);
        Task HandleCommand(Command message);
    }
}
