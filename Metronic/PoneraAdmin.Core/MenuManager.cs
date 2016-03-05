using System.Collections.Generic;
using System.Linq;
using Ponera.Base.Contracts;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Models;

namespace Ponera.PoneraAdmin.Core
{
    public class MenuManager : IMenuManager
    {
        private readonly IMenuBusiness _menuBusiness;
        private readonly ISecurityBusiness _securityBusiness;
        private readonly ISessionManager _sessionManager;

        public MenuManager(IMenuBusiness menuBusiness, ISecurityBusiness securityBusiness, ISessionManager sessionManager)
        {
            _menuBusiness = menuBusiness;
            _securityBusiness = securityBusiness;
            _sessionManager = sessionManager;
        }

        public IList<MenuModel> GetUserMenuModels(IList<MenuModel> menuModels)
        {
            IEnumerable<MenuModel> mainMenus = menuModels.Where(model => model.ParentId == null);

            List<MenuModel> usersMenusList = new List<MenuModel>();
            foreach (MenuModel menuModel in mainMenus)
            {
                FillChildMenus(menuModel, menuModels);

                if (menuModel.ChildMenus.Any())
                {
                    usersMenusList.Add(menuModel);
                }
            }

            return usersMenusList;
        }

        public IList<MenuModel> GetMenuModels()
        {
            IList<MenuModel> menuModels = _menuBusiness.GetMenuModels();

            return menuModels;
        }

        private void FillChildMenus(MenuModel menuModel, IList<MenuModel> menuModels)
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
                UserModel userModel = _sessionManager.User;
                IList<RoleModel> roleModels = userModel.Roles;

                if (roleModels.Any(model => model.RoleName == "Admin") || string.IsNullOrEmpty(childMenu.Url))
                {
                    menuModel.ChildMenus.Add(childMenu);
                    continue;
                }

                IList<PageAuthorizationModel> menuAuthorizationModelsByUrl = _securityBusiness.GetMenuAuthorizationModelsByUrl(childMenu.Url);

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
