using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core
{
    public interface ICommandService
    {
        void SaveCommnad(ICommand command);
        Task SaveCommandAsync(ICommand command);
    }
}
