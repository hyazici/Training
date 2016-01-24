using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class DepartmentRepository : BaseRepository<Department, int>
    {
        public IList<Department> GetAllDepartments(bool? deleted = false)
        {
            string query = "Select * From Department Where (@deleted IS NULL OR Deleted = @deleted)";

            List<Department> departments = _dbManager.Query<Department>(query, new { deleted = deleted }).ToList();

            return departments;
        }
    }
}
