using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
	public class DbManager : PetaPoco.Database
	{
		public DbManager()
			: base("PoneraIntranet")
		{

		}

		public IEnumerable<T> GetAll<T>(bool? deleted = null)
		{
			var entityType = typeof(T);
			string query = $"Select * From [{entityType.Name}]";

			if (deleted.HasValue)
			{
				string deletedValue = deleted.Value ? "1" : "0";

				query = $"{query} where Deleted = {deletedValue}";
			}

			return Query<T>(query);
		}

		public IEnumerable<PagedEntity<TEntity>> GetAllByFilter<TEntity>(int start, int length, string search, int sortColumn, string sortDirection) 
			where TEntity : IEntity
		{
			Type entityType = typeof (TEntity);

			StringBuilder sb = new StringBuilder();
			string whereClause = string.Empty;
			string orderByClause = string.Empty;

			PropertyInfo[] propertyInfos = entityType.GetProperties();

			if (!string.IsNullOrEmpty(search))
			{
				for (int i = 0; i < propertyInfos.Length; i++)
				{
					PropertyInfo propertyInfo = propertyInfos[i];
					string columnName = propertyInfo.Name;
					string whereOr = i == 0 ? "WHERE" : "OR";

					sb.Append($" {whereOr} {columnName} LIKE '%{search}%'");
				}

				whereClause = sb.ToString();
			}

			string orderByColumn = sortColumn == -1 ? propertyInfos[0].Name : propertyInfos[sortColumn].Name;
			string ascDesc = string.IsNullOrEmpty(sortDirection) ? "ASC" : sortDirection;
			orderByClause = $"ORDER BY {orderByColumn} {ascDesc}";		

			string query = $@"SELECT *
					  FROM (
						  SELECT ROW_NUMBER() OVER (
								  {orderByClause}
								  ) AS RowNumber, *
						  FROM (
							  SELECT (
									  SELECT COUNT(*)
									  FROM [{entityType.Name}]
									  {whereClause}
									  ) AS TotalDisplayRows
								  ,(
									  SELECT COUNT(*)
									  FROM [{entityType.Name}]
									  ) AS TotalRows
								  ,*
							  FROM [{entityType.Name}]
							  {whereClause}
							  ) RawResults
						  ) Results
					  WHERE RowNumber BETWEEN {start + 1} AND {start + length}";

		    IEnumerable<PagedEntity<TEntity>> pagedEntities = Query<PagedEntity<TEntity>, TEntity>(query);

		    return pagedEntities;
		}
	}
}
