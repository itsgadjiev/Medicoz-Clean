using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Departments.Queries.GetAllDepartments;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllDepartmentsQuery()));
        }
    }
}
