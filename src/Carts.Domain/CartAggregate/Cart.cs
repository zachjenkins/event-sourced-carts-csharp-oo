using Carts.Domain.Common;
using Carts.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carts.Domain.CartAggregate
{
    public class Cart : AggregateRoot
    {
        private IList<Item> items = new List<Item>();

        public int Id { get; }
        public string UserId { get; }
        public IEnumerable<Item> Items => items.AsEnumerable();

        public Cart(CartCreatedEvent cartCreatedEvent)
        {
            if (cartCreatedEvent == null)
                throw new ArgumentNullException(nameof(cartCreatedEvent));

            Version = 1;
            UserId = cartCreatedEvent.UserId;
        }

        public override void Handle(DomainEvent domainEvent)
        {
            Handle((dynamic)domainEvent);
            Version++;
        }

        private void Handle(ItemsAddedEvent itemsAddedEvent)
        {
            var existingItem = FindExistingCartItem(itemsAddedEvent.ProductSku);

            if (existingItem == null)
                items.Add(new Item(itemsAddedEvent));
            else
                existingItem.Handle(itemsAddedEvent);
        }

        private void Handle(ItemsRemovedEvent itemsRemovedEvent)
        {
            var existingItem = FindExistingCartItem(itemsRemovedEvent.ProductSku);

            if (existingItem == null)
                throw new CartException($"Product \"{itemsRemovedEvent.ProductSku}\" " +
                    $"does not exist in the cart ({Id}).");
            else
                existingItem.Handle(itemsRemovedEvent);

            PurgeZeroQuantityProducts();
        }

        private Item FindExistingCartItem(string productSku) => 
            items.SingleOrDefault(i =>
                    i.ProductSku.Equals(productSku));

        private void PurgeZeroQuantityProducts() =>
            items = items.Where(i => i.Quantity > 0).ToList();
    }
}
