﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


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

        public IList<TEntity> GetAll()
        {
            IList<TEntity> entities = _dbManager.GetAll<TEntity>().ToList();

            return entities;
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
