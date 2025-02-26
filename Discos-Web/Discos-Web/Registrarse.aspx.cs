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
	public partial class Registrarse : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            UsuarioTienda tienda = new UsuarioTienda();
            Usuario usuario;
            try
            {
                usuario = new Usuario(txtUser.Text, txtPassword.Text, txtMail.Text);
                tienda.Registrar(usuario);
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", "No se ha podido registrar, vuelva a internarlo.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}