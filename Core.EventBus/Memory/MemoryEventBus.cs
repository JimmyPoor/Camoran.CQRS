using Camoran.CQRS.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.Memory
{
    public class MemoryEventBus : IEventBus
    {
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TEvent>(TEvent @event, IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
