using System.Collections.Generic;
using System.Web;
using Ponera.Base.Contracts;
using Ponera.Base.Models;

namespace Ponera.PoneraAdmin.Core
{
    public class SessionManager : ISessionManager
    {
        public T GetSessionValue<T>(string key) where T : class
        {
            object sessionObjects = HttpContext.Current.Session[key];

            return sessionObjects as T;
        }

        public void SetSessionValue(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public UserModel User
        {
            get
            {
                return GetSessionValue<UserModel>("CurrentUser");
            }

            set
            {
                SetSessionValue("CurrentUser", value);
            }
        }

        public IList<MenuModel> UserMenus
        {
            get
            {
                return GetSessionValue<IList<MenuModel>>("UserMenus");
            }
            set
            {
                SetSessionValue("UserMenus", value);
            }
        }

        public IList<MenuModel> Menus
        {
            get
            {
                return GetSessionValue<IList<MenuModel>>("Menus");
            }
            set
            {
                SetSessionValue("Menus", value);
            }
        }
    }
}
