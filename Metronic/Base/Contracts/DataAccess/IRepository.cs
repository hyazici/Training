using System.Collections.Generic;
using Ponera.Base.Entities;

namespace Ponera.Base.Contracts.DataAccess
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity
    {
        TEntity GetById(TPrimaryKey primaryKey);

        IList<TEntity> GetAll(bool? deleted = null);

        IList<PagedEntity<TEntity>> GetAllByFilter(int start, int length, string search, int sortColumn, string sortDirection);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
