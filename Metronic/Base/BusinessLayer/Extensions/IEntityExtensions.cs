using System;
using AutoMapper;
using Ponera.Base.Entities;

namespace Ponera.Base.BusinessLayer.Extensions
{
    public static class IEntityExtensions
    {
        public static T Map<T>(this IEntity entity)
            where T : class 
        {
            if (entity == null)
            {
                return null;
            }

            Type entityType = entity.GetType();
            Type modelType = typeof(T);

            object model = Mapper.Map(entity, entityType, modelType);

            return model as T;
        }
    }
}
