using Medicoz.Application.Contracts.Percistance;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            return View(_departmentRepository.GetAllAsync());
        }
    }
}
