using CatalogCave.Web.ViewModels.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCave.Web.Domain.Products.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductApiService _productService;

        public ProductsController(IProductApiService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> List(PageRequestFilterViewModel filter)
        {
            var products = await _productService.GetAllAsync(filter);
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
