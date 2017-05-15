<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_FirmaDoc.aspx.vb" Inherits="Mantencion_FirmaDoc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <link href="Firma/demoButtons.css" rel="stylesheet" />
    <title>Mantención Datos Cliente - Firma Documentacion</title>        
    <script src="Firma/BigInt.js"></script>
    <script src="Firma/demobuttons.js"></script>
    <script src="Firma/demoButtons_encryption.js"></script>
    <script src="Firma/sjcl.js"></script>
   <script type="text/javascript">
      function initDemo() {
        var signatureForm = new SignatureForm(document.getElementById("signatureImageCON"));
        signatureForm.connect();
      }
      function signForm() {
          var _signatureImage = document.getElementById("signatureImageCON");    
          document.getElementById("_hdnSignature").value = _signatureImage.src;
          if (_signatureImage.src == "") {
              alert("FIRMA NO VÁLIDA, REINTENTE CAPTURAR FIRMA");
          }
          else {
              return true;
          }
      }
      function initDemoSV() {
          var signatureForm = new SignatureForm(document.getElementById("signatureImageSV"));
          signatureForm.connect();
      }
      function signFormSV(estado) {
          var _signatureImage = document.getElementById("signatureImageSV");
          document.getElementById("_hdnSignatureSV").value = _signatureImage.src;
          if (_signatureImage.src == "") {
              alert("FIRMA NO VÁLIDA, REINTENTE CAPTURAR FIRMA");
          }
          else {
              return true;
          }
      }
      function initDemoSP() {
          var signatureForm = new SignatureForm(document.getElementById("signatureImageSP"));
          signatureForm.connect();
      }
      function signFormSP(estado) {
          var _signatureImage = document.getElementById("signatureImageSP");        
          document.getElementById("_hdnSignatureSP").value = _signatureImage.src;
          if (_signatureImage.src == "") {
              alert("FIRMA NO VÁLIDA, REINTENTE CAPTURAR FIRMA");       
          }
          else {            
              return true;
          }
      }
      function initDemoPEP() {
          var signatureForm = new SignatureForm(document.getElementById("signatureImagePEP"));
          signatureForm.connect();
      }
      function signFormPEP(estado) {
          var _signatureImage = document.getElementById("signatureImagePEP");
          document.getElementById("_hdnSignaturePEP").value = _signatureImage.src;
          if (_signatureImage.src == "") {
              alert("FIRMA NO VÁLIDA, REINTENTE CAPTURAR FIRMA");
          }
          else {
              return true;
          }
      }
   </script>
     <style type="text/css">
         .auto-style7 {
             height: 28px;
             width: 628px;
             align: center;
         }         
         .auto-style9 {
             height: 20px;
             width: 700px;
             text-align: center;
             margin-left: 40px;
         }
         .auto-style12 {
             width: 690px;
             background-color: whitesmoke;
             height: 625px;
         }
                 
         .auto-style32 {
             height: 22px;
             width: 180px;
         }
         #signatureDiv0
         {
             height: 251px;
             width: 398px;
         }
         #signatureImage0
         {
             height: 244px;
             width: 349px;
         }
         #signatureImageSegProteccion
         {
             height: 200px;
             width: 420px;
         }
         #SegProteccion
         {
             width: 441px;
         }
         #signatureImageSV
         {
             height: 150px;
             width: 360px;
         }
         #SV
         {
             width: 451px;
         }
        
         #signatureImageSP
         {
             height: 150px;
             width: 360px;
         }
         #SP
         {
             width: 459px;
         }     
         #signatureImage
         {
             height: 150px;
             width: 360px;
         }
                 
         #signatureImageSP0
         {
             height: 150px;
             width: 360px;
         }
         #SP0
         {
             width: 459px;
         }     
         #signatureImageCON
         {
             height: 150px;
             width: 360px;
         }
         .style2
         {
             width: 99%;
             height: 11px;
             z-index: -1;
         }
         .style7
         {
             text-align: center;
         }
         .style1
         {
             height: 20px;
             width: 671px;
             margin-left: 80px;
             text-align: center;
         }
         .style12
         {
             width: 100%;
         }
         .style16
         {
             width: 319px;
         }
         .style17
         {
             width: 239px;
         }
         .auto-style33 {
             width: 308px;
             height: 17px;
         }
         .auto-style35 {
             font-family: Arial;
             font-size: 12px;
             font-weight: bold;
             color: black;
         }
         .auto-style36 {
             width: 124px;
             height: 17px;
         }
         .auto-style37 {
             width: 167px;
             height: 17px;
         }
         .auto-style38 {
             height: 17px;
         }
         .auto-style39 {
             position: absolute;
             left: 691px;
             top: 94px;
             width: 325px;
             height: 34px;
         }
         </style>
     </head>
