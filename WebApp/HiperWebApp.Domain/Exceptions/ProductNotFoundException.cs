using System;

namespace HiperWebApp.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product not found!")
        {
        }
    }
}
