using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class RoleRepository : BaseRepository<Role, int>
    {
        public IList<Role> GetRolesByUserId(int userId)
        {
            // SELECT r.* FROM Role AS r LEFT OUTER JOIN UserRole AS ur ON r.Id = ur.RoleId WHERE (ur.UserId = 2)

            using (DbManager manager = new DbManager())
            {
                IDbConnection connection = manager.Connection;

                string query = "SELECT r.* FROM [Role] AS r LEFT OUTER JOIN UserRole AS ur ON r.Id = ur.RoleId WHERE (ur.UserId = @userId)";

                IList<Role> roles = connection.Query<Role>(query, new {userId = userId}).ToList();

                return roles;
            }
        }
    }
}