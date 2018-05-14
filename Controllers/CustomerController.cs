using BookCave.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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

        [HttpPost]
        public IActionResult RemoveFromWishList(int? id)
        {
            if (id == null)
            {
                return View("WishList");
            }
            var userId = int.Parse(User.FindFirst("CustomerId").Value);
            _userService.RemoveFromWishList((int) id, userId);
            return RedirectToAction("WishList");
        }

        [HttpGet]
        public IActionResult WishList()
        {
            var userId = int.Parse(User.FindFirst("CustomerId").Value);
            var wishlist = _userService.GetWishList(userId);
            return View(wishlist);

        }        
        public IActionResult OrderHistory()
        {
            var userId = int.Parse(User.FindFirst("CustomerId").Value);
            var orderHistory = _orderService.OrderHistory(userId);
            return View(orderHistory);
        }

        [HttpGet]
        public IActionResult AccountDetails()
        {
            return View();
        }
    }
}
