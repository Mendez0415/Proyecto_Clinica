<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_Clinica.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center; padding: 20px;">
        <h2>Login</h2>
        <br />
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
        <br /><br />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
    </div>
</asp:Content>
