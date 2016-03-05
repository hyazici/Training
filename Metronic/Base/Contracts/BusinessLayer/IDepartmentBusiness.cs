using System.Collections.Generic;
using Ponera.Base.Models;

namespace Ponera.Base.Contracts.BusinessLayer
{
    public interface IDepartmentBusiness
    {
        void AddDepartment(DepartmentModel departmentModel);

        void DeleteDepartment(int departmentId);

        IList<DepartmentModel> GetDepartments(bool? deleted = false);

        void UpdateDepartment(DepartmentModel departmentModel);
    }
}