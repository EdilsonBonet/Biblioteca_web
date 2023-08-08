﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdilsonWeb.ServiceReference20 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference20.IServicexD")]
    public interface IServicexD {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/getCiudades", ReplyAction="http://tempuri.org/IServicexD/getCiudadesResponse")]
        string[] getCiudades();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/getCiudades", ReplyAction="http://tempuri.org/IServicexD/getCiudadesResponse")]
        System.Threading.Tasks.Task<string[]> getCiudadesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/SaveDataToFile", ReplyAction="http://tempuri.org/IServicexD/SaveDataToFileResponse")]
        void SaveDataToFile(string[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/SaveDataToFile", ReplyAction="http://tempuri.org/IServicexD/SaveDataToFileResponse")]
        System.Threading.Tasks.Task SaveDataToFileAsync(string[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/InsertarDatoAlFinal", ReplyAction="http://tempuri.org/IServicexD/InsertarDatoAlFinalResponse")]
        void InsertarDatoAlFinal(string nombre, string apellido, string email, string sexo, string direccion, int codeCiudad, string requerimiento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/InsertarDatoAlFinal", ReplyAction="http://tempuri.org/IServicexD/InsertarDatoAlFinalResponse")]
        System.Threading.Tasks.Task InsertarDatoAlFinalAsync(string nombre, string apellido, string email, string sexo, string direccion, int codeCiudad, string requerimiento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/ObtenerNombresApellidos", ReplyAction="http://tempuri.org/IServicexD/ObtenerNombresApellidosResponse")]
        string[][] ObtenerNombresApellidos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/ObtenerNombresApellidos", ReplyAction="http://tempuri.org/IServicexD/ObtenerNombresApellidosResponse")]
        System.Threading.Tasks.Task<string[][]> ObtenerNombresApellidosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/SetUsuario", ReplyAction="http://tempuri.org/IServicexD/SetUsuarioResponse")]
        void SetUsuario(string nombre, string apellido, string email, string sexo, string celular, int codeCiudad, string cui, string contraseña);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/SetUsuario", ReplyAction="http://tempuri.org/IServicexD/SetUsuarioResponse")]
        System.Threading.Tasks.Task SetUsuarioAsync(string nombre, string apellido, string email, string sexo, string celular, int codeCiudad, string cui, string contraseña);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/BuscarUsuarioPorNombre", ReplyAction="http://tempuri.org/IServicexD/BuscarUsuarioPorNombreResponse")]
        string[][] BuscarUsuarioPorNombre(string nombreABuscar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicexD/BuscarUsuarioPorNombre", ReplyAction="http://tempuri.org/IServicexD/BuscarUsuarioPorNombreResponse")]
        System.Threading.Tasks.Task<string[][]> BuscarUsuarioPorNombreAsync(string nombreABuscar);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicexDChannel : EdilsonWeb.ServiceReference20.IServicexD, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicexDClient : System.ServiceModel.ClientBase<EdilsonWeb.ServiceReference20.IServicexD>, EdilsonWeb.ServiceReference20.IServicexD {
        
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
        
        public void InsertarDatoAlFinal(string nombre, string apellido, string email, string sexo, string direccion, int codeCiudad, string requerimiento) {
            base.Channel.InsertarDatoAlFinal(nombre, apellido, email, sexo, direccion, codeCiudad, requerimiento);
        }
        
        public System.Threading.Tasks.Task InsertarDatoAlFinalAsync(string nombre, string apellido, string email, string sexo, string direccion, int codeCiudad, string requerimiento) {
            return base.Channel.InsertarDatoAlFinalAsync(nombre, apellido, email, sexo, direccion, codeCiudad, requerimiento);
        }
        
        public string[][] ObtenerNombresApellidos() {
            return base.Channel.ObtenerNombresApellidos();
        }
        
        public System.Threading.Tasks.Task<string[][]> ObtenerNombresApellidosAsync() {
            return base.Channel.ObtenerNombresApellidosAsync();
        }
        
        public void SetUsuario(string nombre, string apellido, string email, string sexo, string celular, int codeCiudad, string cui, string contraseña) {
            base.Channel.SetUsuario(nombre, apellido, email, sexo, celular, codeCiudad, cui, contraseña);
        }
        
        public System.Threading.Tasks.Task SetUsuarioAsync(string nombre, string apellido, string email, string sexo, string celular, int codeCiudad, string cui, string contraseña) {
            return base.Channel.SetUsuarioAsync(nombre, apellido, email, sexo, celular, codeCiudad, cui, contraseña);
        }
        
        public string[][] BuscarUsuarioPorNombre(string nombreABuscar) {
            return base.Channel.BuscarUsuarioPorNombre(nombreABuscar);
        }
        
        public System.Threading.Tasks.Task<string[][]> BuscarUsuarioPorNombreAsync(string nombreABuscar) {
            return base.Channel.BuscarUsuarioPorNombreAsync(nombreABuscar);
        }
    }
}