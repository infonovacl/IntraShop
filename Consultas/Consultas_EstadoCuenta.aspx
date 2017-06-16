<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Consultas_EstadoCuenta.aspx.vb" Inherits="Consultas_GestionCobranza" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Estados de Cuenta</title>
     <style type="text/css">
         .auto-style7 {
             height: 8px;
             width: 667px;
             align: center;
         }         
         .auto-style9 {
             height: 20px;
             width: 671px;
             text-align: center;
         }
         .auto-style12 {
             width: 641px;
             background-color: whitesmoke;
             height: 619px;
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
         }
         .auto-style20 {
             width: 251px;
             height: 28px;
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
                        <td class="auto-style16">
                            &nbsp;</td>
                        <td class="auto-style13">
                            &nbsp;</td>
                        <td class="auto-style20">
                            <asp:Label ID="Label2" runat="server" CssClass="etiquetas" Text="FACTURACIONES CLIENTE"></asp:Label>
                        </td>
                        <td class="auto-style17">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style16">&nbsp;</td>
                        <td class="auto-style13">&nbsp;</td>
                        <td class="auto-style20">&nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
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
                            <asp:Button ID="BTN_VerEECC" runat="server" CssClass="botones" Text="OBTENER EECC" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">&nbsp;</td>
                        <td colspan="2">
                            <asp:Label ID="LBL_FacturacionesError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">&nbsp;</td>
                        <td colspan="2">
                            <asp:Label ID="LBL_EECCError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="Grilla_TramaEECC" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="column3" HeaderText="Trama " />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                                    <asp:Button ID="BTN_ProcesaTab" runat="server" Text="Button" style="display:none"  />
                                         </ContentTemplate>             
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_ProcesaTab" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>  
                <table class="auto-style7" align="center">
                    <tr>
                        <td class="auto-style9">                    
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" 
                                onclientclick="CierraVentana();return false;" />
                        </td>
                    </tr>
                </table>
    </div>   
    </form>
    </body>
</html>
