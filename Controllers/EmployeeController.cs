using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmpAccountDetails()
        {
            return View();
        }

        public IActionResult EmpAllProducts(){
            return View();
        }

        public IActionResult Orders()
        {
            throw new NotImplementedException();
        }
    }
}