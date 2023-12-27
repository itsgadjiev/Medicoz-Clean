using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Departments.Commands.AddDepartment
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFileService _fileService;

        public AddDepartmentCommandHandler(IDepartmentRepository departmentRepository, IFileService fileService)
        {
            _departmentRepository = departmentRepository;
            _fileService = fileService;
        }
        public async Task<Unit> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var path = Path.Combine(request.WebRootPath, "uploads/images");
            var imgUrl = _fileService.Upload(request.Image, path);

            Department department = new()
            {
                Detail = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.DetailAZ },
                    { LocalizationLanguages.EN, request.DetailEN }
                },
                Name = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.NameAZ },
                    { LocalizationLanguages.EN, request.NameEN }
                },
                Icon = request.Icon,
                ImageURL = imgUrl,
            };

            await _departmentRepository.AddAsync(department);
            await _departmentRepository.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
