using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
