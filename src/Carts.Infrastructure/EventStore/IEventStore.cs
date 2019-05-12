using Carts.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carts.Infrastructure.EventStore
{
    public interface IEventStore
    {
        Task CreateNewStream(string streamName, IEnumerable<DomainEvent> domainEvents);

        Task AppendEventsToStream(string streamName, IEnumerable<DomainEvent> domainEvents, int? expectedVersion);

        Task<IEnumerable<DomainEvent>> GetStream(string streamName, int fromVersion, int toVersion);

        Task AddSnapshot<T>(string streamName, T snapshot);

        Task<T> GetLatestSnapshot<T>(string streamName) where T : class;
    }
}
