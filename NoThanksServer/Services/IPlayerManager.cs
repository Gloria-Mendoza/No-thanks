using Logic;
using System.Data;
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
        Logic.Player Login(String nickname, String password);
        [OperationContract]
        bool Register(Player player);
        [OperationContract]
        bool SendCode(string emailFrom, int code);
        [OperationContract]
        int GenerateCode();
        [OperationContract]
        int GetGenerateCode();
        [OperationContract]
        bool SendNewEmail(String toEmail, String affair, int validationCode);
        [OperationContract]
        bool UpdatePassword(string password, string email);
    }
}
