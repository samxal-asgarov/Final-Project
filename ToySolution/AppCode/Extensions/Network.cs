﻿using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace ToySolution.AppCode.Extensions
{
    static public partial class Extension
    {
        static public bool SendEmail(this IConfiguration configuration,
            string to,
            string subject,
            string body,
            bool appendCC = false
            )
        {
            try
            {
                // appsettings melumatlari getirik
                string fromMail = configuration["emailAccount:UserName"];
                string displayName = configuration["emailAccount:displayName"];
                string smtpServer = configuration["emailAccount:smtpServer"];
                int smtpPort = Convert.ToInt32(configuration["emailAccount:smtpPort"]);
                string password = configuration["emailAccount:password"];
                string cc = configuration["emailAccount:cc"];

                // message gonderik from to vasitesi ile;

                using (MailMessage message = new MailMessage(new MailAddress(fromMail, displayName), new MailAddress(to))
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true

                })
                {

                    if (!string.IsNullOrWhiteSpace(cc))
                        message.CC.Add(cc);

                    SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                    smtpClient.Credentials = new NetworkCredential(fromMail, password);// ?
                    smtpClient.EnableSsl = true; // ?
                    smtpClient.Send(message);
                }
            }
            catch (Exception )
            {
                return false;
            }

            return true;
        }
    }
}