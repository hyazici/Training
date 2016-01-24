using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Ponera.Base.DataAccess
{
    public class DbManager : PetaPoco.Database
    {
        public DbManager()
            : base("PoneraIntranet")
        {

        }

        public IEnumerable<T> GetAll<T>()
        {
            var entityType = typeof(T);
            string query = $"Select * From {entityType.Name}";

            return Query<T>(query);
        }
    }
}
