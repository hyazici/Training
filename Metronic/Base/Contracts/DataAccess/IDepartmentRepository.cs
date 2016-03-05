using System.Collections.Generic;
using Ponera.Base.Entities;

namespace Ponera.Base.Contracts.DataAccess
{
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        IList<Department> GetAllDepartments(bool? deleted = false);
    }
}