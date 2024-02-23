using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Departments.Queries.GetAllDepartments;
using Medicoz.Application.Features.Doctor.Common;
using Medicoz.Application.Models.Identity;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Doctor.Commands.AddDoctor
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, Unit>
    {
        private readonly IFileService _fileService;
        private readonly IAuthService _authService;
        private readonly IEmailSender _emailSender;
        private readonly Contracts.Localisation.ILocalizationService<Domain.Department> _localizationService;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;
        private readonly IDoctorDepartmentRepository _doctorDepartmentRepository;
        private readonly GetHourlyWorkingTimeIntervalsForDoctor _getHourlyWorkingTime;

        public AddDoctorCommandHandler(IDoctorRepository doctorRepository, IDoctorScheduleRepository doctorScheduleRepository,
            IDoctorDepartmentRepository doctorDepartmentRepository,
            IFileService fileService, GetHourlyWorkingTimeIntervalsForDoctor getHourlyWorkingTime,
            IAuthService authService, IEmailSender emailSender,ILocalizationService<Domain.Department> localizationService,IDepartmentRepository departmentRepository)
        {
            _doctorRepository = doctorRepository;
            _doctorScheduleRepository = doctorScheduleRepository;
            _doctorDepartmentRepository = doctorDepartmentRepository;
            _fileService = fileService;
            _getHourlyWorkingTime = getHourlyWorkingTime;
            _authService = authService;
            _emailSender = emailSender;
            _localizationService = localizationService;
            _departmentRepository = departmentRepository;
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

            string password = String.Concat(request.Name, request.Surname, '!', Guid.NewGuid().ToString().Substring(0, 3));
            string username = String.Concat(request.Name, request.Surname, request.Email, Guid.NewGuid().ToString().Substring(0, 3));

            RegistrationRequest registrationRequest = new RegistrationRequest
            {
                Email = request.Email,
                FirstName = request.Name,
                LastName = request.Surname,
                Password = password,
                UserName = username,
            };


            foreach (var selectedDoctorDepartmentId in request.SelectedDoctorDepartmentIds)
            {
                var doctorDepartment = new Domain.DoctorDepartment
                {
                    DepartmentId = selectedDoctorDepartmentId,
                    Doctor = doctor
                };

                await _doctorDepartmentRepository.AddAsync(doctorDepartment);
            };

            var departments = await _departmentRepository.GetAllAsync();
            var departmetsListDto = departments.Select(x => new DepartmentListDTO
            {
                Detail = _localizationService.GetLocalizedValue(x.Id, nameof(x.Detail)),
                Icon = x.Icon,
                Id = x.Id,
                ImageURL = x.ImageURL,
                Name = _localizationService.GetLocalizedValue(x.Id, nameof(x.Name))

            }).ToList();

            request.DepartmentListDTO = departmetsListDto;
            await _authService.Register(registrationRequest, "Doctor");
            await _doctorRepository.SaveChangesAsync();
            await _emailSender.SendEmailAsync(request.Email, "Medicoz", $"Welcome to our Company Dear {request.Name + request.Surname} Your password is :{password} Your Username is: {username} ");
            
            return Unit.Value;
        }
    }
}
