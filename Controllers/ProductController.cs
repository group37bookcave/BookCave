using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Services;

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
            return View();
        }

        public IActionResult BookDetail()
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
        public IActionResult Register()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Register(HardCoverViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
