using E_CommerceMVC.Services.CategoryServices;
using E_CommerceMVC.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCategoryViewModel modelView = new CreateCategoryViewModel();
            return View(modelView);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel modelView)
        {
            _categoryServices.Create(modelView);
            return RedirectToAction("Index", "Categories");
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryServices.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Update()
        {
            CreateCategoryViewModel viewModel = new CreateCategoryViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(CreateCategoryViewModel viewModel)
        {
            _categoryServices.Update(viewModel);
            return RedirectToAction("Index", "Categories");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            DeleteCategoryViewModel viewModel = new()
            {
                Categories = _categoryServices.GetSelectListItem()
            };
            return View(viewModel);
        }
        //[HttpPost]
        public IActionResult Delete(DeleteCategoryViewModel viewModel)
        {
             _categoryServices.Delete(viewModel);
            return RedirectToAction("Index" , "Categories");
        }

    }
}
