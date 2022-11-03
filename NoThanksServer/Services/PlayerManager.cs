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
        int number = 0;
        public Logic.Player Login(String nickname, String password)
        {
            var player = new Logic.Player()
            {
                Status = false
            };
            try
            {
                var client = new Authentication();
                player = client.Login(nickname, password);
            }
            catch (EntityException entityException)
            {
                //TODO
                Console.WriteLine(entityException.Message);
            }
            return player;
        }

        public bool Register(Player player)
        {
            var status = false;
            try
            {
                Register register = new Register();
                Logic.Player player1 = new Logic.Player()
                {
                    Name = player.Name,
                    LastName = player.LastName,
                    Nickname = player.Nickname,
                    Email = player.Email,
                    Password = player.Password
                };
                status = register.NewRegister(player1);
            }
            catch (EntityException entityException)
            {
                //TODO
                Console.WriteLine(entityException.StackTrace);
            }
            return status;
        }

        public bool SendCode(String emailFrom, int code)
        {
            var status = false;
            try
            {
                SendCode email = new SendCode();
                email.SendMail(emailFrom, code);
            }
            catch (EntityException entityException)
            {
                //TODO
                Console.WriteLine(entityException.StackTrace);
            }
            return status;
        }

        public int GenerateCode()
        {
            Random random = new Random();
            int maximum = 999999;
            int minimum = 100000;

            number = random.Next(minimum, maximum + 1);
            return number;
        }

        public int GetGenerateCode()
        {
            return number;
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
