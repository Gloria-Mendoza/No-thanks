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

        public bool SendMail(string email, int code)
        {
            Boolean result = false;
            /*String body = @"<style>
                            h1{color:dodgerblue;}
                            </style>
                            <h1>Your code is: {code}</h1>";*/

            try
            {
                MailMessage newEmail = new MailMessage();
                newEmail.From = new MailAddress("nothanks364@outlook.com", "Holamundo3");
                newEmail.To.Add(email);
                newEmail.Subject = "Email verification";
                newEmail.SubjectEncoding = System.Text.Encoding.UTF8;
                newEmail.Body = "Your code is:" + code;
                newEmail.BodyEncoding = System.Text.Encoding.UTF8;
                newEmail.IsBodyHtml = true;
                newEmail.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("nothanks364@outlook.com", "Holamundo3");
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(newEmail);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.StackTrace);
                }

                result = true;
            }
            catch (SmtpException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return result;
        }
    }
}
