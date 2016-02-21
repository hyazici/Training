using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Ponera.Base.Models;

namespace Ponera.PoneraAdmin.Core
{
    public static class SessionManager
    {
        public static IEnumerable<MenuModel> MenuModels
        {
            get
            {
                object objMenus = HttpContext.Current.Session["Menus"];

                return objMenus as IList<MenuModel>;
            }
            set
            {
                HttpContext.Current.Session["Menus"] = value;
            }
        }
    }
}
