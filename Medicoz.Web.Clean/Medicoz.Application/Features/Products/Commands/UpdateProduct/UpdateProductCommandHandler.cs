using MediatR;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;

namespace Medicoz.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public UpdateProductCommandHandler(IProductRepository productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId);

            if (productToUpdate == null)
            {
                throw new NotFoundException("Product not found");
            }

            string imgUrl = productToUpdate.ImageUrl;
            if (request.NewImage != null)
            {
                var path = Path.Combine(request.WebRootPath, "uploads/images");
                imgUrl = _fileService.Upload(request.NewImage, path);
            }

            productToUpdate.Name = request.Name;
            productToUpdate.Description = request.Description;
            productToUpdate.Price = request.Price;
            productToUpdate.ImageUrl = imgUrl;

            await _productRepository.UpdateAsync(productToUpdate);
            await _productRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
