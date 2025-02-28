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
        public Usuario User1 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                User1 = (Usuario)Session["usuario"];
                if (User1.ImagenURL != null)
                {
                    NewProfileImage.ImageUrl = "./Images/Profile/" + User1.ImagenURL;
                }
                else
                {
                    NewProfileImage.ImageUrl = "./Images/Profile/DefaultProfileImage.jpg";
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Leer los datos del usuario
                UsuarioTienda tienda = new UsuarioTienda();
                string ruta = Server.MapPath("./Images/Profile/");
                Usuario user = (Usuario)Session["usuario"];
                txtPerfil.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg"); //Tomar la imagen ingresada y guardarla en la carpeta de imagenes

                //Actualizar la URL de la imagen en la base de datos
                user.ImagenURL = "perfil-" + user.Id + ".jpg";
                tienda.ActualizarImagen(user);
                Session["usuario"] = user;

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
            }
        }
    }
}