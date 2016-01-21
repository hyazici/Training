using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Extensions.Linq;
using Dapper.Extensions.Linq.Core;
using Dapper.Extensions.Linq.Core.Configuration;
using Dapper.Extensions.Linq.Extensions;
using Dapper.Extensions.Linq.Mapper;
using Dapper.Extensions.Linq.Predicates;
using Dapper.Extensions.Linq.Sql;

namespace Ponera.Base.DataAccess
{
    public abstract class BaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> 
        where TEntity : class, Entities.IEntity
    {
        protected readonly string _connStr;

        public BaseRepository()
        {
            _connStr = ConfigurationManager.ConnectionStrings["PoneraIntranet"].ConnectionString;
        }

        public TEntity GetById(TPrimaryKey primaryKey)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                TEntity entity = connection.Get<TEntity>(primaryKey);

                return entity;
            }
        }

        public IList<TEntity> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                IList<TEntity> entities = connection.GetList<TEntity>().ToList();

                return entities;
            }
        }

        public void Add(TEntity entity)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                connection.Insert(entity);
            }
        }

        public void Update(TEntity entity)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                connection.Update(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                connection.Delete(entity);
            }
        }
    }
}
