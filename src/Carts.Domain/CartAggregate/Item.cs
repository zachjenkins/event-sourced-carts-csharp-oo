using Carts.Domain.Events;
using System;

namespace Carts.Domain.CartAggregate
{
    public class Item
    {
        public string ProductName { get; private set; }
        public string ProductSku { get; private set; }
        public decimal PricePerUnit { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice => PricePerUnit * Quantity;

        public Item(ItemsAddedEvent itemsAddedEvent)
        {
            if (itemsAddedEvent == null)
                throw new ArgumentNullException(nameof(itemsAddedEvent));

            ProductName = itemsAddedEvent.ProductName;
            ProductSku = itemsAddedEvent.ProductSku;
            PricePerUnit = itemsAddedEvent.PricePerUnit;
            Quantity = itemsAddedEvent.Quantity;
        }

        public void Handle(ItemsAddedEvent itemsAddedEvent)
        {
            if (itemsAddedEvent == null)
                throw new ArgumentNullException(nameof(itemsAddedEvent));

            VerifyProductSkuMatchesInput(itemsAddedEvent.ProductSku);

            // We'll always just update the descriptor and unit price here.
            // This is an eventual consistency model.
            ProductName = itemsAddedEvent.ProductName;
            PricePerUnit = itemsAddedEvent.PricePerUnit;

            Quantity += itemsAddedEvent.Quantity;
        }

        public void Handle(ItemsRemovedEvent itemsRemovedEvent)
        {
            if (itemsRemovedEvent == null)
                throw new ArgumentNullException(nameof(itemsRemovedEvent));

            VerifyProductSkuMatchesInput(itemsRemovedEvent.ProductSku);

            Quantity = (Quantity - itemsRemovedEvent.Quantity) <= 0
                ? 0
                : Quantity - itemsRemovedEvent.Quantity;
        }

        private void VerifyProductSkuMatchesInput(string productSku)
        {
            if (productSku.Equals(ProductSku))
                throw new ArgumentException(
                    $"Tried to update product \"{ProductSku}\" with data " +
                    $"from product \"{productSku}\"");
        }
    }
}
