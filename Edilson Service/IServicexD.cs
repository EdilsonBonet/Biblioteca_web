using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Edilson_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicexD" in both code and config file together.
    [ServiceContract]
    public interface IServicexD
    {
        [OperationContract]
        IList<String> getCiudades();

        [OperationContract]
        void SaveDataToFile(List<string> data);

        [OperationContract]
        void InsertarDatoAlFinal(string nombre, string apellido, string email, string sexo, string direccion, int codeCiudad, string requerimiento);
        
        [OperationContract]
        List<List<string>> ObtenerNombresApellidos();

        [OperationContract]
        void SetUsuario(string nombre, string apellido, string email, string sexo, string celular, int codeCiudad, string cui, string contraseña);
        [OperationContract]
        List<List<string>> BuscarUsuarioPorNombre(string nombreABuscar);
    }
}
