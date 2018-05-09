using System;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        public IActionResult AllProducts()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult BookDetail(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return View("Error");
            }

            return View(product);
        }
        
        public IActionResult AuthorDetail()
        {
            return View();
        }

        public IActionResult NewReleases()
        {
            return View();
        }

        public IActionResult TopRated()
        {
            return View();
        }

         public IActionResult BestSellers()
        {
            return View();
        }
        
        [HttpGet]
        //[Authorize(Policy = "Employee")]
        public IActionResult Register()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        //[Authorize(Policy = "Employee")]
        public IActionResult Register(HardCoverViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
