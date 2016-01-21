using System;
using System.Web;
using Ponera.Base.BusinessLayer;
using Ponera.Base.Models;
using PoneraAdmin.Models;

namespace Security
{
    public static class AuthenticationManager
    {
        private static readonly SecurityService SecurityService = new SecurityService();

        public static UserModel User
        {
            get
            {
                object objUser = HttpContext.Current.Session["CurrentUser"];

                return objUser as UserModel;
            }

            set { HttpContext.Current.Session["CurrentUser"] = value; }
        }

        public static bool Login(LoginViewModel loginViewModel)
        {
            string email = loginViewModel.Email;
            string password = loginViewModel.Password;

            UserModel userModel = SecurityService.GetUserByEmailAddress(email);

            if (userModel == null)
            {
                return false;
            }

            if (userModel.Password != password)
            {
                return false;
            }

            userModel.LastLoginDate = DateTime.Now;

            SecurityService.UpdateUser(userModel);

            User = userModel;

            return true;
        }

        public static void Logout()
        {
            User = null;
        }
    }
}
