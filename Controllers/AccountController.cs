using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Repositories;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly UserService _userService;

        private readonly OrderService _orderService;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = new UserService();
            _orderService = new OrderService();
        }

        [HttpGet]
        public IActionResult RegisterTest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterTest(RegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (!result.Succeeded)
            {
                // Registration failed, return to registration form.
                return View();
            }

            // The user has been registered.
            // Create a Customer in the database for the user.
            var customerId = _userService.CreateCustomer(model);
            
            // Map the CustomerId to the ApplicationUser
            user.UserId = customerId;
            
            
            await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
/*
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}