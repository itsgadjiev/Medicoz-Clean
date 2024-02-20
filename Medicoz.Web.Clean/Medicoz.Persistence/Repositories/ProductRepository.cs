using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;

namespace Medicoz.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
        public IQueryable<Product> GetAllAsQueryable()
        {
            return _context.Products.AsQueryable();
        }
    }
}
