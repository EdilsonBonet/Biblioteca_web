using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using EdilsonWeb.ServiceReference20;

namespace EdilsonWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[][] ciudade = serviceCall();

            foreach (string[] linea in ciudade)
            {
                foreach (string dato in linea)
                {
                    anio.Items.Add(dato);
                }
            }
        }
        public String[][] serviceCall()
        {
            ServicexDClient client = new ServicexDClient();
            String[][] ciudades = client.BuscarUsuarioPorNombre("Edilson");

            return ciudades;
        }


        private static string[][] serviceCall5()
        {
            ServicexDClient client = new ServicexDClient();
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
            protected void Almacenar()
        {
            using (var client = new ServicexDClient())
            {
                string Sexo = "";
                if (macho.Checked)
                {
                    Sexo = "Sexo: Masculino";
                }
                else if (hembra.Checked)
                {
                    Sexo = "Sexo: Femenino";
                }
                string[] data =
                {
                    "Nombre: " +TextNombre.Text,
                    "Apellido: " + TextApellido.Text,Sexo,
                    "Email: " + TextEmail.Text,
                    "Semestre: " + anio.Text,
                    "Celular: " + TextCelular.Text,
                    "CUI: " + TextCui.Text
                };

                client.SaveDataToFile(data);
            }
        }
        protected void guardarBD()
        {
            ServicexDClient client = new ServicexDClient();
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

            client.SetUsuario(nombre, apellido, email, sexos, direccion, codeciudad, cuii ,requerimiento);
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = TextNombre.Text;
            string correo = TextEmail.Text;
            Almacenar();
            guardarBD();
        }
    }
}