using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using System.Net.Mail;
using System.Net;
using MeuRastroCarbonoAPI.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace MeuRastroCarbonoAPI.Services
{
    public class EmailSender : IEmailSender
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public EmailSender(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task SendRenewPasswordEmailAsync(string fromEmail, string toEmail, string smtpDomain, int smtpPort, string name, string code, string fromEmailPassword)
        {
            var webRoot = _env.WebRootPath;

            var pathToFile = Directory.GetCurrentDirectory() + @"\wwwroot\Templates\forgot-password.html";

            var builder = new BodyBuilder();

            using (StreamReader SourceReader = File.OpenText(pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            builder.HtmlBody = builder.HtmlBody.Replace("{0}", name);
            builder.HtmlBody = builder.HtmlBody.Replace("{1}", code);

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(fromEmail, "Meu Rastro de Carbono")
            };
            mail.To.Add(toEmail);
            mail.Subject = "Redefinição de senha";
            mail.IsBodyHtml = true;
            mail.Body = builder.HtmlBody;

            mail.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient(smtpDomain, smtpPort))
            {
                smtp.Credentials = new NetworkCredential(fromEmail, fromEmailPassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
