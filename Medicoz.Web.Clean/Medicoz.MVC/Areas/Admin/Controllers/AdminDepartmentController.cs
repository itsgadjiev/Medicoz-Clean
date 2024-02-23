using MediatR;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Departments.Commands.AddDepartment;
using Medicoz.Application.Features.Departments.Commands.UpdateDepartment;
using Medicoz.Application.Features.Departments.Queries.GetAllDepartments;
using Medicoz.Application.Features.Departments.Queries.GetDepartmentById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/departments")]
    [Authorize(Roles = "Administrator")]

    public class AdminDepartmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminDepartmentController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _mediator.Send(new GetAllDepartmentsQuery());
            return View(departments);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AddDepartmentCommand addDepartmentCommand)
        {
            addDepartmentCommand.WebRootPath = _webHostEnvironment.WebRootPath;

            try
            {
                await _mediator.Send(addDepartmentCommand);
            }
            catch (CustomValidationException e)
            {
                foreach (var item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(addDepartmentCommand);
            }
            catch (BadRequestException e)
            {
                ModelState.AddModelError("", e.ErrorMessage);
                return View(addDepartmentCommand);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            var departmentVM = await _mediator.Send(new GetDepartmentByIdQuery { DepartmentId = id });
            return View(departmentVM);
        }
         
        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(UpdateDepartmentCommand updateDepartmentCommand)
        {
            try
            {
                await _mediator.Send(updateDepartmentCommand);
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
