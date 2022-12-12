using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    /// <summary>
    /// Descripción resumida de AuthenticationTest
    /// </summary>
    [TestClass]
    public class AuthenticationTest
    {
        public AuthenticationTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
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

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Login()
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

            //Assert.Equals(expectedResult, result);
            Assert.AreEqual(expectedResult.ToString(), result.ToString(), $"Jugadores iguales");
        }

        [TestMethod]
        public void UpdatePlayerPassword()
        {
            string password = "3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2"; //"d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db";
            string email = "nothanks364@outlook.com";

            Authentication authentication = new Authentication();

            var result = authentication.UpdatePlayerPassword(password, email);

            Assert.AreEqual(true, result, "Contraseña Actualizada");
        }
    }
}
