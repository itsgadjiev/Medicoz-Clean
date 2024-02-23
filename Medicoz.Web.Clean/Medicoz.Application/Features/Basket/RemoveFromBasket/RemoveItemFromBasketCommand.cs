using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Basket.RemoveFromBasket
{
    public class RemoveItemFromBasketCommand : IRequest<Unit>
    {
        public string ProductId { get; set; }
    }
}
