using MediatR;

namespace Medicoz.Application.Features.Basket.AddToBasket
{
    public class AddToBasketCommand : IRequest<Unit>
    {
        public string Count { get; set; }
    }
}
