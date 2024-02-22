using MediatR;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Departments.Commands.UpdateDepartment;
using Medicoz.Application.Features.Departments.Queries.GetDepartmentById;
using Medicoz.Application.Features.Products.Commands.AddProduct;
using Medicoz.Application.Features.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/product")]
    public class AdminProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminProductController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllProductsQuery(string.Empty, string.Empty)));
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AddProductCommand addProductCommand)
        {
            addProductCommand.WebRootPath = _webHostEnvironment.WebRootPath;
            try
            {
                await _mediator.Send(addProductCommand);
            }
            catch (CustomValidationException e)
            {
                foreach (var item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(addProductCommand);
            }
            catch (BadRequestException e)
            {
                ModelState.AddModelError("", e.ErrorMessage);
                return View(addProductCommand);
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
            updateDepartmentCommand.WebRootPath = _webHostEnvironment.WebRootPath;
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
