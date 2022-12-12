using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class RegisterTest
    {
        [TestMethod]
        public void TestRegisterUserSuccess()
        {
            
        }

        [TestMethod]
        public void TestRegisterUserFailure()
        {
            
        }
        
        [TestMethod]
        public void TestNewRecordSuccess()
        {
            Register register = new Register();
            Logic.Player player = new Logic.Player
            {
                Name = "Nobu",
                LastName = "Pereyra",
                Nickname = "Nobushi",
                Email = "nobushi@outlook.com",
                Password = "bdd117f45b413e54e0e3b0e14aa3352e298c29b9ed6b4b25b41b3374bd45578453695190eb628d8330f6732534f16764465a857d6d50697c27a7d2a3c7de04bc",
                ProfileImage = "acosador",
                TotalScore = 0
            };
            register.NewRecord(player);

            Assert.IsTrue(true, "Registro exitoso");
        }

        [TestMethod]
        public void TestNewRecordFailure()
        {
            Register register = new Register();
            Logic.Player player = new Logic.Player
            {
                Name = "Nobu",
                LastName = "Pereyra",
                Nickname = "Nobushi",
                Email = "nobushi@outlook.com",
                Password = "bdd117f45b413e54e0e3b0e14aa3352e298c29b9ed6b4b25b41b3374bd45578453695190eb628d8330f6732534f16764465a857d6d50697c27a7d2a3c7de04bc",
                ProfileImage = "acosador",
                TotalScore = 0
            };
            register.NewRecord(player);

            Assert.IsFalse(false, "Registro fallido");
        }

        [TestMethod]
        public void TestExistsEmailOrNicknameSuccess()
        {
            
        }

        [TestMethod]
        public void TestExistsEmailOrNicknameFailure()
        {

        }
    }
}
