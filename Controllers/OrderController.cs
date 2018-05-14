using System;
using System.Linq;
using System.Security.Claims;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using Newtonsoft.Json;

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
        public IActionResult Address(AddressInputModel address)
        {
            if (!ModelState.IsValid)
            {
                 return View();   
            }
            var userId = _signInManager.IsSignedIn(User) ? int.Parse(User.FindFirst("CustomerId").Value) : 10;
            var order = _orderService.GetActiveOrder(userId);
            order = _orderService.AddAddressesToOrder(address, order);
            TempData["order"] = JsonConvert.SerializeObject(order);
            return RedirectToAction("ReviewPage");
        }
               
        public IActionResult ReviewPage()
        {
            if (TempData["order"] == null)
            {
                return View("ShoppingCart");
            }
            
            var order = JsonConvert.DeserializeObject<OrderViewModel>(TempData["order"].ToString());
            if (order?.Items == null || !order.Items.Any())
            {
                return View("ShoppingCart");
            }
            return View(order);
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


        
        public IActionResult Receipt()
        {
			if (TempData["order"] == null)
            {
                return View("ShoppingCart");
            }

            var order = JsonConvert.DeserializeObject<OrderViewModel>(TempData["order"].ToString());
            return View(order);
        }

        [HttpPost]
        public IActionResult Checkout()
        {   
            var userId = _signInManager.IsSignedIn(User) ? int.Parse(User.FindFirst("CustomerId").Value) : 10;
            var order = _orderService.GetActiveOrder(userId);
            if (order?.Items == null || !order.Items.Any())
            {
                return RedirectToAction("ShoppingCart");
            }
			TempData["order"] = JsonConvert.SerializeObject(order);
            _orderService.CheckoutOrder(order.OrderId);
            return RedirectToAction("Receipt");
        }
    }
}