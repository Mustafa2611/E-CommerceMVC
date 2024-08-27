using E_CommerceAPI.Models;
using E_CommerceMVC.Models.Enums;
using E_CommerceMVC.Services.OrderServices;
using E_CommerceMVC.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace E_CommerceMVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IOrderServices _orderServices;

        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor contextAccessor, IOrderServices orderServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
            _orderServices = orderServices;
        }

        [HttpGet]
        public IActionResult RegisterIdentity()
        {
            RegisterViewModel model = new()
            {
                GenderList = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(x=> new SelectListItem { Value = x.ToString(), Text = x.ToString() })
            };
            return View(model);  
        }

        [HttpPost]
        public async Task<IActionResult> RegisterIdentity(RegisterViewModel model)
        {
            if (ModelState.IsValid) {

                var user = new User()
                {
                    UserName = model.Name,
                    Email = model.EmailAddress,
                    Gender = model.SelectedGender,
                    Age = model.age
                };

                var result = await _userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                    _contextAccessor.HttpContext.Session.SetString("Username", user.UserName);
                    _orderServices.CreateOrder();
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                //RegisterIdentity();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _contextAccessor.HttpContext.Session.SetString("Username", model.UserName);
                    return RedirectToAction("Index", "Home");
                }
               
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                

            }
            return View(model);
        }

       
        [AllowAnonymous]
        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> IsEmailAvailable(string Email)
        {
            //Check If the Email Id is Already in the Database
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {Email} is already in use.");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _contextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Login", "Accounts");
        }

    }
}
