<%@ Page Title="" Language="VB" MasterPageFile="~/Maestro.master" AutoEventWireup="false" CodeFile="Bienvenida.aspx.vb" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/EstilosShop.css" rel="stylesheet" />
      <asp:Panel ID="Panel1" runat="server" style="text-align: center" Height="97px">
            <h1>
                <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Bienvenidos a Sistema"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" CssClass="auto-style1" Text="Administrativo Web"></asp:Label>
            </h1>
            <br />
            <div style="text-align: left">
                <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" DestinationPageUrl="~/Cliente.aspx" DisplayRememberMe="False" Font-Names="Verdana" Font-Size="11pt" ForeColor="#333333" Height="187px" style="font-size: 12pt" Width="760px">
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <LabelStyle CssClass="etiquetas" />
                    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CssClass="etiquetas" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" Height="30px" />
                    <TextBoxStyle CssClass="etiquetas" Font-Size="11pt" />
                    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                </asp:Login>
            </div>
            <br />
            <br />
        </asp:Panel>
</asp:Content>
