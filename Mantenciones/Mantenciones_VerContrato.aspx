<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_VerContrato.aspx.vb" Inherits="Mantencion_Tarjetas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <link href="Firma/demoButtons.css" rel="stylesheet" />
    <title>Mantención Datos Cliente - Tarjetas</title>    
    <script src="Firma/BigInt.js"></script>
    <script src="Firma/demobuttons.js"></script>
    <script src="Firma/demoButtons_encryption.js"></script>
    <script src="Firma/sjcl.js"></script>
   <script type="text/javascript">
      function initDemo() {
        var signatureForm = new SignatureForm(document.getElementById("signatureImage"));
        signatureForm.connect();
      }
      function signForm() {
          var _signatureImage = document.getElementById("signatureImage");
         // var _hdnSignature = $("input[id$='_hdnSignature']");
          document.getElementById("_hdnSignature").value = _signatureImage.src;
          return true;
      }
    </script>
     <style type="text/css">
         .auto-style7 {
             height: 30px;
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
             height: 625px;
         }
         </style>
     </head>
<body style="width: 694px; height: 624px;">
    <form id="form1" runat="server">
    <div class="auto-style12">       
        <asp:ScriptManager runat="server" ID="ScriptManager1">
        </asp:ScriptManager>
                <asp:Label ID="LBL_DatosClienteError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                <table class="auto-style7" align="center">
                    <tr>
                        <td class="auto-style9"><asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />                         
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                         
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" Text="CONTRATO" CssClass="botones" Width="100px" ID="BTN_Contrato"></asp:Button>

                            <asp:HiddenField runat="server" ID="_hdnSignature"></asp:HiddenField>

                            <br />
                        </td>
                    </tr>
                </table>
    </div>
    </form>
    </body>
</html>
