using Carts.Domain.Common;
using Carts.Infrastructure.Internal.InternalContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carts.Infrastructure.Internal.EventStore
{
    public class MongoEventStore : IEventStore
    {
        public MongoEventStore()
        {
        
        }

        public Task AddSnapshot<T>(string streamName, T snapshot)
        {


            throw new NotImplementedException();
        }

        public Task AppendEventsToStream(string streamName, IEnumerable<DomainEvent> domainEvents, int? expectedVersion)
        {
            throw new NotImplementedException();
        }

        public Task CreateNewStream(string streamName, IEnumerable<DomainEvent> domainEvents)
        {
            //var stream = new EventStream(streamName);

            //var res = await mongoCollection.InsertOneAsync()

            throw new NotImplementedException();
        }

        public Task<T> GetLatestSnapshot<T>(string streamName) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DomainEvent>> GetStream(string streamName, int fromVersion, int toVersion)
        {
            throw new NotImplementedException();
        }
    }

    public class EventStream
    {
        public string StreamName { get; set; }
        public int Version { get; set; }

        
    }
}
