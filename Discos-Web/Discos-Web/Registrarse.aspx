<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Discos_Web.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-12">
            <h1 class="text-center mb-3">Sign Up</h1>
        </div>
        <div class="col-2"></div>
        <div class="col-8">
            <div class="mb-3">
                <label for="txtMail" class="form-label">Mail</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtMail"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtUser" class="form-label">Usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUser"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarme" CssClass="btn btn-dark" OnClick="btnRegistrarse_Click"/>
        </div>
        <div class="col-2"></div>
    </div>

</asp:Content>
