using MediatR;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Doctor.Commands.AddDoctor;
using Medicoz.Application.Features.Doctor.Commands.UpdateDoctor;
using Medicoz.Application.Features.Doctor.Queries.GetDoctorByIdAp;
using Medicoz.Application.Features.Doctor.Queries.GetDoctorsList;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/doctor")]
    public class AdminDoctorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminDoctorController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task<IActionResult> Index()
        {
            var query = new GetDoctorsListQuery();
            var doctorsList = await _mediator.Send(query);

            return View(doctorsList);
        }


        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AddDoctorCommand addDoctorCommand)
        {
            addDoctorCommand.WebRootPath = _webHostEnvironment.WebRootPath;

            try
            {
                await _mediator.Send(addDoctorCommand);
            }
            catch (CustomValidationException e)
            {
                foreach (var item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(addDoctorCommand);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            var query = new GetDoctorByIdAPQuery(id);
            var updateDoctorCommand = await _mediator.Send(query);

            return View(updateDoctorCommand);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(UpdateDoctorCommand updateDoctorCommand)
        {
            try
            {
                await _mediator.Send(updateDoctorCommand);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (CustomValidationException e)
            {
                foreach (var item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
