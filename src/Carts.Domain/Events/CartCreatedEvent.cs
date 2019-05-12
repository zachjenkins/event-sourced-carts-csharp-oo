using System;

namespace Carts.Domain.Events
{
    public sealed class CartCreatedEvent
    {
        public DateTime CartCreated { get; }
        public string UserId { get; }

        public CartCreatedEvent(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new CartException($"Cart must have a valid user ID : \"{userId}\" is not valid.");

            CartCreated = DateTime.UtcNow;
        }
    }
}
