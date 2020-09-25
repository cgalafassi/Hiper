using HiperWebApp.Application.Interfaces;
using HiperWebApp.Domain.Core.Interfaces.Services;
using HiperWebApp.Domain.Models;

namespace HiperWebApp.Application.Services
{
    public class ApplicationServiceProduct : IApplicationServiceProduct
    {
        private readonly IProductService serviceProduct;

        public ApplicationServiceProduct(IProductService productService)
        {
            this.serviceProduct = productService;
        }

        public void Add(Product product)
        {
            serviceProduct.Add(product);
        }

        public void Dispose()
        {
            serviceProduct.Dispose();
        }

        public System.Collections.Generic.IEnumerable<Product> GetAll()
        {
            return serviceProduct.GetAll();
        }

        public Product GetById(int id)
        {
            return serviceProduct.GetById(id);
        }

        public void Remove(int id)
        {
            Product product = serviceProduct.GetById(id);
            serviceProduct.Remove(product);
        }

        public void Update(Product product)
        {
            serviceProduct.Update(product);
        }
    }
}
