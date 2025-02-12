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
    public partial class DeatlleDisco : System.Web.UI.Page
    {
        public Disco DiscoDetalle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoTienda negocio = new DiscoTienda();
            List<Disco> list = negocio.listar("");
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                DiscoDetalle = list.Find(x => x.Id == id);
            }
        }
    }
}