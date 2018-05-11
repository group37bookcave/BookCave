using System;
using System.Collections.Generic;
using BookCave.Models.EntityModels;
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
            var books = _productService.GetAllBooks();
            return View(books);
        }

        public IActionResult BookDetail(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var book = _productService.GetBookById(id);
            return View(book);
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
            var books = _productService.GetTop10();
            return View(books);
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
        public IActionResult SearchByTitle(string name)
        {
            var books = _productService.SearchByName(name);
            return View(books);
        }
    }
}
