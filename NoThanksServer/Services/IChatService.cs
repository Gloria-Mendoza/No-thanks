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
        void Connect(string username);

        [OperationContract]
        void Disconnect(string username);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string username);
    }

    [ServiceContract]
    public interface IChatServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallBack(string message);
    }
}
