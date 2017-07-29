<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_VerContrato.aspx.vb" Inherits="VerContrato" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" /> 
    <title>Mantención Datos Cliente - Ver Contrato</title>       
     <style type="text/css">
         .auto-style7 {
             height: 30px;
             width: 600px;
             align: center;
         }         
         .auto-style9 {
             height: 20px;
             width: 671px;
             text-align: center;
         }
         .auto-style12 {
             width: 601px;
             background-color: whitesmoke;
             height: 625px;
         }
         </style>
     </head>
<body style="width: 600px; height: 620px;">
    <form id="form1" runat="server">
    <div class="auto-style12">       
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />   
                <asp:Label ID="LBL_VerPDFError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                <table class="auto-style7" align="center">
                    <tr>
                        <td class="auto-style9">                        
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" />                           
                            <br />
                        </td>
                    </tr>
                </table>
    </div>
    </form>
    </body>
</html>
