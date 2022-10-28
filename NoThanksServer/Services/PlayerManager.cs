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
                var client = new Authentication();
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

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class PlayerManager : IChatService
    {
        private List<Player> players = new List<Player>();

        public void Connect(string username)
        {
            Player player = new Player()
            {
                Nickname = username,
                AOperationContext = OperationContext.Current
            };
            SendMessage($": {player.Nickname} se ha conectado!", player.Nickname);
            players.Add(player);
        }

        public void Disconnect(string username)
        {
            var player = players.FirstOrDefault(i => i.Nickname.Equals(username));
            if(player != null)
            {
                players.Remove(player);
                SendMessage($": {player.Nickname} se ha desconectado!", player.Nickname);
            }
        }

        public void SendMessage(string message, string username)
        {
            foreach(var player in players)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var anotherPlayer = players.FirstOrDefault(i => i.Nickname.Equals(username));
                if(anotherPlayer != null)
                {
                    answer += $": {anotherPlayer.Nickname} ";
                }
                answer += message;
                player.AOperationContext.GetCallbackChannel<IChatServiceCallback>().MessageCallBack(answer);
            }
        }

        public void SendWhisper(string sender, string receiver, string message)
        {
            var player = players.Find(i => i.Nickname.Equals(receiver));
            player.AOperationContext.GetCallbackChannel<IChatServiceCallback>().WhisperCallBack(sender, message);
        }
    }
}
