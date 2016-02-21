using System.Collections.Generic;
using System.Linq;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class MenuAuhorizationRepository : BaseRepository<MenuAuthorization, int>
    {
        public IList<MenuAuthorization> GetMenuAuthorizationsByMenuId(int menuId)
        {
            string query = "SELECT * FROM MenuAuthorization WHERE MenuId = @menuId";

            List<MenuAuthorization> menuAuthorizations = _dbManager.Query<MenuAuthorization>(query, new {menuId = menuId}).ToList();

            return menuAuthorizations;
        }
    }
}
