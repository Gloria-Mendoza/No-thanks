using System;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingNoThanks
{
    [TestClass]
    public class AuthenticationTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        } 
        
        [TestMethod]
        public void TestLoginSuccess()
        {
            string nickname = "Panther";
            string password = "3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2";

            Authentication authentication = new Authentication();

            Logic.Player expectedResult = new Logic.Player()
            {
                IdPlayer = 1,
                Nickname = "Panther",
                Email = "nothanks364@outlook.com",
                Name = "",
                LastName = "",
                TotalScore = 30,
                Status = true,
                Password = "",
                Tokens = 0,
                ProfileImage = "nina",
                Cards = null,
                CardsString = null,
                AOperationContext = null
            };
            var result = authentication.Login(nickname, password);

            Assert.AreEqual(expectedResult.ToString(), result.ToString(), $"Jugadores iguales");
        }
        [TestMethod]
        public void TestLoginFailure()
        {
            string nickname = "Panther";
            string password = "";

            Authentication authentication = new Authentication();

            Logic.Player expectedResult = new Logic.Player()
            {
                IdPlayer = 1,
                Nickname = "Panther",
                Email = "nothanks364@outlook.com",
                Name = "",
                LastName = "",
                TotalScore = 30,
                Status = true,
                Password = "",
                Tokens = 0,
                ProfileImage = "nina",
                Cards = null,
                CardsString = null,
                AOperationContext = null
            };
            var result = authentication.Login(nickname, password);

            Assert.AreNotEqual(expectedResult.ToString(), result.ToString(), $"Jugadores NO SON iguales");

        }
        [TestMethod]
        public void TestUpdatePlayerPasswordSuccess()
        {
            string password = "3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2";
            string email = "nothanks364@outlook.com";

            Authentication authentication = new Authentication();

            var result = authentication.UpdatePlayerPassword(password, email);

            Assert.IsTrue(result, $"Contraseña actualizada");
        }
        
        [TestMethod]
        public void TestUpdatePlayerPasswordFailure()
        {
            string password = "3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2";
            string email = "nothanks";

            Authentication authentication = new Authentication();

            var result = authentication.UpdatePlayerPassword(password, email);

            Assert.IsFalse(result, "Contraseña NO Actualizada");
        }
        
        [TestMethod]
        public void TestUpdatePlayerNicknameSuccess()
        {
            string nickname = "Panther";
            string updatedNickname = "Licuadora";

            Authentication authentication = new Authentication();

            var result = authentication.UpdatePlayerNickname(nickname, updatedNickname);

            Assert.IsTrue(result, $"Nickname actualizado");
        }

        [TestMethod]
        public void TestUpdatePlaterNicknameFailure()
        {
            string nickname = "";
            string updatedNickname = "UsuarioInexistente";

            Authentication authentication = new Authentication();

            var result = authentication.UpdatePlayerNickname(nickname, updatedNickname);

            Assert.IsFalse(result, $"Nickname NO actualizado");
        }

    }
}