using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.ServiceModels;
using ServiceLayer.Services;
using System.Net.Http;

namespace Byza.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); //why model coz whatever user has given the data is ll not b lost it ll b  displayed only the wrong info ll be blank
            }
            if (!string.IsNullOrEmpty(model.ProductImage))
            {
                // remove: data:image/png;base64,
                if (model.ProductImage.Contains(","))
                {
                    model.ProductImage = model.ProductImage.Split(',')[1];
                }
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
        [HttpGet("editproduct/{id}")]
        public async Task<IActionResult> EditProduct([FromRoute]int id)
        {
            var product = await productService.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost("UpdateProducts")]
        public async Task<IActionResult> UpdateProducts(int id, ProductRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProduct",model);
            }
            var result = await productService.UpdateProductAsync(id,model);
            if (result)
            {
                return RedirectToAction("GetAllProducts");
            }
            return View("EditProduct",model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            await productService.DeleteAsync(id);
            return RedirectToAction("GetAllProducts");
        }
    }
}
