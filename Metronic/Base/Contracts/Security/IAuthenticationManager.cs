using Ponera.Base.ViewModel;

namespace Ponera.Base.Contracts.Security
{
    public interface IAuthenticationManager
    {
        bool Login(LoginViewModel loginViewModel);
        void RegisterUser(RegisterViewModel model);
        void Logout();
    }
}