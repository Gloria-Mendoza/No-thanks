using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using Logic;

namespace Test
{

    [TestClass]
    public class EmailSenderTest
    {

        [TestMethod]
        public void TestSendValidationEmailSuccess()
        {
            string toEmail = "nothanks364@outlook.com";
            string affair = "Codigo Validacion";
            int validationCode = 1234;

            EmailSender emailSender = new EmailSender();

            var result = emailSender.SendValidationEmail(toEmail, affair, validationCode);

            Assert.IsTrue(result, $"Email enviado");
        }

        [TestMethod]
        public void TestSendValidationEmailFailure()
        {
            string toEmail = "nothanks364.com";
            string affair = "Codigo Validacion";
            int validationCode = 1234;

            EmailSender emailSender = new EmailSender();

            var result = emailSender.SendValidationEmail(toEmail, affair, validationCode);

            Assert.IsFalse(result, $"Email NO fue enviado, porque el formato de correo es erroneo");
        }
    }
}
