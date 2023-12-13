using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Doctor.Common;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Doctor.Commands.UpdateDoctor;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Unit>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IFileService _fileService;
    private readonly IDoctorScheduleRepository _doctorScheduleRepository;
    private readonly GetHourlyWorkingTimeIntervalsForDoctor _getHourlyWorkingTime;

    public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IFileService fileService, IDoctorScheduleRepository doctorScheduleRepository,GetHourlyWorkingTimeIntervalsForDoctor getHourlyWorkingTime)
    {
        _doctorRepository = doctorRepository;
        _fileService = fileService;
        _doctorScheduleRepository = doctorScheduleRepository;
        _getHourlyWorkingTime = getHourlyWorkingTime;
    }
    public async Task<Unit> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {

        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

        if (doctor == null)
        {
            throw new NotFoundException(nameof(Doctor), request.DoctorId);
        }

        doctor.Title[LocalizationLanguages.AZ] = request.TitleAz;
        doctor.Title[LocalizationLanguages.EN] = request.TitleEn;
        doctor.Description[LocalizationLanguages.AZ] = request.DescriptionAz;
        doctor.Description[LocalizationLanguages.EN] = request.DescriptionEn;
        doctor.Education[LocalizationLanguages.AZ] = request.EducationAz;
        doctor.Education[LocalizationLanguages.EN] = request.EducationEn;
        doctor.Experience[LocalizationLanguages.AZ] = request.ExperienceAz;
        doctor.Experience[LocalizationLanguages.EN] = request.ExperienceEn;
        doctor.Email = request.Email;
        doctor.Phone = request.Phone;
        doctor.Name = request.Name;
        doctor.Surname = request.Surname;
        doctor.Fee = request.Fee;

        if (request.Image != null)
        {
            var path = Path.Combine(request.WebRootPath, "uploads/images");
            var imgUrl = _fileService.Upload(request.Image, path);
            doctor.ImageURL = imgUrl;
        }

        await _doctorRepository.UpdateAsync(doctor);


        var intervals = _getHourlyWorkingTime.Handle(request.DoctorScheduleForUpdateDoctorCommand.StartTime, request.DoctorScheduleForUpdateDoctorCommand.EndTime);

        foreach (var workingDay in request.DoctorScheduleForUpdateDoctorCommand.WorkingDaysOfDoctor)
        {
            foreach (var interval in intervals)
            {
                var doctorSchedule = new DoctorSchedule
                {
                    DayOfWeek = workingDay,
                    Doctor = doctor,
                    StartTime = interval,
                    EndTime = interval.AddHours(_getHourlyWorkingTime.DoctorAcceptanceTime),
                    Id = Guid.NewGuid().ToString()
                };
                await _doctorScheduleRepository.AddAsync(doctorSchedule);
            }
        }

        return Unit.Value;

    }


}


