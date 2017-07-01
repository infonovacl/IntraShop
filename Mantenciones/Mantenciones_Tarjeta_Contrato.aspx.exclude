<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_Tarjeta_Contrato.aspx.vb" Inherits="Mantencion_Tarjeta_Contrato" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <link href="Firma/demoButtons.css" rel="stylesheet" />
    <title>Mantención Datos Cliente</title>  
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
             height: 422px;
         }
         .auto-style14 {
             width: 286px;
             height: 124px;
         }
         .auto-style15 {
             width: 147px;
         }
         </style>
     </head>
<body style="width: 694px; height: 398px;">
    <form id="form1" runat="server">
    <div class="auto-style12">       
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
         <div>
            <div id="signatureDiv">
                 Firma capturada:<br/>
            <img id="signatureImage"/>            
            </div>     
             <br />          
        </div>
                <br />            
                <table class="auto-style7" align="center">
                    <tr>
                        <td class="auto-style9">
                <asp:Label ID="LBL_DatosClienteError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />                         
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" id="signButton" value="CAPTURAR FIRMA" onClick="javascript: initDemo()" class="auto-style15"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BTN_Firmar" runat="server" CssClass="botones" Text="FIRMAR" OnClientClick="javascript:return signForm();" />
                            &nbsp;&nbsp;&nbsp;                         
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" OnClientClick="javascript:window.close();" />
                            <asp:HiddenField ID="_hdnSignature"  runat="server" />
                        </td>
                    </tr>
                </table>
    </div>  
         <object id="wgssSTU" type="application/x-wgssSTU"></object>
    </form>
    </body>
</html>
