using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core
{
    public interface IEventHandler<Event> where Event:IEvent
    {
        void Handle(Event @event);
    }
}
