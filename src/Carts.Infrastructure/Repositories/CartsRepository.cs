using System;
using System.Collections.Generic;
using System.Text;
using Carts.Domain;
using System.Threading.Tasks;
using Carts.Domain.CartAggregate;
using Carts.Infrastructure.EventStore;

namespace Carts.Infrastructure.Repositories
{
    public class CartsRepository : ICartsRepository
    {
        private readonly IEventStore eventStore;

        public CartsRepository(IEventStore cartEventStore)
        {
            this.eventStore = cartEventStore 
                ?? throw new ArgumentNullException(nameof(cartEventStore));
        }

        public async Task<Cart> GetByUserId(string userId)
        {
            var stream = StreamNameFor(userId);

            var latestSnapshot = await eventStore.GetLatestSnapshot<Cart>(stream);

            Cart cart = null;

            if (latestSnapshot == null)
            {
                cart = new Cart()
            }
            else
            {
                cart = latestSnapshot;
            }

            throw new NotImplementedException();
        }

        private string StreamNameFor(string cartId) => $"Cart_{cartId}";
    }
}
