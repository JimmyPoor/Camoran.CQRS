using System;

namespace Camoran.CQRS.Core
{
    public interface IEvent
    {
        int Version { get; set; }
    }
}
