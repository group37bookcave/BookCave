using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        
        public IActionResult WishList()
        {
            
            ViewData["Message"] = "Your wish list.";

            return View();
        }
    }
        
}
