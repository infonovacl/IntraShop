<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Consultas_GestionCobranza.aspx.vb" Inherits="Consultas_GestionCobranza" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Gestion de Cobranza</title>
     
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
         }
         .auto-style13 {
             background-color: white;
         }
         </style>
     </head>
     <script type="text/javascript">
        function pageLoad(sender, e) {
            var objTpDummy =
                document.getElementById('<%= TabPanel5.ClientID %>' + '_tab');
                objTpDummy.style.display = 'none';
        }
        function clientActiveTabChanged(sender, args)
        {
            var myValue = sender.get_activeTabIndex();
            var label1 = document.getElementById('<%= LBL_TabIndice.ClientID %>');
            label1.innerHTML = myValue;                               
        darClick();
        }
        function darClick()
        {
            var objBoton = '<%=BTN_ProcesaTab.ClientID%>'
            var objO = document.getElementById(objBoton);
            objO.click();
        }      
    </script>
<body style="width: 694px; height: 4px;">
    <form id="form1" runat="server">
    <div class="auto-style12">       
        <asp:ScriptManager runat="server" ID="ScriptManager1">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">            
            <ContentTemplate>
                <cc3:TabContainer ID="Tab_GestionCobranza" runat="server" OnClientActiveTabChanged="clientActiveTabChanged" ActiveTabIndex="0" Height="510px" Width="680px">
                    <cc3:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1"><HeaderTemplate>Cobranza Telefónica</HeaderTemplate><ContentTemplate><asp:UpdatePanel ID="UpdatePanel19" runat="server"><ContentTemplate><asp:Panel ID="Panel_CobranzaTelefonica" runat="server" CssClass="panel_tab" Height="500px" ScrollBars="Vertical" Width="660px"><asp:GridView ID="Grilla_GestionTelefonica" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="641px"><Columns><asp:BoundField DataField="column3" DataFormatString="{0:d}" HeaderText="Fecha" /><asp:BoundField DataField="column4" HeaderText="Hora" /><asp:BoundField DataField="column5" HeaderText="Tipo Fono" /><asp:BoundField DataField="column6" HeaderText="Fono"><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="column7" HeaderText="Contacto"><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="column8" HeaderText="Gestión" /><asp:BoundField DataField="column9" DataFormatString="{0:d}" HeaderText="Fec. Compromiso" /><asp:BoundField DataField="column10" HeaderText="U. Gestión" /><asp:BoundField DataField="column11" HeaderText="Telecob" /></Columns></asp:GridView></asp:Panel></ContentTemplate></asp:UpdatePanel><asp:Label ID="LBL_CobranzaTelefonicaError" runat="server" CssClass="etiquetas_tab"></asp:Label><br /></ContentTemplate></cc3:TabPanel>
                    <cc3:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>U.A.C. - U.R.D.</HeaderTemplate></cc3:TabPanel>
                    <cc3:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3"><HeaderTemplate>Cobranza Externa</HeaderTemplate></cc3:TabPanel>
                    <cc3:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4"><HeaderTemplate>Dicom</HeaderTemplate></cc3:TabPanel>
                    <cc3:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5"><HeaderTemplate>PaloBlanco</HeaderTemplate></cc3:TabPanel>
                </cc3:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
                <asp:Label ID="LBL_DatosClienteError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                &nbsp;
                <asp:Label ID="LBL_TabIndice" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="BTN_ProcesaTab" runat="server" Text="Button" style="display:none"  />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                <table class="auto-style7" align="center">
                    <tr>
                        <td class="auto-style9"><asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" style="height: 26px" />                         
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                         
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" OnClientClick="javascript:window.close();" />
                        </td>
                    </tr>
                </table>
    </div>
    </form>
    </body>
</html>
