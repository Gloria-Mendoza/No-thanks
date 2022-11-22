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
        private static List<MatchMember> players = new List<MatchMember>();
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
                Console.WriteLine(entityException.Message);
            }
            MatchMember member = new MatchMember()
            {
                player = player,
            };
            players.Add(member);
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

        public bool ExitsEmail(string text) // ==> ESTÁ MAL ESCRITO!!! :V
        {
            var status = false;
            Validation validation = new Validation();
            return status = validation.ExistEmail(text);
        }

        public bool ExitsNickname(string text) // ==> ESTÁ MAL ESCRITO!!! :V
        {
            var status = false;
            Validation validation = new Validation();
            return status = validation.ExistNickname(text);
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

        public bool SendNewEmail(string toEmail, string affair, int validationCode)
        {
            var client = new SendEmail();
            var status = client.SendNewEmail(toEmail, affair, validationCode);
            return status;
        }

        public bool UpdatePassword(string password, string email)
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

    public partial class PlayerManager : IChatService
    {
        private List<Logic.Room> globalRooms = new List<Room>();

        public string GenerateRoomCode()
        {
            Guid roomId = Guid.NewGuid();
            return roomId.ToString();
        }

        public bool NewRoom(string idRoom)
        {
            var newRoom = new Logic.Room()
            {
                Id = idRoom,
                ActualPlayersCount = 0,
                Players = new List<Player>(),
                Round = 0,
                Scores = new List<int>(),
                Winner = ""
            };
            globalRooms.Add(newRoom);
            return true;
        }

        public bool CheckQuota(string idRoom)
        {
            var status = false;
            var room = globalRooms.Find(r => r.Id.Equals(idRoom));
            if (room != null)
            {
                if (room.HasSpace())
                {
                    status = true;
                }
            }
            return status;
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
                    SendMessage($": {player.Nickname} se ha conectado!", player.Nickname, idRoom);//TODO
                }
                globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).Players.Add(player);
                globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).ActualPlayersCount++;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
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

            if (player != null)
            {
                globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).Players.Remove(player);
                globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).ActualPlayersCount--;
                if (globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).Players.Count() == 0)
                {
                    globalRooms.Remove(globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)));
                }
                else
                {
                    SendMessage($": {player.Nickname} se ha desconectado!", player.Nickname, idRoom);//TODO
                }
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
        }

        public void SendWhisper(string sender, string receiver, string message, string idRoom)
        {
            globalRooms.ForEach(e => e.Players.ForEach(p => Console.WriteLine($"{p.Nickname}")));
            var player = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom))
                .Players.FirstOrDefault(i => i.Nickname.Equals(receiver));
            player.AOperationContext.GetCallbackChannel<IChatServiceCallback>().WhisperCallBack(sender, message);
        }

    }

    public partial class PlayerManager : IDeckOfCards
    {
        List<CardType> deck;
        public void CreateDeck()
        {
            if (deck == null)
            {
                var deck = new List<CardType>();
                for (int i = 0; i < Enum.GetValues(typeof(CardType)).Length; i++)
                {
                    deck.Add((CardType)i);
                }
                this.deck = deck;
            }
            var callback = OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>();
            callback.UpdateDeck(deck.ToArray());
        }

        public void DiscardFirstNine()
        {
            deck.RemoveRange(0, 9);
            var callback = OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>();
            callback.UpdateDeck(deck.ToArray());
        }

        public void ShuffleDeck()
        {
            var random = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                var temp = deck[i];
                var randomIndex = random.Next(0, deck.Count);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }
            var callback = OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>();
            callback.UpdateDeck(deck.ToArray());
        }

        public void TakeCard()
        {
            var card = deck[0];
            deck.RemoveAt(0);
            var callback = OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>();
            callback.TakeCardCallBack(card);
        }
    }
}
