using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Carts.Domain.CartAggregate;
using Carts.Domain.Tests.DataBuilders;
using Carts.Domain.Events;

namespace Carts.Domain.Tests.CartAggregate
{
    public class CartTests
    {
        [Trait(nameof(CartTests), "Handle Items Added Event")]
        public class HandleItemsAddedEvent : CartTests
        {
            [Fact]
            public void Adds_a_new_line_item_when_product_does_not_exist_in_cart()
            {
                
            }

            [Fact]
            public void Updates_a_line_item_when_it_already_exists_in_cart()
            {

            }

            [Fact]
            public void Throws_ArgumentNullException_when_null_event_provided()
            {

            }
        }

        [Trait(nameof(CartTests), "Handle Items Removed Event")]
        public class HandleItemsRemovedEvent : CartTests
        {
            [Fact]
            public void Decrements_existing_item_quantity_when_new_quantity_is_not_zero()
            {

            }

            [Fact]
            public void Removes_existing_item_when_new_quanity_is_zero()
            {

            }

            [Fact]
            public void Throws_CartException_when_item_is_not_found_in_cart()
            {

            }

            [Fact]
            public void Throws_ArgumentNullException_when_null_event_provided()
            {

            }
        }
    }
}
