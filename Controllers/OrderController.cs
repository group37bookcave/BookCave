using System;
using System.Linq;
using System.Security.Claims;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;


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
            var userId = int.Parse(User.FindFirst("customerId").Value);
            
            if(userId == 0)
            {
                return View();
            }
            var activeOrder = _orderService.GetActiveOrder(userId);
            return View(activeOrder);
        }


        [HttpPost]
        public IActionResult Remove(int? id)
        {
            if(id == null)
            {
                return View("ShoppingCart");
            }

            /*var productToRemove = _orderService;
            var productToRemove = (from s in DataBase.Orders
                                    where s.Id == id
                                    select s).SingleOrDefault();
            Database.Remove(productToRemove);
            */

            return RedirectToAction("ShoppingCart");
        }



        [HttpGet]
        public IActionResult Address()
        {
            return View();
        }    

        [HttpPost]
        public IActionResult Address(Address address){
            if(ModelState.IsValid){
        

            /*_orderService.AddToOrder.Address.Add(address); */
            return RedirectToAction("ReviewPage");
        }
            return View();
        }


        [HttpGet] 
        public IActionResult PaymentPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentPage(PaymentInputModel Payment){
            if(ModelState.IsValid){
               // _orderService.CheckoutOrder();
           
                return RedirectToAction("Receipt");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var userId = int.Parse(User.FindFirst("customerId").Value);
            var order = _orderService.GetActiveOrder(userId);
            _orderService.AddToOrder((int) id, order);
            return View("ShoppingCart");
        }
        
        [HttpPost]
        public IActionResult RemoveProduct(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var userId = int.Parse(User.FindFirst("customerId").Value);
            var order = _orderService.GetActiveOrder(userId);
            _orderService.RemoveItem((int) id, order);
            return RedirectToAction("ShoppingCart", order);

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
