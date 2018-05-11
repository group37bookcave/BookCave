using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TermsAndCond()
        {
            return View();
        }

        public IActionResult About()
        {
            throw new NotImplementedException();
        }

        public IActionResult TopRated()
        {
            throw new NotImplementedException();
        }

        public IActionResult Contact()
        {
        ViewData["Message"] = "Your contact page.";
        
        return null;
        }

      

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
