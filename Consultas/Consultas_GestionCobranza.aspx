﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Consultas_GestionCobranza.aspx.vb" Inherits="Consultas_GestionCobranza" %>
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
             height: 619px;
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
                <cc3:TabContainer ID="Tab_GestionCobranza" runat="server" 
            OnClientActiveTabChanged="clientActiveTabChanged" ActiveTabIndex="0" 
            Height="510px" Width="680px">
                    <cc3:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1"><HeaderTemplate>
Cobranza Telefónica
</HeaderTemplate>
<ContentTemplate>
    <asp:Panel ID="Panel_CobranzaTelefonica" runat="server" CssClass="panel_tab" 
        Height="500px" ScrollBars="Vertical" Width="670px">
        <asp:GridView ID="Grilla_GestionTelefonica" runat="server" 
            AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
            Width="651px"><Columns>
<asp:BoundField DataField="column3" DataFormatString="{0:d}" HeaderText="Fecha">
<ItemStyle Width="60px" />
</asp:BoundField>
<asp:BoundField DataField="column4" HeaderText="Hora" />
<asp:BoundField DataField="column5" HeaderText="Tipo Fono" >
<ItemStyle Width="40px" />
</asp:BoundField>
<asp:BoundField DataField="column6" HeaderText="Fono">
<ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
<asp:BoundField DataField="column7" HeaderText="Contacto">
<ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
<asp:BoundField DataField="column8" HeaderText="Gestión" />
<asp:BoundField DataField="column9" DataFormatString="{0:d}" 
                    HeaderText="Fecha Comp.">
<ItemStyle Width="80px" />
</asp:BoundField>
<asp:BoundField DataField="column10" HeaderText="U. Gestión" />
<asp:BoundField DataField="column11" HeaderText="Telecob" />
</Columns>
</asp:GridView>
    </asp:Panel>
    <asp:Label ID="LBL_CobranzaTelefonicaError" runat="server" CssClass="etiquetas_tab"></asp:Label>
</ContentTemplate>
</cc3:TabPanel>
                    <cc3:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>
U.A.C. - U.R.D.
</HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_CobranzaUnidad" runat="server" CssClass="panel_tab" Height="500px" ScrollBars="Vertical" Width="660px">
                                <asp:GridView ID="Grilla_GestionUnidad" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="641px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" DataFormatString="{0:d}" HeaderText="Fecha" />
                                        <asp:BoundField DataField="column4" HeaderText="Hora" />
                                        <asp:BoundField DataField="column5" HeaderText="Ejecutivo" />
                                        <asp:BoundField DataField="column6" HeaderText="Gestión" />
                                        <asp:BoundField DataField="column7" HeaderText="U. Gestión" />
                                        <asp:BoundField DataField="column8" HeaderText="Acción" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_CobranzaUnidadError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                        
</ContentTemplate>

</cc3:TabPanel>
                    <cc3:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3"><HeaderTemplate>
Cobranza Externa
</HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_CobranzaExterna" runat="server" CssClass="panel_tab" Height="500px" ScrollBars="Vertical" Width="660px">
                                <asp:GridView ID="Grilla_CobranzaExterna" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="641px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" DataFormatString="{0:d}" HeaderText="Fecha" />
                                        <asp:BoundField DataField="column4" HeaderText="Hora" />
                                        <asp:BoundField DataField="column5" HeaderText="Empresa C. Ext." />
                                        <asp:BoundField DataField="column6" DataFormatString="{0:d}" HeaderText="Fecha de Pago" />
                                        <asp:BoundField DataField="column7" HeaderText="Unidad Origen" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_CobranzaExternaError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                        
</ContentTemplate>

</cc3:TabPanel>
                    <cc3:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4"><HeaderTemplate>
Dicom
</HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_CobranzaDicom" runat="server" CssClass="panel_tab" Height="500px" ScrollBars="Vertical" Width="660px">
                                <asp:GridView ID="Grilla_CobranzaDicom" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="641px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" DataFormatString="{0:d}" HeaderText="Fecha Envío" />
                                        <asp:BoundField DataField="column4" DataFormatString="{0:d}" HeaderText="Fecha Venc. Docto." />
                                        <asp:BoundField DataField="column5" HeaderText="Morosidad">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column6" DataFormatString="{0:N0}" HeaderText="Nro. Boleta">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column7" DataFormatString="{0:N0}" HeaderText="Monto Deuda">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_CobranzaDicomError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                        
</ContentTemplate>

</cc3:TabPanel>
                    <cc3:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5"><HeaderTemplate>
PaloBlanco
</HeaderTemplate>
</cc3:TabPanel>
                </cc3:TabContainer>
                
                <asp:Label ID="LBL_TabIndice" runat="server" CssClass="etiquetas" style="display:none"></asp:Label>
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
