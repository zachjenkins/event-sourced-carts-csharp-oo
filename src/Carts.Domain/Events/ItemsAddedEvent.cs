using Carts.Domain.Common;

namespace Carts.Domain.Events
{
    public sealed class ItemsAddedEvent : DomainEvent
    {
        public string ProductSku { get; }
        public string ProductName { get; }
        public decimal PricePerUnit { get; }
        public int Quantity { get; }

        public ItemsAddedEvent(string productSku,
                               string productName,
                               decimal pricePerUnit,
                               int quantity
            )
        {
            productSku = productSku.Trim();
            productName = productName.Trim();

            if (string.IsNullOrWhiteSpace(productSku))
                throw new CartException("A valid product sku must be provided.");

            if (string.IsNullOrWhiteSpace(productName))
                throw new CartException("A valid product name must be provided.");

            if (pricePerUnit <= 0)
                throw new CartException("Price per unit must be greater than 0.");

            if (quantity <= 0)
                throw new CartException("Quantity must be greater than 0");

            ProductSku = productSku;
            ProductName = productName;
            PricePerUnit = pricePerUnit;
            Quantity = quantity;
        }
    }
}
