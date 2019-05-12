using Carts.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace Carts.Infrastructure.EventStore
{
    public class MongoEventStore : IEventStore
    {
        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMongoCollection<EventWrapper> mongoCollection;

        public MongoEventStore(IMongoClient mongoClient,
                          IMongoDatabase mongoDatabase,
                          IMongoCollection<EventWrapper> mongoCollection)
        {
            this.mongoClient = mongoClient 
                ?? throw new ArgumentNullException(nameof(mongoClient));

            this.mongoDatabase = mongoDatabase
                ?? throw new ArgumentNullException(nameof(mongoDatabase));

            this.mongoCollection = mongoCollection
                ?? throw new ArgumentNullException(nameof(mongoCollection));
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

    public class EventWrapper
    {
        public string Id { get; set; }
        public DomainEvent Event { get; set; }
        public string EventStreamId { get; set; }
        public int EventSequence { get; set; }
    }
}
