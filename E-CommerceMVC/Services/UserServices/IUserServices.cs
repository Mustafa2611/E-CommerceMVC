using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.Users;

namespace E_CommerceMVC.Services.UserServices
{
    public interface IUserServices
    {
        void Register(CreateUserFormViewModel viewModel);
        User Login(LoginFormDto viewModel);
        void Logout();
    }
}
