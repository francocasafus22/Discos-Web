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
				User1 = (Usuario)Session["usuario"];
        }
	}
}