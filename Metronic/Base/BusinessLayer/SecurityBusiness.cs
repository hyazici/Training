﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ponera.Base.BusinessLayer.Contracts;
using Ponera.Base.BusinessLayer.Extensions;
using Ponera.Base.BusinessLayer.Proxy;
using Ponera.Base.DataAccess;
using Ponera.Base.DataAccess.Contracts;
using Ponera.Base.Entities;
using Ponera.Base.Models;

namespace Ponera.Base.BusinessLayer
{
    public class SecurityBusiness : ISecurityBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPageAuhorizationRepository _pageAuhorizationRepository;

        public SecurityBusiness()
        {
            _userRepository = PoneraProxyGenerator.GenerateRepositoryProxy<IUserRepository, UserRepository>();
            _roleRepository = PoneraProxyGenerator.GenerateRepositoryProxy<IRoleRepository, RoleRepository>();
            _pageAuhorizationRepository = PoneraProxyGenerator.GenerateRepositoryProxy<IPageAuhorizationRepository, PageAuhorizationRepository>();

            // TODO : @deniz Buradaki mapping işlemleri bunu yönetecek ayrı bir class'a taşınacak.
            Mapper.CreateMap<User, UserModel>();
            Mapper.CreateMap<UserModel, User>();
            Mapper.CreateMap<Role, RoleModel>();
            Mapper.CreateMap<RoleModel, Role>();
            Mapper.CreateMap<PageAuthorizationModel, PageAuthorization>();
            Mapper.CreateMap<PageAuthorization, PageAuthorizationModel>();
        }


        public UserModel GetUserByEmailAddress(string email)
        {
            // TODO : @deniz email adress null mı boş mu kontrolü

            User user = _userRepository.GetUserByEmailAddress(email, false);
            UserModel userModel = Mapper.Map<User, UserModel>(user);

            if (userModel == null)
            {
                return null;
            }

            IList<Role> roles = _roleRepository.GetRolesByUserId(userModel.Id);
            IEnumerable<RoleModel> roleModels = roles.Select(role => Mapper.Map<Role, RoleModel>(role));

            userModel.Roles = roleModels.ToList();

            return userModel;
        }

        public void UpdateUser(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentNullException(nameof(userModel));
            }

            User user = Mapper.Map<UserModel, User>(userModel);

            user.UpdateDate = DateTime.Now;
            user.UpdateUserId = 0;

            _userRepository.Update(user);
        }

        public void AddUser(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentNullException(nameof(userModel));
            }

            // TODO : @deniz çeşitli validasyonlar

            User user = Mapper.Map<UserModel, User>(userModel);

            // Kullanıcıya hoş geldin emaili atabilir.


            user.CreateDate = DateTime.Now;
            user.LastLoginDate = user.CreateDate;
            user.CreateUserId = 0;

            _userRepository.Add(user);
        }

        public IList<RoleModel> GetRoles()
        {
            IList<Role> roles = _roleRepository.GetAll(false);

            IList<RoleModel> roleModels = roles.Select(role => Mapper.Map<Role, RoleModel>(role)).ToList();

            return roleModels;
        }

        public RoleModel GetRoleById(int id)
        {
            if (id == 0)
            {
                // TODO : exception fırlat
            }

            Role role = _roleRepository.GetById(id);

            RoleModel roleModel = role.Map<RoleModel>();

            return roleModel;
        }

        public void AddRole(RoleModel roleModel)
        {
            if (roleModel == null)
            {
                throw new ArgumentNullException(nameof(roleModel));
            }

            Role role = Mapper.Map<RoleModel, Role>(roleModel);

            role.CreateDate = DateTime.Now;
            role.CreateUserId = 0;
            role.Deleted = false;

            _roleRepository.Add(role);

            roleModel.Id = role.Id;
        }

        public void UpdateRole(RoleModel roleModel)
        {
            if (roleModel == null)
            {
                throw new ArgumentNullException(nameof(roleModel));
            }

            Role role = _roleRepository.GetById(roleModel.Id);

            if (role == null)
            {
                // TODO : throw exception
            }

            role.RoleName = roleModel.RoleName;
            UpdateRole(role);

            roleModel.Id = role.Id;
        }

        public void DeleteRoleById(int id)
        {
            Role role = _roleRepository.GetById(id);

            if (role == null)
            {
                // TODO : @deniz birşey yapmalı?
            }

            role.Deleted = true;

            UpdateRole(role);
        }

        private void UpdateRole(Role role)
        {
            role.UpdateDate = DateTime.Now;
            role.UpdateUserId = 0;

            _roleRepository.Update(role);
        }

        public IList<PageAuthorizationModel> GetMenuAuthorizationModelsByUrl(string url)
        {
            IList<PageAuthorization> menuAuthorizationsByMenuId = _pageAuhorizationRepository.GetPageAuthorizationsByUrl(url);

            var menuAuthorizationModels = menuAuthorizationsByMenuId.Select(authorization => authorization.Map<PageAuthorizationModel>()).ToList();

            return menuAuthorizationModels;
        }
    }
}
