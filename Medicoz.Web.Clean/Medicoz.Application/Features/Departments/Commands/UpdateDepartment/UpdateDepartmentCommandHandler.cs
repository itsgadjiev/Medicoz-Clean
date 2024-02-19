using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFileService _fileService;

        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IFileService fileService)
        {
            _departmentRepository = departmentRepository;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department == null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }

            department.Detail[LocalizationLanguages.AZ] = request.DetailAZ;
            department.Detail[LocalizationLanguages.EN] = request.DetailEN;
            department.Name[LocalizationLanguages.AZ] = request.NameAZ;
            department.Name[LocalizationLanguages.EN] = request.NameEN;
            department.Icon = request.Icon;

            if (!string.IsNullOrEmpty(request.Image))
            {
                _fileService.RemoveFile("uploads/images", request.Image);
                var path = Path.Combine(request.WebRootPath, "uploads/images");
                var imgUrl = _fileService.Upload(request.NewImage, path);
                department.ImageURL = imgUrl;
            }

            await _departmentRepository.UpdateAsync(department);
            await _departmentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
