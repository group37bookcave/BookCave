using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult AllProducts()
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
    }
}
