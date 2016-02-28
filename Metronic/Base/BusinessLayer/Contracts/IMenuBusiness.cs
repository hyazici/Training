using System.Collections.Generic;
using Ponera.Base.Models;

namespace Ponera.Base.BusinessLayer.Contracts
{
    public interface IMenuBusiness
    {
        IList<MenuModel> GetMenuModels();
    }
}