using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVC.ViewModels.Roles
{
    public class EditRoleViewModel
    {
        [Required]
        public string RoleId { get; set; }

        [Required(ErrorMessage ="Role Name is required")]
        public string RoleName { get; set; }

        public List<string>? Users { get; set; }
    }
}
