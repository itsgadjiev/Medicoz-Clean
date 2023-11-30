using MediatR;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Doctor.Commands.AddDoctor;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/doctor")]
    public class AdminDoctorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminDoctorController(IMediator mediator,IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AddDoctorCommand addDoctorCommand)
        {
            var webRootPath = _webHostEnvironment.WebRootPath;
            addDoctorCommand.WebRootPath = webRootPath;
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
    }
}
