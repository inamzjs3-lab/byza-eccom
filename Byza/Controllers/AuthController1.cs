using Microsoft.AspNetCore.Mvc;

namespace Byza.Controllers
{
    public class AuthController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
