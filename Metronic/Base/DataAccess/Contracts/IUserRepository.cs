using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess.Contracts
{
    public interface IUserRepository : IRepository<User, int>
    {
        User GetUserByEmailAddress(string email, bool? deleted = false);
    }
}