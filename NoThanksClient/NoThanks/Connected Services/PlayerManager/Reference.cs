﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
        private string[] CardsField;
        
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
        public string[] Cards {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="RoomStatus", Namespace="http://schemas.datacontract.org/2004/07/Logic")]
    public enum RoomStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Waitting = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Started = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Finished = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CardType", Namespace="http://schemas.datacontract.org/2004/07/Services")]
    public enum CardType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Three = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Four = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Five = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Six = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Seven = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Eight = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Nine = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Ten = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Eleven = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Twelve = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Thirteen = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fourteen = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fifteen = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sixteen = 13,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Seventeen = 14,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Eightteen = 15,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Nineteen = 16,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Twenty = 17,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyOne = 18,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyTwo = 19,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyThree = 20,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyFour = 21,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyFive = 22,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentySix = 23,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentySeven = 24,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyEight = 25,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TwentyNine = 26,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Thirty = 27,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyOne = 28,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyTwo = 29,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyThree = 30,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyFour = 31,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirtyFive = 32,
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlayerManager.IChatService", CallbackContract=typeof(NoThanks.PlayerManager.IChatServiceCallback))]
    public interface IChatService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/NewRoom", ReplyAction="http://tempuri.org/IChatService/NewRoomResponse")]
        bool NewRoom(string hostUsername, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/NewRoom", ReplyAction="http://tempuri.org/IChatService/NewRoomResponse")]
        System.Threading.Tasks.Task<bool> NewRoomAsync(string hostUsername, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GenerateRoomCode", ReplyAction="http://tempuri.org/IChatService/GenerateRoomCodeResponse")]
        string GenerateRoomCode();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GenerateRoomCode", ReplyAction="http://tempuri.org/IChatService/GenerateRoomCodeResponse")]
        System.Threading.Tasks.Task<string> GenerateRoomCodeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/CheckQuota", ReplyAction="http://tempuri.org/IChatService/CheckQuotaResponse")]
        bool CheckQuota(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/CheckQuota", ReplyAction="http://tempuri.org/IChatService/CheckQuotaResponse")]
        System.Threading.Tasks.Task<bool> CheckQuotaAsync(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/RecoverRoomPlayers", ReplyAction="http://tempuri.org/IChatService/RecoverRoomPlayersResponse")]
        NoThanks.PlayerManager.Player[] RecoverRoomPlayers(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/RecoverRoomPlayers", ReplyAction="http://tempuri.org/IChatService/RecoverRoomPlayersResponse")]
        System.Threading.Tasks.Task<NoThanks.PlayerManager.Player[]> RecoverRoomPlayersAsync(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/StartGame", ReplyAction="http://tempuri.org/IChatService/StartGameResponse")]
        void StartGame(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/StartGame", ReplyAction="http://tempuri.org/IChatService/StartGameResponse")]
        System.Threading.Tasks.Task StartGameAsync(string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Connect", ReplyAction="http://tempuri.org/IChatService/ConnectResponse")]
        void Connect(string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Connect", ReplyAction="http://tempuri.org/IChatService/ConnectResponse")]
        System.Threading.Tasks.Task ConnectAsync(string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Disconnect", ReplyAction="http://tempuri.org/IChatService/DisconnectResponse")]
        void Disconnect(string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Disconnect", ReplyAction="http://tempuri.org/IChatService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/ExpelPlayer", ReplyAction="http://tempuri.org/IChatService/ExpelPlayerResponse")]
        void ExpelPlayer(string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/ExpelPlayer", ReplyAction="http://tempuri.org/IChatService/ExpelPlayerResponse")]
        System.Threading.Tasks.Task ExpelPlayerAsync(string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/SendExpelReason", ReplyAction="http://tempuri.org/IChatService/SendExpelReasonResponse")]
        void SendExpelReason(string username, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/SendExpelReason", ReplyAction="http://tempuri.org/IChatService/SendExpelReasonResponse")]
        System.Threading.Tasks.Task SendExpelReasonAsync(string username, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendMessage")]
        void SendMessage(string message, string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string message, string username, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendWhisper")]
        void SendWhisper(string sender, string receiver, string message, string idRoom);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendWhisper")]
        System.Threading.Tasks.Task SendWhisperAsync(string sender, string receiver, string message, string idRoom);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/MessageCallBack")]
        void MessageCallBack(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/WhisperCallBack")]
        void WhisperCallBack(string sender, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/StartGameRoom")]
        void StartGameRoom(NoThanks.PlayerManager.RoomStatus roomStatus, NoThanks.PlayerManager.Player[] players);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/PlayerExpeled")]
        void PlayerExpeled(string nickname);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceChannel : NoThanks.PlayerManager.IChatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServiceClient : System.ServiceModel.DuplexClientBase<NoThanks.PlayerManager.IChatService>, NoThanks.PlayerManager.IChatService {
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
        
        public void Connect(string username, string idRoom) {
            base.Channel.Connect(username, idRoom);
        }
        
        public System.Threading.Tasks.Task ConnectAsync(string username, string idRoom) {
            return base.Channel.ConnectAsync(username, idRoom);
        }
        
        public void Disconnect(string username, string idRoom) {
            base.Channel.Disconnect(username, idRoom);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(string username, string idRoom) {
            return base.Channel.DisconnectAsync(username, idRoom);
        }
        
        public void ExpelPlayer(string username, string idRoom) {
            base.Channel.ExpelPlayer(username, idRoom);
        }
        
        public System.Threading.Tasks.Task ExpelPlayerAsync(string username, string idRoom) {
            return base.Channel.ExpelPlayerAsync(username, idRoom);
        }
        
        public void SendExpelReason(string username, string message) {
            base.Channel.SendExpelReason(username, message);
        }
        
        public System.Threading.Tasks.Task SendExpelReasonAsync(string username, string message) {
            return base.Channel.SendExpelReasonAsync(username, message);
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
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlayerManager.IDeckOfCards", CallbackContract=typeof(NoThanks.PlayerManager.IDeckOfCardsCallback))]
    public interface IDeckOfCards {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/CreateDeck")]
        void CreateDeck();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/CreateDeck")]
        System.Threading.Tasks.Task CreateDeckAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/ShuffleDeck")]
        void ShuffleDeck(NoThanks.PlayerManager.CardType[] gameDeck);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/ShuffleDeck")]
        System.Threading.Tasks.Task ShuffleDeckAsync(NoThanks.PlayerManager.CardType[] gameDeck);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/DiscardFirstNine")]
        void DiscardFirstNine(NoThanks.PlayerManager.CardType[] gameDeck);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/DiscardFirstNine")]
        System.Threading.Tasks.Task DiscardFirstNineAsync(NoThanks.PlayerManager.CardType[] gameDeck);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeckOfCardsCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/CreateDeckCallBack")]
        void CreateDeckCallBack(NoThanks.PlayerManager.CardType[] gameDeck);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/ShuffleDeckCallBack")]
        void ShuffleDeckCallBack(NoThanks.PlayerManager.CardType[] shuffledDeck);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeckOfCards/DiscardFirstNineCallback")]
        void DiscardFirstNineCallback(NoThanks.PlayerManager.CardType[] gameDeck);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeckOfCardsChannel : NoThanks.PlayerManager.IDeckOfCards, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeckOfCardsClient : System.ServiceModel.DuplexClientBase<NoThanks.PlayerManager.IDeckOfCards>, NoThanks.PlayerManager.IDeckOfCards {
        
        public DeckOfCardsClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public DeckOfCardsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public DeckOfCardsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DeckOfCardsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DeckOfCardsClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void CreateDeck() {
            base.Channel.CreateDeck();
        }
        
        public System.Threading.Tasks.Task CreateDeckAsync() {
            return base.Channel.CreateDeckAsync();
        }
        
        public void ShuffleDeck(NoThanks.PlayerManager.CardType[] gameDeck) {
            base.Channel.ShuffleDeck(gameDeck);
        }
        
        public System.Threading.Tasks.Task ShuffleDeckAsync(NoThanks.PlayerManager.CardType[] gameDeck) {
            return base.Channel.ShuffleDeckAsync(gameDeck);
        }
        
        public void DiscardFirstNine(NoThanks.PlayerManager.CardType[] gameDeck) {
            base.Channel.DiscardFirstNine(gameDeck);
        }
        
        public System.Threading.Tasks.Task DiscardFirstNineAsync(NoThanks.PlayerManager.CardType[] gameDeck) {
            return base.Channel.DiscardFirstNineAsync(gameDeck);
        }
    }
}
