using HiperWebApp.Domain.Core.Interfaces.Repositorys;
using HiperWebApp.Domain.Core.Interfaces.Services;
using HiperWebApp.Domain.Exceptions;
using HiperWebApp.Domain.Models;

namespace HiperWebApp.Domain.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public readonly IProductRepository _repositoryProduct;

        public ProductService(IProductRepository RepositoryProduct)
            : base(RepositoryProduct)
        {
            _repositoryProduct = RepositoryProduct;
        }

        public override Product GetById(int id)
        {
            Product product = base.GetById(id);
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
            return product;
        }
    }
}
