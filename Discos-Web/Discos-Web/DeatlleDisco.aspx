<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DeatlleDisco.aspx.cs" Inherits="Discos_Web.DeatlleDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <% if (DiscoDetalle != null)
        {%>
    <div class="card mx-auto" style="width: 18rem;">
        <img src="<%:DiscoDetalle.Url_Imagen %>" class="card-img-top" alt="...">
        <div class="card-body">
            <h5 class="card-title"><%: DiscoDetalle.Titulo %></h5>
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item"><%: "Tipo: " + DiscoDetalle.Tipo_Disco %></li>
            <li class="list-group-item"><%: "Estilo: " + DiscoDetalle.Estilo_Disco %></li>
            <li class="list-group-item"><%: "Canciones: " + DiscoDetalle.Cant_Canciones %></li>
        </ul>
        <div class="card-body">
            <p class="card-text"><small class="text-body-secondary"><%: "Lanzamiento: " + DiscoDetalle.Fecha.ToShortDateString() %></small></p>
        </div>
    </div>
    <%}
        else
        { %>
    <h1>No hay un libro seleccionado.</h1>
    <%} %>

</asp:Content>
