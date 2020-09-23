using HiperAPI.Application.DTO.Products;

using System.Collections.Generic;

namespace HiperAPI.Application.Interfaces
{
    public interface IApplicationServiceProduct
    {
        void Add(ProductDTO obj);

        void Update(ProductDTO obj);

        void Remove(int id);

        void Dispose();

        ProductDTO GetById(int id);

        IEnumerable<ProductDTO> GetAll();
    }
}
