using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers;
[Route("admin/dashboard")]
[Area("admin")]
[Authorize(Roles = "Administrator")]

public class DashboardController : Controller
{
    [HttpGet("hospital")]
    public IActionResult Hospital()
    {
        return View();
    }

    [HttpGet("ecommerce")]
    public IActionResult ECommerce()
    {
        return View();
    }
}
