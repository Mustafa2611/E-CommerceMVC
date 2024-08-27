using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVC.ViewModels.Roles
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
