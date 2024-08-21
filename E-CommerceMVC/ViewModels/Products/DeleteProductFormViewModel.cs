using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.ViewModels.Products
{
    public class DeleteProductFormViewModel 
    {
       public int ProductId { get; set; }  
       public IEnumerable<SelectListItem> Products { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
