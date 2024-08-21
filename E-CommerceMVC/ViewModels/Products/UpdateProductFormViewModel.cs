using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.ViewModels.Products
{
    public class UpdateProductFormViewModel : CreateProductFormViewModel
    {
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> Products {  get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
