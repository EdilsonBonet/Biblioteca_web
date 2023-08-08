using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lib_UNSA
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                        // Conexión a la base de datos (asegúrate de reemplazar "cadena_de_conexion" con la conexión real a tu base de datos)
                        using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proyecto;Integrated Security=True"))
                        {
                            // Consulta SQL para obtener los registros de la tabla "libros"
                            string query = "SELECT * FROM BaseLibros";
                            // Abrir la conexión
                            con.Open();
                            // Ejecutar la consulta
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader reader = cmd.ExecuteReader();
                            // Recorrer los registros y mostrarlos en la página web
                            resultado.InnerHtml = "";
                            while (reader.Read())
                            {
                                {
                                    string nro = reader["Nro"].ToString();
                                    string titulo = reader["Titulo"].ToString();
                                    string anio = reader["Anio"].ToString();
                                    string edicion = reader["Edicion"].ToString();
                                    string editorial = reader["Editorial"].ToString();
                                    string autores = reader["Autores"].ToString();
                                    string categoria = reader["Categoria"].ToString();
                                    string cantidad = reader["Cantidad"].ToString();
                                    resultado.InnerHtml +=  "<strong>Nro:</strong> " + nro + "<br>"
                                        + "<strong>Título:</strong> " + titulo + "<br>"
                                        + "<strong>Año:</strong> " + anio + "<br>"
                                        + "<strong>Edición:</strong> " + edicion + "<br>"
                                        + "<strong>Editorial:</strong> " + editorial + "<br>"
                                        + "<strong>Autores:</strong> " + autores + "<br>"
                                        + "<strong>Categoría:</strong> " + categoria + "<br>"
                                        + "<strong>Cantidad:</strong> " + cantidad + "<br><br>";
                                }
                            }
                            // Cerrar la conexión
                            con.Close();
                        }
            }
        }

        [WebMethod]
        public static List<Libro> BuscarLibros(string busqueda)
        {
            List<Libro> resultadosFiltrados = new List<Libro>();

            string connectionString = ConfigurationManager.ConnectionStrings["Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proyecto;Integrated Security=True"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Libros WHERE Titulo LIKE @busqueda";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Libro libro = new Libro
                        {
                            //Nro = reader["Nro"].ToString(),
                            Titulo = reader["Titulo"].ToString(),
                            //Anio = Convert.ToInt32(reader["Anio"]),
                            //Edicion = Convert.ToInt32(reader["Edicion"]),
                            //Editorial = reader["Editorial"].ToString(),
                            Autor = reader["Autores"].ToString(),
                            //Categoria = reader["Categoria"].ToString(),
                            //Cantidad = Convert.ToInt32(reader["Cantidad"])
                        };

                        resultadosFiltrados.Add(libro);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                }
            }

            return resultadosFiltrados;
        }
    }
}
public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
}
