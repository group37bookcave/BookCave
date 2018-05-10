using System;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;


using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;


namespace BookCave.Controllers
{
    //[Authorize(Policy = "Customer")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        private readonly UserManager<ApplicationUser> _userManager;
        

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

        [HttpGet]
          public IActionResult Address()
        {
            return View();
        }    

        [HttpPost]
        public IActionResult Address(Address address){
            if(ModelState.IsValid){
            var addr = new Address()
            {
                
            };
            
            var newMovie = new Address()
            {
             
            };

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
        public IActionResult AddToCart(int id)
        {
            var customerId = int.Parse( User.FindFirst("CustomerID").Value );
            var customer = _userManager.GetUserId().Value;
            var order = _orderService.GetActiveOrder(customer);
            var add = _orderService.AddToOrder(id, order.OrderId);
            return View();
        }
    }
}
