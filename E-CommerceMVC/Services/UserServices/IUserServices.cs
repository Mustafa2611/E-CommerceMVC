using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.Users;

namespace E_CommerceMVC.Services.UserServices
{
    public interface IUserServices
    {
        User Register(CreateUserFormViewModel viewModel);
        User Login(LoginFormViewModel viewModel);
        void Logout();
    }
}
