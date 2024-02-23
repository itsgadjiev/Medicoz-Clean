using MediatR;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.ViewModels.Areas.Admin;
using System.Collections.Immutable;

namespace Medicoz.Application.Features.Doctor.Queries.GetDoctorsList
{
    public class GetDoctorsListQueryHandler : IRequestHandler<GetDoctorsListQuery, List<DoctorListVMForAP>>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILocalizationService<Domain.Doctor> _localizationService;
        private readonly IDoctorDepartmentRepository _doctorDepartmentRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public GetDoctorsListQueryHandler(IDoctorRepository doctorRepository, ILocalizationService<Domain.Doctor> localizationService, IDoctorDepartmentRepository doctorDepartmentRepository,IDepartmentRepository departmentRepository)
        {
            _doctorRepository = doctorRepository;
            _localizationService = localizationService;
            _doctorDepartmentRepository = doctorDepartmentRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DoctorListVMForAP>> Handle(GetDoctorsListQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync();
            var docDep = await _doctorDepartmentRepository.GetAllAsync();
            var deps = await _departmentRepository.GetAllAsync();

            var doctorViewModels = doctors.Select(doctor => new DoctorListVMForAP
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Title = _localizationService.GetLocalizedValue(doctor.Id, nameof(doctor.Title)),
                Fee = doctor.Fee,
                Id = doctor.Id,
                ImageUrl = doctor.ImageURL,
                DoctorDepartments = docDep.Where(x => x.DoctorId == doctor.Id).ToList(),
                Departments = docDep
                    .Where(x => x.DoctorId == doctor.Id)
                    .Select(docDept => deps.FirstOrDefault(dep => dep.Id == docDept.DepartmentId))
                    .ToList()

            }).ToList();

            return doctorViewModels;
        }
    }
}
