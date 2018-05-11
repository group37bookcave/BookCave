using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore.Metadata;


namespace BookCave.Controllers
{
    [Authorize(Policy = "Customer")]
    public class CustomerController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public CustomerController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userService = new UserService();
            _orderService = new OrderService();

        }

        [HttpGet]
        public IActionResult AccountDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToWishList(int? id)
        {
            if (id == null)
            {
                return View("WishList");
            }
            var userId = int.Parse(User.FindFirst("CustomerId").Value);
            _userService.AddToWishList((int) id, userId);
            return RedirectToAction("WishList");
        }

        [HttpGet]
        public IActionResult WishList()
        {
            var userId = int.Parse(User.FindFirst("CustomerId").Value);
            var wishlist = _userService.GetWishList(userId);
            return View(wishlist);

        }
        
        [Authorize(Policy = "Customer")]
        public IActionResult OrderHistory()
        {
            var userId = int.Parse(User.FindFirst("CustomerId").Value);
            var orderHistory = _orderService.OrderHistory(userId);
            return View(orderHistory);
        }
        
    }
}
