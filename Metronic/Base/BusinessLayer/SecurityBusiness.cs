﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ponera.Base.BusinessLayer.Attributes;
using Ponera.Base.BusinessLayer.Extensions;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Contracts.DataAccess;
using Ponera.Base.Entities;
using Ponera.Base.Models;
using Ponera.Base.Models.Validators.Attributes;

namespace Ponera.Base.BusinessLayer
{
    public class SecurityBusiness : ISecurityBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPageAuhorizationRepository _pageAuhorizationRepository;

        public SecurityBusiness(IUserRepository userRepository, 
            IRoleRepository roleRepository, 
            IPageAuhorizationRepository pageAuhorizationRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _pageAuhorizationRepository = pageAuhorizationRepository;

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

        public void DeleteUserById(int id)
        {
            if (id == 0)
            {
                // TODO: exception fırlat
            }

            User user = _userRepository.GetById(id);

            user.Deleted = true;

            UpdateUser(user);
        }

        public IList<UserModel> GetAllUsers()
        {
            IList<User> users = _userRepository.GetAll(false);
            IEnumerable<UserModel> userModels = users.Select(user => Mapper.Map<User, UserModel>(user));

            if (userModels == null)
            {
                return null;
            }

            return userModels.ToList();
        }

        public void UpdateUser(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentNullException(nameof(userModel));
            }

            User user = _userRepository.GetById(userModel.Id);

            if (user == null)
            {
                // TODO : throw exception
            }

            // TODO : @deniz aynı email den birden fazla olamaz.

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            user.LastLoginDate = userModel.LastLoginDate;

            UpdateUser(user);

            userModel.Id = user.Id;
        }

        [ValidateModel]
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

            userModel.Id = user.Id;
        }

        public UserModel GetUserById(int id)
        {
            if (id == 0)
            {
                // TODO : exception fırlat
            }

            User user = _userRepository.GetById(id);
            UserModel userModel = user.Map<UserModel>();

            return userModel;
        }

        public bool IsUserExists(string emailAdress)
        {
            if (emailAdress == null)
            {
                throw new ArgumentNullException(nameof(emailAdress));
            }

            User userByEmailAddress = _userRepository.GetUserByEmailAddress(emailAdress);

            return userByEmailAddress != null;
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

            // TODO : @deniz admin role silinemez, update edilemez

            if (role == null)
            {
                // TODO : @deniz birşey yapmalı?
            }

            role.Deleted = true;

            UpdateRole(role);
        }

        [UnitOfWork]
        public void DummyMethod()
        {
            User user = new User()
            {
                CreateDate = DateTime.Now,
                CreateUserId = 0,
                Deleted = false,
                Email = "sadasd",
                FirstName = "Test",
                LastName = "Test",
                LastLoginDate = DateTime.Now,
                Password = "test",
            };

            _userRepository.Add(user);

            Role role = new Role()
            {
                CreateDate = DateTime.Now,
                CreateUserId = 0,
                Deleted = false,
                RoleName = "TestName"
            };

            _roleRepository.Add(role);

            // throw new Exception();
        }

        public IList<PageAuthorizationModel> GetMenuAuthorizationModelsByUrl(string url)
        {
            IList<PageAuthorization> menuAuthorizationsByMenuId = _pageAuhorizationRepository.GetPageAuthorizationsByUrl(url);

            var menuAuthorizationModels = menuAuthorizationsByMenuId.Select(authorization => authorization.Map<PageAuthorizationModel>()).ToList();

            return menuAuthorizationModels;
        }

        private void UpdateRole(Role role)
        {
            role.UpdateDate = DateTime.Now;
            role.UpdateUserId = 0;

            // TODO : @deniz admin role silinemez, update edilemez

            _roleRepository.Update(role);
        }

        private void UpdateUser(User user)
        {
            user.UpdateDate = DateTime.Now;
            user.UpdateUserId = 0;

            _userRepository.Update(user);
        }
    }
}
