using MediatR;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Percistance;

namespace Medicoz.Application.Features.DoctorAppointment.Queries.GetAppointments
{
    public class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, List<Domain.DoctorAppointment>>
    {
        private readonly IDoctorAppointmentRepository _doctorAppointmentRepository;
        private readonly IUserService _userService;

        public GetAppointmentsQueryHandler(IDoctorAppointmentRepository doctorAppointmentRepository, IUserService userService)
        {
            _doctorAppointmentRepository = doctorAppointmentRepository;
            _userService = userService;
        }
        public async Task<List<Domain.DoctorAppointment>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrentUserAsync();
            var appointments = await _doctorAppointmentRepository.GetAppointmentsFromTodayByStatus(user.Email, request.AppointmentStatus);

            return appointments;
        }
    }
}
