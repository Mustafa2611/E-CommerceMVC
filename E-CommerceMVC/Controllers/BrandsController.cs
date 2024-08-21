using E_CommerceAPI.Models;
using E_CommerceMVC.Services.BrandServices;
using E_CommerceMVC.ViewModels.Brands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandServices _brandService;

        //private readonly IBrandLocalServices _brandLocalService;
        public BrandsController(IBrandServices brandService)
        {
            _brandService = brandService;
            //_brandLocalService = brandLocalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateBrandFormViewModel model = new CreateBrandFormViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateBrandFormViewModel model)
        {
            _brandService.Create(model);
            return RedirectToAction("Index", "Brands");
        }

        [HttpGet]
        public IActionResult GetAll()
        {


            var brands = _brandService.GetAllBrands();
            return View(brands);
        }

        [HttpGet]
        public IActionResult Update()
        {
            CreateBrandFormViewModel model = new CreateBrandFormViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CreateBrandFormViewModel model)
        {
             _brandService.Update(model);
            return RedirectToAction("Index", "Brands");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            BrandsListFormViewModel model = new()
            {
                Brands = _brandService.GetSelectListItem().ToList(),
            };
            //IEnumerable<SelectListItem> modelb = model.Brands;

            return View(model);
        }

        //[HttpDelete]
        public IActionResult Delete(BrandsListFormViewModel model)
        {
            _brandService.Delete(model);
            return RedirectToAction("Index", "Brands");
        }
    }
}
