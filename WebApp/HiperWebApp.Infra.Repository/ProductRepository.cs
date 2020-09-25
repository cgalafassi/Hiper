using HiperWebApp.Domain.Core.Interfaces.Repositorys;
using HiperWebApp.Domain.Models;
using HiperWebApp.Infra.Data;

namespace HiperWebApp.Infra.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
