using MediatR;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.DoctorDetail.Queries.GetDoctorDetail;
using Medicoz.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers;

[Route("medicoz/doctor")]
public class DoctorController : Controller
{

    private readonly IMediator _mediator;
    private readonly IUserService _userService;


    public DoctorController(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }

    [HttpGet("{doctorId}")]
    public async Task<IActionResult> Detail(string doctorId)
    {
        var query = new GetDoctorDetailQuery { DoctorId = doctorId };
        var viewModel = await _mediator.Send(query);

        return View(viewModel);
    }

    [HttpPost("{doctorId}")]
    public async Task<IActionResult> Detail(string doctorId, DoctorDetailViewModel doctorDetailViewModel)
    {
        doctorDetailViewModel.MakeAnAppointmentCommand.DoctorId = doctorId;
        doctorDetailViewModel.MakeAnAppointmentCommand.PasentId = _userService.UserId;

        try
        {
            await _mediator.Send(doctorDetailViewModel.MakeAnAppointmentCommand);
        }
        catch (BadRequestException ex)
        {
            var query = new GetDoctorDetailQuery { DoctorId = doctorId };
            var viewModel = await _mediator.Send(query);

            ModelState.AddModelError("", ex.ErrorMessage);
            return View(viewModel);
        }

        return RedirectToAction("Index", "Home");
    }
}
