using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVC.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Email is in use")]
        [DataType(DataType.EmailAddress)]
        //[Remote(action: "IsEmailAvailable", controller:"Accounts")]
        public string? EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Password don't match.")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Gender")]
        public string SelectedGender { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; set; } = Enumerable.Empty<SelectListItem>();

        public int age { get; set; }
    }
}
