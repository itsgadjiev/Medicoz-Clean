using MediatR;
using Microsoft.AspNetCore.Http;

namespace Medicoz.Application.Features.Products.Commands.AddCommand
{
    public class AddProductCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public string WebRootPath { get; set; }

    }
}
