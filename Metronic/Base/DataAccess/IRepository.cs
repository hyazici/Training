using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public interface IRepository<TEntity, TPrimaryKey>
                where TEntity : class, IEntity
    {
        TEntity GetById(TPrimaryKey primaryKey);

        IList<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
