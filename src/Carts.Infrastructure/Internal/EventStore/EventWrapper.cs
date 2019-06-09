using Carts.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carts.Infrastructure.Internal.EventStore
{
    public class EventWrapper
    {
        public string Id { get; set; }
        public string StreamId { get; set; }
        public int Sequence { get; set; }
        public DomainEvent Event { get; set; }
    }
}
