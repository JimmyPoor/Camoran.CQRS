using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(TEvent @event, IEventHandler<TEvent> handler) where TEvent : IEvent;
        void Publish<TEvent>(TEvent @event) where TEvent:IEvent;
    }
}
