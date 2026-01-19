using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace Byza.Controllers
{
    public class SellerController : Controller
    {
        private readonly IProductService _productService;

        public SellerController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SellerDashboard()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

    }
}
