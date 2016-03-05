using System.Collections.Generic;
using Ponera.Base.Models;

namespace Ponera.Base.Contracts.BusinessLayer
{
    public interface IMenuBusiness
    {
        IList<MenuModel> GetMenuModels();
    }
}