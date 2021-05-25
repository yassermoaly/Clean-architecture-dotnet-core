using DataAccessLayer.Interfaces;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SharedConfig.Config;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Services
{
    public class MailService : IMailService
    {
        private readonly AppConfig _config;
        public MailService(AppConfig config)
        {
            _config = config;
        }

        public async Task<bool> SendClassicEmail(List<string> to, string subject, string message, List<string> cc = null, List<string> bcc = default)
        {
            var mailMessage = new MimeMessage
            {
                Subject = subject,
            };

            foreach (string toMail in to)
                mailMessage.To.Add(MailboxAddress.Parse(toMail));

            if (cc != null)
            {
                foreach (string ccMail in cc)
                    mailMessage.Cc.Add(MailboxAddress.Parse(ccMail));
            }

            if (bcc != null)
            {
                foreach (string bccMail in bcc)
                    mailMessage.Bcc.Add(MailboxAddress.Parse(bccMail));
            }

            BodyBuilder MailBodyBuilder = new() { TextBody = message };
            mailMessage.Body = MailBodyBuilder.ToMessageBody();


            // SMTP Setup
            try
            {
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(_config.Smtp.Host, _config.Smtp.Port, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_config.Smtp.Username, _config.Smtp.Password);
                    await client.SendAsync(mailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }
    }
}