<body style="width: 689px; height: 624px;">
    <form id="form1" runat="server">
    <div class="auto-style12">       
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:HyperLink ID="Link_DescargaWacom" runat="server" CssClass="etiquetas_cerrarsesion" NavigateUrl="~/Utiles/Wacom-STU-SDK-2.10.0.msi" ToolTip="Descargar Driver y SDK para PAD Wacom de Firmas">Descarga WacomSDK</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label78" runat="server" CssClass="etiquetas_titulo" 
                                    Text="FIRMA DOCUMENTACION FAMILYSHOP"></asp:Label>
                                <br />              
                        <asp:Panel ID="Panel_Central" runat="server" Height="450px">
                            &nbsp;<div class="style7">
                                <asp:RadioButtonList ID="RBL_Documentos" runat="server" AutoPostBack="True" CssClass="auto-style35" Height="16px" RepeatDirection="Horizontal" style="z-index: 1; " Width="678px">
                                    <asp:ListItem Enabled="False" Value="0">Contrato</asp:ListItem>
                                    <asp:ListItem Enabled="False" Value="1">Seguro Protección (Desgravamen)</asp:ListItem>
                                    <asp:ListItem Enabled="False" Value="2">Seguro Vida</asp:ListItem>
                                    <asp:ListItem Enabled="False" Value="3">P.E.P.</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div >
                                <table class="style2">
                                    <tr>
                                        <td class="auto-style37">
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="IMG_ContratoFirmado" runat="server" Height="25px" 
                                                ImageUrl="~/Imagenes/ok.png" Visible="False" Width="25px" />
