using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.Brands;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.Services.BrandServices
{
    public interface IBrandServices
    {
        void Create(CreateBrandFormViewModel viewModel);
        void Update(CreateBrandFormViewModel viewModel);
        void Delete(BrandsListFormViewModel viewModel);

        IEnumerable<SelectListItem> GetSelectListItem();
        IEnumerable<Brand> GetAllBrands();


    }
}
