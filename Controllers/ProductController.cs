using System;
using System.Collections.Generic;
using BookCave.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models.InputModels;
using System.Security.Claims;

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
            ViewBag.First = "ALL";
            ViewBag.Second = "PRODUCTS";
            return View(books);
        }

        [HttpPost]
        public IActionResult AllProducts(string SearchString , string FilterBy)
        {
            ViewBag.First = "ALL";
            ViewBag.Second = "PRODUCTS";

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

        public IActionResult Rowling()
        {
            ViewBag.First = "ALL";
            ViewBag.Second = "PRODUCTS";

            List<BookViewModel> books = _productService.SearchByAuthor("Rowling");
            return View("AllProducts", books);
        }

        public IActionResult Yrsa()
        {
            ViewBag.First = "ALL";
            ViewBag.Second = "PRODUCTS";
            
            List<BookViewModel> books = _productService.SearchByAuthor("Yrsa");
            return View("AllProducts", books);
        }

        public IActionResult James()
        {
            ViewBag.First = "ALL";
            ViewBag.Second = "PRODUCTS";
            
            List<BookViewModel> books = _productService.SearchByAuthor("James");
            return View("AllProducts", books);
        }

        [HttpPost]
        public IActionResult FilterByGenre(string FilterBy)
        {
            ViewBag.First = "ALL";
            ViewBag.Second = "PRODUCTS";

            if(FilterBy== null)
            {
                return View("AllProducts");
            }
            
            Genre genre = new Genre();
            genre.Name = FilterBy;
            List<BookViewModel> books = _productService.FilterByGenre(genre);
            return View("AllProducts", books);
        }

        public IActionResult Biographies()
        {
            ViewBag.First = "BIOGRAPHIES";
            ViewBag.Second = "&MEMOIRS";

            Genre genre = new Genre();
            genre.Name = "Biographies & Memoirs";
            List<BookViewModel> books = _productService.FilterByGenre(genre);
            return View("AllProducts", books);
        }

        public IActionResult Children()
        {
            ViewBag.First = "CHIL";
            ViewBag.Second = "DREN";

            Genre genre = new Genre();
            genre.Name = "Children";
            List<BookViewModel> books = _productService.FilterByGenre(genre);
            return View("AllProducts", books);
        }

        public IActionResult Fantasy()
        {
            ViewBag.First = "FANT";
            ViewBag.Second = "ASY";

            Genre genre = new Genre();
            genre.Name = "Fantasy";
            List<BookViewModel> books = _productService.FilterByGenre(genre);
            return View("AllProducts", books);
        }

        public IActionResult Fiction()
        {
            ViewBag.First = "FIC";
            ViewBag.Second = "TION";

            Genre genre = new Genre();
            genre.Name = "Fiction";
            List<BookViewModel> books = _productService.FilterByGenre(genre);
            return View("AllProducts", books);
        }

        [HttpPost]
        public IActionResult SortBy(string SortBy)
        {
            ViewBag.First = "ALL";
            ViewBag.Second = "PRODUCTS";

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
            ViewBag.First = "ALL";
            ViewBag.Second = "PRODUCTS";

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

        public IActionResult Review(){
               return View("BookDetail");
        }
        
        
        [Authorize(Policy="Customer")]
        [HttpPost]
        public IActionResult Review(string review, int? rating, int? productId)
        {
            if(review == null || rating == null || productId == null)
            {
                return View("BookDetail");
            }
            
            var userId = int.Parse(User.FindFirst("CustomerId").Value);
            _productService.AddReview(review, (int) rating, (int) productId, userId);
            var id = (int) productId;
            return RedirectToAction("BookDetail", id);
    
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

        public IActionResult Paberbacks()
        {
            var paberbacks = _productService.GetAllPaberbacks();
            ViewBag.First = "PAPER";
            ViewBag.Second = "BACKS";
            return View("AllProducts", paberbacks);
        }

        public IActionResult AudioBooks()
        {
            var audiobooks = _productService.GetAllAudioBooks();
            ViewBag.First = "AUDIO";
            ViewBag.Second = "BOOKS";
            return View("AllProducts", audiobooks);
        }

        public IActionResult EBooks()
        {
            var ebooks = _productService.GetAllEBooks();
            ViewBag.First = "E";
            ViewBag.Second = "BOOKS";
            return View("AllProducts", ebooks);
        }

        public IActionResult Hardcover()
        {
            var hardcover = _productService.GetAllHardcovers();
            ViewBag.First = "HARD";
            ViewBag.Second = "COVER";
            return View("AllProducts", hardcover);
        }
    }
}
