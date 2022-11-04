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
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlayerManager.IChatService", CallbackContract=typeof(NoThanks.PlayerManager.IChatServiceCallback))]
    public interface IChatService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Connect", ReplyAction="http://tempuri.org/IChatService/ConnectResponse")]
        void Connect(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Connect", ReplyAction="http://tempuri.org/IChatService/ConnectResponse")]
        System.Threading.Tasks.Task ConnectAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Disconnect", ReplyAction="http://tempuri.org/IChatService/DisconnectResponse")]
        void Disconnect(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Disconnect", ReplyAction="http://tempuri.org/IChatService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendMessage")]
        void SendMessage(string message, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string message, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendWhisper")]
        void SendWhisper(string sender, string receiver, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendWhisper")]
        System.Threading.Tasks.Task SendWhisperAsync(string sender, string receiver, string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/MessageCallBack")]
        void MessageCallBack(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/WhisperCallBack")]
        void WhisperCallBack(string sender, string message);
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
        
        public void Connect(string username) {
            base.Channel.Connect(username);
        }
        
        public System.Threading.Tasks.Task ConnectAsync(string username) {
            return base.Channel.ConnectAsync(username);
        }
        
        public void Disconnect(string username) {
            base.Channel.Disconnect(username);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(string username) {
            return base.Channel.DisconnectAsync(username);
        }
        
        public void SendMessage(string message, string username) {
            base.Channel.SendMessage(message, username);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string message, string username) {
            return base.Channel.SendMessageAsync(message, username);
        }
        
        public void SendWhisper(string sender, string receiver, string message) {
            base.Channel.SendWhisper(sender, receiver, message);
        }
        
        public System.Threading.Tasks.Task SendWhisperAsync(string sender, string receiver, string message) {
            return base.Channel.SendWhisperAsync(sender, receiver, message);
        }
    }
}
