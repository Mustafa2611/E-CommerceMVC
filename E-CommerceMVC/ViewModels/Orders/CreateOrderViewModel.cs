using E_CommerceAPI.Models;

namespace E_CommerceMVC.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Completion { get; set; }

        public User User { get; set; }

    }
}
