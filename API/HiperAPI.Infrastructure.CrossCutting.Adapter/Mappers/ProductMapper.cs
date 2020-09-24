using HiperAPI.Application.DTO.Products;
using HiperAPI.Domain.Models;
using HiperAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

using System.Collections.Generic;
using System.Linq;

namespace HiperAPI.Infrastructure.CrossCutting.Adapter.Mappers
{
    public class ProductMapper : IProductMapper
    {

        public IEnumerable<ProductDTO> MapperListProduct(IEnumerable<Product> products)
        {
            List<ProductDTO> productDTOList = new List<ProductDTO>();

            products.ToList().ForEach((product) =>
            {
                ProductDTO productDTO = MapToDTO(product);
                productDTOList.Add(productDTO);
            });

            return productDTOList;
        }

        public IEnumerable<Product> MapperListProduct(IEnumerable<ProductDTO> productDTOs)
        {
            List<Product> productsList = new List<Product>();

            productDTOs.ToList().ForEach((productDTO) =>
                {
                    Product product = MapToEntity(productDTO);
                    productsList.Add(product);
                });

            return productsList;
        }

        public ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO()
            {
                Id = product.ClientBDId,
                Name = product.Name,
                Value = product.Value,
                Quantity = product.Quantity
            };
        }

        public Product MapToEntity(ProductDTO productDTO)
        {
            return new Product()
            {
                ClientBDId = productDTO.Id,
                Name = productDTO.Name,
                Value = productDTO.Value,
                Quantity = productDTO.Quantity
            };
        }

        public Product MapToNewProduct(ProductDTO productDTO)
        {
            return new Product()
            {
                ClientBDId = productDTO.Id,
                Name = productDTO.Name,
                Value = productDTO.Value,
                Quantity = productDTO.Quantity
            };
        }
    }
}
