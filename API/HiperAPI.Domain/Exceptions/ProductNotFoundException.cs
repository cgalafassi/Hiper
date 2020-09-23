using System;

namespace HiperAPI.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product not found!")
        {
        }
    }
}
