using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.ViewModels.Brands
{
    public class BrandsListFormViewModel : CreateBrandFormViewModel
    {
        public IEnumerable<SelectListItem> Brands = Enumerable.Empty<SelectListItem>();

    }
}
