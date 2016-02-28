using System.Collections.Generic;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess.Contracts
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity
    {
        TEntity GetById(TPrimaryKey primaryKey);

        IList<TEntity> GetAll(bool? deleted = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
