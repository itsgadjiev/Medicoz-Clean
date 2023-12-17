using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Doctor.Commands.UpdateDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Doctor.Queries.GetDoctorByIdAp;

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdAPQuery, UpdateDoctorCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorScheduleRepository _doctorScheduleRepository;

    public GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository,IDoctorScheduleRepository doctorScheduleRepository)
    {
        _doctorRepository = doctorRepository;
        _doctorScheduleRepository = doctorScheduleRepository;
    }
    public async Task<UpdateDoctorCommand> Handle(GetDoctorByIdAPQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

        var updateDoctorCommand = new UpdateDoctorCommand
        {
            DoctorId = doctor.Id,
            Name = doctor.Name,
            Surname = doctor.Surname,
            TitleAz = doctor.Title[LocalizationLanguages.AZ],
            TitleEn = doctor.Title[LocalizationLanguages.EN],
            DescriptionAz = doctor.Description[LocalizationLanguages.AZ],
            DescriptionEn = doctor.Description[LocalizationLanguages.EN],
            EducationAz = doctor.Education[LocalizationLanguages.AZ],
            EducationEn = doctor.Education[LocalizationLanguages.EN],
            ExperienceAz = doctor.Experience[LocalizationLanguages.AZ],
            ExperienceEn = doctor.Experience[LocalizationLanguages.EN],
            Fee = doctor.Fee,
            Phone = doctor.Phone,
            Email = doctor.Email,
            ImageUrl = doctor.ImageURL,
            PreviousDoctorSchedules = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAsync(request.DoctorId),

        };

        return updateDoctorCommand;

    }
}
