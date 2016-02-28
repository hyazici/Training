﻿using System.Collections.Generic;
using System.Net.Mail;

namespace Ponera.Base.Notification.Contracts
{
    public interface IMailService
    {
        void SendEmail(MailMessage mailMessage);
        void SendBulkEmail(IList<MailMessage> mailMessages);
    }
}