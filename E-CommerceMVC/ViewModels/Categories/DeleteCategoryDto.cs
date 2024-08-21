using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.ViewModels.Categories
{
    public class DeleteCategoryDto : CreateCategoryDto
    {
        public IEnumerable<SelectListItem> Categories =  Enumerable.Empty<SelectListItem>();
    }
}
