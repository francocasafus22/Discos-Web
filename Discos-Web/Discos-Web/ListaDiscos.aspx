<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaDiscos.aspx.cs" Inherits="Discos_Web.ListaDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <h1>Discos</h1>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-4">
                    <div class="mb-3">
                        <asp:Label ID="lblBuscar" runat="server" Text="FIltrar:"></asp:Label>
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end">
                    <div class="mb-3">
                        <asp:CheckBox ID="cbAvanzado" runat="server" Text="Filtro Avanzado" CssClass="" AutoPostBack="true" OnCheckedChanged="cbAvanzado_CheckedChanged"/>
                    </div>
                </div>

            </div>
            <%if (cbAvanzado.Checked)
                { %>
            <div class="row g-3 mb-3">
                <div class="col-md-3">
                    <asp:Label ID="lblCampo" runat="server" Text="Campo"></asp:Label>
                    <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Titulo"></asp:ListItem>
                        <asp:ListItem Text="Tipo"></asp:ListItem>
                        <asp:ListItem Text="Estilo"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblCriterio" runat="server" Text="Criterio"></asp:Label>
                    <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblFiltro" runat="server" Text="Filtro"></asp:Label>
                    <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Estado" runat="server" Text="Estado"></asp:Label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Cualquiera"></asp:ListItem>
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-dark" OnClick="btnBuscar_Click" />
                </div>
            </div>
            <%} %>
            <asp:GridView ID="dgvDiscos" runat="server" CssClass="table" AutoGenerateColumns="false"
                DataKeyNames="Id" OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged"
                AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvDiscos_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                    <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                    <asp:BoundField HeaderText="Canciones" DataField="Cant_Canciones" />
                    <asp:BoundField HeaderText="Estilo" DataField="Estilo_Disco.Descripcion" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo_Disco.Descripcion" />
                    <asp:CheckBoxField HeaderText="Estado" DataField="Estado" />
                    <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Acción" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="AgregarDisco.aspx" class="btn btn-dark">Agregar</a>
</asp:Content>
