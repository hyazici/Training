using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ponera.Base.DataAccess;
using Ponera.Base.Entities;
using Ponera.Base.Models;

namespace Ponera.Base.BusinessLayer
{
    public class SecurityService
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public SecurityService()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();

            // TODO : @deniz Buradaki mapping işlemleri bunu yönetecek ayrı bir class'a taşınacak.
            Mapper.CreateMap<User, UserModel>();
            Mapper.CreateMap<UserModel, User>();
            Mapper.CreateMap<Role, RoleModel>();
            Mapper.CreateMap<RoleModel, Role>();
        }


        public UserModel GetUserByEmailAddress(string email)
        {
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
    }
}
