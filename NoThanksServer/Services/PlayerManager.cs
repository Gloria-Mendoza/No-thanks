using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using static Logic.Player;
using Logic;

namespace Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
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
                Console.WriteLine(entityException.StackTrace);
            };
            return player;
        }

        public bool SendValidationEmail(string toEmail, string affair, int validationCode)
        {
            var client = new EmailSender();
            var status = client.SendValidationEmail(toEmail, affair, validationCode);
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

        public bool ExitsEmail(string text) // ==> EST� MAL ESCRITO!!! :V
        {
            var status = false;
            Validation validation = new Validation();
            return status = validation.ExistEmail(text);
        }

        public bool ExitsNickname(string text) // ==> EST� MAL ESCRITO!!! :V
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

    }

    public partial class PlayerManager : IChatService
    {
        private List<Logic.Room> globalRooms = new List<Room>();

        public string GenerateRoomCode()
        {
            Guid roomId = Guid.NewGuid();
            return roomId.ToString();
        }

        public bool NewRoom(string hostUsername, string idRoom)
        {
            var newRoom = new Logic.Room()
            {
                Id = idRoom,
                HostUsername = hostUsername,
                MatchStatus = RoomStatus.Waitting,
                ActualPlayersCount = 0,
                Players = new List<Player>(),
                Round = 0,
                Scores = new List<int>(),
                Winner = ""
            };
            globalRooms.Add(newRoom);
            return true;
        }

        public Room GetRoom(String roomId)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id == roomId);
            return room;
        }

        public List<Logic.Player> RecoverRoomPlayers(string idRoom)
        {
            var roomPlayersList = globalRooms.Find(r => r.Id.Equals(idRoom)).Players;
            return roomPlayersList;
        }

        public void StartGame(string idRoom)
        {
            var room = globalRooms.Find(r => r.Id.Equals(idRoom));
            if (room != null)
            {
                globalRooms.Find(r => r.Id.Equals(idRoom)).Round++;
                globalRooms.Find(r => r.Id.Equals(idRoom)).MatchStatus = RoomStatus.Started;
                Player[] players = room.Players.ToArray();
                foreach (var player in room.Players)
                {
                    if (!player.Nickname.Equals(room.HostUsername))
                    {
                        player.AOperationContext.GetCallbackChannel<IChatServiceCallback>().StartGameRoom(RoomStatus.Started, players);
                    }
                }
            }
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
                if (room.MatchStatus == RoomStatus.Started)
                {
                    status = false;
                }
            }
            return status;
        }

        public void Connect(string username, string idRoom, string message)
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
                    SendMessage($": {player.Nickname} {message}!", player.Nickname, idRoom);
                }
                globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).Players.Add(player);
                globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom)).ActualPlayersCount++;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Disconnect(string username, string idRoom, string message)
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
                    SendMessage($": {player.Nickname} {message}!", player.Nickname, idRoom);
                }
            }
        }

        public void ExpelPlayer(string username, string idRoom, string message)
        {
            var room = globalRooms.Find(r => r.Id.Equals(idRoom));
            if (room != null)
            {
                Player[] players = room.Players.ToArray();
                foreach (var player in room.Players)
                {
                    if (!player.Nickname.Equals(room.HostUsername))
                    {
                        player.AOperationContext.GetCallbackChannel<IChatServiceCallback>().PlayerExpeled(username, message);
                    }
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
            var player = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom))
                .Players.FirstOrDefault(i => i.Nickname.Equals(receiver));
            player.AOperationContext.GetCallbackChannel<IChatServiceCallback>().WhisperCallBack(sender, message);
        }

    }

    public partial class PlayerManager : IDeckOfCards
    {
        List<CardType> deck;
        public void CreateDeck(String roomId)
        {
            if (deck == null)
            {
                var deck = new List<CardType>();
                for (int i = 3; i < Enum.GetValues(typeof(CardType)).Length; i++)
                {
                    deck.Add((CardType)i);
                }
                this.deck = deck;
                ShuffleDeck();
                DiscardFirstNine();
            }
            //Esto le manda y actualiza el mazo a todos los jugadores de la sala
            var room = GetRoom(roomId);
            if (room != null)
            {
                room.Players[0].Cards = new List<CardType>();
                foreach (var player in room.Players)
                {
                    // player.AOperationContext.GetCallbackChannel<IDeckOfCardsCallBack>().UpdateDeck(deck.ToArray());
                }
                OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>().UpdateDeck(deck.ToArray());
            }
        }

        public void DiscardFirstNine()
        {
            deck.RemoveRange(0, 9);
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
        }

        public void TakeCard(String roomId)
        {
            var card = deck[0];
            deck.RemoveAt(0);
            var room = GetRoom(roomId);
            if (room != null)
            {
                OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>().UpdatePlayerDeck(room.Players[0].Cards.ToArray()); //<- dará primer jugador
                OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>().UpdateDeck(deck.ToArray());
                foreach (var player in room.Players)
                {
                    //var callback = player.AOperationContext.GetCallbackChannel<IDeckOfCardsCallBack>();
                    if (player.AOperationContext == OperationContext.Current) //Si el contexto = contextoJugador que pidió la carta entonces le manda la carta
                    {
                        player.Cards.Add(card); //Agrega la carta al jugador
                                                // callback.UpdatePlayerDeck(player.Cards.ToArray()); //Actualiza el mazo del jugador
                    }
                    // callback.UpdateDeck(deck.ToArray()); //Actualiza el mazo de todos los jugadores

                }
            }
        }
    }
    public partial class PlayerManager : IUpdateProfile
    {
        public List<String> GetGlobalPlayers()
        {
            List<String> result = new List<String>();
            ListPlayers list = new ListPlayers();
            result = list.ListAllPlayer();
            return result;
        }

        public List<String> GetGlobalFriends(int idPlayer)
        {
            List<String> result = new List<String>();
            ListFriends list = new ListFriends();
            result = list.ListAllFriend(idPlayer);
            return result;
        }

        public List<String> GetGlobalRequest()
        {
            List<String> result = new List<String>();
            ListFriends list = new ListFriends();
            //result = list.ListAllFriend();
            return result;
        }

        public bool SaveImage(String imageManager, int idProfile)
        {
            var status = false;
            try
            {


                return true;
                
            }
            catch (ExternalException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void GetImage(int idProfile)
        {
            try
            {
                if (File.Exists($"imageProfile\\{idProfile}.jpg"))
                {
                    byte[] image = File.ReadAllBytes($"imageProfile\\{idProfile}.jpg");
                    var callbackchannel = OperationContext.Current.GetCallbackChannel<IUdateProfileCallBack>();
                    callbackchannel.ImageCallBack(image);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool UpdateNewNickname(string nickname, string newnickname)
        {
            var status = false;
            try
            {
                var client = new Authentication();
                status = client.UpdateNewNickname(nickname, newnickname);
            }
            catch (EntityException entityException)
            {
                //TODO
                Console.WriteLine(entityException.Message);
            }
            return status;
        }

    }


}
