using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System;

namespace Logic
{
    public class SendCode
    {

        public bool SendMail(string email)
        {
            Boolean result = false;
            String body = @"<style>
                            h1{color:dodgerblue;}
                            </style>
                            <h1>Your code is: HTY025RG#789/4DX</h1>";


            MailMessage newEmail = new MailMessage();
            newEmail.From = new MailAddress("nothanks364@outlook.com", "No Thanks Game");
            newEmail.To.Add(email);
            newEmail.Subject = "Email verification";
            newEmail.IsBodyHtml = true;
            newEmail.Body = body;

            var smtp = new SmtpClient();
            try
            {
                smtp.Send(newEmail);
                result = true;
            }
            catch (SmtpException exception)
            {
                Console.WriteLine(exception.StackTrace);
            }

            return result;
        }
            //"nothanksteam5@gmail.com", "Holamundo3"
            //"smtp.gmail.com", 587
            /*try
            {
                SmtpMail mail = new SmtpMail("TryIt");
                mail.From = "nothanksteam5@gmail.com";
                mail.To = email;
                mail.Subject = "E-mail Confirmation";
                mail.TextBody = body;

                SmtpServer smtpServer = new SmtpServer("aspmx.l.google.com");
                smtpServer.User = "nothanksteam5@gmail.com";
                smtpServer.Password = "Holamundo3";
                smtpServer.Port = 25;
                smtpServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient smtpClient= new SmtpClient();
                smtpClient.SendMail(smtpServer, mail);

                result = true;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
            return result;*/
    }
}
