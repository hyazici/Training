using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

using Ponera.Base.BusinessLayer.Proxy;
using Ponera.Base.DataAccess;
using Ponera.Base.DataAccess.Contracts;
using Ponera.Base.Entities;
using Ponera.Base.Notification.Contracts;

namespace Ponera.Base.Notification
{
    public class MailService : IMailService
    {
        private readonly string _emailHost;
        private readonly int _emailPort;
        private readonly string _emailUserName;
        private readonly string _emailPassword;
        private readonly bool _emailEnableSsl;

        private readonly IEmailLogRepository _emailLogRepository;

        public MailService()
        {
            _emailHost = ConfigurationManager.AppSettings["EmailHost"];
            string emailPortValue = ConfigurationManager.AppSettings["EmailPort"];

            _emailPort = int.Parse(emailPortValue);

            _emailUserName = ConfigurationManager.AppSettings["EmailUserName"];
            _emailPassword = ConfigurationManager.AppSettings["EmailPassword"];

            string enableSslValue = ConfigurationManager.AppSettings["EmailEnableSsl"];

            _emailEnableSsl = bool.Parse(enableSslValue);

            // TODO : @deniz buradaki business layer referance'ı kaldıralacak
            _emailLogRepository = PoneraProxyGenerator.GenerateRepositoryProxy<IEmailLogRepository, EmailLogRepository>();
        }

        public void SendEmail(MailMessage mailMessage)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(_emailHost, _emailPort))
                {
                    smtpClient.EnableSsl = _emailEnableSsl;

                    smtpClient.Credentials = new NetworkCredential(_emailUserName, _emailPassword);

                    smtpClient.Send(mailMessage);

                    LogEmail(mailMessage);
                }
            }
            catch (Exception ex)
            {
                LogEmail(mailMessage, ex);
            }
        }

        public void SendBulkEmail(IList<MailMessage> mailMessages)
        {
            foreach (MailMessage mailMessage in mailMessages)
            {
                SendEmail(mailMessage);
            }
        }

        private void LogEmail(MailMessage mailMessage, Exception ex = null)
        {
            string result = ex == null ? "Success" : "Failed";
            string errorMessage = ex?.Message;

            List<MailAddress> toList = mailMessage.To.ToList();
            List<MailAddress> ccList = mailMessage.CC.ToList();
            List<MailAddress> bccList = mailMessage.Bcc.ToList();

            toList.AddRange(ccList);
            toList.AddRange(bccList);

            foreach (MailAddress mailAddress in toList)
            {
                EmailLog emailLog = new EmailLog()
                {
                    CreateDate = DateTime.Now,
                    Result = result,
                    FromEmail = mailMessage.From.Address,
                    Subject = mailMessage.Subject,
                    ToEmail = mailAddress.Address,
                    ErrorMessage = errorMessage
                }; 

                _emailLogRepository.Add(emailLog);
            }
        }
    }
}
