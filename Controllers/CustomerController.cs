using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
   /* [Authorize(Policy = "Customer")]*/
    public class CustomerController : Controller
    {
        public IActionResult Receipt()
        {
            return View();
        }

        public IActionResult AccountDetails()
        {
            return View();
        }

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
            throw new NotImplementedException();
        }
    }
}
