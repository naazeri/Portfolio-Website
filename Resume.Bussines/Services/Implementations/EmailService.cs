﻿using Microsoft.Extensions.Configuration;
using Resume.Bussines.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Resume.Bussines.Services.Implementations;

public class EmailService(IConfiguration configuration) : IEmailService
{

  public bool SendEmail(string to, string subject, string body)
  {

    var fromEmail = configuration["Settings:EmailSmtp:Sender"];
    string password = configuration["Settings:EmailSmtp:Password"];


    try
    {
      var mail = new MailMessage();

      var smtpServer = new SmtpClient(configuration["Settings:EmailSmtp:Host"]);

      mail.From = new MailAddress(fromEmail, "علی رضایی");

      mail.To.Add(to);

      mail.Subject = subject;

      mail.Body = body;

      mail.IsBodyHtml = true;

      smtpServer.Port = Convert.ToInt32(configuration["Settings:EmailSmtp:Port"]); ;

      smtpServer.Credentials = new NetworkCredential(fromEmail, password);

      smtpServer.EnableSsl = Convert.ToBoolean(configuration["Settings:EmailSmtp:EnableSSL"]);

      smtpServer.Send(mail);
      return true;

    }
    catch (Exception e)
    {
      return false;
    }
  }

}