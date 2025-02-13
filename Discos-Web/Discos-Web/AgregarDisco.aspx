<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarDisco.aspx.cs" Inherits="Discos_Web.AgregarDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row g-3">
        <figure class="text-center">
            <asp:Label ID="lblTitulo" runat="server" Text="hh" CssClass="display-5"></asp:Label>
        </figure>

        <div class="col-md-2">
            <label for="txtId" class="form-label">Id:</label>
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-5">
            <label for="txtTitulo" class="form-label">Titulo:</label>
            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-5">
            <label for="txtFecha" class="form-label">Fecha de Lanzamiento:</label>
            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label for="txtCanciones" class="form-label">Canciones</label>
            <asp:TextBox ID="txtCanciones" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-5">
            <label for="ddlTipo" class="form-label">Tipo:</label>
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="col-md-5">
            <label for="ddlEstilo" class="form-label">Estilo:</label>
            <asp:DropDownList ID="ddlEstilo" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col-12">
                    <label for="txtImagen" class="form-label">Url Imagen:</label>
                    <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" OnTextChanged="txtImagen_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>

                <div class="col-12">
                    <asp:Image ID="img_Disco" runat="server" CssClass="mt-3 d-block mx-auto" Width="30%" ImageUrl="https://imgs.search.brave.com/p-yZANTOLgHYlaDNBQ5r7caAKbb7fRxZuTL2EHy5uDs/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9mYWtl/aW1nLnBsLzYwMHg0/MDA.jpeg" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="row g-3">
                    <div class="col-md-12">
                        <div class="mb-3">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-dark" />
                            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-danger" OnClick="btnBorrar_Click" />
                            <asp:Button ID="btnInactivo" runat="server" Text="Inactivar" CssClass="btn btn-warning" OnClick="btnInactivo_Click" />
                            <%if (ConfirmarEliminacion)
                              { %>
                            <asp:CheckBox ID="cbConfirmar" runat="server" Text="Confirmar Eliminacion" />
                            <asp:Button ID="btnBorrarConfirmado" runat="server" Text="Borrar" CssClass="btn btn-outline-danger" OnClick="btnBorrarConfirmado_Click"/>
                            <%} %>
                        </div>
                    </div>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>
