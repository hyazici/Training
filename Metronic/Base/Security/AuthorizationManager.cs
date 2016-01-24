using System.Collections.Generic;
using System.Linq;
using Ponera.Base.Models;

namespace Ponera.Base.Security
{
    public static class AuthorizationManager
    {
        public static bool IsUserAuthorized(string[] roles)
        {
            if (roles == null || roles.Length == 0)
            {
                return false;
            }

            UserModel userModel = AuthenticationManager.User;

            if (userModel == null)
            {
                return false;
            }

            IList<RoleModel> roleModels = userModel.Roles;

            bool authorizedUser = roleModels.Select(model => model.RoleName).Any(roles.Contains);

            return authorizedUser;
        }
    }
}
