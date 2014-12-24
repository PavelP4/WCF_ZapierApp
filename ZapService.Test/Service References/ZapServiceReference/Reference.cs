﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZapService.Test.ZapServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.zapservice.com/", ConfigurationName="ZapServiceReference.IZapService")]
    public interface IZapService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.zapservice.com/IZapService/GetOK", ReplyAction="http://www.zapservice.com/IZapService/GetOKResponse")]
        string GetOK();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.zapservice.com/IZapService/GetOK", ReplyAction="http://www.zapservice.com/IZapService/GetOKResponse")]
        System.Threading.Tasks.Task<string> GetOKAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.zapservice.com/IZapService/Subscribe", ReplyAction="http://www.zapservice.com/IZapService/SubscribeResponse")]
        ZapServiceNS.DataObjects.Responses.SubscribeResponse Subscribe(ZapServiceNS.DataObjects.Requests.SubscribeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.zapservice.com/IZapService/Subscribe", ReplyAction="http://www.zapservice.com/IZapService/SubscribeResponse")]
        System.Threading.Tasks.Task<ZapServiceNS.DataObjects.Responses.SubscribeResponse> SubscribeAsync(ZapServiceNS.DataObjects.Requests.SubscribeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.zapservice.com/IZapService/UnSubscribe", ReplyAction="http://www.zapservice.com/IZapService/UnSubscribeResponse")]
        ZapServiceNS.DataObjects.Responses.UnSubscribeResponse UnSubscribe(ZapServiceNS.DataObjects.Requests.UnSubscribeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.zapservice.com/IZapService/UnSubscribe", ReplyAction="http://www.zapservice.com/IZapService/UnSubscribeResponse")]
        System.Threading.Tasks.Task<ZapServiceNS.DataObjects.Responses.UnSubscribeResponse> UnSubscribeAsync(ZapServiceNS.DataObjects.Requests.UnSubscribeRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IZapServiceChannel : ZapService.Test.ZapServiceReference.IZapService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ZapServiceClient : System.ServiceModel.ClientBase<ZapService.Test.ZapServiceReference.IZapService>, ZapService.Test.ZapServiceReference.IZapService {
        
        public ZapServiceClient() {
        }
        
        public ZapServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ZapServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ZapServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ZapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetOK() {
            return base.Channel.GetOK();
        }
        
        public System.Threading.Tasks.Task<string> GetOKAsync() {
            return base.Channel.GetOKAsync();
        }
        
        public ZapServiceNS.DataObjects.Responses.SubscribeResponse Subscribe(ZapServiceNS.DataObjects.Requests.SubscribeRequest request) {
            return base.Channel.Subscribe(request);
        }
        
        public System.Threading.Tasks.Task<ZapServiceNS.DataObjects.Responses.SubscribeResponse> SubscribeAsync(ZapServiceNS.DataObjects.Requests.SubscribeRequest request) {
            return base.Channel.SubscribeAsync(request);
        }
        
        public ZapServiceNS.DataObjects.Responses.UnSubscribeResponse UnSubscribe(ZapServiceNS.DataObjects.Requests.UnSubscribeRequest request) {
            return base.Channel.UnSubscribe(request);
        }
        
        public System.Threading.Tasks.Task<ZapServiceNS.DataObjects.Responses.UnSubscribeResponse> UnSubscribeAsync(ZapServiceNS.DataObjects.Requests.UnSubscribeRequest request) {
            return base.Channel.UnSubscribeAsync(request);
        }
    }
}