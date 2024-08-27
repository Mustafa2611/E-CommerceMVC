using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVC.ViewModels.Roles
{
    public class DeleteRoleViewModel
    {
        [Required]
        public string RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
