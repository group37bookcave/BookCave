using System;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    //[Authorize(Policy = "Customer")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        public IActionResult ShoppingCart()
        {
           /* 
            var ActiveOrders = _orderService.GetActiveOrder();
            /*Vantar product id og user id */
            /*var products = _orderService.AddToOrder();
            return View(products);
            return View(ActiveOrders);
            */
            throw new NotImplementedException();
        }

          public IActionResult Address()
        {
            return View();
        }

        public IActionResult RemoveProduct()
        {
            throw new NotImplementedException();
        }

        public IActionResult ReviewPage()
        {
            throw new NotImplementedException();
        }
    }
}
