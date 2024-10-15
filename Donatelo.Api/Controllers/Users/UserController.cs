using Microsoft.AspNetCore.Mvc;

namespace Donatelo.Api.Controllers.Users
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
