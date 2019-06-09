using Carts.Domain.Common;
using Carts.Infrastructure.Internal.EventStore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carts.Infrastructure.Internal.InternalContracts
{
    public interface IEventStore
    {
        Task CreateNewStream(string streamName, IEnumerable<DomainEvent> domainEvents);

        Task AppendEventsToStream(string streamName, IEnumerable<DomainEvent> domainEvents, int? expectedVersion);

        Task<IEnumerable<EventWrapper>> GetStream(string streamName, int fromVersion, int toVersion);

        Task AddSnapshot<T>(string streamName, T snapshot);

        Task<T> GetLatestSnapshot<T>(string streamName) where T : class;
    }
}
