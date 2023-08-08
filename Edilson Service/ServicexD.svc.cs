using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Edilson_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicexD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicexD.svc or ServicexD.svc.cs at the Solution Explorer and start debugging.
    public class ServicexD : IServicexD
    {
        public IList<String> getCiudades()
        {
            List<String> ciudades = new List<String>();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBWebEdilson;Integrated Security=True";

            string query = "SELECT Ciudad FROM DataCiudad"; // Reemplaza "Ciudades" con el nombre de tu tabla

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        ciudades.Add(nombre);
                    }

                    reader.Close();
                }
            }

            return ciudades;
        }


        public void InsertarDatoAlFinal(string nombre, string apellido, string email, string sexo, string direccion, int codeCiudad, string requerimiento)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBWebEdilson;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO DataAlumnos ( Nombre, Apellidos, Email, Sexo, Direccion, CodeCiudad, Requerimiento) VALUES ( @Nombre, @Apellidos, @Email, @Sexa,@Direccion, @CodeCiudad,@Requerimiento)";

                using (SqlCommand command2 = new SqlCommand(insertQuery, connection))
                {

                    command2.Parameters.AddWithValue("@Nombre", nombre);
                    command2.Parameters.AddWithValue("@Apellidos", apellido);
                    command2.Parameters.AddWithValue("@Email", email);
                    command2.Parameters.AddWithValue("@Sexa", sexo);
                    command2.Parameters.AddWithValue("@Direccion", direccion);
                    command2.Parameters.AddWithValue("@CodeCiudad", codeCiudad);
                    command2.Parameters.AddWithValue("@Requerimiento", requerimiento);

                    command2.ExecuteNonQuery();
                }
            }
        }
        public void SetUsuario(string nombre, string apellido, string email, string sexo, string celular, int codeCiudad, string cui, string contraseña)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBWebEdilson;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO DataUsuarios ( Nombre, Apellidos, Email, Sexo, Celular, CodeCiudad, Cui, Contraseña) VALUES ( @Nombre, @Apellidos, @Email, @Sexa,@Celular, @CodeCiudad,@Cui, @Contraseña)";

                using (SqlCommand command2 = new SqlCommand(insertQuery, connection))
                {

                    command2.Parameters.AddWithValue("@Nombre", nombre);
                    command2.Parameters.AddWithValue("@Apellidos", apellido);
                    command2.Parameters.AddWithValue("@Email", email);
                    command2.Parameters.AddWithValue("@Sexa", sexo);
                    command2.Parameters.AddWithValue("@Celular", celular);
                    command2.Parameters.AddWithValue("@CodeCiudad", codeCiudad);
                    command2.Parameters.AddWithValue("@Cui", cui);
                    command2.Parameters.AddWithValue("@Contraseña", contraseña);

                    command2.ExecuteNonQuery();
                }
            }
        }

        public void SaveDataToFile(List<string> data)
        {
            string filePath = @"K:\DEV\textos\informacion.txt";
            File.WriteAllLines(filePath, data);
        }
        public List<List<string>> ObtenerNombresApellidos()
        {
            string cadena_conexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBWebEdilson;Integrated Security=True";

            List<List<string>> nombresApellidos = new List<List<string>>();

            using (SqlConnection conexion = new SqlConnection(cadena_conexion))
            {
                conexion.Open();

                string solicitud = "SELECT Nombre, Apellidos FROM DataAlumnos";
                using (SqlCommand comando = new SqlCommand(solicitud, conexion))
                {
                    using (SqlDataReader datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            string nombre = datos.GetString(0);
                            string apellido = datos.GetString(1);

                            List<string> nombreApellido = new List<string> { nombre, apellido };

                            nombresApellidos.Add(nombreApellido);
                        }
                    }
                }
            }

            return nombresApellidos;
        }
        public List<List<string>> BuscarUsuarioPorNombre(string nombreABuscar)
        {
            List<List<string>> resultados = new List<List<string>>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBWebEdilson;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Cui, Contraseña FROM DataUsuarios WHERE Cui = @NombreABuscar";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@NombreABuscar", nombreABuscar);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["Cui"].ToString();
                            string apellidos = reader["Contraseña"].ToString();
                            List<string> nombreCompleto = new List<string> { nombre, apellidos };
                            resultados.Add(nombreCompleto);
                        }
                    }
                }
            }

            return resultados;
        }


    }
}
