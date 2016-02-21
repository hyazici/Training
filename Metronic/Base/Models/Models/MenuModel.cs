using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Ponera.Base.Entities;

namespace Ponera.Base.Models
{
    public class MenuModel
    {
        public MenuModel()
        {
            ChildMenus = new List<MenuModel>();
            MenuAuthorizationModels = new List<MenuAuthorizationModel>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public IList<MenuAuthorizationModel> MenuAuthorizationModels { get; set; }

        public DateTime CreateDate { get; set; }

        public IList<MenuModel> ChildMenus { get; set; }
    }
}
