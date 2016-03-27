using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.Entities
{
    public class PagedEntity<TEntity>
        where TEntity : IEntity
    {
        public int RowNumber { get; set; }

        public int TotalDisplayRows { get; set; }

        public int TotalRows { get; set; }

        public TEntity Entity { get; set; }
    }
}
