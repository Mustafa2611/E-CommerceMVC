using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVC.ViewModels.Roles
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
