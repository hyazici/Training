using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Ponera.Base.Contracts.DataAccess;
using Ponera.Base.Entities;


namespace Ponera.Base.DataAccess
{
    public abstract class BaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, Entities.IEntity
    {
        // TODO : @deniz IOC'e geçtiğimiz dbmanger container'den gelmeli.
        protected readonly DbManager _dbManager;

        public BaseRepository()
        {
            _dbManager = new DbManager();
        }

        public TEntity GetById(TPrimaryKey primaryKey)
        {
            TEntity entity = _dbManager.SingleOrDefault<TEntity>(primaryKey);

            return entity;
        }

        public IList<TEntity> GetAll(bool? deleted = null)
        {
            IList<TEntity> entities = _dbManager.GetAll<TEntity>(deleted).ToList();

            return entities;
        }

        public IList<PagedEntity<TEntity>> GetAllByFilter(int start, int length, string search, int sortColumn, string sortDirection)
        {
            List<PagedEntity<TEntity>> pagedEntities = _dbManager.GetAllByFilter<TEntity>(start, length, search, sortColumn, sortDirection).ToList();

            return pagedEntities;
        }

        public void Add(TEntity entity)
        {
            _dbManager.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _dbManager.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbManager.Delete(entity);
        }
    }
}
