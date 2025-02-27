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
            EmailService emailService = new EmailService();
            try
            {
                usuario = new Usuario();
                usuario.User = txtUser.Text;
                usuario.Pass = txtPassword.Text;
                usuario.Mail = txtMail.Text;

                int id = tienda.Registrar(usuario);

                emailService.armarCorreo(usuario.Mail, "Registro exitoso", "Bienvenido a Discos Web, su usuario es: " + usuario.User);
                emailService.enviarCorreo();

                if (tienda.Login(usuario))
                {
                    Session["usuario"] = usuario;
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Error al iniciar sesión, vuelva a intentarlo.");
                    Response.Redirect("Error.aspx", false);
                }

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}