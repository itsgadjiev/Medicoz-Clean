using Medicoz.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }



    }
}