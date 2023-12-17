using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Departments.Queries.GetAllDepartments;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/departments")]
    public class AdminDepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMediator _mediator;

        public AdminDepartmentController(IDepartmentRepository departmentRepository,IMediator mediator)
        {
            _departmentRepository = departmentRepository;
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _mediator.Send(new GetAllDepartmentsQuery());
            return View(departments);
        }


    }
}
