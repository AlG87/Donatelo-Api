using Microsoft.AspNetCore.Mvc;

namespace Donatelo.Api.Controllers.Headquarters
{
    public class InstallationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
