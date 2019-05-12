using System;
using System.Collections.Generic;
using System.Text;
using Carts.Domain.Events;
using Carts.Domain.CartAggregate;

namespace Carts.Domain.Tests.DataBuilders
{
    public class CartBuilder
    {
        private Cart cart;

        private CartBuilder()
        {
            
        }

        public static CartBuilder Randomized()
        {
            return new CartBuilder();
        }

        public Cart Build() => cart;
    }
}
