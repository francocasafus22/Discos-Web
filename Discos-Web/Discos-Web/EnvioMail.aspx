<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EnvioMail.aspx.cs" Inherits="Discos_Web.EnvioMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col">
            <div class="mb-3">
                <label for="txtMail" class="form-label">Mail</label>
                <asp:TextBox ID="txtMail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtAsunto" class="form-label">Asunto</label>
                <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtMensaje" class="form-label">Mensaje</label>
                <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnEnviarMail" runat="server" Text="Enviar" CssClass="btn btn-dark" OnClick="btnEnviarMail_Click"/>
            </div>
        </div>

    </div>

</asp:Content>
