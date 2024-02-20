using Medicoz.Domain;
using System.Linq.Expressions;

namespace Medicoz.Application.Contracts.Percistance
{
    public interface IBasketItemRepository : IGenericRepository<Domain.BasketItem>
    {
        BasketItem FirstOrDefault(Expression<Func<BasketItem, bool>> predicate);
    }
}
