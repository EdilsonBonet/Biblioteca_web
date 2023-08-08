using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IList<String> getSemestres();

        [OperationContract]
        List<List<string>> ObtenerNombresApellidos();

        [OperationContract]
        void SetUsuario(string nombre, string apellido, string email, string sexo, string celular, int codeCiudad, string cui, string contraseña);
        [OperationContract]
        List<List<string>> BuscarUsuarioPorNombre(string nombreABuscar);
    }

}
