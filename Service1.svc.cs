using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public IList<String> getSemestres()
        {
            List<String> semestres = new List<String>();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proyecto;Integrated Security=True";

            string query = "SELECT Semestre FROM DataSemestre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        semestres.Add(nombre);
                    }
                    reader.Close();
                }
            }
            return semestres;
        }
        public void SetUsuario(string nombre, string apellido, string email, string sexo, string celular, int codeCiudad, string cui, string contraseña)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proyecto;Integrated Security=True";

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
        public List<List<string>> ObtenerNombresApellidos()
        {
            string cadena_conexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proyecto;Integrated Security=True";

            List<List<string>> nombresApellidos = new List<List<string>>();

            using (SqlConnection conexion = new SqlConnection(cadena_conexion))
            {
                conexion.Open();

                string solicitud = "SELECT Nombre, Apellidos FROM DataUsuarios";
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
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proyecto;Integrated Security=True";

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
