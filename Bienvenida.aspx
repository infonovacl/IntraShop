<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Bienvenida.aspx.vb" Inherits="Bienvenida" MasterPageFile="~/Maestro.master" %>

<asp:Content ID="Contenido1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel1" runat="server" style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Bienvenidos a Sistema" CssClass="auto-style1"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" CssClass="auto-style1" Text="Administrativo Web"></asp:Label>
        </asp:Panel>
</asp:Content>
