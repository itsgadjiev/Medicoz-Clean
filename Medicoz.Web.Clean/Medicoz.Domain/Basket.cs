using Medicoz.Domain.Common.concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Domain
{
    public class Basket : BaseEntity
    {
        public List<BasketItem> BasketItems { get; set; }
        public double BasketTotal { get; set; }
    }
}
