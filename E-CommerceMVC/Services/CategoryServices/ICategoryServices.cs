using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.Services.CategoryServices
{
    public interface ICategoryServices
    {

        void Create(CreateCategoryViewModel viewModel);
        void Update(CreateCategoryViewModel viewModel);
        void Delete(CreateCategoryViewModel viewModel);

        IEnumerable<SelectListItem> GetSelectListItem();
        IEnumerable<Category> GetAllCategories();

    }
}
