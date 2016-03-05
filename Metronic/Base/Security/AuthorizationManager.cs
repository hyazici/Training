using System.Collections.Generic;
using System.Linq;
using Ponera.Base.Contracts;
using Ponera.Base.Contracts.Security;
using Ponera.Base.Models;

namespace Ponera.Base.Security
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly ISessionManager _sessionManager;

        public AuthorizationManager(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public bool IsUserAuthorized(string[] roles)
        {
            if (roles == null || roles.Length == 0)
            {
                return false;
            }

            UserModel userModel = _sessionManager.User;

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
