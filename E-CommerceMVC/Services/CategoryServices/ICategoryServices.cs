using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.Services.CategoryServices
{
    public interface ICategoryServices
    {

        void Create(CreateCategoryDto viewModel);
        void Update(CreateCategoryDto viewModel);
        void Delete(CreateCategoryDto viewModel);

        IEnumerable<SelectListItem> GetSelectListItem();
        IEnumerable<Category> GetAllCategories();

    }
}
