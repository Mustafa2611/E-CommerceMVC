using E_CommerceMVC.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace E_CommerceAPI.Models
{
    public class User
        : IdentityUser
    {
        public string Gender { get; set; } = nameof(Gender);
        public int Age { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
