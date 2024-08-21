using E_CommerceAPI.Models;
using E_CommerceMVC.Data;
using E_CommerceMVC.ViewModels.Brands;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.Services.BrandServices
{
    public class BrandServices : IBrandServices
    {
        private readonly ApplicationDbContext _context;

        public BrandServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(CreateBrandFormViewModel viewModel)
        {
            var brand = new Brand()
            {
              BrandName=  viewModel.BrandName
            };
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }


        public IEnumerable<SelectListItem> GetSelectListItem()
        {
            return _context.Brands.Select(b=> new SelectListItem { Value = b.BrandId.ToString() , Text = b.BrandName}).ToList();
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }


        public void Update(CreateBrandFormViewModel viewModel)
        {
            Brand brand = new()
            {
                BrandId= viewModel.BrandId,
                BrandName= viewModel.BrandName
            };
            _context.Brands.Update(brand);
            _context.SaveChanges();

        }

        public void Delete(BrandsListFormViewModel viewModel)
        {
            Brand brand = new()
            {
                BrandId = viewModel.BrandId,
                BrandName = viewModel.BrandName
            };
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

    }
}
