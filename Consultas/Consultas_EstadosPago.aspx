<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Consultas_EstadosPago.aspx.vb" Inherits="Consultas_EstadosPago" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Aumento de Linea Credito</title>
     <style type="text/css">      
         .auto-style1 {
             width: 346px;
             height: 12px;
             left: 5px;
         }
         .auto-style3 {
             width: 345px;
               left: 5px;
         }
         .auto-style4 {
             text-align: center;
             height: 34px;
         }
         .auto-style5 {
             width: 99%;
             height: 156px;
         }
         .auto-style7 {
             width: 340px;
             background-color: whitesmoke;
             height: 250px;
         }
         .auto-style9 {
             width: 344px;
             left: 5px;
         }
         .auto-style10 {
             text-align: center;
         }
         </style>
    </head>
<body style="width: 761px; height: 6px; left: 5px;">
    <form id="form1" runat="server" class="auto-style1">
    <div class="auto-style7">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="20">
            <ProgressTemplate>
                <div class="update">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
            <ContentTemplate>
                <table cellspacing="1" class="auto-style5">
                    <tr>
                        <td class="auto-style10">
                            <asp:Label ID="Label2" runat="server" CssClass="etiquetas_tab" Text="Día de Pago Actual"></asp:Label>
                        </td>
                        <td class="auto-style10">
                            <asp:Label ID="LBL_FechaSolicitud" runat="server" CssClass="etiquetas_tab">Día de Pago Nuevo</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            <asp:TextBox ID="TXT_DiaActualPago" runat="server" Enabled="False" Width="50px"></asp:TextBox>
                        </td>
                        <td class="auto-style10">
                            <asp:DropDownList ID="DDL_NuevoDiaPago" runat="server" CssClass="dropdown_tab" Width="70px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table class="auto-style9">
                    <tr>
                        <td>                            
                            <asp:Label ID="LBL_CambioDiaPagoError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                        </td>
                    </tr>
                </table>             
                        <table class="auto-style3">
                            <tr>
                                <td class="auto-style4">                                   
                                    <asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" OnClientClick="javascript:window.close();" Text="CERRAR" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>             
        </asp:UpdatePanel>                            
        <br />    
    </div>
    </form>
    </body>
</html>
