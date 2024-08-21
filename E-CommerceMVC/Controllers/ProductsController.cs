using E_CommerceAPI.Models;
using E_CommerceMVC.Services.BrandServices;
using E_CommerceMVC.Services.CategoryServices;
using E_CommerceMVC.Services.ProductServices;
using E_CommerceMVC.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;
        public ProductsController(IProductServices productServices, IBrandServices brandServices, ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _brandServices = brandServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateProductFormViewModel viewModel = new()
            {
                Brands = _brandServices.GetSelectListItem(),
                Categories = _categoryServices.GetSelectListItem()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateProductFormViewModel viewModel)
        {
            _productServices.CreateProduct(viewModel);
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public IActionResult GetDetails()
        {
            var result = _productServices.GetProducts();
            return View(result);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productServices.GetProducts();
            return View(result);
        }

        [HttpGet]
        public IActionResult Update()
        {
            UpdateProductFormViewModel viewModel = new()
            {
                Products =_productServices.GetSelectListItem(),
                Brands = _brandServices.GetSelectListItem(),
                Categories = _categoryServices.GetSelectListItem()

            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(UpdateProductFormViewModel viewModel)
        {
            _productServices.Update(viewModel);
            return RedirectToAction("Index", "Products");

        }

        [HttpGet]
        public IActionResult Delete()
        {
            DeleteProductFormViewModel viewModel = new()
            {
                Products = _productServices.GetSelectListItem().ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(DeleteProductFormViewModel viewModel)
        {
            _productServices.Delete(viewModel);
            return RedirectToAction("Index", "Products");

        }

    }

}
