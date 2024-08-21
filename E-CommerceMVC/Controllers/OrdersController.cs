using E_CommerceAPI.Models;
using E_CommerceMVC.Services.OrderServices;
using E_CommerceMVC.ViewModels.OrderItems;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMVC.Controllers
{

    public class OrdersController : Controller
    {
        private readonly IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(int ProductId) {
            _orderServices.AddItem(ProductId);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet("/Cart")]
        public IActionResult GetItems()
        {
            return View(_orderServices.AllOrderItems());
        }

        [HttpPost]
        public IActionResult Confirmation(int OrderId) { 
            _orderServices.ConfirmOrder(OrderId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Delete(int itemId)
        {
            _orderServices.DeleteItem(itemId);
            return RedirectToAction("GetItems", "Orders");
        }
    }
}
