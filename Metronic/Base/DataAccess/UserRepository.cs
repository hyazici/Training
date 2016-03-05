using System.Linq;
using Ponera.Base.Contracts.DataAccess;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public User GetUserByEmailAddress(string email, bool? deleted = false)
        {
            string query = "Select * From [User] Where (@deleted IS NULL OR Deleted = @deleted) AND Email = @email";

            User user = _dbManager.Query<User>(query, new { deleted = deleted, email = email }).FirstOrDefault();

            return user;
        }
    }
}
