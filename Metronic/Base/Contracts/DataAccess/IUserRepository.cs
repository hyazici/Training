using Ponera.Base.Entities;

namespace Ponera.Base.Contracts.DataAccess
{
    public interface IUserRepository : IRepository<User, int>
    {
        User GetUserByEmailAddress(string email, bool? deleted = false);
    }
}