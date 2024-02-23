using MediatR;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.DoctorAppointment.Queries.GetAppointments;
using Medicoz.Domain.Common.Enums;

namespace Medicoz.Application.Features.DoctorAppointment.Queries.GetTodayAppointments
{
    public class GetTodayAppointmentsQueryHandler : IRequestHandler<GetTodayAppointmentsQuery, List<Domain.DoctorAppointment>>
    {
        private readonly IDoctorAppointmentRepository _doctorAppointmentRepository;
        private readonly IUserService _userService;

        public GetTodayAppointmentsQueryHandler(IDoctorAppointmentRepository doctorAppointmentRepository, IUserService userService)
        {
            _doctorAppointmentRepository = doctorAppointmentRepository;
            _userService = userService;
        }
        public async Task<List<Domain.DoctorAppointment>> Handle(GetTodayAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrentUserAsync();
            var appointments = await _doctorAppointmentRepository.GetAppointmentsByStatusForToday(user.Email,AppointmentStatus.Waiting);

            return appointments;
        }
    }
}
