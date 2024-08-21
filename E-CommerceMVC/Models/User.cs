using E_CommerceMVC.Models.Enums;

namespace E_CommerceAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; } = nameof(Gender);
        public int Age { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
