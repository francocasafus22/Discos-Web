using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using tienda;

namespace Discos_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                txtPassword.Enabled = false;
                txtUser.Enabled = false;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioTienda tienda = new UsuarioTienda();
            Usuario usuario;
            try
            {
                usuario = new Usuario(txtUser.Text, txtPassword.Text, false);
                if(tienda.Login(usuario))
                {
                    Session["usuario"] = tienda.ObtenerUsuario(usuario);                   
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            txtPassword.Enabled = true;
            txtUser.Enabled = true;
        }
    }
}