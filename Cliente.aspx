<%@ Page Language="VB" MasterPageFile="~/Maestro.master" EnableViewState="true" AutoEventWireup ="false" CodeFile="Cliente.aspx.vb" Inherits="Cliente" %>
<%@ MasterType virtualpath="~/Maestro.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <link href="css/EstilosShop.css" rel="stylesheet" />
    <script type="text/javascript">
        function pageLoad(sender, e) {
            var objTpDummy =
                document.getElementById('<%= TabPanel17.ClientID %>' + '_tab');
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
    <div>   
        <table class="tablas">
            <tr>
                <td class="auto-style3" style="width: 2997px; ">
                    <asp:Label ID="Label1" runat="server" Text="Rut Cliente :" CssClass="etiquetas"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TXT_ConsultaRutCliente" runat="server" CssClass="cajastextoparametro" Width="73px">9608468</asp:TextBox>
                    &nbsp;<asp:Label ID="Label26" runat="server" Text="-" CssClass="etiquetas"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="TXT_ConsultaDV" runat="server" MaxLength="1" Width="16px" CssClass="cajastextoparametro">4</asp:TextBox>
                </td>
                <td class="auto-style3" style="width: 2997px; text-align: center;">
                    <asp:Button ID="BTN_Buscar" runat="server" Text="BUSCAR" Height="26px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BTN_Limpiar" runat="server" Text="LIMPIAR" CssClass="botones" />
                </td>
                <td class="auto-style3" style="width: 1020px; ">
                    <asp:TextBox ID="TXT_ConsultaNombreCompleto" runat="server" Width="260px" CssClass="cajastextoparametro"></asp:TextBox>
                </td>
            </tr>
        </table>    
    </div>
        <div>
            <table class="tablas">
                <tr>
                    <td style="width: 82px">
                        <asp:Label ID="Label2" runat="server" Text="Tienda " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaNumeroSucursal" runat="server" CssClass="cajastexto" Width="50px"></asp:TextBox>
                    </td>
                    <td style="width: 64px">
                        <asp:TextBox ID="TXT_ConsultaNombreSucursal" runat="server" CssClass="cajastexto" Width="160px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Folio Contrato " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td style="width: 88px">
                        <asp:TextBox ID="TXT_ConsultaFolioContrato" runat="server" CssClass="cajastexto" Width="80px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Última Mantención " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaFechaUltimaMantención" runat="server" CssClass="cajastexto" Width="90px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px; width: 82px;">
                        <asp:Label ID="Label3" runat="server" Text="Estado Cliente " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td colspan="2" style="height: 20px">
                        <asp:TextBox ID="TXT_ConsultaEstadoGeneral" runat="server" Width="230px" CssClass="cajastexto"></asp:TextBox>
                    </td>
                    <td style="height: 20px">
                        <asp:Label ID="Label5" runat="server" Text="Fecha " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td style="height: 20px; width: 88px;">
                        <asp:TextBox ID="TXT_ConsultaFechaEstadoGeneral" runat="server" CssClass="cajastexto" Width="80px"></asp:TextBox>
                        </td>
                    <td colspan="2" style="height: 20px; text-align: center;">
                    <asp:Label ID="LBL_MensajeContratos" runat="server" CssClass="etiquetasmensaje"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table class="tablas">
            <tr>
                <td>
                        <asp:Label ID="Label7" runat="server" Text="Día de Pago " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaDiaPago" runat="server" Width="100px" CssClass="cajastextonumerico"></asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label11" runat="server" Text="Fecha pago " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaFechaPago" runat="server" CssClass="cajastexto" Width="120px"></asp:TextBox>
                </td>
                <td style="text-align: right">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label15" runat="server" Text="Días de Mora " CssClass="etiquetas"></asp:Label>
                    </td>
                <td style="text-align: right">
                    <asp:TextBox ID="TXT_ConsultaDiasMora" runat="server" CssClass="cajastextonumerico" Width="100px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label8" runat="server" Text="Línea de Crédito " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaLineaCredito" runat="server" Width="100px" CssClass="cajastextonumerico">0</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label12" runat="server" Text="A pago " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaMontoAPago" runat="server" CssClass="cajastextonumerico" Width="120px">0</asp:TextBox>
                </td>
                <td>
                        &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label9" runat="server" Text="Cupo Disponible " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaCupoDisponible" runat="server" Width="100px" CssClass="cajastextonumerico">0</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label13" runat="server" Text="Pagos del Período " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaPagosPeriodo" runat="server" CssClass="cajastextonumerico" Width="120px">0</asp:TextBox>
                </td>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="LBL_MensajeAvance" runat="server" CssClass="etiquetasmensaje"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label10" runat="server" Text="Total deuda  " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaTotalDeuda" runat="server" Width="100px" CssClass="cajastextonumerico">0</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label14" runat="server" Text="Saldo " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaSaldo" runat="server" CssClass="cajastextonumerico" Width="120px">0</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="LBL_TabIndice" runat="server" CssClass="etiquetas" style="display:none"></asp:Label>
                    </td>
                <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="BTN_ProcesaTab" runat="server" Text="Button" style="display:none"  />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table class="tablas">
            <tr>
                <td>
                        <asp:Label ID="Label16" runat="server" Text="Calle " CssClass="etiquetas"></asp:Label>
                    </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TXT_ConsultaDireccCalle" runat="server" Width="220px" CssClass="cajastexto"></asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label19" runat="server" Text="Número " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaDireccNumero" runat="server" Width="82px" CssClass="cajastextonumerico"></asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label22" runat="server" Text="Depto. " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaDireccDepto" runat="server" Width="65px" CssClass="cajastextonumerico"></asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label23" runat="server" Text="Teléfono Particular " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaTeleFonoParticular" runat="server" Width="100px" CssClass="cajastexto"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label17" runat="server" Text="Villa " CssClass="etiquetas"></asp:Label>
                    </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TXT_ConsultaDireccVilla" runat="server" Width="220px" CssClass="cajastexto"></asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label20" runat="server" Text="Región " CssClass="etiquetas"></asp:Label>
                    </td>
                <td colspan="3">
                    <asp:TextBox ID="TXT_ConsultaDireccRegion" runat="server" Width="220px" CssClass="cajastexto"></asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label24" runat="server" Text="Teléfono Celular " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaTeleFonoCelular" runat="server" Width="100px" CssClass="cajastexto"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label18" runat="server" Text="Altura " CssClass="etiquetas"></asp:Label>
                    </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TXT_ConsultaDireccAltura" runat="server" Width="220px" CssClass="cajastexto"></asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label21" runat="server" Text="Comuna " CssClass="etiquetas"></asp:Label>
                    </td>
                <td colspan="3">
                    <asp:TextBox ID="TXT_ConsultaDireccComuna" runat="server" Width="220px" CssClass="cajastexto"></asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label25" runat="server" Text="Tarjeta Entregada " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_ConsultaTarjetaEntregada" runat="server" Width="100px" CssClass="cajastexto"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div>
            <table class="tablas">
                <tr>
                    <td>
                        <asp:Label ID="LBL_Vencimiento1" runat="server" CssClass="etiquetas">-</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento2" runat="server" CssClass="etiquetas">-</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento3" runat="server" CssClass="etiquetas">-</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento4" runat="server" CssClass="etiquetas">-</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento5" runat="server" CssClass="etiquetas">-</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento6" runat="server" CssClass="etiquetas">-</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota1" runat="server" CssClass="cajastextonumerico" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota2" runat="server" CssClass="cajastextonumerico" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota3" runat="server" CssClass="cajastextonumerico" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota4" runat="server" CssClass="cajastextonumerico" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota5" runat="server" CssClass="cajastextonumerico" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota6" runat="server" CssClass="cajastextonumerico" Width="100px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_TabConsultas">
            <ajaxtoolkit:tabcontainer ID="Tab_Consultas" runat="server"  BorderColor="#FFCC00" BorderStyle="Outset" Height="215px" Width="1500px" OnClientActiveTabChanged="clientActiveTabChanged" ActiveTabIndex="10" ViewStateMode="Enabled">
                <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                    <HeaderTemplate>
                        Estados
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Estados" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Estados" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" SelectText="" ShowSelectButton="True" />
                                            <asp:BoundField DataField="column3" HeaderText="Fecha" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="column4" HeaderText="Hora" />
                                            <asp:BoundField DataField="column7" HeaderText="Cód. Est. Nuevo" />
                                            <asp:BoundField DataField="column8" HeaderText="Estado Nuevo" />
                                            <asp:BoundField DataField="column5" HeaderText="Cód. Est. Antiguo" />
                                            <asp:BoundField DataField="column6" HeaderText="Estado Antiguo" />
                                            <asp:BoundField DataField="column9" HeaderText="Operador" />
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </asp:Panel>
                                <asp:Label ID="LBL_EstadosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <asp:Panel ID="Panel_EstadosDetalle" runat="server" Visible="False" Width="754px">
                                    <asp:Label ID="Label123" runat="server" CssClass="etiquetas_tab" Text="Descripción Sub-Estado "></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TXT_EstadoDescripcionSubEstado" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="350px">BLOQUEADO</asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Button ID="BTN_EstadosSubEstados" runat="server" CssClass="botones" Text="VOLVER" />
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                    <HeaderTemplate>
                        Laboral
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <table id="TBL_Laboral" runat="server" class="tabla_tabcontainer" style="width: 752px">
                                    <tr>
                                        <td style="margin-left: 40px; width: 155px;">
                                            <asp:Label ID="Label83" runat="server" CssClass="etiquetas_tab" Text="Empleador"></asp:Label>
                                        </td>
                                        <td style="width: 328px; ">
                                            <asp:TextBox ID="TXT_LaboralEmpleador" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="280px"></asp:TextBox>
                                        </td>
                                        <td style="width: 172px">
                                            <asp:Label ID="Label95" runat="server" CssClass="etiquetas_tab" Text="Antigüedad"></asp:Label>
                                        </td>
                                        <td style="text-align: right; width: 209px;">
                                            <asp:TextBox ID="TXT_LaboralAntiguedad" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="220px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label85" runat="server" CssClass="etiquetas_tab" Text="Dirección"></asp:Label>
                                        </td>
                                        <td style="width: 328px; ">
                                            <asp:TextBox ID="TXT_LaboralDireccion" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="280px"></asp:TextBox>
                                        </td>
                                        <td style="width: 172px">
                                            <asp:Label ID="Label96" runat="server" CssClass="etiquetas_tab" Text="Total Ingresos"></asp:Label>
                                        </td>
                                        <td style="text-align: left; width: 209px;">
                                            <asp:TextBox ID="TXT_LaboralIngresos" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="150px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px; height: 23px;">
                                            <asp:Label ID="Label87" runat="server" CssClass="etiquetas_tab" Text="Región"></asp:Label>
                                        </td>
                                        <td style="width: 328px; height: 23px;">
                                            <asp:TextBox ID="TXT_LaboralRegion" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="150px"></asp:TextBox>
                                        </td>
                                        <td style="width: 172px; height: 23px;"></td>
                                        <td style="text-align: right; height: 23px; width: 209px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label89" runat="server" CssClass="etiquetas_tab" Text="Comuna"></asp:Label>
                                        </td>
                                        <td style="width: 328px; ">
                                            <asp:TextBox ID="TXT_LaboralComuna" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="150px"></asp:TextBox>
                                        </td>
                                        <td style="width: 172px">&nbsp;</td>
                                        <td style="text-align: right; width: 209px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label91" runat="server" CssClass="etiquetas_tab" Text="Teléfono"></asp:Label>
                                        </td>
                                        <td style="width: 328px; ">
                                            <asp:TextBox ID="TXT_LaboralTelefono" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="150px"></asp:TextBox>
                                        </td>
                                        <td style="width: 172px">&nbsp;</td>
                                        <td style="text-align: right; width: 209px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label93" runat="server" CssClass="etiquetas_tab" Text="Anexo"></asp:Label>
                                        </td>
                                        <td style="width: 328px; ">
                                            <asp:TextBox ID="TXT_LaboralAnexo" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="150px"></asp:TextBox>
                                        </td>
                                        <td style="width: 172px">&nbsp;</td>
                                        <td style="text-align: right; width: 209px;">&nbsp;</td>
                                    </tr>
                                </table>
                                <asp:Label ID="LBL_LaboralError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                    <HeaderTemplate>
                        Contratos
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Contratos" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Contratos" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" DataFormatString="{0:d}" HeaderText="Fecha Firma" />
                                            <asp:BoundField DataField="column4" HeaderText="Folio Contrato" />
                                            <asp:BoundField DataField="column5" HeaderText="Descripción del Contrato" />
                                            <asp:BoundField DataField="column6" HeaderText="Tienda" />
                                            <asp:BoundField DataField="column7" HeaderText="Storbox" />
                                            <asp:BoundField DataField="column8" HeaderText="Responsable" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_ContratosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                    <HeaderTemplate>
                        Modificaciones
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Modificaciones" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Modificaciones" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" HeaderText="Modificación de" />
                                            <asp:BoundField DataField="column9" HeaderText="Dato Antiguo" />
                                            <asp:BoundField DataField="column8" HeaderText="Dato Nuevo" />
                                            <asp:BoundField DataField="column4" DataFormatString="{0:d}" HeaderText="Fecha" />
                                            <asp:BoundField DataField="column5" HeaderText="Hora" />
                                            <asp:BoundField DataField="column6" HeaderText="Tienda" />
                                            <asp:BoundField DataField="column7" HeaderText="Responsable" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_ModificacionesError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
                    <HeaderTemplate>
                        Descuentos
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Descuentos" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Descuentos" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" ShowSelectButton="True" />
                                            <asp:BoundField DataField="column4" HeaderText="Tienda" />
                                            <asp:BoundField DataField="column5" HeaderText="Caja" />
                                            <asp:BoundField DataField="column6" HeaderText="Nro. Comprobante" />
                                            <asp:BoundField DataField="column7" DataFormatString="{0:d}" HeaderText="Fecha Pago" />
                                            <asp:BoundField DataField="column8" DataFormatString="{0:N0}" HeaderText="Total Descuento">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column9" HeaderText="Estado" />
                                            <asp:BoundField DataField="column10" HeaderText="Código" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_DescuentosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                                <asp:Panel ID="Panel_DescuentosDetalle" runat="server" CssClass="panel_tab" ScrollBars="Vertical" Visible="False">
                                    <table cellspacing="1" class="auto-style3">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label124" runat="server" CssClass="etiquetas_tab" Text="Monto Capital"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosMontoCapital" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label131" runat="server" CssClass="etiquetas_tab" Text="Interés Mora"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosInteresMora" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label138" runat="server" CssClass="etiquetas_tab" Text="Saldo  a Favor Inicial"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosSaldoFavorInicial" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label125" runat="server" CssClass="etiquetas_tab" Text="Monto Interés"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosMontoInteres" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label132" runat="server" CssClass="etiquetas_tab" Text="Gastos Cobranza"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosGastosCobranza" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label139" runat="server" CssClass="etiquetas_tab" Text="Monto del Abono"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosMontoAbono" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label126" runat="server" CssClass="etiquetas_tab" Text="Monto Honorarios"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosMontoHonorarios" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label133" runat="server" CssClass="etiquetas_tab" Text="Impuesto"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosImpuesto" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label140" runat="server" CssClass="etiquetas_tab" Text="Saldo a Favor Final"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosSaldoFavorFinal" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label127" runat="server" CssClass="etiquetas_tab" Text="Cobro Producto"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosCobroProducto" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label134" runat="server" CssClass="etiquetas_tab" Text="Cobros Grales."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosCobrosGrales" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label141" runat="server" CssClass="etiquetas_tab" Text="Fecha de Proceso"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosFechaProceso" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label128" runat="server" CssClass="etiquetas_tab" Text="Comisión Avance"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosComisionAvance" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label135" runat="server" CssClass="etiquetas_tab" Text="Costas Judiciales"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosCostasJudiciales" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label142" runat="server" CssClass="etiquetas_tab" Text="Estado del Abono"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosEstadoAbono" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label129" runat="server" CssClass="etiquetas_tab" Text="Administración"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosAdministracion" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label136" runat="server" CssClass="etiquetas_tab" Text="Interés Periodo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosInteresPeriodo" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label130" runat="server" CssClass="etiquetas_tab" Text="Seguros"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosSeguros" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label137" runat="server" CssClass="etiquetas_tab" Text="Cargos Pagados"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TXT_DescuentosCargosPagados" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="LBL_DescuentosDetalleError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                    <br />
                                    <asp:Button ID="BTN_DescuentosDetalle" runat="server" CssClass="botones" Text="VOLVER" />
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                        <br />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel6">
                    <HeaderTemplate>
                        Consultas DB
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table class="auto-style2" style="width: 60%">
                            <tr>
                                <td colspan="6">
                                    <asp:Label ID="LBL_NombreCliente" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label98" runat="server" CssClass="etiquetas_tab" Text="Fecha"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label101" runat="server" CssClass="etiquetas_tab" Text="Hora"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label102" runat="server" CssClass="etiquetas_tab" Text="Motivo"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label103" runat="server" CssClass="etiquetas_tab" Text="Edad"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label104" runat="server" CssClass="etiquetas_tab" Text="Score"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label105" runat="server" CssClass="etiquetas_tab" Text="Antecedentes"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label106" runat="server" CssClass="etiquetas_tab" Text="Dirección"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label107" runat="server" CssClass="etiquetas_tab" Text="Ciudad"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px;">
                                    <asp:Label ID="LBL_Fecha" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="height: 19px;">
                                    <asp:Label ID="LBL_Hora" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="height: 19px;">
                                    <asp:Label ID="LBL_Motivo" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="height: 19px;">
                                    <asp:Label ID="LBL_Edad" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:Label ID="LBL_Score" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:Label ID="LBL_Antecedentes" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:Label ID="LBL_Dirección" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:Label ID="LBL_Ciudad" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Label ID="Label100" runat="server" CssClass="etiquetas_tab" Text="Nose de donde sale este dato"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel_ConsultasDB" runat="server" Height="113px" ScrollBars="Vertical" Width="754px">
                            <asp:GridView ID="Grilla_ConsultasDB" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Fecha" />
                                    <asp:BoundField HeaderText="Hora" />
                                    <asp:BoundField HeaderText="Motivo" />
                                    <asp:BoundField HeaderText="Edad" />
                                    <asp:BoundField HeaderText="Score" />
                                    <asp:BoundField HeaderText="Antecedentes" />
                                    <asp:BoundField HeaderText="Dirección" />
                                    <asp:BoundField HeaderText="Ciudad" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel7">
                    <HeaderTemplate>
                        Solicitudes
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Solicitudes" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Solicitudes" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" HeaderText="Tipo Solicitud" />
                                            <asp:BoundField DataField="column4" DataFormatString="{0:d}" HeaderText="Fecha" />
                                            <asp:BoundField DataField="column5" DataFormatString="{0:HH:mm}" HeaderText="Hora" />
                                            <asp:BoundField DataField="column6" HeaderText="Rut Operador" />
                                            <asp:BoundField DataField="column7" HeaderText="Estado Solicitud" />
                                            <asp:BoundField DataField="column8" HeaderText="Glosa" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_SolicitudesError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel8" runat="server" HeaderText="TabPanel8">
                    <HeaderTemplate>
                        Resumen Cuenta
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <table class="auto-style2" style="width: 765px; height: 174px;">
                                    <tr>
                                        <td style="width: 224px">
                                            <asp:Label ID="Label108" runat="server" CssClass="etiquetas_tab" Text="Últimos Abonos"></asp:Label>
                                        </td>
                                        <td style="width: 226px">
                                            <asp:Label ID="Label109" runat="server" CssClass="etiquetas_tab" Text="Clasificaciones"></asp:Label>
                                        </td>
                                        <td style="width: 693px">
                                            <asp:Label ID="Label110" runat="server" CssClass="etiquetas_tab" Text="Fecha Solicitud"></asp:Label>
                                        </td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="TXT_ResumenFecSolicitud" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="8" style="width: 224px">
                                            <asp:Panel ID="Panel_ResumenUltimosAbonos" runat="server" Height="180px" ScrollBars="Vertical" Width="245px">
                                                <asp:GridView ID="Grilla_ResumenUltimosAbonos" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" Width="225px">
                                                    <Columns>
                                                        <asp:BoundField DataField="column3" HeaderText="Tipo" />
                                                        <asp:BoundField DataField="column5" DataFormatString="{0:d}" HeaderText="Fecha " />
                                                        <asp:BoundField DataField="column6" DataFormatString="{0:N0}" HeaderText="Monto ">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                            <asp:Label ID="LBL_ResumenUltAbonosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                        </td>
                                        <td rowspan="8" style="width: 226px">
                                            <asp:Panel ID="Panel_ResumenUltimasClasificaciones" runat="server" Height="180px" ScrollBars="Vertical" Width="135px">
                                                <asp:GridView ID="Grilla_ResumenUltimasClasificaciones" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" Width="102px">
                                                    <Columns>
                                                        <asp:BoundField DataField="column3" HeaderText="Mes">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="column4" HeaderText="Clasif.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                            <asp:Label ID="LBL_ResumenClasifError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                        </td>
                                        <td style="width: 693px">
                                            <asp:Label ID="Label112" runat="server" CssClass="etiquetas_tab" Text="Fecha Aprobación"></asp:Label>
                                        </td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="TXT_ResumenFecAprobacion" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 693px">
                                            <asp:Label ID="Label114" runat="server" CssClass="etiquetas_tab" Text="Fecha Verificación Particular"></asp:Label>
                                        </td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="TXT_ResumenFecVerifParticular" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 693px">
                                            <asp:Label ID="Label116" runat="server" CssClass="etiquetas_tab" Text="Fecha Verificación Laboral"></asp:Label>
                                        </td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="TXT_ResumenFecVerifLaboral" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 693px">
                                            <asp:Label ID="Label118" runat="server" CssClass="etiquetas_tab" Text="Fecha Rechazo"></asp:Label>
                                        </td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="TXT_ResumenFecRechazo" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 693px">&nbsp;</td>
                                        <td style="width: 250px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 693px">
                                            <asp:Label ID="Label120" runat="server" CssClass="etiquetas_tab" Text="Total Cuenta Al"></asp:Label>
                                        </td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="TXT_ResumenTotalCuentaAl" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 693px">
                                            <asp:Label ID="Label121" runat="server" CssClass="etiquetas_tab" Text="COMPRAS TOTALES"></asp:Label>
                                        </td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="TXT_ResumenComprasTotales" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 693px">
                                            <asp:Label ID="Label122" runat="server" CssClass="etiquetas_tab" Text="PAGOS TOTALES"></asp:Label>
                                        </td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="TXT_ResumenPagosTotales" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel11" runat="server" HeaderText="TabPanel11">
                    <HeaderTemplate>
                        Comentarios
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Comentarios" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Comentarios" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" DataFormatString="{0:d}" HeaderText="Fecha ">
                                            <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column4" HeaderText="Hora">
                                            <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column5" HeaderText="Glosa">
                                            <ItemStyle Width="500px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_ComentariosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel9" runat="server" HeaderText="TabPanel9">
                    <HeaderTemplate>
                        Pagos
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Pagos" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Pagos" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="720px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" HeaderText="Origen Pago" />
                                            <asp:BoundField DataField="column4" HeaderText="Tipo" />
                                            <asp:BoundField DataField="column5" HeaderText="Tienda Pago" />
                                            <asp:BoundField DataField="column6" HeaderText="Caja" />
                                            <asp:BoundField DataField="column7" HeaderText="Nro.Comprobante" />
                                            <asp:BoundField DataField="column8" DataFormatString="{0:d}" HeaderText="Fecha Pago" />
                                            <asp:BoundField DataField="column9" DataFormatString="{0:N0}" HeaderText="Monto Pagado">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column10" HeaderText="Cód. Sucursal">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_PagosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel10">
                    <HeaderTemplate>
                        Ventas
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Ventas" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Ventas" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" ShowSelectButton="True" />
                                            <asp:BoundField DataField="column4" HeaderText="Descripción Venta" />
                                            <asp:BoundField DataField="column5" HeaderText="Sucursal" />
                                            <asp:BoundField DataField="column6" DataFormatString="{0:d}" HeaderText="Fecha">
                                            <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column7" HeaderText="Hora" />
                                            <asp:BoundField DataField="column8" HeaderText="Caja" />
                                            <asp:BoundField DataField="column9" HeaderText="Nro.Comp." />
                                            <asp:BoundField DataField="column10" HeaderText="Cuotas" />
                                            <asp:BoundField DataField="column11" DataFormatString="{0:N0}" HeaderText="Venta Capital">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column12" DataFormatString="{0:N0}" HeaderText="Venta Financ.">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column13" DataFormatString="{0:d}" HeaderText="Fec. 1er Venc.">
                                            <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column14" HeaderText="Estado" />
                                            <asp:BoundField DataField="column15" HeaderText="Comprador" />
                                            <asp:BoundField DataField="column16" HeaderText="Codigo Sucursal" />
                                            <asp:BoundField DataField="column17" HeaderText="Codigo Negocio" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_VentasError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <asp:Panel ID="Panel_VentasDetalle" runat="server" ScrollBars="Vertical" Visible="False" CssClass="panel_tab" Height="180px">
                                    <asp:GridView ID="Grilla_VentasDetalle" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" HeaderText="Nro. Cuota" >
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column4" DataFormatString="{0:d}" HeaderText="Fecha Vencimiento" />
                                            <asp:BoundField DataField="column5" DataFormatString="{0:N0}" HeaderText="Monto Capital" >
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column6" DataFormatString="{0:N0}" HeaderText="Monto Interés" >
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column7" DataFormatString="{0:N0}" HeaderText="Monto Honorarios" >
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column8" DataFormatString="{0:N0}" HeaderText="Cobro Producto" >
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column9" DataFormatString="{0:N0}" HeaderText="Monto Total" >
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column10" HeaderText="Estado Cuota" />
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </asp:Panel>
                                <asp:Label ID="LBL_VentasDetalleError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                                <asp:Button ID="BTN_VentasDetalle" runat="server" CssClass="botones" Text="VOLVER" Visible="False" />
                                <br />
                                <br />
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel12" runat="server" HeaderText="TabPanel12">
                    <HeaderTemplate>
                        Repactaciones
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Repactaciones" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Repactaciones" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="726px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" HeaderText="Tienda" />
                                            <asp:BoundField DataField="column4" HeaderText="Caja" />
                                            <asp:BoundField DataField="column5" HeaderText="Nro.Comprobante" />
                                            <asp:BoundField DataField="column6" DataFormatString="{0:d}" HeaderText="Fecha Proceso" />
                                            <asp:BoundField DataField="column7" DataFormatString="{0:N0}" HeaderText="Pie">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column8" DataFormatString="{0:N0}" HeaderText="Descuento">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column9" DataFormatString="{0:N0}" HeaderText="Saldo Repactado">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column10" DataFormatString="{0:N0}" HeaderText="Total">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </asp:Panel>
                                <asp:Label ID="LBL_RepactacionesError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel13" runat="server" HeaderText="TabPanel13">
                    <HeaderTemplate>
                        Deuda
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            <ContentTemplate>
                                <table id="TBL_Deuda" runat="server" class="tabla_tabcontainer">
                                    <tr>
                                        <td style="margin-left: 40px; width: 155px;">
                                            <asp:Label ID="Label55" runat="server" CssClass="etiquetas_tab" Text="Monto Capital"></asp:Label>
                                        </td>
                                        <td style="width: 84px; text-align: right;">
                                            <asp:TextBox ID="TXT_DeudaMontoCapital" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                        <td style="width: 150px">&nbsp;</td>
                                        <td style="width: 166px">
                                            <asp:Label ID="Label57" runat="server" CssClass="etiquetas_tab" Text="Interés Mora"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:TextBox ID="TXT_DeudaInteresMora" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px; height: 23px;">
                                            <asp:Label ID="Label59" runat="server" CssClass="etiquetas_tab" Text="Monto Interés"></asp:Label>
                                        </td>
                                        <td style="width: 84px; text-align: right; height: 23px;">
                                            <asp:TextBox ID="TXT_DeudaMontoInteres" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                        <td style="width: 150px; height: 23px;"></td>
                                        <td style="width: 166px; height: 23px;">
                                            <asp:Label ID="Label61" runat="server" CssClass="etiquetas_tab" Text="Gastos Cobranza"></asp:Label>
                                        </td>
                                        <td style="text-align: right; height: 23px;">
                                            <asp:TextBox ID="TXT_DeudaGastosCobranza" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label63" runat="server" CssClass="etiquetas_tab" Text="Monto Honorario"></asp:Label>
                                        </td>
                                        <td style="width: 84px; text-align: right;">
                                            <asp:TextBox ID="TXT_DeudaMontoHonorario" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                        <td style="width: 150px">&nbsp;</td>
                                        <td style="width: 166px">
                                            <asp:Label ID="Label65" runat="server" CssClass="etiquetas_tab" Text="Impuestos"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:TextBox ID="TXT_DeudaImpuestos" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label67" runat="server" CssClass="etiquetas_tab" Text="Cobro Producto"></asp:Label>
                                        </td>
                                        <td style="width: 84px; text-align: right;">
                                            <asp:TextBox ID="TXT_DeudaCobroProducto" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                        <td style="width: 150px">&nbsp;</td>
                                        <td style="width: 166px">
                                            <asp:Label ID="Label69" runat="server" CssClass="etiquetas_tab" Text="Costas Judiciales"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:TextBox ID="TXT_DeudaCostasJudiciales" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label71" runat="server" CssClass="etiquetas_tab" Text="Comisión Avance"></asp:Label>
                                        </td>
                                        <td style="width: 84px; text-align: right;">
                                            <asp:TextBox ID="TXT_DeudaComisionAvance" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                        <td style="width: 150px">&nbsp;</td>
                                        <td style="width: 166px">
                                            <asp:Label ID="Label73" runat="server" CssClass="etiquetas_tab" Text="Interés Periodo"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:TextBox ID="TXT_DeudaInteresPeriodo" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label75" runat="server" CssClass="etiquetas_tab" Text="Administración"></asp:Label>
                                        </td>
                                        <td style="width: 84px; text-align: right;">
                                            <asp:TextBox ID="TXT_DeudaAdministracion" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                        <td style="width: 150px">&nbsp;</td>
                                        <td style="width: 166px">
                                            <asp:Label ID="Label77" runat="server" CssClass="etiquetas_tab" Text="Otros Cobros"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:TextBox ID="TXT_DeudaOtrosCobros" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">
                                            <asp:Label ID="Label79" runat="server" CssClass="etiquetas_tab" Text="Seguros"></asp:Label>
                                        </td>
                                        <td style="width: 84px; text-align: right;">
                                            <asp:TextBox ID="TXT_DeudaSeguros" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                        <td style="width: 150px">&nbsp;</td>
                                        <td style="width: 166px">
                                            <asp:Label ID="Label81" runat="server" CssClass="etiquetas_tab" Text="Saldo a Favor    ( - )"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:TextBox ID="TXT_DeudaSaldoFavor" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 155px">&nbsp;</td>
                                        <td style="width: 84px; text-align: right;">&nbsp;</td>
                                        <td style="width: 150px">&nbsp;</td>
                                        <td style="border-style: outset none none none; border-top-width: 2px;">
                                            <asp:Label ID="Label82" runat="server" CssClass="etiquetas_tabtotales" Text="TOTAL DEUDA"></asp:Label>
                                        </td>
                                        <td style="border-top-width: 2px; text-align: right; border-left-style: none; border-right-style: none; border-top-style: outset; border-bottom-style: none;">
                                            <asp:TextBox ID="TXT_DeudaTotal" runat="server" CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="LBL_DeudaError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel14" runat="server" HeaderText="TabPanel14">
                    <HeaderTemplate>
                        Por Pagar
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_XPagar" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_XPagar" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" HeaderText="Fecha Venc." DataFormatString="{0:d}" >
                                            <FooterStyle Font-Bold="True" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column4" HeaderText="Tienda" />
                                            <asp:BoundField DataField="column5" HeaderText="Nro. Boleta" />
                                            <asp:BoundField DataField="column6" HeaderText="Nro. Cuota" />
                                            <asp:BoundField DataField="column7" DataFormatString="{0:N0}" HeaderText="Capital">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column8" DataFormatString="{0:N0}" HeaderText="Interés">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column9" DataFormatString="{0:N0}" HeaderText="Honorario">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column10" DataFormatString="{0:N0}" HeaderText="Cobros">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column11" DataFormatString="{0:N0}" HeaderText="Total Cuota">
                                            <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column12" DataFormatString="{0:N0}" HeaderText="Pendiente" >
                                            <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column13" DataFormatString="{0:N0}" HeaderText="Abonado">
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_XPagarError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel15" runat="server" HeaderText="TabPanel15">
                    <HeaderTemplate>
                        Seguros
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_Seguros" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                                    <asp:GridView ID="Grilla_Seguros" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px">
                                        <Columns>
                                            <asp:BoundField DataField="column4" HeaderText="Seguro" />
                                            <asp:BoundField DataField="column5" HeaderText="Compañia" />
                                            <asp:BoundField DataField="column6" HeaderText="Tienda" />
                                            <asp:BoundField DataField="column7" HeaderText="Caja" />
                                            <asp:BoundField DataField="column8" HeaderText="Folio" />
                                            <asp:BoundField DataField="column9" DataFormatString="{0:d}" HeaderText="Inicio Vig." />
                                            <asp:BoundField DataField="column10" DataFormatString="{0:d}" HeaderText="Termino Vig." />
                                            <asp:BoundField DataField="column11" HeaderText="Motivo Anulación" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_SegurosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel16" runat="server" HeaderText="TabPanel16">
                    <HeaderTemplate>
                        SBIF
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel_SBIF" runat="server" CssClass="panel_tab" ScrollBars="Vertical" Width="300px">
                                    <asp:GridView ID="Grilla_SBIF" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="258px">
                                        <Columns>
                                            <asp:BoundField DataField="column3" HeaderText="Mes/Año" />
                                            <asp:BoundField DataField="column4" HeaderText="Clasificación">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="LBL_SBIFError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel17" runat="server" HeaderText="TabPanel17">
                    <HeaderTemplate>
                        PaloBlanco
                    </HeaderTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxtoolkit:tabcontainer>
            <br />
        </div>
</asp:Content>


