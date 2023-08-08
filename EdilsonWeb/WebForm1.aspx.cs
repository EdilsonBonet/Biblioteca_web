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
using EdilsonWeb.ServiceReference16;


namespace EdilsonWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //string[] lineas = File.ReadAllLines(Server.MapPath("~/datos.txt"));
                string[] ciudade = serviceCall();

                foreach (string linea in ciudade)
                {
                    ciudadOpciones.Items.Add(linea);
                }
            }

        }

        public String[] serviceCall()
        {
            ServicexDClient client = new ServicexDClient();
            String[] ciudades = client.getCiudades();

            return ciudades;
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
                    "Ciudad: " + ciudadOpciones.Text,
                    "Requerimiento: " + TextAreaRequerimiento.Value
                };

                client.SaveDataToFile(data);
            }
        }
        protected void guardargaa() {
            ServicexDClient client = new ServicexDClient();
            string sexos = "ga";
            if (macho.Checked) {
                sexos = "Mas";
            }
            else if(hembra.Checked) {
                sexos = "Fem";
            }

            string nombre = TextNombre.Text;
            string apellido =TextApellido.Text;
            string email = TextEmail.Text;
            string direccion = TextDireccion.Text;
            int codeciudad = ciudadOpciones.SelectedIndex;
            string requerimiento =TextAreaRequerimiento.Value;
            
            client.InsertarDatoAlFinal(nombre,apellido,email,sexos,direccion,codeciudad,requerimiento);
        }

        private void crearSesion(string nombre, string apellido)
        {

            Session["Nombre"] = nombre;
            Session["Apellido"] = apellido;
        }
        protected void crearCookie( string dato, int duracionDias, string nombre)
        {
            HttpCookie cookie = new HttpCookie(nombre, dato);
            cookie.Expires = DateTime.Now.AddDays(duracionDias);
            Response.Cookies.Add(cookie);
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string x = TextNombre.Text;
            StringBuilder contenido = new StringBuilder();
            string sexo = " ";
            contenido.AppendLine("Nombre: " + x);
            contenido.AppendLine("Apellido: " + TextApellido.Text);
            if (macho.Checked)
            {
                sexo += "Masculino";
            }
            else if (hembra.Checked)
            {
                sexo += "Femenino";      
            }
            contenido.AppendLine(sexo);
            contenido.AppendLine("Email: " + TextEmail.Text);
            contenido.AppendLine("Dirección: " + TextDireccion.Text);
            contenido.AppendLine("Ciudad: " + ciudadOpciones.Text);
            contenido.AppendLine("Requerimiento: " + TextAreaRequerimiento.Value);
            string data = contenido.ToString();
            txtAreaResultado.Visible = true;
            txtAreaResultado.Value = contenido.ToString();
            Almacenar();
            guardargaa();
            crearSesion(TextNombre.Text, TextApellido.Text);
            crearCookie(sexo, 1, "CKsexo");
            crearCookie(TextEmail.Text, 1,"CKemail");
            crearCookie(TextDireccion.Text, 1, "CKdireccion");
            crearCookie(ciudadOpciones.Text, 1, "CKciudad");
            crearCookie(TextAreaRequerimiento.Value, 1, "CKrequerimiento");
            Response.Redirect("Auxiliarga.aspx");
        }
    }
}