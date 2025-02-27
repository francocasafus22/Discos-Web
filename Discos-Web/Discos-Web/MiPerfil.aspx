<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Discos_Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["usuario"] != null)
        {%>
    <h1 class="text-center">Mi Perfil</h1>
    <div class="row align-items-center">
        <!-- Columna de la imagen -->
        <div class="col-md-4">
            <div class="mb-3">
                <label for="formPerfil" class="form-label">Imagen Perfil</label>
                <input class="form-control" type="file" id="formPerfil">
            </div>
            <div class="mb-3 text-center">
                <img src="https://placehold.org/500x500/FF0000/FFFFFF?text=Hola+Mundo" class="img-fluid rounded" alt="Imagen">
            </div>
        </div>

        <!-- Columna del formulario -->
        <div class="col-md-8">
            <div>
                <div class="mb-3">
                    <label for="txtMail" class="form-label">Email</label>
                    <input type="email" class="form-control" id="txtMail" placeholder="Ingrese su correo">
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <input type="text" class="form-control" id="txtNombre" placeholder="Ingrese su nombre">
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <input type="text" class="form-control" id="txtApellido" placeholder="Ingrese su apellido">
                </div>
                <div class="mb-3">
                    <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                    <input type="date" class="form-control" id="txtFechaNacimiento" placeholder="Ingrese su fecha de nacimiento">
                </div>
                <div class="mb-3">
                    <label for="password" class="form-label">Contraseña</label>
                    <input type="password" class="form-control" id="password" placeholder="Ingrese su contraseña">
                </div>
                <button type="submit" class="btn btn-primary">Enviar</button>
            </div>
        </div>
    </div>


    <%}
        else
        { %>
    <h1>No hay un usuario logueado.</h1>
    <%} %>
</asp:Content>
