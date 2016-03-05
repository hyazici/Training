using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ponera.Base.BusinessLayer.Extensions;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Contracts.DataAccess;
using Ponera.Base.Entities;
using Ponera.Base.Models;

namespace Ponera.Base.BusinessLayer
{
    public class MenuBusiness : IMenuBusiness
    {
        private readonly IMenuRepository _menuRepository;

        public MenuBusiness(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;

            Mapper.CreateMap<MenuModel, Menu>();
            Mapper.CreateMap<Menu, MenuModel>();
        }

        public IList<MenuModel> GetMenuModels()
        {
            IList<Menu> menus = _menuRepository.GetAll(false);

            IList<MenuModel> menuModels = new List<MenuModel>();

            foreach (Menu mainMenu in menus)
            {
                var menuModel = mainMenu.Map<MenuModel>();
                menuModels.Add(menuModel);
            }

            return menuModels.OrderBy(model => model.Code).ToList();
        }
    }
}
