namespace E_CommerceAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int Age { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
