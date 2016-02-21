using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ponera.Base.BusinessLayer.Extensions;
using Ponera.Base.DataAccess;
using Ponera.Base.Entities;
using Ponera.Base.Models;

namespace Ponera.Base.BusinessLayer
{
    public class MenuBusiness
    {
        private readonly MenuRepository _menuRepository;
        private readonly MenuAuhorizationRepository _menuAuhorizationRepository;

        public MenuBusiness()
        {
            _menuRepository = new MenuRepository();
            _menuAuhorizationRepository = new MenuAuhorizationRepository();

            Mapper.CreateMap<MenuModel, Menu>();
            Mapper.CreateMap<Menu, MenuModel>();
            Mapper.CreateMap<MenuAuthorizationModel, MenuAuthorization>();
            Mapper.CreateMap<MenuAuthorization, MenuAuthorizationModel>();
        }

        public IList<MenuModel> GetMenuModels()
        {
            IList<Menu> menus = _menuRepository.GetAll(false);
            //IEnumerable<Menu> mainMenus = menus.Where(menu => !menu.ParentId.HasValue);

            IList<MenuModel> menuModels = new List<MenuModel>();

            foreach (Menu mainMenu in menus)
            {
                var menuModel = mainMenu.Map<MenuModel>();
                menuModels.Add(menuModel);
                menuModel.MenuAuthorizationModels = GetMenuAuthorizationModels(mainMenu.Id);

                // FillMenus(menuModel, mainMenu, menus);
            }

            return menuModels.OrderBy(model => model.Code).ToList();
        }

        public IList<MenuAuthorizationModel> GetMenuAuthorizationModels(int menuId)
        {
            IList<MenuAuthorization> menuAuthorizationsByMenuId = _menuAuhorizationRepository.GetMenuAuthorizationsByMenuId(menuId);

            var menuAuthorizationModels = menuAuthorizationsByMenuId.Select(authorization => authorization.Map<MenuAuthorizationModel>()).ToList();

            return menuAuthorizationModels;
        }
    }
}
