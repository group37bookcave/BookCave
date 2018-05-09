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
        {/*
            int userId = int.Parse(User.FindFirst("customerId").Value);
            if(userId==0)
            {
                return View();
            }

            var ActiveOrder = _orderService.GetActiveOrder(userId);
            return View(ActiveOrder);*/
            return View();
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
            return View();
        }

          public IActionResult Receipt()
        {
            return View();
        }
    }
}
