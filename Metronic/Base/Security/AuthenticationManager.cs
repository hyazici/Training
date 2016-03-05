using System;
using System.Net.Mail;
using Ponera.Base.Contracts;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Contracts.Security;
using Ponera.Base.Models;
using Ponera.Base.ViewModel;

namespace Ponera.Base.Security
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly ISecurityBusiness _securityBusiness;
        private readonly IMailService _mailService;
        private readonly ISessionManager _sessionManager;

        public AuthenticationManager(ISecurityBusiness securityBusiness, IMailService mailService, ISessionManager sessionManager)
        {
            _securityBusiness = securityBusiness;
            _mailService = mailService;
            _sessionManager = sessionManager;
        }

        public bool Login(LoginViewModel loginViewModel)
        {
            string email = loginViewModel.Email;
            string password = loginViewModel.Password;

            UserModel userModel = _securityBusiness.GetUserByEmailAddress(email);

            if (userModel == null)
            {
                return false;
            }

            if (userModel.Password != password)
            {
                return false;
            }

            userModel.LastLoginDate = DateTime.Now;

            _securityBusiness.UpdateUser(userModel);

            _sessionManager.User = userModel;

            return true;
        }

        public void RegisterUser(RegisterViewModel model)
        {
            UserModel userModel = new UserModel();
            userModel.FirstName = model.FirstName;
            userModel.LastName = model.LastName;
            userModel.Email = model.Email;
            userModel.Password = model.Password; // TODO : @deniz password encode edilecek.

            _securityBusiness.AddUser(userModel);

            _mailService.SendEmail(new MailMessage()
            {
                From = new MailAddress("poneraintranet@gmail.com", "Ponera Admin"),
                Subject = "Hoş Geldiniz",
                Body = "Ponera Admin paneline başarıyla kaydoldunuz, tebrik ederiz.",
                IsBodyHtml = false,
                CC = { new MailAddress("huseyin.yazici@ponera.com.tr") },
                To = { new MailAddress(userModel.Email) }
            });
        }

        public void Logout()
        {
            _sessionManager.User = null;
        }
    }
}
