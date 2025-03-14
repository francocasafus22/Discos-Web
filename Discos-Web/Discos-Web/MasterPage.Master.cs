﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tienda;

namespace Discos_Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!(Page is Login || Page is Registrarse || Page is Error || Page is Default || Page is DeatlleDisco))
            {
                if (!(Seguridad.SesionActiva(Session["usuario"])))
                    Response.Redirect("Login.aspx", false);
            }

            if (Seguridad.SesionActiva(Session["usuario"]))
            {
                hyperLinkLogin.Visible = false;
                hyperLinkRegistrar.Visible = false;
                btnCerrarSesion.Visible = true;
                ProfileImage.Visible = true;
                
            }
            else
            {
                hyperLinkLogin.Visible = true;
                hyperLinkRegistrar.Visible = true;
                btnCerrarSesion.Visible = false;
                ProfileImage.Visible = false;
                
            }

           if (Seguridad.IsAdmin((Usuario)Session["usuario"]))
            {
                hyperLista.Visible = true;
            }
            else
            {
                hyperLista.Visible = false;
            }

            if (Seguridad.SesionActiva(Session["usuario"]) && ((Usuario)Session["usuario"]).ImagenURL != null)
                ProfileImage.ImageUrl = "./Images/Profile/" + ((Usuario)Session["usuario"]).ImagenURL;
            else
                ProfileImage.ImageUrl = "./Images/Profile/DefaultProfileImage.jpg";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}