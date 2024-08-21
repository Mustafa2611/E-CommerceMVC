using E_CommerceMVC.Services.UserServices;
using E_CommerceMVC.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace E_CommerceMVC.Controllers
{
    [HandleError]
    public class UsersController : Microsoft.AspNetCore.Mvc.Controller
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
            CreateUserFormViewModel model = new CreateUserFormViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(CreateUserFormViewModel model) { 
            _userServices.Register(model);
            
            return RedirectToAction("Index","Home");
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
            _userServices.Login(model);
            if (_userServices.Login(model)!=null)
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
