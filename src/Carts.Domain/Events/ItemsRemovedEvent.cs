using Carts.Domain.Common;

namespace Carts.Domain.Events
{
    public sealed class ItemsRemovedEvent : DomainEvent
    {
        public string ProductSku { get; }
        public int Quantity { get; }

        public ItemsRemovedEvent(string productSku, int quantity)
        {
            productSku = productSku.Trim();

            if (string.IsNullOrWhiteSpace(productSku))
                throw new CartException("Must provide a valid product SKU when removing items.");

            if (quantity <= 0)
                throw new CartException("Must provide a positive number when removing items from cart");

            ProductSku = productSku;
            Quantity = quantity;
        }
    }
}
