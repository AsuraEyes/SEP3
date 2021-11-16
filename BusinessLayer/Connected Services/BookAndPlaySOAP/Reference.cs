﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookAndPlaySOAP
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://spring.io/guides/gs-producing-web-service", ConfigurationName="BookAndPlaySOAP.BookAndPlayPort")]
    public interface BookAndPlayPort
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<BookAndPlaySOAP.SOAPResponse1> SOAPAsync(BookAndPlaySOAP.SOAPRequest1 request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://spring.io/guides/gs-producing-web-service")]
    public partial class SOAPRequest
    {
        
        private int idField;
        
        private Operation operationField;
        
        private Game gameField;
        
        private User userField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Operation Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public Game Game
        {
            get
            {
                return this.gameField;
            }
            set
            {
                this.gameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public User User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://spring.io/guides/gs-producing-web-service")]
    public enum Operation
    {
        
        /// <remarks/>
        GET,
        
        /// <remarks/>
        DELETE,
        
        /// <remarks/>
        POST,
        
        /// <remarks/>
        PATCH,
        
        /// <remarks/>
        GETALL,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://spring.io/guides/gs-producing-web-service")]
    public partial class Game
    {
        
        private int idField;
        
        private string nameField;
        
        private int complexityField;
        
        private int timeEstimationField;
        
        private int minNumberOfPlayersField;
        
        private int maxNumberOfPlayersField;
        
        private string shortDescriptionField;
        
        private string neededEquipmentField;
        
        private int minAgeField;
        
        private int maxAgeField;
        
        private string tutorialField;
        
        private bool approvedField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int complexity
        {
            get
            {
                return this.complexityField;
            }
            set
            {
                this.complexityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int timeEstimation
        {
            get
            {
                return this.timeEstimationField;
            }
            set
            {
                this.timeEstimationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int minNumberOfPlayers
        {
            get
            {
                return this.minNumberOfPlayersField;
            }
            set
            {
                this.minNumberOfPlayersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int maxNumberOfPlayers
        {
            get
            {
                return this.maxNumberOfPlayersField;
            }
            set
            {
                this.maxNumberOfPlayersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string shortDescription
        {
            get
            {
                return this.shortDescriptionField;
            }
            set
            {
                this.shortDescriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string neededEquipment
        {
            get
            {
                return this.neededEquipmentField;
            }
            set
            {
                this.neededEquipmentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int minAge
        {
            get
            {
                return this.minAgeField;
            }
            set
            {
                this.minAgeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int maxAge
        {
            get
            {
                return this.maxAgeField;
            }
            set
            {
                this.maxAgeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string tutorial
        {
            get
            {
                return this.tutorialField;
            }
            set
            {
                this.tutorialField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public bool approved
        {
            get
            {
                return this.approvedField;
            }
            set
            {
                this.approvedField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://spring.io/guides/gs-producing-web-service")]
    public partial class User
    {
        
        private string usernameField;
        
        private string passwordField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private int roleIdField;
        
        private string phoneCountryCodeField;
        
        private string phoneNumberField;
        
        private string emailAddressField;
        
        private bool requestedPromotionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string lastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int roleId
        {
            get
            {
                return this.roleIdField;
            }
            set
            {
                this.roleIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string phoneCountryCode
        {
            get
            {
                return this.phoneCountryCodeField;
            }
            set
            {
                this.phoneCountryCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string phoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string emailAddress
        {
            get
            {
                return this.emailAddressField;
            }
            set
            {
                this.emailAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public bool requestedPromotion
        {
            get
            {
                return this.requestedPromotionField;
            }
            set
            {
                this.requestedPromotionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://spring.io/guides/gs-producing-web-service")]
    public partial class SOAPResponse
    {
        
        private Game gameField;
        
        private string notificationField;
        
        private GameList gameListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Game Game
        {
            get
            {
                return this.gameField;
            }
            set
            {
                this.gameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string notification
        {
            get
            {
                return this.notificationField;
            }
            set
            {
                this.notificationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public GameList GameList
        {
            get
            {
                return this.gameListField;
            }
            set
            {
                this.gameListField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://spring.io/guides/gs-producing-web-service")]
    public partial class GameList
    {
        
        private User userUsernameField;
        
        private Game[] gameListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public User userUsername
        {
            get
            {
                return this.userUsernameField;
            }
            set
            {
                this.userUsernameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("gameList", Order=1)]
        public Game[] gameList
        {
            get
            {
                return this.gameListField;
            }
            set
            {
                this.gameListField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SOAPRequest1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://spring.io/guides/gs-producing-web-service", Order=0)]
        public BookAndPlaySOAP.SOAPRequest SOAPRequest;
        
        public SOAPRequest1()
        {
        }
        
        public SOAPRequest1(BookAndPlaySOAP.SOAPRequest SOAPRequest)
        {
            this.SOAPRequest = SOAPRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SOAPResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://spring.io/guides/gs-producing-web-service", Order=0)]
        public BookAndPlaySOAP.SOAPResponse SOAPResponse;
        
        public SOAPResponse1()
        {
        }
        
        public SOAPResponse1(BookAndPlaySOAP.SOAPResponse SOAPResponse)
        {
            this.SOAPResponse = SOAPResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface BookAndPlayPortChannel : BookAndPlaySOAP.BookAndPlayPort, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class BookAndPlayPortClient : System.ServiceModel.ClientBase<BookAndPlaySOAP.BookAndPlayPort>, BookAndPlaySOAP.BookAndPlayPort
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public BookAndPlayPortClient() : 
                base(BookAndPlayPortClient.GetDefaultBinding(), BookAndPlayPortClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BookAndPlayPortSoap11.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BookAndPlayPortClient(EndpointConfiguration endpointConfiguration) : 
                base(BookAndPlayPortClient.GetBindingForEndpoint(endpointConfiguration), BookAndPlayPortClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BookAndPlayPortClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(BookAndPlayPortClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BookAndPlayPortClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(BookAndPlayPortClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BookAndPlayPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<BookAndPlaySOAP.SOAPResponse1> BookAndPlaySOAP.BookAndPlayPort.SOAPAsync(BookAndPlaySOAP.SOAPRequest1 request)
        {
            return base.Channel.SOAPAsync(request);
        }
        
        public System.Threading.Tasks.Task<BookAndPlaySOAP.SOAPResponse1> SOAPAsync(BookAndPlaySOAP.SOAPRequest SOAPRequest)
        {
            BookAndPlaySOAP.SOAPRequest1 inValue = new BookAndPlaySOAP.SOAPRequest1();
            inValue.SOAPRequest = SOAPRequest;
            return ((BookAndPlaySOAP.BookAndPlayPort)(this)).SOAPAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BookAndPlayPortSoap11))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BookAndPlayPortSoap11))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8080/ws");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return BookAndPlayPortClient.GetBindingForEndpoint(EndpointConfiguration.BookAndPlayPortSoap11);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return BookAndPlayPortClient.GetEndpointAddress(EndpointConfiguration.BookAndPlayPortSoap11);
        }
        
        public enum EndpointConfiguration
        {
            
            BookAndPlayPortSoap11,
        }
    }
}