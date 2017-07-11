using System;

namespace Camoran.CQRS.Core
{
    public interface IEvent : IMessage
    {
        Guid EventId { get; set; }
        int Version { get; set; }
    }
}
