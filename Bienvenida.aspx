<%@ Page Title="" Language="VB" MasterPageFile="~/Maestro.master" AutoEventWireup="false" CodeFile="Bienvenida.aspx.vb" Inherits="_Default" %>
<%@ MasterType virtualpath="~/Maestro.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/EstilosShop.css" rel="stylesheet" />
    <script type="text/javascript">
function validar_rut(source, arguments) {
   // document.getElementById("LBL_LoginError").innerHTML = ""; //limpia label error
    var rut = arguments.Value; suma = 0; mul = 2; i = 0;
    for (i = rut.length - 3; i >= 0; i--) {
        suma = suma + parseInt(rut.charAt(i)) * mul;
        mul = mul == 7 ? 2 : mul + 1;
    }
    var dvr = '' + (11 - suma % 11);
    if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

    if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
        arguments.IsValid = false;
    else
        arguments.IsValid = true;
}
</script>
      <asp:Panel ID="Panel1" runat="server" style="text-align: center" Height="97px">
            <h1>
                <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Bienvenidos a Sistema"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" CssClass="auto-style1" Text="Administrativo Web"></asp:Label>
            </h1>
            <p>
                </p>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" DestinationPageUrl="~/Cliente.aspx" DisplayRememberMe="False" Font-Names="Verdana" Font-Size="11pt" ForeColor="#333333" Height="187px" style="font-size: 12pt" Width="760px">
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <LabelStyle CssClass="etiquetas" />
                        <LayoutTemplate>
                            <table cellpadding="4" cellspacing="0" style="border-collapse:collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0" style="height:187px;width:760px;">
                                            <tr>
                                                <td align="center" colspan="3" style="color:White;background-color:#5D7B9D;font-size:0.9em;font-weight:bold;">Iniciar Sesión</td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="etiquetas" style="width: 271px">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="etiquetasimportante">Usuario :</asp:Label>
                                                </td>
                                                <td style="width: 309px; text-align: left;">&nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="etiquetas" Font-Size="11pt" Width="120px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validar_rut" ControlToValidate="UserName" CssClass="etiquetasmensaje" Display="Dynamic" ErrorMessage="  RUT NO ES VÁLIDO" SetFocusOnError="True" ValidationGroup="login"></asp:CustomValidator>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ClientvalidationFunction="validar_rut" ControlToValidate="UserName" CssClass="etiquetasmensaje" ErrorMessage="User Name is required." ForeColor="Red" ToolTip="User Name is required." ValidationGroup="Login1">Debe Ingresar Usuario</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="etiquetas" style="width: 271px">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="etiquetasimportante">Password:</asp:Label>
                                                </td>
                                                <td style="width: 309px; text-align: left;">&nbsp;&nbsp;&nbsp; 
                                                    <asp:TextBox ID="Password" runat="server" CssClass="etiquetas" Font-Size="11pt" TextMode="Password" Width="120px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp; </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" CssClass="etiquetasmensaje" ErrorMessage="Password is required." ForeColor="Red" ToolTip="Password is required." ValidationGroup="Login1">Debe Ingresar Contraseña</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="color:Red; height: 29px;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center">
                                                    <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" CssClass="etiquetasimportante" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" Height="30px" Text="Iniciar Sesión" ValidationGroup="Login1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CssClass="etiquetas" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" Height="30px" />
                        <TextBoxStyle CssClass="etiquetas" Font-Size="11pt" />
                        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                    </asp:Login>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
</asp:Content>
