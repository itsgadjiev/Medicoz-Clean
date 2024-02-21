using Medicoz.Domain.Common.concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Domain
{
    public class BasketItem : BaseEntity
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
        public Basket Basket { get; set; }
        public string BasketId { get; set; }
        public double BasketItemTotal { get; set; }
    }
}
