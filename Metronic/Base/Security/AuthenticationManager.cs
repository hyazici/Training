using System;
using System.Web;
using Ponera.Base.BusinessLayer;
using Ponera.Base.Models;
using PoneraAdmin.Models;

namespace Ponera.Base.Security
{
    public static class AuthenticationManager
    {
        private static readonly SecurityBusiness SecurityBusiness = new SecurityBusiness();

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

            UserModel userModel = SecurityBusiness.GetUserByEmailAddress(email);

            if (userModel == null)
            {
                return false;
            }

            if (userModel.Password != password)
            {
                return false;
            }

            userModel.LastLoginDate = DateTime.Now;

            SecurityBusiness.UpdateUser(userModel);

            User = userModel;

            return true;
        }

        public static void RegisterUser(RegisterViewModel model)
        {
            UserModel userModel = new UserModel();
            userModel.FirstName = model.FirstName;
            userModel.LastName = model.LastName;
            userModel.Email = model.Email;
            userModel.Password = model.Password; // TODO : @deniz password encode edilecek.

            SecurityBusiness.AddUser(userModel);
        }

        public static void Logout()
        {
            User = null;
        }
    }
}
