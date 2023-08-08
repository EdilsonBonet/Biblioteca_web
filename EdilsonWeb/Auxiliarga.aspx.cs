using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdilsonWeb
{
    public partial class Auxiliarga : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            deleteSessions();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadSession();
        }
        private void loadSession()
        {
            String nombre = (String)(Session["Nombre"]);
            String apellido = (String)(Session["Apellido"]);
            // Asignacion de la informacion a los campos HTML respectivos
            LabelUsuario.Text = "Enviado por Sesion: ";
            LabelNombre.Text = "Nombre: " + nombre;
            LabelApellido.Text = " Apellido: " + apellido;
        }
        private void deleteSessions()
        {
            Session.RemoveAll();
            Session.Abandon();
        }

    }

}