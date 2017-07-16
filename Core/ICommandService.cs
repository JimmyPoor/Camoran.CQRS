using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core
{
    public interface ICommandService<Command>
    {
        void SaveCommnad(Command command) ;
        Task SaveCommandAsync(Command command);
    }
}
