﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdilsonWeb.ServiceReference4 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference4.IServicexD")]
    public interface IServicexD {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/getCiudades", ReplyAction="http://tempuri.org/IServicexD/getCiudadesResponse")]
        string[] getCiudades();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/getCiudades", ReplyAction="http://tempuri.org/IServicexD/getCiudadesResponse")]
        System.Threading.Tasks.Task<string[]> getCiudadesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/SaveDataToFile", ReplyAction="http://tempuri.org/IServicexD/SaveDataToFileResponse")]
        void SaveDataToFile(string[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/SaveDataToFile", ReplyAction="http://tempuri.org/IServicexD/SaveDataToFileResponse")]
        System.Threading.Tasks.Task SaveDataToFileAsync(string[] data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicexDChannel : EdilsonWeb.ServiceReference4.IServicexD, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicexDClient : System.ServiceModel.ClientBase<EdilsonWeb.ServiceReference4.IServicexD>, EdilsonWeb.ServiceReference4.IServicexD {
        
        public ServicexDClient() {
        }
        
        public ServicexDClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicexDClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicexDClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicexDClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] getCiudades() {
            return base.Channel.getCiudades();
        }
        
        public System.Threading.Tasks.Task<string[]> getCiudadesAsync() {
            return base.Channel.getCiudadesAsync();
        }
        
        public void SaveDataToFile(string[] data) {
            base.Channel.SaveDataToFile(data);
        }
        
        public System.Threading.Tasks.Task SaveDataToFileAsync(string[] data) {
            return base.Channel.SaveDataToFileAsync(data);
        }
    }
}
