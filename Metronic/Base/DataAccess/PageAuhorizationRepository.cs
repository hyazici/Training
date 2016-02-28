using System.Collections.Generic;
using System.Linq;
using Ponera.Base.DataAccess.Contracts;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class PageAuhorizationRepository : BaseRepository<PageAuthorization, int>, IPageAuhorizationRepository
    {
        public IList<PageAuthorization> GetPageAuthorizationsByUrl(string url, bool? deleted = false)
        {
            string query = "SELECT * FROM PageAuthorization WHERE Url = @url AND (@deleted IS NULL OR Deleted = @deleted)";

            List<PageAuthorization> menuAuthorizations = _dbManager.Query<PageAuthorization>(query, new { url = url, deleted = deleted }).ToList();

            return menuAuthorizations;
        }
    }
}
