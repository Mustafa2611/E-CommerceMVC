using E_CommerceAPI.Models;
using E_CommerceMVC.Data;
using E_CommerceMVC.Services.OrderServices;
using E_CommerceMVC.ViewModels.Users;

namespace E_CommerceMVC.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IOrderServices _orderServices;

        public UserServices(ApplicationDbContext context, IHttpContextAccessor contextAccessor, IOrderServices orderServices)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _orderServices = orderServices;
        }

        public User Login(LoginFormDto viewModel)
        {
            User user = _context.Users.FirstOrDefault(u=> u.UserName == viewModel.UserName);

            if(user != null)
                _contextAccessor.HttpContext.Session.SetString("Username", user.UserName);

            return user;


        }

        public void Register(CreateUserFormViewModel viewModel)
        {
            User user = new()
            {
                UserName = viewModel.UserName,
                Age = viewModel.age
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            _contextAccessor.HttpContext.Session.SetString("Username", user.UserName);

            _orderServices.CreateOrder();

        }
        public void Logout()
        {
            _contextAccessor.HttpContext.Session.Clear();
        }

    }
}
