using System;

namespace Ponera.PoneraAdmin.Core.Permission
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ActionPermissionAttribute : Attribute
    {
        private readonly ActionPermissions _actionPermission;

        public ActionPermissionAttribute(ActionPermissions actionPermission)
        {
            _actionPermission = actionPermission;
        }

        public ActionPermissions Permission => _actionPermission;
    }
}
