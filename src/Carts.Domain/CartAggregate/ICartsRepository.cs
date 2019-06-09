using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Carts.Domain.CartAggregate;

namespace Carts.Domain.CartAggregate
{
    public interface ICartsRepository
    {
        Task<Cart> GetByUserId(string userId);
        Task<Cart> Insert(Cart cart);
    }
}
