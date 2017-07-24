using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public interface IEventService
    {
        IEventBus EventBus { get;  }

        ISnapshot<IEvent> SnapShot { get; }

        void SaveEvent(IEvent @event);

        IEnumerable<IEvent> GetEvents(Guid a);

    }
}
