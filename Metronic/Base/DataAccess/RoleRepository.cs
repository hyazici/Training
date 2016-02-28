using System.Collections.Generic;
using System.Linq;
using Ponera.Base.DataAccess.Contracts;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        public IList<Role> GetRolesByUserId(int userId)
        {
            string query = "SELECT r.* FROM [Role] AS r LEFT OUTER JOIN UserRole AS ur ON r.Id = ur.RoleId WHERE (ur.UserId = @userId)";

            IList<Role> roles = _dbManager.Query<Role>(query, new { userId = userId }).ToList();

            return roles;
        }
    }
}