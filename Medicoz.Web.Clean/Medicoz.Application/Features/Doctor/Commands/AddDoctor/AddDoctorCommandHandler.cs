using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.OurServices.Commands.AddOurService;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Doctor.Commands.AddDoctor
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, Unit>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;
        private readonly IFileService _fileService;
        private int DoctorAcceptanceTime = 1;

        public AddDoctorCommandHandler(IDoctorRepository doctorRepository, IDoctorScheduleRepository doctorScheduleRepository, IFileService fileService)
        {
            _doctorRepository = doctorRepository;
            _doctorScheduleRepository = doctorScheduleRepository;
            _fileService = fileService;

        }
        public async Task<Unit> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddDoctorCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var path = Path.Combine(request.WebRootPath, "uploads/images");
            var imgUrl = _fileService.Upload(request.Image, path);

            var doctor = new Domain.Doctor
            {
                Title = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.TitleAz },
                    { LocalizationLanguages.EN, request.TitleEn }
                },
                Description = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.DescriptionAz },
                    { LocalizationLanguages.EN, request.DescriptionEn }
                },
                Education = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.EducationAz },
                    { LocalizationLanguages.EN, request.EducationEn }
                },
                Experience = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.ExperienceAz },
                    { LocalizationLanguages.EN, request.ExperienceEn }
                },
                Email = request.Email,
                Phone = request.Phone,
                Name = request.Name,
                Surname = request.Surname,
                ImageURL = imgUrl,
            };

            await _doctorRepository.AddAsync(doctor);

            var intervals = GetHourlyIntervals(request.DoctorScheduleForAddDoctorCommand.StartTime, request.DoctorScheduleForAddDoctorCommand.EndTime);

            foreach (var workingDay in request.DoctorScheduleForAddDoctorCommand.WorkingDaysOfDoctor)
            {
                foreach (var interval in intervals)
                {
                    var doctorSchedules = new DoctorSchedule
                    {
                        DayOfWeek = workingDay,
                        Doctor = doctor,
                        StartTime = interval,
                        EndTime = interval.AddHours(DoctorAcceptanceTime),
                    };
                    await _doctorScheduleRepository.AddAsync(doctorSchedules);
                }
            }


            return Unit.Value;
        }

        public List<DateTime> GetHourlyIntervals(DateTime startDateTime, DateTime endDateTime)
        {
            if (startDateTime >= endDateTime)
            {
                throw new ArgumentException("Start date should be earlier than end date.");
            }

            List<DateTime> intervals = new List<DateTime>();
            intervals.Add(startDateTime);

            DateTime currentInterval = startDateTime;

            while (currentInterval < endDateTime)
            {
                currentInterval = currentInterval.AddHours(DoctorAcceptanceTime);
                if (currentInterval <= endDateTime)
                {
                    intervals.Add(currentInterval);
                }
            }

            return intervals;
        }
    }
}
