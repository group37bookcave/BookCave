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
            return View();
        }


        /*Remove, laga nöfn á föllum */
        /*[HttpGet]
        public IActionResult Remove(int id){
            
            if(id == null)
            {
                View("NotFound");
            }

            var product = productService.GetProduct(id);
            return View(product);
        }
*/
        [HttpPost]
        public IActionResult Remove(int id){
            /*if(id == null)
            {
                return View();
            }
            */
            productService.RemoveProduct(id);
            return RedirectToAction("Index");
        }
    }
}
