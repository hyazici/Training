using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Extensions.Linq.Extensions;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class DepartmentRepository : BaseRepository<Department, int>
    {
        public IList<Department> GetAllDepartments(bool? deleted = false)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                string query = "Select * From Department Where (@deleted IS NULL OR Deleted = @deleted)";

                List<Department> departments = connection.Query<Department>(query, new {deleted = deleted}).ToList();

                return departments;
            }
        }
    }
}
