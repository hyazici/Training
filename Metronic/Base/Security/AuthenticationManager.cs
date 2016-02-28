using System;
using System.Net.Mail;
using System.Web;
using Ponera.Base.BusinessLayer;
using Ponera.Base.BusinessLayer.Contracts;
using Ponera.Base.BusinessLayer.Proxy;
using Ponera.Base.Models;
using Ponera.Base.Notification;
using Ponera.Base.Notification.Contracts;
using Ponera.Base.ViewModel;

namespace Ponera.Base.Security
{
    public static class AuthenticationManager
    {
        private static readonly ISecurityBusiness SecurityBusiness = PoneraProxyGenerator.GenerateBusinessProxy<ISecurityBusiness, SecurityBusiness>();
        private static readonly IMailService MailService = new MailService();

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

            MailService.SendEmail(new MailMessage()
            {
                From = new MailAddress("poneraintranet@gmail.com", "Ponera Admin"),
                Subject = "Hoş Geldiniz",
                Body = "Ponera Admin paneline başarıyla kaydoldunuz, tebrik ederiz.",
                IsBodyHtml = false,
                CC = { new MailAddress("huseyin.yazici@ponera.com.tr")},
                To = { new MailAddress(userModel.Email) }
            });
        }

        public static void Logout()
        {
            User = null;
        }
    }
}
