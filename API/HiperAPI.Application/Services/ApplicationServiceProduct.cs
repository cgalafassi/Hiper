using HiperAPI.Application.DTO.Products;
using HiperAPI.Application.Interfaces;
using HiperAPI.Domain.Core.Interfaces.Services;
using HiperAPI.Domain.Models;
using HiperAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

using System.Collections.Generic;

namespace HiperAPI.Application.Services
{
    public class ApplicationServiceProduct : IApplicationServiceProduct
    {
        private readonly IProductService serviceProduct;
        private readonly IProductMapper mapper;

        public ApplicationServiceProduct(IProductService productService, IProductMapper mapper)
        {
            this.serviceProduct = productService;
            this.mapper = mapper;
        }

        public void Add(ProductDTO productDto)
        {
            Product product = mapper.MapToNewProduct(productDto);
            serviceProduct.Add(product);
        }

        public void Dispose() => serviceProduct.Dispose();

        public IEnumerable<ProductDTO> GetAll()
        {
            IEnumerable<Product> products = serviceProduct.GetAll();
            IEnumerable<ProductDTO> productDto = mapper.MapperListProduct(products);

            return productDto;
        }

        public ProductDTO GetById(int id)
        {
            Product product = serviceProduct.GetById(id);
            ProductDTO productDto = mapper.MapToDTO(product);

            return productDto;
        }

        public void Remove(int id)
        {
            Product product = serviceProduct.GetById(id);
            serviceProduct.Remove(product);
        }

        public void Update(ProductDTO productDto)
        {
            Product product = mapper.MapToEntity(productDto);
            serviceProduct.Update(product);
        }
    }
}
