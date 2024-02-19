using MediatR;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.ViewModels.Areas.Admin;

namespace Medicoz.Application.Features.Doctor.Queries.GetDoctorsList
{
    public class GetDoctorsListQueryHandler : IRequestHandler<GetDoctorsListQuery, List<DoctorListVMForAP>>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILocalizationService<Domain.Doctor> _localizationService;

        public GetDoctorsListQueryHandler(IDoctorRepository doctorRepository,ILocalizationService<Domain.Doctor> localizationService)
        {
            _doctorRepository = doctorRepository;
            _localizationService = localizationService;
        }

        public async Task<List<DoctorListVMForAP>> Handle(GetDoctorsListQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync();

            var doctorViewModels = doctors.Select(doctor => new DoctorListVMForAP
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Title = _localizationService.GetLocalizedValue(doctor.Id,nameof(doctor.Title)),
                Fee = doctor.Fee,
                Id = doctor.Id,
                ImageUrl = doctor.ImageURL

            }).ToList();

            return doctorViewModels;
        }
    }
}
