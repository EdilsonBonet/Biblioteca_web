using Lib_UNSA.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lib_UNSA
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void verificarUsuario()
        {
            string cuii = TextBoxUser.Text;
            String[][] usuario = serviceCall(cuii);
            string contraseña = TextBoxPassword.Text;
            for (int i = 0; i < usuario.Length; i++)
            {
                if (usuario[i][0] == cuii && usuario[i][1] == contraseña)
                {
                    Response.Redirect("WebForm3.aspx");
                }
            }
            if ("Piero" == cuii && "pier123" == contraseña)
            {
                Response.Redirect("WebForm4.aspx");
            }

        }
        public String[][] serviceCall(string cuack)
        {
            Service1Client client = new Service1Client();
            String[][] ciudades = client.BuscarUsuarioPorNombre(cuack);

            return ciudades;
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }
        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            verificarUsuario();
        }
    }
}
