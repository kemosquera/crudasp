using Microsoft.AspNetCore.Mvc;
using MvcCrudApp.Models;
using MvcCrudApp.Services;

namespace MvcCrudApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // Display all products
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        // Display create form
        public IActionResult Create() => View();

        // Handle create form submission
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.Create(product);
            return RedirectToAction("Index");
        }

        // Display edit form
        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // Handle edit form submission
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            if (!_productService.Update(id, product)) return NotFound();
            return RedirectToAction("Index");
        }

        // Display product details
        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // Display delete confirmation
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // Handle delete action
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_productService.Delete(id)) return NotFound();
            return RedirectToAction("Index");
        }
    }
}