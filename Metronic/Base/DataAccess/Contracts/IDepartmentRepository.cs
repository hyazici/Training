using System.Collections.Generic;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess.Contracts
{
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        IList<Department> GetAllDepartments(bool? deleted = false);
    }
}