using System;
using System.IO;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lib_UNSA.ServiceReference1;
using System.Web.Services;

namespace Lib_UNSA
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] semestre = serviceCall();

            foreach (string linea in semestre)
            {
                anio.Items.Add(linea);
            }
        }
        public String[] serviceCall()
        {
            Service1Client client = new Service1Client();
            String[] ciudades = client.getSemestres();

            return ciudades;
        }
        private static string[][] serviceCall5()
        {
            Service1Client client = new Service1Client();
            //ServiceReference17.IService1 client = new ServiceReference17.Service1Client();
            string[][] nombresApellidos = client.ObtenerNombresApellidos();
            return nombresApellidos;
        }
        private static bool CompararNombresApellidos(string nombrecito, string apellidito)
        {

            string[][] nombresApellidos = serviceCall5();


            foreach (string[] nombresApellidoArray in nombresApellidos)
            {
                string nombre = nombresApellidoArray[0];
                string apellido = nombresApellidoArray[1];
                if (nombre == nombrecito && apellido == apellidito)
                {
                    return true;

                }
            }
            return false;
        }

        [WebMethod]
        public static bool verificarNombreyApellido(string nombre, string apellido)
        {
            bool rpta = CompararNombresApellidos(nombre, apellido);
            return rpta;
        }
        protected void guardarBD()
        {
            Service1Client client = new Service1Client();
            string sexos = "ga";
            if (macho.Checked)
            {
                sexos = "Mas";
            }
            else if (hembra.Checked)
            {
                sexos = "Fem";
            }

            string nombre = TextNombre.Text;
            string apellido = TextApellido.Text;
            string email = TextEmail.Text;
            string direccion = TextCelular.Text;
            int codeciudad = anio.SelectedIndex;
            string cuii = TextCui.Text;
            string requerimiento = contraseña1.Text;

            client.SetUsuario(nombre, apellido, email, sexos, direccion, codeciudad, cuii, requerimiento);
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = TextNombre.Text;
            string correo = TextEmail.Text;
            guardarBD();
        }
    }
}
