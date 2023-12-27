using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Departments.Commands.UpdateDepartment;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, UpdateDepartmentCommand>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<UpdateDepartmentCommand> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByIdAsync(request.DepartmentId);
        if (department == null)
            throw new NotFoundException(nameof(Department), request.DepartmentId);

        UpdateDepartmentCommand updateDepartmentCommand = new UpdateDepartmentCommand()
        {
            DetailAZ = department.Detail[LocalizationLanguages.AZ],
            DetailEN = department.Detail[LocalizationLanguages.EN],
            NameAZ = department.Name[LocalizationLanguages.AZ],
            NameEN = department.Detail[LocalizationLanguages.EN],
            Icon = department.Icon,
            Image = department.ImageURL,
            Id = department.Id,
        };

        return updateDepartmentCommand;
    }
}
