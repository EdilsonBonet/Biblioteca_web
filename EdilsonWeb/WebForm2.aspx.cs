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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void verificarUsuario()
        {
            String[][] usuario = serviceCall();
            string cuii = TextBoxUser.Text;
            string contraseña = TextBoxPassword.Text;
            for (int i = 0; i < usuario.Length; i++)
            {
                if (usuario[i][0] == cuii && usuario[i][1] == contraseña)
                {
                    Response.Redirect("Registro.aspx");
                }
            }

        }
        public String[][] serviceCall()
        {
            ServicexDClient client = new ServicexDClient();
            String[][] ciudades = client.BuscarUsuarioPorNombre("Edilson");

            return ciudades;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            verificarUsuario(); 

        }
    }
}