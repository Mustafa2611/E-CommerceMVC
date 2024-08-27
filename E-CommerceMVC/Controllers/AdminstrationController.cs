using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVC.Controllers
{
    public class AdminstrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _usermanager;

        public AdminstrationController(RoleManager<IdentityRole> roleManager, UserManager<User> usermanager)
        {
            _roleManager = roleManager;
            _usermanager = usermanager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid) {
                var RoleIsExist =await _roleManager.RoleExistsAsync(model.RoleName);
                if (RoleIsExist)
                {
                    ModelState.AddModelError("", "The Role is already exist.");
                }
                else
                {
                    var role = new IdentityRole()
                    {
                        Name = model.RoleName
                    };

                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Adminstration");
                    }
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var Roles =await _roleManager.Roles.ToListAsync();
            return View(Roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string RoleId)
        {
            var role =await _roleManager.FindByIdAsync(RoleId);
            if(role == null)
                return View("Error");
            var model = new EditRoleViewModel()
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Users = new List<string>()
            };

            foreach(var user in await _usermanager.Users.ToListAsync())
            {
                if(await _usermanager.IsInRoleAsync(user, role.Name))
                    model.Users.Add(user.UserName);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Role = await _roleManager.FindByIdAsync(model.RoleId);
                if (Role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {model.RoleId} cannot be found";
                    return View("NotFound");
                }
                Role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(Role);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetRoles", "Adminstration");
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

       
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string RoleId)
        {
            if (ModelState.IsValid)
            {
                var Role = await _roleManager.FindByIdAsync(RoleId);
                if (Role == null)
                {
                    ViewBag.ErrorMessage = $"Role with id = {RoleId} not found.";
                    return View("NotFound");
                }
                var result = await _roleManager.DeleteAsync(Role);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetRoles", "Adminstration");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("GetRoles", await _roleManager.Roles.ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var Role = await _roleManager.FindByIdAsync(roleId);
            if (Role == null)
            {
                return View("Error");
            }

            ViewBag.RoleName = Role.Name;

            var model = new List<UserRoleViewModel>();

            foreach (var user in await _usermanager.Users.ToListAsync())
            {
                var userRoleViewModel = new UserRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await _usermanager.IsInRoleAsync(user, Role.Name))
                    userRoleViewModel.IsSelected = true;
                else
                    userRoleViewModel.IsSelected = false;

                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model , string roleId)
        {
            if (ModelState.IsValid)
            {

                var Role = await _roleManager.FindByIdAsync(roleId);
                if (Role == null)
                {
                    ViewBag.ErrorMessage = $"Role with id= {roleId} not found";
                    return View("NotFound");
                }

                for (int i = 0; i < model.Count; i++)
                {
                    var user = await _usermanager.FindByIdAsync(model[i].UserId);
                    IdentityResult result;

                    if (model[i].IsSelected && !(await _usermanager.IsInRoleAsync(user, Role.Name)))
                        result = await _usermanager.AddToRoleAsync(user, Role.Name);
                    else if (!model[i].IsSelected && (await _usermanager.IsInRoleAsync(user, Role.Name)))
                        result = await _usermanager.RemoveFromRoleAsync(user, Role.Name);
                    else
                        continue;

                    if (result.Succeeded)
                    {
                        if (i < model.Count - 1)
                            continue;
                        else
                            return RedirectToAction("EditRole", new { roleId = roleId });
                    }
                }

            }
            return RedirectToAction("EditRole", new { roleId = roleId });

        }

    }
}
