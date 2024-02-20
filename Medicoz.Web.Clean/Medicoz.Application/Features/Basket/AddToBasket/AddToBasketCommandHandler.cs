using MediatR;
using Medicoz.Application.Contracts.Percistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Basket.AddToBasket
{
    public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommand, Unit>
    {
        public AddToBasketCommandHandler(IProductRepository productRepository)
        {
            
        }
        public Task<Unit> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
