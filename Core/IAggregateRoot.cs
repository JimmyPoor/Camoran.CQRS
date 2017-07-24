using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public interface IAggregateRoot
    {
        Guid ID { get; set; }

        int Version { get; }
      
        void RestoreFromEvents(IEnumerable<IEvent> evnts);

        void ApplyEvent(IEvent @event);

        void SetVersion(int version);

        IEnumerable<IEvent> UnCommitEvents { get; }

    }


    public interface IAggregateRootFactory<T> where T:IAggregateRoot
    {
        T Create();
    }
}
