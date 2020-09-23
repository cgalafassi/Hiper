using HiperAPI.Domain.Core.Interfaces.Repositorys;
using HiperAPI.Domain.Models;
using HiperAPI.Infrastructure.Data;

namespace HiperAPI.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly SqlContext _context;
        public ProductRepository(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
