using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Receipt()
        {
            return View();
        }
    }
}
