using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.ServiceModel;
using Logic;
using log4net;
using Logs;


namespace Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public partial class GameService : IPlayerManager
    {
        private static readonly ILog Log = Logger.GetLogger();

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
                Log.Error($"{entityException.Message}");
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
                Log.Error($"{entityException.Message}");
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
                    Password = player.Password,
                    ProfileImage = player.ProfileImage,
                    TotalScore = player.TotalScore
                };
                status = register.RegisterUser(player1);
            }
            catch (EntityException entityException)
            {
                Log.Error($"{entityException.Message}");
            }
            return status;
        }

        public int GenerateCode()
        {
            Random random = new Random();
            int MAX = 999999;
            int MIN = 100000;

            return random.Next(MIN, MAX + 1); ;
        }

        public bool ExistsEmailOrNickname(string nickname, string email)
        {
            Register register = new Register();
            var status = false;

            try
            {
                status = register.ExistsEmailOrNickname(nickname, email);
            }
            catch (EntityException entityException)
            {
                Log.Error($"{entityException.Message}");
            }
            return status;
        }
    }

    public partial class GameService : IGameService
    {
        private List<Logic.Room> globalRooms = new List<Room>();

        public string GenerateRoomCode()
        {
            Guid roomId = Guid.NewGuid();
            return roomId.ToString();
        }

        public bool NewRoom(string hostUsername, string roomId)
        {
            var newRoom = new Logic.Room()
            {
                Id = roomId,
                HostUsername = hostUsername,
                MatchStatus = RoomStatus.Waitting,
                CurrentPlayersCount = 0,
                Players = new List<Player>(),
                Round = 0,
                Scores = new List<int>(),
                Winner = "",
                RoomTokens = 0
            };
            globalRooms.Add(newRoom);
            return true;
        }

        public Room GetRoom(String roomId)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id == roomId);
            return room;
        }

        public List<Logic.Player> RecoverRoomPlayers(string roomId)
        {
            var roomPlayersList = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId)).Players;
            return roomPlayersList;
        }

        public void StartGame(string roomId, string[] message)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));
            if (room != null)
            {
                Player[] players = room.Players.ToArray();
                if (room.HadMinPlayersToStart())
                {
                    room.MatchStatus = RoomStatus.Started;
                    foreach (var player in room.Players)
                    {
                        player.AOperationContext.GetCallbackChannel<IGameServiceCallback>().StartGameRoom(RoomStatus.Started, players);
                    }
                    SendMessage(message[0], null, roomId);
                }
                else
                {
                    foreach (var player in room.Players)
                    {
                        player.AOperationContext.GetCallbackChannel<IGameServiceCallback>().StartGameRoom(RoomStatus.Waitting, players);
                    }
                    SendMessage(message[1], null, roomId);
                }
            }
        }

        public void FinishGame(string roomId, Player[] players)
        {
            List<int> scores = new List<int>();

            players.ToList().ForEach(p =>
            {
                scores.Add((int)p.TotalScore);
            });

            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));

            room.Players.ForEach(p =>
            {
                p.TotalScore = players.First(ap => ap.Nickname.Equals(p.Nickname)).TotalScore;
            });

            room.Scores = scores;

            try
            {
                GameManager gameManager = new GameManager();
                gameManager.AddFinishedGame(room);
            }
            catch (EntityException entityException)
            {
                Log.Error($"{entityException.Message}");
            }
        }

        public bool CheckQuota(string roomId)
        {
            var status = false;
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));
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

        public void Connect(string username, string roomId, string message)
        {
            Player player = new Player()
            {
                Nickname = username,
                AOperationContext = OperationContext.Current,
                Cards = new List<CardType>(),
                Tokens = 11
            };

            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));
            if (room.Players.Count() > 0)
            {
                SendMessage($": {player.Nickname} {message}!", player.Nickname, roomId);
            }
            room.Players.Add(player);
            room.CurrentPlayersCount++;
        }

        public void Disconnect(string username, string roomId, string message)
        {
            Logic.Player player = null;
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));

            if (room != null)
            {
                player = room.Players.FirstOrDefault(i => i.Nickname.Equals(username));
            }

            if (player != null)
            {
                room.Players.Remove(player);
                room.CurrentPlayersCount--;
                if (room.Players.Count() == 0)
                {
                    globalRooms.Remove(room);
                }
                else
                {
                    SendMessage($": {player.Nickname} {message}!", player.Nickname, roomId);
                }
            }
        }

        public void ExpelPlayer(string username, string roomId, string message)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));
            if (room != null)
            {
                Player[] players = room.Players.ToArray();
                foreach (var player in room.Players)
                {
                    if (!player.Nickname.Equals(room.HostUsername))
                    {
                        player.AOperationContext.GetCallbackChannel<IGameServiceCallback>().PlayerExpeled(username, message);
                    }
                }
            }
        }

        public void SendMessage(string message, string username, string roomId)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));
            foreach (var player in room.Players)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var anotherPlayer = room.Players.FirstOrDefault(i => i.Nickname.Equals(username));
                if (anotherPlayer != null)
                {
                    answer += $": {anotherPlayer.Nickname} ";
                }
                answer += message;
                player.AOperationContext.GetCallbackChannel<IGameServiceCallback>().MessageCallBack(answer);
            }
        }

        public void SendWhisper(string player, string message)
        {
            var room = globalRooms.FirstOrDefault(r => r.Players.Any(p => p.Nickname.Equals(player)));
            if (room != null)
            {
                var playerToWhisper = room.Players.FirstOrDefault(p => p.Nickname.Equals(player));
                var currentCallbackChannel = OperationContext.Current.GetCallbackChannel<IGameServiceCallback>();
                var sender = room.Players.FirstOrDefault(p => p.AOperationContext.GetCallbackChannel<IGameServiceCallback>().Equals(currentCallbackChannel));
                if (playerToWhisper != null && sender != null)
                {
                    playerToWhisper?.AOperationContext.GetCallbackChannel<IGameServiceCallback>().WhisperCallBack(sender.Nickname, message);
                }
            }
        }
        public void CreateDeck(String roomId)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(roomId));
            if (room.Deck == null)
            {
                var deck = new List<CardType>();
                for (int i = 3; i < Enum.GetValues(typeof(CardType)).Length; i++)
                {
                    deck.Add((CardType)i);
                }
                room.Deck = deck;
                ShuffleDeck(roomId);
                DiscardFirstNine(roomId);
            }

            if (room != null)
            {
                room.RoomTokens = 0;
                foreach (var player in room.Players)
                {
                    player.AOperationContext.GetCallbackChannel<IGameServiceCallback>().UpdateDeck(room.Deck.ToArray(), room.RoomTokens);
                }
            }
        }
        public void DiscardFirstNine(string idRoom)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom));
            room.Deck.RemoveRange(0, 9);
        }

        public void ShuffleDeck(string idRoom)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom));
            var random = new Random();
            for (int i = 0; i < room.Deck.Count; i++)
            {
                var temp = room.Deck[i];
                var randomIndex = random.Next(0, room.Deck.Count);
                room.Deck[i] = room.Deck[randomIndex];
                room.Deck[randomIndex] = temp;
            }
        }

        public void TakeCard(string idRoom, string username)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom));
            if (room.Deck.Count > 0)
            {
                var card = room.Deck[0];
                room.Deck.RemoveAt(0);
                room.NextRound();

                var player = room.Players.FirstOrDefault(p => p.Nickname.Equals(username));

                if (player != null)
                {
                    player.Cards.Add(card);
                    player.CardsString += $"{(int)card},";
                    player.Tokens += room.RoomTokens;
                    room.RoomTokens = 0;
                }

                foreach (var aPlayer in room.Players)
                {
                    var callback = aPlayer.AOperationContext.GetCallbackChannel<IGameServiceCallback>();
                    callback.UpdateDeck(room.Deck.ToArray(), room.RoomTokens); //Actualiza el mazo de todos los jugadores
                    callback.NextTurn(room.Round, room.Players.ToArray());
                }
            }
            else
            {
                foreach (var player in room.Players)
                {
                    room.RoomTokens = 0;
                    room.MatchStatus = RoomStatus.Finished;
                    player.AOperationContext.GetCallbackChannel<IGameServiceCallback>().EndGame(RoomStatus.Finished);
                }
            }

        }

        public void SkipPlayersTurn(string idRoom, string username)
        {
            var room = globalRooms.FirstOrDefault(r => r.Id.Equals(idRoom));
            var player = room.Players.FirstOrDefault(i => i.Nickname.Equals(username));
            if (player.Tokens > 0)
            {
                player.Tokens--;
                room.RoomTokens++;
                room.NextRound();
                foreach (var anotherPlayer in room.Players)
                {
                    anotherPlayer.AOperationContext.GetCallbackChannel<IGameServiceCallback>().SkipPlayersTurnCallback(room.Round, room.RoomTokens);
                    anotherPlayer.AOperationContext.GetCallbackChannel<IGameServiceCallback>().NextTurn(room.Round, room.Players.ToArray());
                }
            }
            else
            {
                TakeCard(idRoom, username);
            }

        }
    }
    public partial class GameService : IUpdateProfile
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
            return result;
        }

        public List<String> GetGlobalRequest()
        {
            List<String> result = new List<String>();
            return result;
        }

        public bool SaveImage(String imageManager, int idProfile)
        {

            var status = false;
            try
            {
                var client = new Authentication();
                status = client.SaveImage(imageManager, idProfile);
            }
            catch (EntityException entityException)
            {
                Log.Error($"Fallo: {entityException.Message}");
            }
            Console.WriteLine();
            return status;
        }

        public bool UpdateNewNickname(string nickname, string newNickname)
        {
            var status = false;
            try
            {
                var client = new Authentication();
                status = client.UpdatePlayerNickname(nickname, newNickname);
            }
            catch (EntityException entityException)
            {
                Log.Error($"Fallo: {entityException.Message}");
            }
            return status;
        }
    }


}
