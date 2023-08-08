using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lib_UNSA
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Conexión a la base de datos (asegúrate de reemplazar "cadena_de_conexion" con la conexión real a tu base de datos)
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proyecto;Integrated Security=True"))
                {
                    // Consulta SQL para obtener los registros de la tabla "libros"
                    string query = "SELECT * FROM DataReservas";
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
                            string cui = reader["CUI"].ToString();
                            string nombre = reader["NOMBRE"].ToString();
                            string id = reader["ID-LIBRO"].ToString();
                            string titulo = reader["TITULO"].ToString();
                            string fecha = reader["FECHA"].ToString();
                            resultado.InnerHtml += "<strong>CUI del alumno:</strong> " + cui + "<br>"
                                + "<strong>Nombre del alumno:</strong> " + nombre + "<br>"
                                + "<strong>Id del libro:</strong> " + id + "<br>"
                                + "<strong>Título del libro:</strong> " + titulo + "<br>"
                                + "<strong>Fecha de reserva:</strong> " + fecha + "<br>" + "<br>";
                        }
                    }
                    // Cerrar la conexión
                    con.Close();
                }
            }
        }
    }
}
