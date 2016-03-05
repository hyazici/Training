namespace Ponera.Base.Contracts.Security
{
    public interface IAuthorizationManager
    {
        bool IsUserAuthorized(string[] roles);
    }
}