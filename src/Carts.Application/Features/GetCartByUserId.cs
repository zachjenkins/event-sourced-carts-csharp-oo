using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Carts.Domain.CartAggregate;
using Carts.Domain.Events;
using MediatR;

namespace Carts.Application.Features
{
    public class GetCartByUserId
    {
        public class Query : IRequest<Cart>
        {
            public string UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Cart>
        {
            private readonly ICartsRepository cartsRepository;

            public Handler(ICartsRepository cartsRepository)
            {
                this.cartsRepository = cartsRepository;
            }

            public async Task<Cart> Handle(Query query, CancellationToken cancellationToken)
            {
                var cart = await cartsRepository.GetByUserId(query.UserId);

                if (cart == null)
                {
                    var cartCreatedEvent = new CartCreatedEvent(query.UserId);

                    cart = new Cart(cartCreatedEvent);

                    
                }

                throw new Exception();
            }
        }
    }
}
