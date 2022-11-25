﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoThanks.PlayerManager {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/Logic")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NoThanks.PlayerManager.CardType[] CardsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdPlayerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NicknameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TokensField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TotalScoreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NoThanks.PlayerManager.CardType[] Cards {
            get {
                return this.CardsField;
            }
            set {
                if ((object.ReferenceEquals(this.CardsField, value) != true)) {
                    this.CardsField = value;
                    this.RaisePropertyChanged("Cards");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdPlayer {
            get {
                return this.IdPlayerField;
            }
            set {
                if ((this.IdPlayerField.Equals(value) != true)) {
                    this.IdPlayerField = value;
                    this.RaisePropertyChanged("IdPlayer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nickname {
            get {
                return this.NicknameField;
            }
            set {
                if ((object.ReferenceEquals(this.NicknameField, value) != true)) {
                    this.NicknameField = value;
                    this.RaisePropertyChanged("Nickname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Tokens {
            get {
                return this.TokensField;
            }
            set {
                if ((this.TokensField.Equals(value) != true)) {
                    this.TokensField = value;
                    this.RaisePropertyChanged("Tokens");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> TotalScore {
            get {
                return this.TotalScoreField;
            }
            set {
                if ((this.TotalScoreField.Equals(value) != true)) {
                    this.TotalScoreField = value;
                    this.RaisePropertyChanged("TotalScore");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CardType", Namespace="http://schemas.datacontract.org/2004/07/Logic")]
    public enum CardType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Three = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Four = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Five = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Six = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Seven = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Eight = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Nine = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Ten = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Eleven = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Twelve = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Thirteen = 13,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fourteen = 14,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fifteen = 15,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sixteen = 16,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Seventeen = 17,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Eightteen = 18,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Nineteen = 19,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Twenty = 20,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyOne = 21,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyTwo = 22,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyThree = 23,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyFour = 24,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyFive = 25,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentySix = 26,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentySeven = 27,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyEight = 28,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyNine = 29,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Thirty = 30,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyOne = 31,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyTwo = 32,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyThree = 33,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyFour = 34,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyFive = 35,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RoomStatus", Namespace="http://schemas.datacontract.org/2004/07/Logic")]
    public enum RoomStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Waitting = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Started = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Finished = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlayerManager.IPlayerManager")]
    public interface IPlayerManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/Login", ReplyAction="http://tempuri.org/IPlayerManager/LoginResponse")]
        NoThanks.PlayerManager.Player Login(string nickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/Login", ReplyAction="http://tempuri.org/IPlayerManager/LoginResponse")]
        System.Threading.Tasks.Task<NoThanks.PlayerManager.Player> LoginAsync(string nickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/Register", ReplyAction="http://tempuri.org/IPlayerManager/RegisterResponse")]
        bool Register(NoThanks.PlayerManager.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/Register", ReplyAction="http://tempuri.org/IPlayerManager/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(NoThanks.PlayerManager.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/SendCode", ReplyAction="http://tempuri.org/IPlayerManager/SendCodeResponse")]
        bool SendCode(string emailFrom, int code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/SendCode", ReplyAction="http://tempuri.org/IPlayerManager/SendCodeResponse")]
        System.Threading.Tasks.Task<bool> SendCodeAsync(string emailFrom, int code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/GenerateCode", ReplyAction="http://tempuri.org/IPlayerManager/GenerateCodeResponse")]
        int GenerateCode();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/GenerateCode", ReplyAction="http://tempuri.org/IPlayerManager/GenerateCodeResponse")]
        System.Threading.Tasks.Task<int> GenerateCodeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/GetGenerateCode", ReplyAction="http://tempuri.org/IPlayerManager/GetGenerateCodeResponse")]
        int GetGenerateCode();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/GetGenerateCode", ReplyAction="http://tempuri.org/IPlayerManager/GetGenerateCodeResponse")]
        System.Threading.Tasks.Task<int> GetGenerateCodeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/SendValidationEmail", ReplyAction="http://tempuri.org/IPlayerManager/SendValidationEmailResponse")]
        bool SendValidationEmail(string toEmail, string affair, int validationCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/SendValidationEmail", ReplyAction="http://tempuri.org/IPlayerManager/SendValidationEmailResponse")]
        System.Threading.Tasks.Task<bool> SendValidationEmailAsync(string toEmail, string affair, int validationCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/UpdatePassword", ReplyAction="http://tempuri.org/IPlayerManager/UpdatePasswordResponse")]
        bool UpdatePassword(string password, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/UpdatePassword", ReplyAction="http://tempuri.org/IPlayerManager/UpdatePasswordResponse")]
        System.Threading.Tasks.Task<bool> UpdatePasswordAsync(string password, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/ExitsEmail", ReplyAction="http://tempuri.org/IPlayerManager/ExitsEmailResponse")]
        bool ExitsEmail(string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/ExitsEmail", ReplyAction="http://tempuri.org/IPlayerManager/ExitsEmailResponse")]
        System.Threading.Tasks.Task<bool> ExitsEmailAsync(string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/ExitsNickname", ReplyAction="http://tempuri.org/IPlayerManager/ExitsNicknameResponse")]
        bool ExitsNickname(string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerManager/ExitsNickname", ReplyAction="http://tempuri.org/IPlayerManager/ExitsNicknameResponse")]
        System.Threading.Tasks.Task<bool> ExitsNicknameAsync(string text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPlayerManagerChannel : NoThanks.PlayerManager.IPlayerManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlayerManagerClient : System.ServiceModel.ClientBase<NoThanks.PlayerManager.IPlayerManager>, NoThanks.PlayerManager.IPlayerManager {
        
        public PlayerManagerClient() {
        }
        
        public PlayerManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PlayerManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public NoThanks.PlayerManager.Player Login(string nickname, string password) {
            return base.Channel.Login(nickname, password);
        }
        
        public System.Threading.Tasks.Task<NoThanks.PlayerManager.Player> LoginAsync(string nickname, string password) {
            return base.Channel.LoginAsync(nickname, password);
        }
        
        public bool Register(NoThanks.PlayerManager.Player player) {
            return base.Channel.Register(player);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(NoThanks.PlayerManager.Player player) {
            return base.Channel.RegisterAsync(player);
        }
        
        public bool SendCode(string emailFrom, int code) {
            return base.Channel.SendCode(emailFrom, code);
        }
        
        public System.Threading.Tasks.Task<bool> SendCodeAsync(string emailFrom, int code) {
            return base.Channel.SendCodeAsync(emailFrom, code);
        }
        
        public int GenerateCode() {
            return base.Channel.GenerateCode();
        }
        
        public System.Threading.Tasks.Task<int> GenerateCodeAsync() {
            return base.Channel.GenerateCodeAsync();
        }
        
        public int GetGenerateCode() {
            return base.Channel.GetGenerateCode();
        }
        
        public System.Threading.Tasks.Task<int> GetGenerateCodeAsync() {
            return base.Channel.GetGenerateCodeAsync();
        }
        
        public bool SendValidationEmail(string toEmail, string affair, int validationCode) {
            return base.Channel.SendValidationEmail(toEmail, affair, validationCode);
        }
        
        public System.Threading.Tasks.Task<bool> SendValidationEmailAsync(string toEmail, string affair, int validationCode) {
            return base.Channel.SendValidationEmailAsync(toEmail, affair, validationCode);
        }
        
        public bool UpdatePassword(string password, string email) {
            return base.Channel.UpdatePassword(password, email);
        }
        
        public System.Threading.Tasks.Task<bool> UpdatePasswordAsync(string password, string email) {
            return base.Channel.UpdatePasswordAsync(password, email);
        }
        
        public bool ExitsEmail(string text) {
            return base.Channel.ExitsEmail(text);
        }
        
        public System.Threading.Tasks.Task<bool> ExitsEmailAsync(string text) {
            return base.Channel.ExitsEmailAsync(text);
        }
        
        public bool ExitsNickname(string text) {
            return base.Channel.ExitsNickname(text);
        }
        
        public System.Threading.Tasks.Task<bool> ExitsNicknameAsync(string text) {
            return base.Channel.ExitsNicknameAsync(text);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlayerManager.IGameService", CallbackContract=typeof(NoThanks.PlayerManager.IGameServiceCallback))]
    public interface IGameService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/NewRoom", ReplyAction="http://tempuri.org/IGameService/NewRoomResponse")]
        bool NewRoom(string hostUsername, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/NewRoom", ReplyAction="http://tempuri.org/IGameService/NewRoomResponse")]
        System.Threading.Tasks.Task<bool> NewRoomAsync(string hostUsername, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GenerateRoomCode", ReplyAction="http://tempuri.org/IGameService/GenerateRoomCodeResponse")]
        string GenerateRoomCode();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GenerateRoomCode", ReplyAction="http://tempuri.org/IGameService/GenerateRoomCodeResponse")]
        System.Threading.Tasks.Task<string> GenerateRoomCodeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/CheckQuota", ReplyAction="http://tempuri.org/IGameService/CheckQuotaResponse")]
        bool CheckQuota(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/CheckQuota", ReplyAction="http://tempuri.org/IGameService/CheckQuotaResponse")]
        System.Threading.Tasks.Task<bool> CheckQuotaAsync(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/RecoverRoomPlayers", ReplyAction="http://tempuri.org/IGameService/RecoverRoomPlayersResponse")]
        NoThanks.PlayerManager.Player[] RecoverRoomPlayers(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/RecoverRoomPlayers", ReplyAction="http://tempuri.org/IGameService/RecoverRoomPlayersResponse")]
        System.Threading.Tasks.Task<NoThanks.PlayerManager.Player[]> RecoverRoomPlayersAsync(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/StartGame", ReplyAction="http://tempuri.org/IGameService/StartGameResponse")]
        void StartGame(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/StartGame", ReplyAction="http://tempuri.org/IGameService/StartGameResponse")]
        System.Threading.Tasks.Task StartGameAsync(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Connect", ReplyAction="http://tempuri.org/IGameService/ConnectResponse")]
        void Connect(string username, string idRoom, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Connect", ReplyAction="http://tempuri.org/IGameService/ConnectResponse")]
        System.Threading.Tasks.Task ConnectAsync(string username, string idRoom, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Disconnect", ReplyAction="http://tempuri.org/IGameService/DisconnectResponse")]
        void Disconnect(string username, string idRoom, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Disconnect", ReplyAction="http://tempuri.org/IGameService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(string username, string idRoom, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ExpelPlayer", ReplyAction="http://tempuri.org/IGameService/ExpelPlayerResponse")]
        void ExpelPlayer(string username, string idRoom, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ExpelPlayer", ReplyAction="http://tempuri.org/IGameService/ExpelPlayerResponse")]
        System.Threading.Tasks.Task ExpelPlayerAsync(string username, string idRoom, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/SendMessage")]
        void SendMessage(string message, string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string message, string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/SendWhisper")]
        void SendWhisper(string sender, string receiver, string message, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/SendWhisper")]
        System.Threading.Tasks.Task SendWhisperAsync(string sender, string receiver, string message, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/CreateDeck")]
        void CreateDeck(string roomId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/CreateDeck")]
        System.Threading.Tasks.Task CreateDeckAsync(string roomId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/TakeCard")]
        void TakeCard(string roomId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/TakeCard")]
        System.Threading.Tasks.Task TakeCardAsync(string roomId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/MessageCallBack")]
        void MessageCallBack(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/WhisperCallBack")]
        void WhisperCallBack(string sender, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/StartGameRoom")]
        void StartGameRoom(NoThanks.PlayerManager.RoomStatus roomStatus, NoThanks.PlayerManager.Player[] players);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/PlayerExpeled")]
        void PlayerExpeled(string nickname, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/UpdateDeck")]
        void UpdateDeck(NoThanks.PlayerManager.CardType[] gameDeck);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/UpdatePlayerDeck")]
        void UpdatePlayerDeck(NoThanks.PlayerManager.CardType[] playerDeck);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceChannel : NoThanks.PlayerManager.IGameService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameServiceClient : System.ServiceModel.DuplexClientBase<NoThanks.PlayerManager.IGameService>, NoThanks.PlayerManager.IGameService {
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool NewRoom(string hostUsername, string idRoom) {
            return base.Channel.NewRoom(hostUsername, idRoom);
        }
        
        public System.Threading.Tasks.Task<bool> NewRoomAsync(string hostUsername, string idRoom) {
            return base.Channel.NewRoomAsync(hostUsername, idRoom);
        }
        
        public string GenerateRoomCode() {
            return base.Channel.GenerateRoomCode();
        }
        
        public System.Threading.Tasks.Task<string> GenerateRoomCodeAsync() {
            return base.Channel.GenerateRoomCodeAsync();
        }
        
        public bool CheckQuota(string idRoom) {
            return base.Channel.CheckQuota(idRoom);
        }
        
        public System.Threading.Tasks.Task<bool> CheckQuotaAsync(string idRoom) {
            return base.Channel.CheckQuotaAsync(idRoom);
        }
        
        public NoThanks.PlayerManager.Player[] RecoverRoomPlayers(string idRoom) {
            return base.Channel.RecoverRoomPlayers(idRoom);
        }
        
        public System.Threading.Tasks.Task<NoThanks.PlayerManager.Player[]> RecoverRoomPlayersAsync(string idRoom) {
            return base.Channel.RecoverRoomPlayersAsync(idRoom);
        }
        
        public void StartGame(string idRoom) {
            base.Channel.StartGame(idRoom);
        }
        
        public System.Threading.Tasks.Task StartGameAsync(string idRoom) {
            return base.Channel.StartGameAsync(idRoom);
        }
        
        public void Connect(string username, string idRoom, string message) {
            base.Channel.Connect(username, idRoom, message);
        }
        
        public System.Threading.Tasks.Task ConnectAsync(string username, string idRoom, string message) {
            return base.Channel.ConnectAsync(username, idRoom, message);
        }
        
        public void Disconnect(string username, string idRoom, string message) {
            base.Channel.Disconnect(username, idRoom, message);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(string username, string idRoom, string message) {
            return base.Channel.DisconnectAsync(username, idRoom, message);
        }
        
        public void ExpelPlayer(string username, string idRoom, string message) {
            base.Channel.ExpelPlayer(username, idRoom, message);
        }
        
        public System.Threading.Tasks.Task ExpelPlayerAsync(string username, string idRoom, string message) {
            return base.Channel.ExpelPlayerAsync(username, idRoom, message);
        }
        
        public void SendMessage(string message, string username, string idRoom) {
            base.Channel.SendMessage(message, username, idRoom);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string message, string username, string idRoom) {
            return base.Channel.SendMessageAsync(message, username, idRoom);
        }
        
        public void SendWhisper(string sender, string receiver, string message, string idRoom) {
            base.Channel.SendWhisper(sender, receiver, message, idRoom);
        }
        
        public System.Threading.Tasks.Task SendWhisperAsync(string sender, string receiver, string message, string idRoom) {
            return base.Channel.SendWhisperAsync(sender, receiver, message, idRoom);
        }
        
        public void CreateDeck(string roomId) {
            base.Channel.CreateDeck(roomId);
        }
        
        public System.Threading.Tasks.Task CreateDeckAsync(string roomId) {
            return base.Channel.CreateDeckAsync(roomId);
        }
        
        public void TakeCard(string roomId) {
            base.Channel.TakeCard(roomId);
        }
        
        public System.Threading.Tasks.Task TakeCardAsync(string roomId) {
            return base.Channel.TakeCardAsync(roomId);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlayerManager.IUpdateProfile", CallbackContract=typeof(NoThanks.PlayerManager.IUpdateProfileCallback))]
    public interface IUpdateProfile {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateProfile/SaveImage", ReplyAction="http://tempuri.org/IUpdateProfile/SaveImageResponse")]
        bool SaveImage(byte[] imageManager, string nameProfile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateProfile/SaveImage", ReplyAction="http://tempuri.org/IUpdateProfile/SaveImageResponse")]
        System.Threading.Tasks.Task<bool> SaveImageAsync(byte[] imageManager, string nameProfile);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUpdateProfile/GetImage")]
        void GetImage(string nameProfile);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUpdateProfile/GetImage")]
        System.Threading.Tasks.Task GetImageAsync(string nameProfile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateProfile/GetGlobalPlayers", ReplyAction="http://tempuri.org/IUpdateProfile/GetGlobalPlayersResponse")]
        string[] GetGlobalPlayers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateProfile/GetGlobalPlayers", ReplyAction="http://tempuri.org/IUpdateProfile/GetGlobalPlayersResponse")]
        System.Threading.Tasks.Task<string[]> GetGlobalPlayersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateProfile/GetGlobalFriends", ReplyAction="http://tempuri.org/IUpdateProfile/GetGlobalFriendsResponse")]
        string[] GetGlobalFriends();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateProfile/GetGlobalFriends", ReplyAction="http://tempuri.org/IUpdateProfile/GetGlobalFriendsResponse")]
        System.Threading.Tasks.Task<string[]> GetGlobalFriendsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUpdateProfileCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUpdateProfile/ImageCallBack")]
        void ImageCallBack(byte[] image);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUpdateProfileChannel : NoThanks.PlayerManager.IUpdateProfile, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateProfileClient : System.ServiceModel.DuplexClientBase<NoThanks.PlayerManager.IUpdateProfile>, NoThanks.PlayerManager.IUpdateProfile {
        
        public UpdateProfileClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public UpdateProfileClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public UpdateProfileClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UpdateProfileClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UpdateProfileClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool SaveImage(byte[] imageManager, string nameProfile) {
            return base.Channel.SaveImage(imageManager, nameProfile);
        }
        
        public System.Threading.Tasks.Task<bool> SaveImageAsync(byte[] imageManager, string nameProfile) {
            return base.Channel.SaveImageAsync(imageManager, nameProfile);
        }
        
        public void GetImage(string nameProfile) {
            base.Channel.GetImage(nameProfile);
        }
        
        public System.Threading.Tasks.Task GetImageAsync(string nameProfile) {
            return base.Channel.GetImageAsync(nameProfile);
        }
        
        public string[] GetGlobalPlayers() {
            return base.Channel.GetGlobalPlayers();
        }
        
        public System.Threading.Tasks.Task<string[]> GetGlobalPlayersAsync() {
            return base.Channel.GetGlobalPlayersAsync();
        }
        
        public string[] GetGlobalFriends() {
            return base.Channel.GetGlobalFriends();
        }
        
        public System.Threading.Tasks.Task<string[]> GetGlobalFriendsAsync() {
            return base.Channel.GetGlobalFriendsAsync();
        }
    }
}
