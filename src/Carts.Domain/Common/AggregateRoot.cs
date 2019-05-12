using System.Collections.Generic;

namespace Carts.Domain.Common
{
    /// <summary>
    ///     Marker interface!
    /// </summary>
    public abstract class AggregateRoot
    {
        public int Version { get; protected set; }
        public List<DomainEvent> NewEvents { get; protected set; } = new List<DomainEvent>();

        public abstract void Handle(DomainEvent domainEvent);
    }
}
