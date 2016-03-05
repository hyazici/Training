using System.Collections.Generic;
using Ponera.Base.Models;

namespace Ponera.Base.Contracts
{
    public interface ISessionManager
    {
        T GetSessionValue<T>(string key) where T : class;

        void SetSessionValue(string key, object value);

        UserModel User { get; set; }

        IList<MenuModel> UserMenus { get; set; }

        IList<MenuModel> Menus { get; set; }
    }
}
