using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core
{
    public interface ICommandHandler<Command> where Command:ICommand
    {
        ICommandService Service { get; }

        void Send(Command message);
        void HandleCommand(Command message);
    }
}
