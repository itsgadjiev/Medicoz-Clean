using MediatR;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public AddProductCommandHandler(IProductRepository productRepository,IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var path = Path.Combine(request.WebRootPath, "uploads/images");
            var imgUrl = _fileService.Upload(request.Image, path);

            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = imgUrl,
                Id = Guid.NewGuid().ToString(),
                Price = request.Price,
            };

            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
