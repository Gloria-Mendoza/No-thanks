using System;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Logic
{
    public class SendEmail
    {
        public const string FROM_EMAIL = "nothanks364@outlook.com";
        public const string DISPLAY_NAME = "No Thanks: The Game!";
        public const string BODY = "Your validation code is: ";

        public bool SendNewEmail(String toEmail, String affair, int validationCode)
        {
            bool result = true;
            try
            {
                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress(FROM_EMAIL, DISPLAY_NAME),
                    Subject = affair,
                    Body = $"{BODY} {validationCode}",
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                SmtpClient client = new SmtpClient("smtp.office365.com", 587)
                {
                    Credentials = new NetworkCredential(FROM_EMAIL, "Holamundo3"),
                    EnableSsl = true
                };
                client.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                _ = ex.Message;
                result = false;
            }
            return result;
        }

    }
}
