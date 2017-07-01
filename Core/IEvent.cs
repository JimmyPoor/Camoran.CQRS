using System;

namespace Camoran.CQRS.Core
{
    public interface IEvent : IMessage
    {
        int Version { get; set; }
    }
}
