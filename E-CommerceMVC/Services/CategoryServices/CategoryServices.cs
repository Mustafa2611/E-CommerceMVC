using E_CommerceAPI.Models;
using E_CommerceMVC.Data;
using E_CommerceMVC.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(CreateCategoryDto viewModel)
        {
            var Category = new Category { 
                CategoryId = viewModel.CategoryId ,
                CategoryName = viewModel.CategoryName 

            };
            _context.Categories.Add(Category);
            _context.SaveChanges();
        }

        public void Delete(CreateCategoryDto viewModel)
        {
            var Category = new Category
            {
                CategoryId = viewModel.CategoryId,
                CategoryName = viewModel.CategoryName

            };
            _context.Categories.Remove(Category);
            _context.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetSelectListItem()
        {
            return _context.Categories.Select(c=> new SelectListItem { Value = c.CategoryId.ToString() , Text = c.CategoryName}).ToList();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public void Update(CreateCategoryDto viewModel)
        {
            var Category = new Category
            {
                CategoryId = viewModel.CategoryId,
                CategoryName = viewModel.CategoryName

            };
            _context.Categories.Update(Category);
            _context.SaveChanges();
        }
    }
}
