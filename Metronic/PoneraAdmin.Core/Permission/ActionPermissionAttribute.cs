using System;

namespace Ponera.PoneraAdmin.Core.Permission
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ActionPermissionAttribute : Attribute
    {
        private readonly string _actionPermission;

        public ActionPermissionAttribute(ActionPermissions actionPermissions)
            : this(actionPermissions.ToString())
        {
            
        }

        public ActionPermissionAttribute(string actionPermission)
        {
            _actionPermission = actionPermission;
        }

        public string Permission => _actionPermission;
    }
}
