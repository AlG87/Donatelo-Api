using Microsoft.AspNetCore.Mvc;

namespace Donatelo.Api.Controllers.Donations
{
    public class DonationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
