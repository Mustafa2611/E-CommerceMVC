using E_CommerceAPI.Models;
using E_CommerceMVC.Data;
using E_CommerceMVC.ViewModels.OrderItems;
using E_CommerceMVC.ViewModels.Orders;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVC.Services.OrderServices
{

    public class OrderServices : IOrderServices
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _context;

        public OrderServices(IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public void CreateOrder()
        {
            var username = _contextAccessor.HttpContext.Session.GetString("Username");
            User user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();
            if (user != null)
            {
                Order order = new Order()
                {
                    User = user,
                    OrderDate = DateTime.Now,
                    TotalAmount = 0,
                };

                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }

        public void ConfirmOrder(int OrderId)
        {
            Order order = _context.Orders.Find(OrderId);
            if (order != null ) {
                order.Completion = "Yes";
                _context.Orders.Update(order);
                _context.SaveChanges();
                CreateOrder();

            }
        }


        public void AddItem(int ProductId)
        {
            var username = _contextAccessor.HttpContext.Session.GetString("Username");
            User user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();
            Product product = _context.Products.Find(ProductId) ?? throw new Exception("Product not Found.");
            if (user != null)
            {
                Order currentOrder = _context.Orders.Where(o => o.UserId == user.UserId && o.Completion == "No").SingleOrDefault();
                OrderItem item = new OrderItem()
                {
                    Order = currentOrder,
                    OrderId = currentOrder.OrderId,
                    Product = product,
                    ProductId = product.ProductId,
                    Price = product.Price,
                    Quantity = 1
                };

                _context.OrderItems.Add(item);
                currentOrder.TotalAmount += item.Price * item.Quantity;
                _context.Orders.Update(currentOrder);
                _context.SaveChanges();
            }
        }


        public IEnumerable<OrderItem> AllOrderItems()
        {
            var username = _contextAccessor.HttpContext.Session.GetString("Username");
            User user = _context.Users.Where(u => u.UserName == username).FirstOrDefault() ?? throw new Exception("not found");
            if (user != null)
            {
                Order currentOrder = _context.Orders.Where(o => o.UserId == user.UserId && o.Completion == "No").SingleOrDefault() ?? throw new Exception("not found") ;
                var items = _context.OrderItems.Include(i => i.Order).Include(i => i.Product).Where(i => i.OrderId == currentOrder.OrderId).ToList();

                return items;
            }
            return null;
        }

        public void DeleteItem(int itemId)
        {
            OrderItem item = _context.OrderItems.Find(itemId);
            if(item != null)
            {
                _context.OrderItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
