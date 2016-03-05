using System.Collections.Generic;
using Ponera.Base.Models;

namespace Ponera.Base.Contracts
{
    public interface IMenuManager
    {
        IList<MenuModel> GetMenuModels();
        IList<MenuModel> GetUserMenuModels(IList<MenuModel> menuModels);
    }
}