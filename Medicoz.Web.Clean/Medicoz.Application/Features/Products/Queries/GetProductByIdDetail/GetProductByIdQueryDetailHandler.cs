using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Products.Queries.GetProductByIdDetail;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryDetailHandler : IRequestHandler<GetProductByIdQueryDetail, ProductDetailDTO>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryDetailHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDetailDTO> Handle(GetProductByIdQueryDetail request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new NotFoundException(nameof(Department), request.Id);

            var productDetailDTO = new ProductDetailDTO()
            {
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                ProductId = product.Id,
            };

            return productDetailDTO;
        }
    }
}
