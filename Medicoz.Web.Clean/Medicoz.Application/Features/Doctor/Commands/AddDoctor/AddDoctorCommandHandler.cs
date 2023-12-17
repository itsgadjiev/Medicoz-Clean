using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Doctor.Common;
using Medicoz.Application.Models.Identity;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Doctor.Commands.AddDoctor
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, Unit>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;
        private readonly IFileService _fileService;
        private readonly GetHourlyWorkingTimeIntervalsForDoctor _getHourlyWorkingTime;
        private readonly IAuthService _authService;
        private readonly IEmailSender _emailSender;

        public AddDoctorCommandHandler(IDoctorRepository doctorRepository, IDoctorScheduleRepository doctorScheduleRepository,
            IFileService fileService, GetHourlyWorkingTimeIntervalsForDoctor getHourlyWorkingTime,
            IAuthService authService, IEmailSender emailSender)
        {
            _doctorRepository = doctorRepository;
            _doctorScheduleRepository = doctorScheduleRepository;
            _fileService = fileService;
            _getHourlyWorkingTime = getHourlyWorkingTime;
            _authService = authService;
            _emailSender = emailSender;
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
                Fee = request.Fee,
                Id = Guid.NewGuid().ToString()
            };

            await _doctorRepository.AddAsync(doctor);

            var intervals = _getHourlyWorkingTime.Handle(request.DoctorScheduleForAddDoctorCommand.StartTime, request.DoctorScheduleForAddDoctorCommand.EndTime);

            foreach (var workingDay in request.DoctorScheduleForAddDoctorCommand.WorkingDaysOfDoctor)
            {
                foreach (var interval in intervals)
                {
                    var doctorSchedules = new DoctorSchedule
                    {
                        DayOfWeek = workingDay,
                        Doctor = doctor,
                        StartTime = interval,
                        EndTime = interval.AddHours(_getHourlyWorkingTime.DoctorAcceptanceTime),
                        Id = Guid.NewGuid().ToString()
                    };
                    await _doctorScheduleRepository.AddAsync(doctorSchedules);
                }
            }

            RegistrationRequest registrationRequest = new RegistrationRequest
            {
                Email = request.Email,
                FirstName = request.Name,
                LastName = request.Surname,
                Password = "123321Ab!",
                UserName = String.Concat(request.Name, request.Surname),
            };

            await _authService.Register(registrationRequest, "Doctor");
            await _doctorRepository.SaveChangesAsync();
            //_emailSender.SendEmail(request.Email, "Medicoz", $"Welcome to our Company Dear {request.Name + request.Surname} ");
            return Unit.Value;
        }
    }
}
