using WebApp.MVC.Models.AccountViewModels;

namespace WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<UserLoginResponse> Login(LoginViewModel userLogin);
        Task<UserLoginResponse> Register(RegisterViewModel userRegister);
    }
}
