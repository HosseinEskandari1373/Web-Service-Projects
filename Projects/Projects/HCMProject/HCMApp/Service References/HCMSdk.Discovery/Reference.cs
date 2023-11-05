﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCMApp.HCMSdk.Discovery {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="EndpointCollection", Namespace="http://schemas.microsoft.com/xrm/2011/Contracts/Discovery", ItemName="KeyValuePairOfEndpointTypestringztYlk6OT")]
    [System.SerializableAttribute()]
    public class EndpointCollection : System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<Microsoft.Xrm.Sdk.Discovery.EndpointType, string>> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OrganizationDetailCollection", Namespace="http://schemas.microsoft.com/xrm/2011/Contracts/Discovery", ItemName="OrganizationDetail")]
    [System.SerializableAttribute()]
    public class OrganizationDetailCollection : System.Collections.Generic.List<Microsoft.Xrm.Sdk.Discovery.OrganizationDetail> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ErrorDetailCollection", Namespace="http://schemas.microsoft.com/xrm/2011/Contracts", ItemName="KeyValuePairOfstringanyType")]
    [System.SerializableAttribute()]
    public class ErrorDetailCollection : System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, object>> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/Contracts/Discovery", ConfigurationName="HCMSdk.Discovery.IDiscoveryService")]
    public interface IDiscoveryService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.microsoft.com/xrm/2011/Contracts/Discovery/IDiscoveryService/Execu" +
            "te", ReplyAction="http://schemas.microsoft.com/xrm/2011/Contracts/Discovery/IDiscoveryService/Execu" +
            "teResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Microsoft.Xrm.Sdk.DiscoveryServiceFault), Action="http://schemas.microsoft.com/xrm/2011/Contracts/Discovery/IDiscoveryService/Execu" +
            "teDiscoveryServiceFaultFault", Name="DiscoveryServiceFault", Namespace="http://schemas.microsoft.com/xrm/2011/Contracts")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Microsoft.Xrm.Sdk.Discovery.RetrieveOrganizationsRequest))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Microsoft.Xrm.Sdk.Discovery.RetrieveUserIdByExternalIdRequest))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Microsoft.Xrm.Sdk.Discovery.RetrieveOrganizationRequest))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Microsoft.Xrm.Sdk.Discovery.RetrieveUserIdByExternalIdResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Microsoft.Xrm.Sdk.Discovery.RetrieveOrganizationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Microsoft.Xrm.Sdk.Discovery.RetrieveOrganizationsResponse))]
        Microsoft.Xrm.Sdk.Discovery.DiscoveryResponse Execute(Microsoft.Xrm.Sdk.Discovery.DiscoveryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.microsoft.com/xrm/2011/Contracts/Discovery/IDiscoveryService/Execu" +
            "te", ReplyAction="http://schemas.microsoft.com/xrm/2011/Contracts/Discovery/IDiscoveryService/Execu" +
            "teResponse")]
        System.Threading.Tasks.Task<Microsoft.Xrm.Sdk.Discovery.DiscoveryResponse> ExecuteAsync(Microsoft.Xrm.Sdk.Discovery.DiscoveryRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDiscoveryServiceChannel : HCMApp.HCMSdk.Discovery.IDiscoveryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DiscoveryServiceClient : System.ServiceModel.ClientBase<HCMApp.HCMSdk.Discovery.IDiscoveryService>, HCMApp.HCMSdk.Discovery.IDiscoveryService {
        
        public DiscoveryServiceClient() {
        }
        
        public DiscoveryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DiscoveryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiscoveryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiscoveryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Microsoft.Xrm.Sdk.Discovery.DiscoveryResponse Execute(Microsoft.Xrm.Sdk.Discovery.DiscoveryRequest request) {
            return base.Channel.Execute(request);
        }
        
        public System.Threading.Tasks.Task<Microsoft.Xrm.Sdk.Discovery.DiscoveryResponse> ExecuteAsync(Microsoft.Xrm.Sdk.Discovery.DiscoveryRequest request) {
            return base.Channel.ExecuteAsync(request);
        }
    }
}