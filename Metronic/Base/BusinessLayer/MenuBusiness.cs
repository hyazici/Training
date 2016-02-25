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

        public MenuBusiness()
        {
            _menuRepository = new MenuRepository();

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
