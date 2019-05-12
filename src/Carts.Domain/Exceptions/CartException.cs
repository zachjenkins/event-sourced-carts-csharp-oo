using System;
using System.Collections.Generic;
using System.Text;

namespace Carts.Domain
{
    public class CartException : Exception
    {
        public CartException(string message) : base(message)
        {

        }
    }
}
