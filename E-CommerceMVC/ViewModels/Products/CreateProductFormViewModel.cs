using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVC.ViewModels.Products

{
    public class CreateProductFormViewModel
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        
        public IFormFile Cover { get; set; } = default!;

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public IEnumerable<SelectListItem> Brands = Enumerable.Empty<SelectListItem>();
       
        [Display(Name = "Category")]
        public List<int> SelectedCategories { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        
       
    }
}