&nbsp;
                                            <asp:Image ID="IMG_ContratoRechazado" runat="server" Height="25px" 
                                                ImageUrl="~/Imagenes/cancela.png" Visible="False" Width="25px" />
                                        </td>
                                        <td class="auto-style33">
                                            &nbsp;
                                            <asp:Image ID="IMG_SeguroProteccionFirmado" runat="server" Height="25px" 
                                                ImageUrl="~/Imagenes/ok.png" Visible="False" Width="25px" />
                                            &nbsp;&nbsp;
                                            <asp:Image ID="IMG_SeguroProteccionRechazado" runat="server" Height="25px" 
                                                ImageUrl="~/Imagenes/cancela.png" Visible="False" Width="25px" />
                                        </td>
                                        <td class="auto-style36">
                                            &nbsp;&nbsp;
                                            <asp:Image ID="IMG_SeguroVidaFirmado" runat="server" Height="25px" 
                                                ImageUrl="~/Imagenes/ok.png" Visible="False" Width="25px" />
                                            &nbsp;&nbsp;
                                            <asp:Image ID="IMG_SeguroVidaRechazado" runat="server" Height="25px" 
                                                ImageUrl="~/Imagenes/cancela.png" Visible="False" Width="25px" />
                                        </td>
                                        <td class="auto-style38">
                                            <asp:Image ID="IMG_PEPFirmado" runat="server" Height="25px" ImageUrl="~/Imagenes/ok.png" Visible="False" Width="25px" />
                                            &nbsp;
                                            <asp:Image ID="IMG_PEPRechazado" runat="server" Height="25px" ImageUrl="~/Imagenes/cancela.png" Visible="False" Width="25px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="LBL_DatosClienteError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>             
                <br />
                <table class="style12">
                    <tr>
                        <td style="text-align: center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones_ancho" 
                                Text="CERRAR" Width="110px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BTN_ImprimeTarjeta" runat="server" CssClass="botones_ancho" 
                                Text="TARJETA" Width="110px" Visible="False" />
                            <br />
                            <asp:HiddenField runat="server" ID="_hdnSignature"></asp:HiddenField>
                            <asp:HiddenField runat="server" ID="_hdnSignatureSV"></asp:HiddenField>                                                                                  
                            <asp:HiddenField runat="server" ID="_hdnSignatureSP"></asp:HiddenField>                                                                                  
                            <asp:HiddenField runat="server" ID="_hdnSignaturePEP"></asp:HiddenField>                                                                                  
                        </td>
                    </tr>
                </table>
              <div class="auto-style39">
                            <asp:MultiView ID="MultiView_FirmaDocs" runat="server">
                                <asp:View ID="ViewContrato" runat="server">
                                    <asp:Panel ID="Panel_IntroContrato" runat="server" Height="124px" Width="667px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label75" runat="server" CssClass="etiquetas_titulo" 
                                            Text="FIRMA CONTRATO "></asp:Label>
                                <br />
                                <br />
                                        <asp:TextBox ID="TXT_IntroContrato" runat="server" BorderStyle="None" 
                                            CssClass="etiquetas_introdoc" Height="80px" ReadOnly="True" Rows="3" 
                                            TextMode="MultiLine" Width="680px"></asp:TextBox>
                                <br />
                                        <table class="style2">
                                            <tr>
                                                <td class="style7">
                                                    <asp:Button ID="BTN_ContratoAcepta" runat="server" CssClass="botones_anchoX2" 
                                                        Height="22px" Text="ACEPTA" />
                                                </td>
                                                <td class="style7">
                                                    <asp:Button ID="BTN_RechazaContrato" runat="server" CssClass="botones_anchoX2" 
                                                        Height="22px" Text="RECHAZA" />
                                                </td>
                                            </tr>
                                        </table>
                                  
                                    </asp:Panel>
                                    <asp:Panel ID="Panel_FirmaContrato" runat="server" Height="68px" 
                                        Visible="False">
                                        <div ID="CON">
                                    <br />
                                            <asp:Label ID="Label80" runat="server" CssClass="etiquetas_popup" 
                                                Text="Firma Capturada "></asp:Label>
                                    <br/>
                                    <img id="signatureImageCON" border="1"/>
                                            <object ID="wgssSTUCON" type="application/x-wgssSTU">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </object>
                                        </div>
                                <br />
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="LBL_ContratoError" runat="server" 
                                                    CssClass="etiquetasmensajeerror"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                <br />
                                        <table align="center" class="auto-style7">
                                            <tr>
                                                <td class="style1">
                                            <input type="button" id="BTN_CAPFirmaCON" runat="server" value="CAPTURAR FIRMA" 
                                            onClick="javascript: initDemo()" class="auto-style32" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="BTN_FirmarContrato" runat="server" CssClass="botones_anchoX2" 
                                                        OnClientClick="javascript:return signForm();" Text="FIRMAR CONTRATO" />
                                                    <br />
                                                    &nbsp;&nbsp;<br />
                                                    <asp:LinkButton ID="LINK_VerPREContrato" runat="server">Ver Pre-Contrato</asp:LinkButton>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="LINK_VerContrato" runat="server" 
                                                        onclientclick="javascript:my_window=window.open('/Mantenciones/Mantenciones_VerContrato.aspx','VerContrato','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()">Ver Contrato</asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                    <br />
                                                    <br />
                                                    </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </asp:View>
                                <asp:View ID="ViewSeguroProteccion" runat="server">
                                    <asp:Panel ID="Panel_IntroSeguroProteccion" runat="server" Height="124px" 
                                        Width="667px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label76" runat="server" CssClass="etiquetas_titulo" 
                                            Text="FIRMA SEGURO PROTECCIÓN"></asp:Label>
                                <br />
                                <br />
                                        <asp:TextBox ID="TXT_IntroSeguroProteccion" runat="server" BorderStyle="None" 
                                            CssClass="etiquetas_introdoc" Height="80px" ReadOnly="True" Rows="3" 
                                            TextMode="MultiLine" Width="680px"></asp:TextBox>
                                <br />
                                        <table class="style2">
                                            <tr>
                                                <td class="style7">
                                                    <asp:Button ID="BTN_SeguroProteccionAcepta" runat="server" 
                                                        CssClass="botones_anchoX2" Height="22px" Text="ACEPTA" />
                                                </td>
                                                <td class="style7">
                                                    <asp:Button ID="BTN_RechazaSeguroProteccion" runat="server" 
                                                        CssClass="botones_anchoX2" Height="22px" Text="RECHAZA" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel_FirmaSeguroProteccion" runat="server" Height="68px" 
                                        Visible="False">
                                        <div ID="SP">
                                    <br />
                                            <asp:Label ID="Label74" runat="server" CssClass="etiquetas_popup" 
                                                Text="Firma Capturada "></asp:Label>
                                    <br/>
                                    <img id="signatureImageSP" border="1"/>
                                            <object ID="wgssSTUSP" type="application/x-wgssSTU">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </object>
                                        </div>
                                <br />
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="LBL_SeguroProteccionError" runat="server" 
                                                    CssClass="etiquetasmensajeerror"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                <br />
                                        <table align="center" class="auto-style7">
                                            <tr>
                                                <td class="auto-style9">
                                            <input type="button" id="BTN_CAPFirmaSP" runat="server" value="CAPTURAR FIRMA" 
                onClick="javascript: initDemoSP()" class="auto-style32" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="BTN_FirmarSP" runat="server" CssClass="botones_anchoX2" 
                                                        OnClientClick="javascript:return signFormSP();" Text="FIRMAR SEGURO" />
                                                    <br />
                                                    &nbsp;&nbsp;&nbsp;<br />
                                                    <asp:LinkButton ID="LINK_VerSP" runat="server" 
                                                        onclientclick="javascript:my_window=window.open('/Mantenciones/Mantenciones_VerSeguroProteccion.aspx','VerSeguroProteccion','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()">Ver Seguro Protección</asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </asp:View>
                        <br />
                                <asp:View ID="ViewSeguroVida" runat="server">
                                    <asp:Panel ID="Panel_IntroSeguroVida" runat="server" Height="124px" 
                                        Width="667px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                        <asp:Label ID="Label77" runat="server" CssClass="etiquetas_titulo" 
                                            Text="FIRMA SEGURO VIDA"></asp:Label>
                                <br />
                                <br />
                                        <asp:TextBox ID="TXT_IntroSeguroVida" runat="server" BorderStyle="None" 
                                            CssClass="etiquetas_introdoc" Height="80px" ReadOnly="True" Rows="3" 
                                            TextMode="MultiLine" Width="680px"></asp:TextBox>
                                <br />
                                        <table class="style2">
                                            <tr>
                                                <td class="style7">
                                                    <asp:Button ID="BTN_SeguroVidaAcepta" runat="server" CssClass="botones_anchoX2" 
                                                        Height="22px" Text="ACEPTA" />
                                                </td>
                                                <td class="style7">
                                                    <asp:Button ID="BTN_RechazaSeguroVida" runat="server" 
                                                        CssClass="botones_anchoX2" Height="22px" Text="RECHAZA" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel_FirmaSeguroVida" runat="server" Height="99px" 
                                        Visible="False">
                                        <div ID="SV">
                                    <br />
                                            <asp:Label ID="Label79" runat="server" CssClass="etiquetas_popup" 
                                                Text="Firma Capturada "></asp:Label>
                                    <br/>
                                    <img id="signatureImageSV" border="1"/>
                                            <object ID="wgssSTUSV" type="application/x-wgssSTU">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </object>
                                        </div>
                                <br />
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="LBL_SeguroVidaError" runat="server" 
                                                    CssClass="etiquetasmensajeerror"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                <br />
                                        <table align="center" class="auto-style7">
                                            <tr>
                                                <td class="auto-style9">
                                            <input type="button" id="BTN_CAPFirmaSV" runat="server" value="CAPTURAR FIRMA" 
                                            onClick="javascript: initDemoSV()" class="auto-style32"/>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="BTN_FirmarSV" runat="server" CssClass="botones_anchoX2" 
                                                        OnClientClick="javascript:return signFormSV();" Text="FIRMAR SEGURO" />
                                                    <br />
                                                    &nbsp;<br />
                                                    <asp:LinkButton ID="LINK_VerSV" runat="server" 
                                                        onclientclick="javascript:my_window=window.open('/Mantenciones/Mantenciones_VerSeguroVida.aspx','VerSeguroVida','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()">Ver Seguro Vida</asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </asp:View>
                                <asp:View ID="ViewPEP" runat="server">
                                    <asp:Panel ID="Panel_PEP" runat="server" Height="124px" Width="667px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label1" runat="server" CssClass="etiquetas_titulo" 
                                            Text="FIRMA P.E.P. "></asp:Label>
                                <br />
                                <br />
                                        <asp:TextBox ID="TXT_IntroPEP" runat="server" BorderStyle="None" 
                                            CssClass="etiquetas_introdoc" Height="80px" ReadOnly="True" Rows="3" 
                                            TextMode="MultiLine" Width="680px"></asp:TextBox>
                                <br />
                                        <table class="style2">
                                            <tr>
                                                <td class="style7">
                                                    <asp:Button ID="BTN_PEPAcepta" runat="server" CssClass="botones_anchoX2" 
                                                        Height="22px" Text="ACEPTA" />
                                                </td>
                                                <td class="style7">
                                                    <asp:Button ID="BTN_PEPRechaza" runat="server" CssClass="botones_anchoX2" 
                                                        Height="22px" Text="RECHAZA" />
                                                </td>
                                            </tr>
                                        </table>
                                  
                                    </asp:Panel>
                                    <asp:Panel ID="Panel_FirmaPEP" runat="server" Height="68px" 
                                        Visible="False">
                                        <div ID="PEP">
                                    <br />
                                            <asp:Label ID="Label2" runat="server" CssClass="etiquetas_popup" 
                                                Text="Firma Capturada "></asp:Label>
                                    <br/>
                                    <img id="signatureImagePEP" border="1"/>
                                            <object ID="wgssSTUPEP" type="application/x-wgssSTU">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </object>
                                        </div>
                                <br />
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="LBL_PEPError" runat="server" 
                                                    CssClass="etiquetasmensajeerror"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                <br />
                                        <table align="center" class="auto-style7">
                                            <tr>
                                                <td class="style1">
                                            <input type="button" id="BTN_CAPFirmaPEP" runat="server" value="CAPTURAR FIRMA" 
                                            onClick="javascript: initDemoPEP()" class="auto-style32" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="BTN_FirmarPEP" runat="server" CssClass="botones_anchoX2" 
                                                        OnClientClick="javascript:return signFormPEP();" Text="FIRMAR P.E.P." />
                                                    <br />
                                                    &nbsp;&nbsp;<br />
                                                    <asp:LinkButton ID="LINK_VerPEP" runat="server"                                                 
                                                        onclientclick="javascript:my_window=window.open('/Mantenciones/Mantenciones_VerPEP.aspx','VerContrato','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()">Ver P.E.P.</asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                    <br />
                                                    <br />
                                                    </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </asp:View>
                            </asp:MultiView>
                                        </div>
    </div>
    </form>
    </body>
</html>
