using System.Collections.Generic;
using Ponera.Base.Models;

namespace Ponera.Base.Contracts.BusinessLayer
{
    public interface ISecurityBusiness
    {
        void AddRole(RoleModel roleModel);

        void AddUser(UserModel userModel);

        void DeleteRoleById(int id);

        IList<PageAuthorizationModel> GetMenuAuthorizationModelsByUrl(string url);

        IList<UserModel> GetAllUsers();

        RoleModel GetRoleById(int id);

        IList<RoleModel> GetRoles();

        UserModel GetUserByEmailAddress(string email);

        void UpdateRole(RoleModel roleModel);

        void UpdateUser(UserModel userModel);
        void DummyMethod();
    }
}