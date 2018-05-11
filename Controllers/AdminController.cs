using System.Security.Claims;
using System.Threading.Tasks;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserService _userService;

        public AdminController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = new UserService();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterInputModel model)
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

            // Create an Employee in the database for the user.
            var employeeId = _userService.CreateEmployee(model);


            // Add claims to the ApplicationUser.
            await _userManager.AddClaimAsync(user, new Claim("EmployeeId", employeeId.ToString()));

            await _userManager.AddClaimAsync(user, new Claim("Role", "Employee"));
            await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));

            // Sign in the ApplicationUser
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            _userService.GetEmployees();
            return View();
        }       
    }
}