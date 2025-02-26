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
    public partial class AgregarDisco : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarEliminacion = false;

            if (!Seguridad.IsAdmin((Usuario)Session["usuario"]))
            {
                Session.Add("error", "No tiene permisos para acceder a esta página");
                Response.Redirect("Error.aspx", false);
            }

            try
            {
                if (!IsPostBack)
                {
                    txtId.Enabled = false;
                    DiscoTienda tienda = new DiscoTienda();
                    TipoTienda tipoTienda = new TipoTienda();
                    EstiloTienda estiloTienda = new EstiloTienda();

                    ddlEstilo.DataSource = estiloTienda.listarEstilo();
                    ddlEstilo.DataTextField = "Descripcion";
                    ddlEstilo.DataValueField = "Id";
                    ddlEstilo.DataBind();

                    ddlTipo.DataSource = tipoTienda.listarTipos();
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataBind();

                    string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                    if (id != "")
                    {
                        DiscoTienda negocio = new DiscoTienda();
                        Disco disco = negocio.listarConId(id);
                        Session.Add("Seleccionado", disco);

                        txtTitulo.Text = disco.Titulo;
                        txtId.Text = disco.Id.ToString();
                        txtCanciones.Text = disco.Cant_Canciones.ToString();
                        txtImagen.Text = disco.Url_Imagen;
                        txtFecha.Text = disco.Fecha.ToString("yyyy-MM-dd");
                        lblTitulo.Text = "Modificar";
                        ddlEstilo.SelectedValue = disco.Estilo_Disco.Id.ToString();
                        ddlTipo.SelectedValue = disco.Tipo_Disco.Id.ToString();
                        img_Disco.ImageUrl = txtImagen.Text;
                        if (!disco.Estado)
                            btnInactivo.Text = "Activar";
                    }
                    else
                    {
                        lblTitulo.Text = "Agregar";
                        btnBorrar.Enabled = false;
                        btnInactivo.Enabled = false;
                    }

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                //redirigir a una pagina de error;
                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //Agregar
                Disco disco = new Disco();
                DiscoTienda tienda = new DiscoTienda();
                disco.Titulo = txtTitulo.Text;
                disco.Fecha = Convert.ToDateTime(txtFecha.Text);
                disco.Cant_Canciones = int.Parse(txtCanciones.Text);
                disco.Url_Imagen = txtImagen.Text;
                disco.Estilo_Disco = new Estilo();
                disco.Estilo_Disco.Id = int.Parse(ddlEstilo.SelectedValue);
                disco.Tipo_Disco = new Tipo();
                disco.Tipo_Disco.Id = int.Parse(ddlTipo.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    //Modificar
                    disco.Id = int.Parse(txtId.Text);
                    tienda.modificar(disco);
                    Response.Redirect("ListaDiscos.aspx", false);
                }
                else
                {
                    tienda.agregar(disco);
                    Response.Redirect("ListaDiscos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                //redirigir a una pagina de error;
                throw ex;
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            img_Disco.ImageUrl = txtImagen.Text;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnBorrarConfirmado_Click(object sender, EventArgs e)
        {
            if (cbConfirmar.Checked)
            {
                DiscoTienda tienda = new DiscoTienda();
                string id = txtId.Text;
                tienda.borrar(id);
                Response.Redirect("ListaDiscos.aspx", false);
            }
        }

        protected void btnInactivo_Click(object sender, EventArgs e)
        {
            try
            {
                DiscoTienda tienda = new DiscoTienda();
                Disco seleccionado = (Disco)Session["Seleccionado"];

                tienda.EstadoDisco(txtId.Text, !seleccionado.Estado);
                
                Response.Redirect("ListaDiscos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}