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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.SesionActiva(Session["usuario"]))
                {
                    Usuario user = (Usuario)Session["usuario"];

                    txtApellido.Text = user.Apellido;
                    txtNombre.Text = user.Nombre;
                    txtMail.Text = user.Mail;
                    txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");

                    if (user.ImagenURL != null)
                    {
                        NewProfileImage.ImageUrl = "./Images/Profile/" + user.ImagenURL;
                    }
                    else
                    {
                        NewProfileImage.ImageUrl = "./Images/Profile/DefaultProfileImage.jpg";
                    }
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                //Leer los datos del usuario
                UsuarioTienda tienda = new UsuarioTienda();
                Usuario user = (Usuario)Session["usuario"];

                if(txtPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/Profile/");
                    txtPerfil.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg"); //Tomar la imagen ingresada y guardarla en la carpeta de imagenes
                    user.ImagenURL = "perfil-" + user.Id + ".jpg";  // Añadir la imagen al usuario
                }
                  
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Mail = txtMail.Text;

                if (DateTime.Parse(txtFechaNacimiento.Text) == DateTime.MinValue) { }
                else if (DateTime.Parse(txtFechaNacimiento.Text) < new DateTime(1753, 1, 1))
                {
                    throw new Exception("La fecha debe ser igual o mayor a 01/01/1753.");
                }

                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                tienda.ActualizarDatos(user);
                Session["usuario"] = user;

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