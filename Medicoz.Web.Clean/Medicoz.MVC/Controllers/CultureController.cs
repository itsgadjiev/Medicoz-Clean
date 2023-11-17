using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Web;

namespace Medicoz.MVC.Controllers
{
    public class CultureController : Controller
    {

        public IActionResult ChangeCulture(string culture)
        {
            ChangeUserCulture(culture);
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult ChangeCultureOnAp(string culture)
        {
            ChangeUserCulture(culture);
            return RedirectToAction("Hospital", "Dashboard", new { area = "Admin" });
        }

        protected void ChangeUserCulture(string cultureCode)
        {
            var cultureInfo = new CultureInfo(cultureCode);
            cultureInfo.NumberFormat.CurrencySymbol = "€";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
