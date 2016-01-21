using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class UserRepository : BaseRepository<User, int>
    {
        public User GetUserByEmailAddress(string email, bool? deleted = false)
        {
            using (DbManager manager = new DbManager())
            {
                IDbConnection connection = manager.Connection;

                string query = "Select * From [User] Where (@deleted IS NULL OR Deleted = @deleted) AND Email = @email";

                User user = connection.Query<User>(query, new {deleted = deleted, email = email}).FirstOrDefault();

                return user;
            }
        }
    }
}
