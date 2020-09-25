using FluentAssertions;

using HiperWebApp.Domain.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiperWebApp.Test
{
    [TestClass]
    public class ProductDomainTest
    {
        [TestMethod]
        public void Product_IsEqual_Should_Be_True()
        {
            Product product = GetProduct();
            Product product2 = GetProduct();

            product.IsEquals(product2).Should().BeTrue();
        }

        [TestMethod]
        public void Product_IsEqual_Should_Be_False()
        {
            Product product = GetProduct();
            Product product2 = GetProduct(value: 3);

            product.IsEquals(product2).Should().BeFalse();
        }

        private Product GetProduct(int id = 1, string name = "Refri", double value = 2.5, int quantity = 3)
        {
            return new Product()
            {
                Id = id,
                Name = name,
                Value = value,
                Quantity = quantity
            };
        }
    }
}
