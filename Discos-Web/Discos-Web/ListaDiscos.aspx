<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaDiscos.aspx.cs" Inherits="Discos_Web.ListaDiscos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>discos</h1>
    <asp:GridView ID="dgvDiscos" runat="server" CssClass="table" AutoGenerateColumns="false"
         DataKeyNames="Id" OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged"
         AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvDiscos_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
            <asp:BoundField HeaderText="Canciones" DataField="Cant_Canciones" />
            <asp:BoundField HeaderText="Estilo" DataField="Estilo_Disco.Descripcion" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo_Disco.Descripcion" />
            <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Acción" />
        </Columns>
    </asp:GridView>
    <a href="AgregarDisco.aspx" class="btn btn-dark">Agregar</a>
</asp:Content>
