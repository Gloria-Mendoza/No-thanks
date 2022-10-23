using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using Logic;

namespace Services
{
    public partial class PlayerManager : IPlayerManager
    {
        public bool Login(String nickname, String password)
        {
            var status = false;
            try
            {
                Authentication client = new Authentication();
                status = client.Login(nickname, password);
            }
            catch (EntityException entityException)
            {
                //TODO
                Console.WriteLine(entityException.Message);
            }
            return status;
        }

        public bool Register(Player player)
        {
            return false;
        }
    }

    public partial class PlayerManager : IChatService
    {
        private List<Player> players = new List<Player>();
        private int nextID = 1;

        public void Connect(string username)
        {
            Player player = new Player()
            {
                IdPlayer = nextID,
                Nickname = username
            };
            nextID++;
            SendMessage($": {player.Nickname} se ha conectado!", "");
            players.Add(player);
        }

        public void Disconnect(string username)
        {
            var player = players.FirstOrDefault(i => i.Nickname == username);
            if(player != null)
            {
                players.Remove(player);
                SendMessage($": {player.Nickname} se ha desconectado!", "");
            }
        }

        public void SendMessage(string message, string username)
        {
            foreach(var player in players)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var anotherPlayer = players.FirstOrDefault(i => i.Nickname == player.Nickname);
                if(anotherPlayer != null)
                {
                    answer += $": {player.Nickname} ";
                }
                answer += message;
                OperationContext.Current.GetCallbackChannel<IChatServiceCallback>().MessageCallBack(answer);
            }
        }
    }
}
