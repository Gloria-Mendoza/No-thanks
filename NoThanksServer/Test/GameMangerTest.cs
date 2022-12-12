using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{

    [TestClass]
    public class GameMangerTest
    {

        [TestMethod]
        public void TestAddFinishedGameSuccess()
        {
            GameManager gameManager = new GameManager();

            List<int> scores = new List<int>();
            List<Player> players = new List<Player>();

            scores.Add(30);
            players.Add(new Player()
            {
                IdPlayer = 1,
                TotalScore = 30,
                Nickname = "Panther"
            });

            players.Add(new Player()
            {
                IdPlayer = 0,
                TotalScore = 30,
                Nickname = "Prueba"
            });

            var finishedRoom = new Room()
            {
                Players = players,
                Scores = scores,
            };

            var result = gameManager.AddFinishedGame(finishedRoom);

            Assert.AreEqual(true, result, "Sala guardada con éxito");
        }

        [TestMethod]
        public void TestAddFinishedGameFailure()
        {
            GameManager gameManager = new GameManager();

            List<int> scores = new List<int>();
            List<Player> players = new List<Player>();

            scores.Add(0);
            players.Add(new Player()
            {
                IdPlayer = 1,
                TotalScore = 30,
                Nickname = ""
            });

            players.Add(new Player()
            {
                IdPlayer = 0,
                TotalScore = 0,
                Nickname = ""
            });

            var finishedRoom = new Room()
            {
                Players = players,
                Scores = scores,
            };

            var result = gameManager.AddFinishedGame(finishedRoom);

            Assert.AreEqual(false, result, "Sala NO guardada");
        }
    }
}
