<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_Tarjeta_Contrato.aspx.vb" Inherits="Mantencion_Tarjeta_Contrato" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Mantención Datos Cliente</title>
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
             width: 690px;
             background-color: whitesmoke;
             height: 600px;
         }
         </style>
     </head>
<body style="width: 694px; height: 313px;">
    <form id="form1" runat="server">
    <div class="auto-style12">       
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
                <asp:Label ID="LBL_DatosClienteError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                <table class="auto-style7" align="center">
                    <tr>
                        <td class="auto-style9"><asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />                         
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                         
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" OnClientClick="javascript:window.close();" />
                        </td>
                    </tr>
                </table>
    </div>
    </form>
    </body>
</html>
