<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Discos_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>hola</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%foreach (dominio.Disco disco in listaDiscos)
            {%>
        <div class="col">
            <div class="card h-100">
                <img src="<%: disco.Url_Imagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: disco.Titulo %></h5>
                    <p class="card-text"><%: "Estilo: " + disco.Estilo_Disco + " | Tipo: " + disco.Tipo_Disco%></p>
                    <a href="DeatlleDisco.aspx?id=<%: disco.Id %>" class="btn btn-primary">Ver Detalle</a>
                </div>
            </div>
        </div>
        <%}%>
    </div>

    

</asp:Content>
