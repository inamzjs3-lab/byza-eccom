using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        [Route("signup-buyer")]
        [HttpGet]
        public IActionResult SignupBuyer()
        {
            return View();
        }
        [Route("signup-seller")]
        [HttpGet]
        public IActionResult SignupSeller()
        {
            return View();
        }
        [HttpGet("AddProduct")]
        public IActionResult AddProducts()
        {
            return View();
        }
        [HttpGet("GetById")]
        public IActionResult GetById()
        {
            return View();
        }
        [HttpDelete("deleteproducts")]
        public IActionResult DeleteById()
        {
            return View();  
        }

    }
}
