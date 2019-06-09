using Carts.Domain.CartAggregate;
using Carts.Infrastructure.Internal.InternalContracts;
using System;
using System.Threading.Tasks;

namespace Carts.Infrastructure.Internal.Repositories
{
    internal class CartsRepository : ICartsRepository
    {
        private readonly IEventStore eventStore;

        public CartsRepository(IEventStore cartEventStore)
        {
            this.eventStore = cartEventStore 
                ?? throw new ArgumentNullException(nameof(cartEventStore));
        }

        public async Task<Cart> GetByUserId(string userId)
        {

            Cart cart = null;

            //if (latestSnapshot == null)
            //{
            //    cart = new Cart(null);
            //}
            //else
            //{
            //    cart = latestSnapshot;
            //}

            throw new NotImplementedException();
        }

        public async Task<Cart> Insert(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
