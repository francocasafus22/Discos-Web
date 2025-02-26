using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tienda;

namespace Discos_Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] != null)
            {
                hyperLinkLogin.Visible = false;
                hyperLinkRegistrar.Visible = false;
                btnCerrarSesion.Visible = true;
            }
            else
            {
                hyperLinkLogin.Visible = true;
                hyperLinkRegistrar.Visible = true;
                btnCerrarSesion.Visible = false;
            }

           if (UsuarioTienda.IsAdmin((Usuario)Session["usuario"]))
            {
                hyperLista.Visible = true;
            }
            else
            {
                hyperLista.Visible = false;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx", false);
        }
    }
}