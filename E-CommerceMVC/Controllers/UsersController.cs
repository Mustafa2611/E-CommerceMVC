using E_CommerceMVC.Models.Enums;
using E_CommerceMVC.Services.UserServices;
using E_CommerceMVC.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.Controllers
{
    public class UsersController :Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            CreateUserFormViewModel model = new CreateUserFormViewModel()
            {
                GenderList = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(g=> new SelectListItem
                {
                    Value = g.ToString(),
                    Text = g.ToString()
                })
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(CreateUserFormViewModel model) 
        {
            var register = _userServices.Register(model);
            if ( register !=null)
                return RedirectToAction("Index", "Home");
            ModelState.AddModelError("Username", $"Invalid username or password.");
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            LoginFormDto model = new LoginFormDto();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginFormDto model)
        { 
          var login =  _userServices.Login(model);
            if (login != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Username", $"Invalid username or password.");
            return View(model);

        }

        public IActionResult Logout()
        {
            _userServices.Logout();
            return RedirectToAction("Index","Home");
        }
    }
}
