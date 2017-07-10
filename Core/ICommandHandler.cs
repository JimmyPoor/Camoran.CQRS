using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public interface ICommandHandler
    {
        void SendCommand<ICommand>(ICommand message);
    }
}
