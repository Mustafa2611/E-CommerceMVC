using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.ViewModels.Categories
{
    public class DeleteCategoryViewModel : CreateCategoryViewModel
    {
        public IEnumerable<SelectListItem> Categories =  Enumerable.Empty<SelectListItem>();
    }
}
