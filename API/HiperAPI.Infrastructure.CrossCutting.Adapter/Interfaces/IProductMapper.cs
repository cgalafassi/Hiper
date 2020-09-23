using HiperAPI.Application.DTO.Products;
using HiperAPI.Domain.Models;

using System.Collections.Generic;

namespace HiperAPI.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IProductMapper
    {
        Product MapToEntity(ProductDTO productDTO);
        Product MapToNewProduct(ProductDTO productDTO);
        IEnumerable<ProductDTO> MapperListProduct(IEnumerable<Product> products);
        IEnumerable<Product> MapperListProduct(IEnumerable<ProductDTO> products);
        ProductDTO MapToDTO(Product product);
    }
}
