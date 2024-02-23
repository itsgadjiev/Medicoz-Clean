using MediatR;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Percistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.DoctorAppointment.Queries.GetPreviousAppointments
{
    public class GetPreviousAppointmentsQueryHandler : IRequestHandler<GetPreviousAppointmentsQuery, List<Domain.DoctorAppointment>>
    {
         private readonly IDoctorAppointmentRepository _doctorAppointmentRepository;
        private readonly IUserService _userService;

        public GetPreviousAppointmentsQueryHandler(IDoctorAppointmentRepository doctorAppointmentRepository, IUserService userService)
        {
            _doctorAppointmentRepository = doctorAppointmentRepository;
            _userService = userService;
        }
        public async Task<List<Domain.DoctorAppointment>> Handle(GetPreviousAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrentUserAsync();
            var appointments = await _doctorAppointmentRepository.GetPreviousAppointmentsByStatus(user.Email,Domain.Common.Enums.AppointmentStatus.Waiting);

            return appointments;
        }
    }
}
