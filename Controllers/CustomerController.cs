using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;


namespace BookCave.Controllers
{
    // [Authorize(Policy = "Customer")]

    public class CustomerController : Controller
    
    {
        private readonly ProductService productService = new ProductService();
      
        [HttpGet]
        public IActionResult AccountDetails()
        {
            return View();
        }

        [HttpPost]
       /* public IActionResult AccountDetails()
        {
            return View();
        }
*/
        public IActionResult OrderHistory()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Orders()
        {
            throw new NotImplementedException();
        }

        public IActionResult WishList()
        {
            return View();
        }
        
    }
}
