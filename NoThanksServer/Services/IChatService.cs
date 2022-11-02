using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract(CallbackContract = typeof(IChatServiceCallback))]
    public interface IChatService
    {
        [OperationContract]
        void CreateRoom(Logic.Room room);
        [OperationContract]
        bool CheckQuota(string idRoom);
        [OperationContract]
        string GenerateRoomCode();
        [OperationContract]
        void Connect(string username,string idRoom);

        [OperationContract]
        void Disconnect(string username, string idRoom);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string username, string idRoom);

        [OperationContract(IsOneWay = true)]
        void SendWhisper(string sender, string receiver, string message, string idRoom);
    }

    [ServiceContract]
    public interface IChatServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallBack(string message);

        [OperationContract (IsOneWay = true)]
        void WhisperCallBack(string sender, string message);   
    }
}
