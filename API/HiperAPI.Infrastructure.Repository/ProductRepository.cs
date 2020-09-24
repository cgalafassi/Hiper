using HiperAPI.Domain.Core.Interfaces.Repositorys;
using HiperAPI.Domain.Models;
using HiperAPI.Infrastructure.Data;

using System.Linq;

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

        public override Product GetById(int id)
        {
            return  _context.Set<Product>().ToList().DefaultIfEmpty(null).FirstOrDefault(x => x.ClientBDId == id);
        }
    }
}
