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
        bool SaveImage(byte[] imageManager, string nameProfile);
        [OperationContract(IsOneWay = true)]
        void GetImage(string nameProfile);
        [OperationContract]
        List<String> GetGlobalPlayers();
        [OperationContract]
        List<String> GetGlobalFriends();
    }

    [ServiceContract]
    public interface IUdateProfileCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ImageCallBack(byte[] image);

    }
}
