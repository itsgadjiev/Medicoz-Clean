using MediatR;
using Microsoft.AspNetCore.Http;

namespace Medicoz.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string WebRootPath { get; set; }
        public IFormFile NewImage { get; set; }

    }
}
