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
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public partial class PlayerManager : IPlayerManager
    {

        private List<Logic.Room> globalRooms = new List<Room>();

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
            return false;
        }

        public bool SendNewEmail(string toEmail, string affair, int validationCode)
        {
            var client = new SendEmail();
            var status = client.SendNewEmail(toEmail, affair, validationCode);
            return status;
        }

        public bool UpdatePassword(string password,string email)
        {
            var status = false;
            try
            {
                var client = new Authentication();
                status = client.UpdatePlayerPassword(password, email);
            }
            catch (EntityException entityException)
            {
                //TODO
                Console.WriteLine(entityException.Message);
            }
            return status;
        }
    }

    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class PlayerManager : IChatService
    {
        //private List<Player> players = new List<Player>();

        public void CreateRoom(Logic.Room room)
        {
            globalRooms.Add(room);
        }

        public string GenerateRoomCode()
        {
            var roomCode = new Guid(1, 2, 3, new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }).ToString();
            return roomCode;
        }

        public void Connect(string username, string idRoom)
        {
            Player player = new Player()
            {
                Nickname = username,
                AOperationContext = OperationContext.Current
            };
            try
            {
                if (globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).Players.Count() > 0)
                {
                    SendMessage($": {player.Nickname} se ha conectado!", player.Nickname, idRoom);
                }
                globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).Players.Add(player);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e);
            }
            

            
            //players.Add(player);
        }

        public void Disconnect(string username, string idRoom)
        {
            Logic.Player player = null;
            try
            {
                player = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom))
                .Players.FirstOrDefault(i => i.Nickname.Equals(username));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
            //var player = players.FirstOrDefault(i => i.Nickname.Equals(username));
            if (player != null)
            {
                var room = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom));
                room.Players.Remove(player);
                if(room.Players.Count() == 0)
                {
                    globalRooms.Remove(room);
                }
                else
                {
                    SendMessage($": {player.Nickname} se ha desconectado!", player.Nickname, idRoom);
                }
                //players.Remove(player);
            }
        }

        public void SendMessage(string message, string username, string idRoom)
        {
            foreach (var player in globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).Players)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var anotherPlayer = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).Players.FirstOrDefault(i => i.Nickname.Equals(username));
                if (anotherPlayer != null)
                {
                    answer += $": {anotherPlayer.Nickname} ";
                }
                answer += message;
                player.AOperationContext.GetCallbackChannel<IChatServiceCallback>().MessageCallBack(answer);
            }
            /*
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
            }*/
        }

        public void SendWhisper(string sender, string receiver, string message, string idRoom)
        {
            globalRooms.ForEach(e => e.Players.ForEach(p => Console.WriteLine($"{p.Nickname}")));
            var player = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom))
                .Players.FirstOrDefault(i => i.Nickname.Equals(receiver));
            //var player = players.Find(i => i.Nickname.Equals(receiver));
            player.AOperationContext.GetCallbackChannel<IChatServiceCallback>().WhisperCallBack(sender, message);
        }
    }
}
