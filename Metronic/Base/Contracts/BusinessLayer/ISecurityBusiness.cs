using System.Collections.Generic;
using Ponera.Base.Models;

namespace Ponera.Base.Contracts.BusinessLayer
{
    public interface ISecurityBusiness
    {
        void AddUser(UserModel userModel);

        UserModel GetUserById(int id);

        void DeleteUserById(int id);

        IList<UserModel> GetAllUsers();

        void AddRole(RoleModel roleModel);

        void DeleteRoleById(int id);

        IList<PageAuthorizationModel> GetMenuAuthorizationModelsByUrl(string url);

        RoleModel GetRoleById(int id);

        IList<RoleModel> GetRoles();

        UserModel GetUserByEmailAddress(string email);

        void UpdateRole(RoleModel roleModel);

        void UpdateUser(UserModel userModel);

        void DummyMethod();
    }
}