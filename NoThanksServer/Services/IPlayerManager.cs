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
        bool SendCode(string emailFrom);

        [OperationContract]
        List<String> GetRecord();

        [OperationContract]
        List<int?> GetScore();

        [OperationContract]
        bool SendValidationEmail(String toEmail, String affair, int validationCode);

        [OperationContract]
        bool UpdatePassword(string password, string email);

        [OperationContract]
        bool ExitsEmail(string text); // ==> ESTÁ MAL ESCRITO!!! :V
        [OperationContract]
        bool ExitsNickname(string text); // ==> ESTÁ MAL ESCRITO!!! :V
    }

    [DataContract]
    public partial class MatchMember
    {
        [DataMember]
        public Player player;
    }
}
