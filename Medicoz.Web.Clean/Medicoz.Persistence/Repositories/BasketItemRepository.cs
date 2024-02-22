using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using System.Linq.Expressions;

namespace Medicoz.Persistence.Repositories
{
    public class BasketItemRepository : GenericRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(AppDbContext context) : base(context)
        {
        }

        public BasketItem FirstOrDefault(Expression<Func<BasketItem, bool>> predicate)
        {
            return new BasketItem();
        }
    }
}
