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
    public partial class Default : System.Web.UI.Page
    {
        public List<Disco> listaDiscos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoTienda negocio = new DiscoTienda();
            listaDiscos = negocio.listar("");

            if(Session["usuario"] == null)
            {
                Session.Add("error", "Debe loguearse para acceder a esta página");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                lblSaludo.Text = "Bienvenido " + usuario.User;
            }
        }

    }
}