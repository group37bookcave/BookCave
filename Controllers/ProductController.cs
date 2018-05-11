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

        [HttpGet]
        public IActionResult AllProducts()
        {
            var books = _productService.GetAllBooks();
            return View(books);
        }

        [HttpPost]
        public IActionResult AllProducts(string SearchString , string FilterBy)
        {
            if(SearchString == null)
            {
                return View();
            }
            if(FilterBy == "Author")
            {
                List<BookViewModel> books = _productService.SearchByAuthor(SearchString);
                return View(books);
            }
            else if(FilterBy == "ISBN")
            {
                List<BookViewModel> books = _productService.SearchByIsbn(SearchString);
                return View(books);
            }
            else{
                List<BookViewModel> books = _productService.SearchByName(SearchString);
                return View(books);
            }
        }

        [HttpPost]
        public IActionResult FilterByGenre(string FilterBy)
        {
            if(FilterBy== null)
            {
                return View("AllProducts");
            }
            
            Genre genre = new Genre();
            genre.Name = FilterBy;
            List<BookViewModel> books = _productService.FilterByGenre(genre);
            return View("AllProducts", books);
        }

        [HttpPost]
        public IActionResult SortBy(string SortBy)
        {
            if(SortBy == null)
            {
                return View("AllProducts");
            }
            
            if(SortBy == "Name"){
                 List<BookViewModel> books = _productService.SortByName();
                return View("AllProducts", books);
                
            }
            else if(SortBy == "Price")
            {
                List<BookViewModel> books = _productService.SortByPrice();
                return View("AllProducts", books);
            }
            else{
                return View("AllProducts");
            }
            
            
        }

        /*
        [HttpPost]
        public IActionResult FilterByFormat(string FilterBy)
        {
            if(FilterBy== null)
            {
                return View("AllProducts");
            }
            
            Format genre = new Format();
            genre.Name = FilterBy;
            List<BookViewModel> books = _productService.FilterByGenre(genre);
            return View("AllProducts", books);
        }
        */

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
     
    }
}
