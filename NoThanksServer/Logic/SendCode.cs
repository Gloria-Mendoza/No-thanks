using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System;
using MailKit;

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

            /*try
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
            return result;*/
            try
            {
                using (MailMessage emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.Subject = "E-mail Confirmation";
                    emailMessage.Body = body;
                    emailMessage.IsBodyHtml = false;
                    emailMessage.Priority = MailPriority.Normal;
                    emailMessage.From = new MailAddress("nothanksteam5@gmail.com", "¡No Thanks!");

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;//25,465
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;          
                        smtp.Credentials = new System.Net.NetworkCredential("nothanksteam5@gmail.com", "Holamundo3");
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        smtp.Send(emailMessage);

                        result = true;
                    }
                    emailMessage.Dispose();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
            return result;
        }
    }
}
