<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Discos_Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col-8">
            <div class="mb-3">
                <label for="txtUser" class="form-label">Usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUser"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password"></asp:TextBox>
            </div>
            <%if (Session["usuario"] == null)
                {  %>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-dark" OnClick="btnIngresar_Click" />
            <%}
                else
                {%>
            <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn btn-dark" OnClick="btnCerrarSesion_Click" />
            <%} %>
        </div>
        <div class="col-2"></div>
    </div>


</asp:Content>
