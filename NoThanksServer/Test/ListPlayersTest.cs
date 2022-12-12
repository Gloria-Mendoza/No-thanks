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
            listPlayers.ListAllPlayer();
            Assert.AreNotEqual(0, listPlayers.ListAllPlayer().Count, "Lista de jugadores NO vacía");
        }

    }
}
