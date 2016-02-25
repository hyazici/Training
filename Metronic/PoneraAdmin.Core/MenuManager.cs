using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponera.Base.BusinessLayer;
using Ponera.Base.Models;
using Ponera.Base.Security;

namespace Ponera.PoneraAdmin.Core
{
    public static class MenuManager
    {
        private static readonly MenuBusiness MenuBusiness = new MenuBusiness();
        private static readonly SecurityBusiness SecurityBusiness = new SecurityBusiness();

        private static IList<MenuModel> FlatMenuModels = new List<MenuModel>();

        public static IEnumerable<MenuModel> GetUserMenuModels()
        {
            FlatMenuModels = MenuBusiness.GetMenuModels();
            IEnumerable<MenuModel> mainMenus = FlatMenuModels.Where(model => model.ParentId == null);

            List<MenuModel> usersMenusList = new List<MenuModel>();
            foreach (MenuModel menuModel in mainMenus)
            {
                FillChildMenus(menuModel, FlatMenuModels);

                if (menuModel.ChildMenus.Any())
                {
                    usersMenusList.Add(menuModel);
                }
            }

            return usersMenusList;
        }

        public static IList<MenuModel> GetFlatMenuModels()
        {
            return FlatMenuModels;
        }

        private static void FillChildMenus(MenuModel menuModel, IList<MenuModel> menuModels)
        {
            List<MenuModel> childMenus = menuModels
                .Where(model => model.ParentId == menuModel.Id)
                .OrderBy(model => model.Code)
                .ToList();

            if (!childMenus.Any())
            {
                return;
            }

            foreach (MenuModel childMenu in childMenus)
            {
                UserModel userModel = AuthenticationManager.User;
                IList<RoleModel> roleModels = userModel.Roles;

                if (roleModels.Any(model => model.RoleName == "Admin") || string.IsNullOrEmpty(childMenu.Url))
                {
                    menuModel.ChildMenus.Add(childMenu);
                    continue;
                }

                IList<PageAuthorizationModel> menuAuthorizationModelsByUrl = SecurityBusiness.GetMenuAuthorizationModelsByUrl(childMenu.Url);

                if (menuAuthorizationModelsByUrl.Any(
                    model => (model.UserId == userModel.Id || roleModels.Any(roleModel => roleModel.Id == model.RoleId) && model.Permission == "Read")))
                {
                    menuModel.ChildMenus.Add(childMenu);
                }

                FillChildMenus(childMenu, menuModels);
            }
        }
    }
}
