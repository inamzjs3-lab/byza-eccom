using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.ServiceModels;
using ServiceLayer.Services;

namespace Byza.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); //why model coz whatever user has given the data is ll not b lost it ll b  displayed only the wrong info ll be blank
            }
            await productService.AddProductAsync(model);
            return RedirectToAction("GetAllProducts");
        }
        [HttpGet("getproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.GetProductsAsync();
            return View(products);
          
        }
        [HttpPut("UpdateProducts")]
        public async Task<IActionResult> UpdateProducts(int id, ProductRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await productService.UpdateProductAsync(id, model);
            if (result)
            {
                return RedirectToAction("GetAllProducts");
            }
            return View(model);

        }
    }
}
