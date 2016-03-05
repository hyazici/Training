using System.Collections.Generic;
using Ponera.Base.Entities;

namespace Ponera.Base.Contracts.DataAccess
{
    public interface IRoleRepository : IRepository<Role, int>
    {
        IList<Role> GetRolesByUserId(int userId);
    }
}