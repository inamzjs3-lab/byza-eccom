using System.Diagnostics;
using Byza.Models;
using Microsoft.AspNetCore.Mvc;

namespace Byza.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("login-buyer")]
        public IActionResult LoginViewBuyer()
        {
            return View();
        }
        [HttpGet("login-seller")]
        public IActionResult LoginViewSeller()
        {
            return View();
        }
        [Route("sign up buyer")]
        [HttpGet]
        public IActionResult SignupBuyer()
        {
            return View();
        }
    }
}
