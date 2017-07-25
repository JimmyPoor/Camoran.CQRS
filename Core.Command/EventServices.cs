using System;
using System.Collections.Generic;
using Guards.Extensions;

namespace Camoran.CQRS.Core.Infrastructure
{
    public class MemoryEventService : IEventService
    {
        protected static List<IEvent> Events;

        public IEventBus EventBus { get; protected set; }

        public ISnapshot<IEvent> SnapShot { get; protected set; }


        public MemoryEventService(IEventBus bus, ISnapshot<IEvent> snapshot)
        {
            bus.EnsureNotNull();
            snapshot.EnsureNotNull();

            Events = new List<IEvent>();
            EventBus = bus;
            SnapShot = snapshot;
        }

        public IEnumerable<IEvent> GetEvents(Guid aggId)
        {
            var @event = Events.Find(e => e.AggregateId == aggId);
            return @event != null ? GetEvents(aggId, @event.Version): Events.FindAll(e => e.AggregateId == aggId);
        }

        public void SaveEvent(IEvent @event)
        {
            @event.EnsureNotNull();

            Events.Add(@event);
            SnapShot.Save(@event.Version, @event);
        }

        public IEnumerable<IEvent> GetEvents(Guid aggId, int version)
        {
            var events= SnapShot.GetByVersionId(version);

            return Events.FindAll(e => e.AggregateId == aggId);
        }
    }
}
