<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Discos_Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["usuario"] != null)
        {%>
    <div class="card mx-auto" style="width: 18rem;">
        <img src="https://as1.ftcdn.net/v2/jpg/09/90/23/86/1000_F_990238695_EdYzCxmjhLK5dIV9zh81jX8pzVZIY4pK.jpg" class="card-img-top" alt="...">
        <div class="card-body">
            <h5 class="card-title"><%:User1.User%></h5>
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item"><%: "Mail: " + User1.Mail %></li>
            <li class="list-group-item"><%: "Tipo Usuario: "  + User1.TipoUsuario%></li>
        </ul>
        <div class="card-body">
            <p class="card-text"><small class="text-body-secondary"><%: "Fecha Creación: " + "01-01-2001" %></small></p>
        </div>
    </div>
    <%}
        else
        { %>
    <h1>No hay un usuario logueado.</h1>
    <%} %>

</asp:Content>
