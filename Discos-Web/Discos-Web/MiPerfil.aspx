<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Discos_Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (tienda.Seguridad.SesionActiva(Session["usuario"]))
        {%>
    <h1 class="text-center">Mi Perfil</h1>
    <div class="row align-items-center">
        <!-- Columna de la imagen -->
        <div class="col-md-4">
            <div class="mb-3">
                <label for="formPerfil" class="form-label">Imagen Perfil</label>
                <input class="form-control" type="file" id="txtPerfil" runat="server">
            </div>
            <div class="mb-3 text-center">
                <asp:Image ID="NewProfileImage" runat="server" CssClass="img-fluid rounded" />
            </div>
        </div>

        <!-- Columna del formulario -->
        <div class="col-md-8">
            <div>
                <div class="mb-3">
                    <label for="txtMail" class="form-label">Email</label>
                    <asp:TextBox CssClass="form-control" ID="txtMail" runat="server" Enabled="false"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="validacion" />
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ErrorMessage="Solo se permiten números" ValidationExpression="^\d+$" ControlToValidate="txtApellido" runat="server" />
                    <%--<asp:RangeValidator ErrorMessage="Fuera de rango..." ControlToValidate="txtApellido" MinimumValue="1" Type="" MaximumValue="50" runat="server" CssClass="validacion" />--%>
                    <%--<asp:RequiredFieldValidator ErrorMessage="Apellido requerido" ControlToValidate="txtApellido" runat="server" CssClass="validacion" />--%>
                </div>
                <div class="mb-3">
                    <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                    <asp:TextBox CssClass="form-control" ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-dark" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-dark" />
            </div>
        </div>
    </div>


    <%}
        else
        { %>
    <h1>No hay un usuario logueado.</h1>
    <%} %>
</asp:Content>
