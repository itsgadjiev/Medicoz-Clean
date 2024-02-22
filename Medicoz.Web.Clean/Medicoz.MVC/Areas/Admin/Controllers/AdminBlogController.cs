using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    public class AdminBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
