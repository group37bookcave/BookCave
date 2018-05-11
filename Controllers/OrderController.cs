using System;
using System.Linq;
using System.Security.Claims;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;

//using System.Threading.Tasks;




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
            int userId = int.Parse(User.FindFirst("CustomerId").Value);
            if(userId==0)
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

           // Order updatedOrder = _orderService.RemoveFromOrder(productId);


            return RedirectToAction("ShoppingCart");
        }



        [HttpGet]
        public IActionResult Address()
        {
            return View();
        }    

        [HttpPost]
        public IActionResult Address(AddressInputModel address){
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
        public IActionResult AddToCart(int id)
        {
            return View();
        }

        public IActionResult OrderHistory()
        {
            int userId = int.Parse(User.FindFirst("CustomerId").Value);
            if(userId == 0)
            {
                return View();
            }
            var orderHistory = _orderService.OrderHistory(userId);
            return View(orderHistory);
        }
    }
}
