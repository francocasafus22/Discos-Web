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
    public partial class ListaDiscos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.IsAdmin((Usuario)Session["usuario"]))
            {
                Session.Add("error", "No tiene permisos para acceder a esta página");
                Response.Redirect("Error.aspx", false);
            }

            txtBuscar.Enabled = !cbAvanzado.Checked;

            if (!IsPostBack)
            {
                DiscoTienda negocio = new DiscoTienda();
                Session.Add("listaDiscos", negocio.listar(""));
                dgvDiscos.DataSource = Session["listaDiscos"];
                dgvDiscos.DataBind();
            }
        }

        protected void dgvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarDisco.aspx?id=" + id);
        }

        protected void dgvDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDiscos.PageIndex = e.NewPageIndex;
            dgvDiscos.DataSource = Session["listaDiscos"];
            dgvDiscos.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaFiltrada = ((List<Disco>)Session["listaDiscos"]).FindAll(x => x.Titulo.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            dgvDiscos.DataSource = listaFiltrada;
            dgvDiscos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (ddlCampo.SelectedIndex)
            {
                case 0: //Titulo
                    ddlCriterio.Items.Clear();
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                    ddlCriterio.Items.Add("Contiene");
                    txtFiltro.Enabled = true;
                    break;
                case 1: //Tipo
                    ddlCriterio.Items.Clear();
                    ddlCriterio.Items.Add("CD");
                    ddlCriterio.Items.Add("Tape");
                    ddlCriterio.Items.Add("Vinilo");
                    txtFiltro.Enabled = false;
                    break;
                case 2: //Estilo
                    ddlCriterio.Items.Clear();
                    ddlCriterio.Items.Add("Pop Punk");
                    ddlCriterio.Items.Add("Pop");
                    ddlCriterio.Items.Add("Rock");
                    ddlCriterio.Items.Add("Grunge");
                    txtFiltro.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscoTienda tienda = new DiscoTienda();
                dgvDiscos.DataSource = tienda.busquedaFiltrada(txtFiltro.Text, ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), ddlEstado.SelectedItem.ToString());
                dgvDiscos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void cbAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbAvanzado.Checked)
            {
                dgvDiscos.DataSource = Session["listaDiscos"];
                dgvDiscos.DataBind();
            }
        }

    }
}