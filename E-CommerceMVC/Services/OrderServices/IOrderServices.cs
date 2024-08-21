using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.OrderItems;
using E_CommerceMVC.ViewModels.Orders;

namespace E_CommerceMVC.Services.OrderServices
{
    public interface IOrderServices
    {
        public void CreateOrder();

        public void ConfirmOrder(int OrderId);


        public void AddItem(int ProductId);

        public IEnumerable<OrderItem> AllOrderItems();

        public void DeleteItem(int ItemId);


    }
}
