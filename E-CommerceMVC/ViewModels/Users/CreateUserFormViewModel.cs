using E_CommerceMVC.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVC.ViewModels.Users
{
    public class CreateUserFormViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Display(Name ="Gender")]
        public string SelectedGender { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; } = Enumerable.Empty<SelectListItem>();
        public int age { get; set; }
    }
}
