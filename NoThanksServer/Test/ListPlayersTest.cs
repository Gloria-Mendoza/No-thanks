using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{

    [TestClass]
    public class ListPlayersTest
    {

        [TestMethod]
        public void TestListAllPlayersSuccess()
        {
            ListPlayers listPlayers = new ListPlayers();
            List<String> expectedResult = new List<String>
            {
                "Panther",
                "Nobushi",
                "Nobu",
                "No"
            };

            Assert.AreEqual(expectedResult, listPlayers.ListAllPlayer(), "Lista de jugadores no vacía");
            
            //Assert.AreNotEqual(0, new ListPlayers().ListAllPlayer().Count, "Lista de jugadores no vacía");
            
        }

        [TestMethod]
        public void TestListAllPlayersFailure()
        {
            ListPlayers listPlayers = new ListPlayers();
            List<String> expectedResult = new List<String>
            {
                "Panther",
                "Nobushi",
                "Nobu",
                "No"
            };

            Assert.AreNotEqual(expectedResult, listPlayers.ListAllPlayer(), "Lista de jugadores vacía");
        }
    }
}
