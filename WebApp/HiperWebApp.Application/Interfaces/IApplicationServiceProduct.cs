using HiperWebApp.Domain.Models;

using System.Collections.Generic;

namespace HiperWebApp.Application.Interfaces
{
    public interface IApplicationServiceProduct
    {
        void Add(Product product);

        void Update(Product product);

        void Remove(int id);

        void Dispose();

        Product GetById(int id);

        IEnumerable<Product> GetAll();
    }
}
