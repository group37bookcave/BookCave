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
    //[Authorize(Policy = "Customer")]
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

<<<<<<< HEAD
        public IActionResult Login()
        {
            return View();
        }

=======
>>>>>>> b62e0b3f7cd4dc9c06a7b66a226491308a64d115
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
