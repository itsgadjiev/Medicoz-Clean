using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Products.Commands.UpdateProduct;
using Medicoz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<UpdateProductCommand> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product =await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new NotFoundException(nameof(Department), request.Id);

            var updateCommand = new UpdateProductCommand()
            {
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                ProductId = product.Id,

            };

            return updateCommand;
        }
    }
}
