using System;
using System.Linq;
using System.Security.Claims;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Identity;

//using System.Threading.Tasks;




namespace BookCave.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public OrderController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _orderService = new OrderService();
        }

        public IActionResult ShoppingCart()
        {
            var userId = _signInManager.IsSignedIn(User) ? int.Parse(User.FindFirst("CustomerId").Value) : 10;
            var activeOrder = _orderService.GetActiveOrder(userId);
            return View(activeOrder);
        }


        [HttpPost]
        public IActionResult Remove(int? id)
        {
            if (id == null)
            {
                return View("ShoppingCart");
            }
            var userId = _signInManager.IsSignedIn(User) ? int.Parse(User.FindFirst("CustomerId").Value) : 10;
            var order = _orderService.GetActiveOrder(userId);
            _orderService.RemoveItem((int) id, order);
            order = _orderService.GetActiveOrder(userId);
            return RedirectToAction("ShoppingCart", order);
        }


        [HttpGet]
        public IActionResult Address()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Address(AddressInputModel address){
            if(ModelState.IsValid){
       
            return View();
        }


        [HttpGet]
        public IActionResult PaymentPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentPage(PaymentInputModel Payment)
        {
            if (ModelState.IsValid)
            {
                // _orderService.CheckoutOrder();

                return RedirectToAction("Receipt");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var userId = _signInManager.IsSignedIn(User) ? int.Parse(User.FindFirst("CustomerId").Value) : 10;
            var order = _orderService.GetActiveOrder(userId);
            _orderService.AddToOrder((int) id, order);
            order = _orderService.GetActiveOrder(userId);
            return View("ShoppingCart", order);
        }

        public IActionResult ReviewPage()
        {
            return View();
        }

        public IActionResult Receipt()
        {
            return View();
        }
    }
}