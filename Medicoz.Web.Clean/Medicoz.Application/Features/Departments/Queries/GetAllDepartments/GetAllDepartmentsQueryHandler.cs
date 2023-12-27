using MediatR;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentListDTO>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILocalizationService<Department> _localizationService;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository,ILocalizationService<Department> localizationService)
        {
            _departmentRepository = departmentRepository;
            _localizationService = localizationService;
        }

        public async Task<List<DepartmentListDTO>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync();
            var departmetsListDto = departments.Select(x => new DepartmentListDTO
            {
                Detail = _localizationService.GetLocalizedValue(x.Id,nameof(x.Detail)),
                Icon = x.Icon,
                Id = x.Id,
                ImageURL = x.ImageURL,
                Name = _localizationService.GetLocalizedValue(x.Id, nameof(x.Name))

            }).ToList();

            return departmetsListDto;
        }


    }
}
