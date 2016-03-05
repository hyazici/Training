using System.Collections.Generic;
using Ponera.Base.Entities;

namespace Ponera.Base.Contracts.DataAccess
{
    public interface IPageAuhorizationRepository : IRepository<PageAuthorization, int>
    {
        IList<PageAuthorization> GetPageAuthorizationsByUrl(string url, bool? deleted = false);
    }
}