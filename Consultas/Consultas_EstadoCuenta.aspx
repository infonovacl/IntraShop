<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Consultas_EstadoCuenta.aspx.vb" Inherits="Consultas_GestionCobranza" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Estados de Cuenta</title>
     <style type="text/css">
         .auto-style12 {
             width: 678px;
             background-color: whitesmoke;
             height: 637px;
         }
         .style1
         {
             width: 100%;
         }
         .style2
         {
             width: 97px;
         }
         .style3
         {
             width: 354px;
         }
         .style4
         {
             width: 31px;
         }
         .auto-style13 {
             width: 111px;
             height: 28px;
         }
         .auto-style16 {
             width: 97px;
             height: 28px;
         }
         .auto-style17 {
             height: 28px;
         }
         .auto-style18 {
             width: 97%;
             height: 190px;
         }
         .auto-style20 {
             width: 251px;
             height: 28px;
         }
         .auto-style21 {
             text-align: center;
             height: 26px;
         }
         .auto-style22 {
             height: 450px;
         }
         .auto-style23 {
             height: 28px;
             text-align: center;
         }
         </style>
     </head>
     <script type="text/javascript">
                function CierraVentana() {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.dispose();
            self.close();      
        }
    </script>
<body style="width: 694px; height: 4px;">
    <form id="form1" runat="server">
    <div class="auto-style12">       
        <asp:ScriptManager runat="server" ID="ScriptManager1" EnableViewState="False" 
            LoadScriptsBeforeUI="False" ScriptMode="Release" AsyncPostBackTimeout="0">
        </asp:ScriptManager>       
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="20">
            <ProgressTemplate>
                <div class="update">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                
                <asp:Label ID="LBL_TabIndice" runat="server" CssClass="etiquetas" style="display:none"></asp:Label>
                <table class="auto-style18">
                    <tr>
                        <td class="auto-style23" colspan="4">
                            <asp:Label ID="Label2" runat="server" CssClass="etiquetas" Text="FACTURACIONES CLIENTE"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style16"></td>
                        <td class="auto-style13">
                            <asp:Label ID="Label1" runat="server" CssClass="etiquetas" Text="Facturaciones "></asp:Label>
                        </td>
                        <td class="auto-style20">
                            <asp:DropDownList ID="DDL_Facturaciones" runat="server" AutoPostBack="True" CssClass="dropdown_tab" DataTextFormatString="{0:dd/MM/yyyy}" ViewStateMode="Enabled" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style17">
                            <asp:Button ID="BTN_VerEECC" runat="server" CssClass="botones" Text="OBTENER EECC" Width="130px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="LBL_FacturacionesError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="auto-style22">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>      
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21" colspan="4">
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" onclientclick="CierraVentana();return false;" Text="CERRAR" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="Grilla_TramaEECC" runat="server" AutoGenerateColumns="False" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="column3" HeaderText="Trama " />
                    </Columns>
                </asp:GridView>
                <br />
                                         </ContentTemplate>             
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_VerEECC" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>  
    </div>   
    </form>
    </body>
</html>
