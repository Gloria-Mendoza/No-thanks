using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract(CallbackContract = typeof(IUdateProfileCallBack))]
    public interface IUpdateProfile
    {
        [OperationContract]
        bool SaveImage(string imageManager, int idProfile);
        [OperationContract(IsOneWay = true)]
        void GetImage(int idProfile);
        [OperationContract]
        List<String> GetGlobalPlayers();
        [OperationContract]
        List<String> GetGlobalFriends(int idPlayer);
        [OperationContract]
        List<String> GetGlobalRequest();
        [OperationContract]
        bool UpdateNewNickname(string nickname, string newnickname);
    }

    [ServiceContract]
    public interface IUdateProfileCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ImageCallBack(byte[] image);

    }
}
