using MediatR;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Features.DoctorAppointment.Queries.GetAppointments;
using Medicoz.Application.Features.DoctorAppointment.Queries.GetPreviousAppointments;
using Medicoz.Application.Features.DoctorAppointment.Queries.GetTodayAppointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Doctor")]
    [Area("Admin")]
    [Route("admin/DoctorAppointment")]
    public class DoctorAppointmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public DoctorAppointmentController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appointments = await _mediator.Send(new GetAppointmentsQuery { AppointmentStatus = Domain.Common.Enums.AppointmentStatus.Waiting});
            return View(appointments);
        }
        [HttpGet("today")]
        public async Task<IActionResult> AppointmentsToday() 
        {
            var appointments = await _mediator.Send(new GetTodayAppointmentsQuery ());
            return View(appointments);
        }

        [HttpGet("previous")]
        public async Task<IActionResult> PreviousAppointments()
        {
            var appointments = await _mediator.Send(new GetPreviousAppointmentsQuery());
            return View(appointments);
        }
    }
}
