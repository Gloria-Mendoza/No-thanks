using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    [ServiceContract]
    public interface IPlayerManager
    {
        [OperationContract]
        bool Login(String nickname, String password);
        [OperationContract]
        bool Register(Player player);
    }
}
