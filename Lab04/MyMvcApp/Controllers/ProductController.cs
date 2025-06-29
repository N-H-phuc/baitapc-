using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>
        {
            new Product { ID = 1, Name = "iPhone 13", Price = 22909000 },
            new Product { ID = 2, Name = "iPhone 15", Price = 29990000 },
            new Product { ID = 3, Name = "SS Galaxy S24", Price = 28990000 }
        };

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Product p)
        {
            p.ID = products.Max(p => p.ID) + 1;
            products.Add(p);
            return RedirectToAction("Index");
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            return View(product);
        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit(Product updated)
        {
            var product = products.FirstOrDefault(p => p.ID == updated.ID);
            if (product != null)
            {
                product.Name = updated.Name;
                product.Price = updated.Price;
            }
            return RedirectToAction("Index");
        }

        // 👇 View xác nhận xóa
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            return View(product);
        }

        // 👇 POST xác nhận xóa
        [HttpPost("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}
