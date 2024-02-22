using Medicoz.Application.Enums;
using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class Order : BaseEntity
    {
        public Basket Basket { get; set; }
        public string BasketId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
