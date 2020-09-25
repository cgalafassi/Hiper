using FluentAssertions;

using HiperAPI.Application.DTO.Products;
using HiperAPI.Application.Interfaces;
using HiperAPI.Application.Services;
using HiperAPI.Domain.Core.Interfaces.Services;
using HiperAPI.Domain.Models;
using HiperAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using System.Collections.Generic;
using System.Linq;

namespace HiperAPI.Unit.Test
{
    [TestClass]
    public class ApplicationServiceProductTest
    {
        private Mock<IProductService> _mockServiceProduct;
        private Mock<IProductMapper> _mockIProductMapper;
        private IApplicationServiceProduct application;

        [TestInitialize]
        public void Initialize()
        {
            _mockServiceProduct = new Mock<IProductService>();
            _mockIProductMapper = new Mock<IProductMapper>();

            application = new ApplicationServiceProduct(_mockServiceProduct.Object, _mockIProductMapper.Object);
        }

        [TestMethod]
        public void ApplicationServiceProduct_GetAll_Should_Return_All_Products()
        {
            Product product = GetProduct();
            ProductDTO productDTO = GetProductDTO(product);

            List<Product> listProduct = new List<Product>
            {
                product
            };

            List<ProductDTO> listProductDTO = new List<ProductDTO>
            {
                productDTO
            };

            _mockServiceProduct.Setup(x => x.GetAll()).Returns(listProduct);
            _mockIProductMapper.Setup(x => x.MapperListProduct(listProduct)).Returns(listProductDTO);

            List<ProductDTO> result = application.GetAll().ToList();
            result.Count().Should().Be(1);
            result.First().Name.Should().Be(product.Name);
        }

        [TestMethod]
        public void ApplicationServiceProduct_GetAll_Should_Return_Product()
        {
            Product product = GetProduct();
            ProductDTO productDTO = GetProductDTO(product);

            _mockServiceProduct.Setup(x => x.GetById(1)).Returns(product);
            _mockIProductMapper.Setup(x => x.MapToDTO(product)).Returns(productDTO);

            ProductDTO result = application.GetById(1);
            result.Id.Should().Be(1);
            result.Name.Should().Be(product.Name);
            result.Value.Should().Be(product.Value);
            result.Quantity.Should().Be(product.Quantity);
        }

        private Product GetProduct()
        {
            return new Product()
            {
                Id = 1,
                ClientBDId = 1,
                Name = "Refri",
                Value = 2.5,
                Quantity = 3
            };
        }

        private ProductDTO GetProductDTO(Product product)
        {
            return new ProductDTO()
            {
                Id = product.ClientBDId,
                Name = product.Name,
                Value = product.Value,
                Quantity = product.Quantity
            };
        }
    }
}
