using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();

        public IActionResult GetAll()
        {
            var products = productRepository.GetAllProducts();

            return View(products);
        }

        public IActionResult GetById(int id)
        {
            var product = productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            productRepository.AddNewProduct(product);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            productRepository.UpdateProduct(product);

            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);

            return RedirectToAction("GetAll");
        }
    }
}