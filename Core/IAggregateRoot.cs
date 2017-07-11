using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public interface IAggregateRoot
    {
        int Version { get; }
      
        void RestoreFromEvents(IEnumerable<IEvent> evnts);

        void ApplyEvent(IEvent @event);
    }
}
