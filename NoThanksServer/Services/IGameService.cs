using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract(CallbackContract = typeof(IGameServiceCallback))]
    public interface IGameService
    {
        [OperationContract]
        bool NewRoom(string hostUsername, string idRoom);

        [OperationContract]
        string GenerateRoomCode();

        [OperationContract]
        bool CheckQuota(string idRoom);

        [OperationContract]
        List<Logic.Player> RecoverRoomPlayers(string idRoom);

        [OperationContract]
        void StartGame(string idRoom);

        [OperationContract]
        void Connect(string username,string idRoom, string message);

        [OperationContract]
        void Disconnect(string username, string idRoom, string message);
        [OperationContract]
        void ExpelPlayer(string username, string idRoom, string message);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string username, string idRoom);

        [OperationContract(IsOneWay = true)]
        void SendWhisper(string sender, string receiver, string message, string idRoom);
        [OperationContract(IsOneWay = true)]
        void CreateDeck(String roomId);
        [OperationContract(IsOneWay = true)]
        void TakeCard(String roomId);
    }

    [ServiceContract]
    public interface IGameServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallBack(string message);
        [OperationContract (IsOneWay = true)]
        void WhisperCallBack(string sender, string message);
        [OperationContract(IsOneWay = true)]
        void StartGameRoom(RoomStatus roomStatus, Player[] players);
        [OperationContract(IsOneWay = true)]
        void PlayerExpeled(string nickname, string message);
        /*[OperationContract(IsOneWay = true)]
        void SkipPlayersTurn(int round);*/
        [OperationContract(IsOneWay = true)]
        void UpdateDeck(CardType[] gameDeck);
        [OperationContract(IsOneWay = true)]
        void UpdatePlayerDeck(CardType[] playerDeck);
    }
}
