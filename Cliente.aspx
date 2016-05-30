<%@ Page Language="VB" MasterPageFile="~/Maestro.master" AutoEventWireup="false" CodeFile="Cliente.aspx.vb" Inherits="MenuPrincipal" %>
<%@ MasterType virtualpath="~/Maestro.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <link href="css/EstilosShop.css" rel="stylesheet" />
    <div>
    
        <table class="tablas">
            <tr>
                <td class="auto-style3" style="width: 2997px; height: 1px;">
                    <asp:Label ID="Label1" runat="server" Text="Rut Cliente :" CssClass="cajastextoparametro"></asp:Label>
&nbsp;
                    <asp:TextBox ID="TXT_RutCliente" runat="server" CssClass="cajastextoparametro" Width="73px">9608468</asp:TextBox>
                    &nbsp;<asp:Label ID="Label26" runat="server" Text="-" CssClass="cajastextoparametro"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server" MaxLength="1" Width="16px" CssClass="cajastextoparametro">4</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BTN_Buscar" runat="server" Text="BUSCAR" CssClass="botones" />
&nbsp;&nbsp;
                    <asp:Button ID="BTN_Limpiar" runat="server" Text="LIMPIAR" CssClass="botones" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style3" style="width: 1020px; height: 1px;">
                    <asp:TextBox ID="TXT_Apellidos" runat="server" Width="260px" CssClass="cajastextoparametro">ALEJANDRO BERNARDO GROSS ERGAS</asp:TextBox>
                </td>
            </tr>
        </table>
    
    </div>
        <div>
            <table class="tablas">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Tienda " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_CodigoTienda" runat="server" CssClass="cajastexto" Width="50px">24</asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_NombreTienda" runat="server" CssClass="cajastexto" Width="210px">SAN FELIPE</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Folio Contrato " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_FolioContrato" runat="server" CssClass="cajastexto" Width="100px">63137</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Última Mantención " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_UltimaMantención" runat="server" CssClass="cajastexto" Width="90px">23-12-2013</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Estado Cliente " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TXT_Estado" runat="server" Width="280px" CssClass="cajastexto">BLOQUEADO</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Fecha " CssClass="etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_Fecha" runat="server" CssClass="cajastexto" Width="100px">11-04-2013</asp:TextBox>
                        </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <table class="tablas">
            <tr>
                <td>
                        <asp:Label ID="Label7" runat="server" Text="Día de Pago " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_DiaPago" runat="server" Width="100px" CssClass="cajastextonumerico">5</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label11" runat="server" Text="Fecha pago " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_FechaPago" runat="server" CssClass="cajastexto" Width="120px">05-01-2016</asp:TextBox>
                </td>
                <td style="text-align: right">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label15" runat="server" Text="Días de Mora " CssClass="etiquetas"></asp:Label>
                    </td>
                <td style="text-align: right">
                    <asp:TextBox ID="TXT_DiasMora" runat="server" CssClass="cajastextonumerico" Width="100px">0</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label8" runat="server" Text="Línea de Crédito " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_LineaCredito" runat="server" Width="100px" CssClass="cajastextonumerico">70.000</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label12" runat="server" Text="A pago " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_APago" runat="server" CssClass="cajastextonumerico" Width="120px">659</asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label9" runat="server" Text="Cupo Disponible " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_CupoDisponible" runat="server" Width="100px" CssClass="cajastextonumerico">68.000</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label13" runat="server" Text="Pagos del Período " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_PagosPeriodo" runat="server" CssClass="cajastextonumerico" Width="120px">0</asp:TextBox>
                </td>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="LBL_Mensaje" runat="server" CssClass="etiquetasmensaje" Text="CLIENTE APTO PARA AVANCE"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label10" runat="server" Text="Total deuda  " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_TotalDeuda" runat="server" Width="100px" CssClass="cajastextonumerico">2.175</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label14" runat="server" Text="Saldo " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_Saldo" runat="server" CssClass="cajastextonumerico" Width="120px">659</asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table class="tablas">
            <tr>
                <td>
                        <asp:Label ID="Label16" runat="server" Text="Calle " CssClass="etiquetas"></asp:Label>
                    </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TXT_DireccCalle" runat="server" Width="220px" CssClass="cajastexto">BUSTOS</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label19" runat="server" Text="Número " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_DireccNumero" runat="server" Width="82px" CssClass="cajastextonumerico">2145</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label22" runat="server" Text="Depto. " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_DireccDepto" runat="server" Width="65px" CssClass="cajastextonumerico">704</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label23" runat="server" Text="Teléfono Particular " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_FonoParticular" runat="server" Width="100px" CssClass="cajastexto">25406789</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label17" runat="server" Text="Villa " CssClass="etiquetas"></asp:Label>
                    </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TXT_DireccVilla" runat="server" Width="220px" CssClass="cajastexto">LAS ARAUCARIAS</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label20" runat="server" Text="Región " CssClass="etiquetas"></asp:Label>
                    </td>
                <td colspan="3">
                    <asp:TextBox ID="TXT_DireccRegion" runat="server" Width="220px" CssClass="cajastexto">R. METROPOLITANA</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label24" runat="server" Text="Teléfono Celular " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_FonoCelular" runat="server" Width="100px" CssClass="cajastexto">62083322</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label18" runat="server" Text="Altura " CssClass="etiquetas"></asp:Label>
                    </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TXT_DireccAltura" runat="server" Width="220px" CssClass="cajastexto">MANQUEHUE</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label21" runat="server" Text="Comuna " CssClass="etiquetas"></asp:Label>
                    </td>
                <td colspan="3">
                    <asp:TextBox ID="TXT_DireccComuna" runat="server" Width="220px" CssClass="cajastexto">COMUNA</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label25" runat="server" Text="Tarjeta Entregada " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_TarjetaEntregada" runat="server" Width="100px" CssClass="cajastexto"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div>
            <table class="tablas">
                <tr>
                    <td>
                        <asp:Label ID="LBL_Vencimiento1" runat="server" CssClass="etiquetas" Text="05-01-2014"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento2" runat="server" CssClass="etiquetas" Text="05-02-2014"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento3" runat="server" CssClass="etiquetas" Text="05-03-2015"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento4" runat="server" CssClass="etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento5" runat="server" CssClass="etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LBL_Vencimiento6" runat="server" CssClass="etiquetas"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="cajastextonumerico" Width="100px">659</asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="cajastextonumerico" Width="100px">758</asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="cajastextonumerico" Width="100px">758</asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="cajastextonumerico" Width="100px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="cajastextonumerico" Width="100px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="cajastextonumerico" Width="100px">0</asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <ajaxtoolkit:tabcontainer ID="Tab_Consultas" runat="server"  BorderColor="#FFCC00" BorderStyle="Outset" Height="240px" Width="1276px" AutoPostBack="True" ActiveTabIndex="15">
                <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                    <HeaderTemplate>
                        Estados
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Estados" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Estados" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" Height="16px"  Width="737px" EmptyDataText="No hay resultados en busqueda" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Fecha" />
                                    <asp:BoundField HeaderText="Hora" />
                                    <asp:BoundField HeaderText="Cód." />
                                    <asp:BoundField HeaderText="Estado Nuevo" />
                                    <asp:BoundField HeaderText="Cód." />
                                    <asp:BoundField HeaderText="Estado Antiguo" />
                                    <asp:BoundField HeaderText="Operador" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                    <HeaderTemplate>
                        Laboral
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table class="tabla_tabcontainer">
                            <tr>
                                <td style="margin-left: 40px; width: 155px;">
                                    <asp:Label ID="Label83" runat="server" CssClass="etiquetas_tab" Text="Empleador"></asp:Label>
                                </td>
                                <td style="width: 730px; ">
                                    <asp:Label ID="LBL_Empleador" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="width: 199px">
                                    <asp:Label ID="Label95" runat="server" CssClass="etiquetas_tab" Text="Antigüedad"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_Antiguedad" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label85" runat="server" CssClass="etiquetas_tab" Text="Dirección"></asp:Label>
                                </td>
                                <td style="width: 730px; ">
                                    <asp:Label ID="LBL_Direccion" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="width: 199px">
                                    <asp:Label ID="Label96" runat="server" CssClass="etiquetas_tab" Text="Total Ingresos"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_TotalIngresos" runat="server" CssClass="etiquetas_tab">0</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label87" runat="server" CssClass="etiquetas_tab" Text="Región"></asp:Label>
                                </td>
                                <td style="width: 730px; ">
                                    <asp:Label ID="LBL_Region" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="width: 199px">&nbsp;</td>
                                <td style="text-align: right">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label89" runat="server" CssClass="etiquetas_tab" Text="Comuna"></asp:Label>
                                </td>
                                <td style="width: 730px; ">
                                    <asp:Label ID="LBL_Comuna" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="width: 199px">&nbsp;</td>
                                <td style="text-align: right">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label91" runat="server" CssClass="etiquetas_tab" Text="Teléfono"></asp:Label>
                                </td>
                                <td style="width: 730px; ">
                                    <asp:Label ID="LBL_Telefono" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="width: 199px">&nbsp;</td>
                                <td style="text-align: right">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label93" runat="server" CssClass="etiquetas_tab" Text="Anexo"></asp:Label>
                                </td>
                                <td style="width: 730px; ">
                                    <asp:Label ID="LBL_Anexo" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                                <td style="width: 199px">&nbsp;</td>
                                <td style="text-align: right">&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                    <HeaderTemplate>
                        Contratos
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Contratos" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Contratos" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Fecha Firma" />
                                    <asp:BoundField HeaderText="Folio Contrato" />
                                    <asp:BoundField HeaderText="Descripción del Contrato" />
                                    <asp:BoundField HeaderText="Tienda" />
                                    <asp:BoundField HeaderText="Storbox" />
                                    <asp:BoundField HeaderText="Responsable" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                    <HeaderTemplate>
                        Modificaciones
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Modificaciones" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Modificaciones" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Modificación de" />
                                    <asp:BoundField HeaderText="Dato Antiguo" />
                                    <asp:BoundField HeaderText="Dato Nuevo" />
                                    <asp:BoundField HeaderText="Fecha" />
                                    <asp:BoundField HeaderText="Hora" />
                                    <asp:BoundField HeaderText="Tienda" />
                                    <asp:BoundField HeaderText="Responsable" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
                    <HeaderTemplate>
                        Descuentos
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Descuentos" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Descuentos" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Tienda" />
                                    <asp:BoundField HeaderText="Caja" />
                                    <asp:BoundField HeaderText="Nro. Comprobante" />
                                    <asp:BoundField HeaderText="Fecha Pago" />
                                    <asp:BoundField HeaderText="Total Descuento" />
                                    <asp:BoundField HeaderText="Estado" />
                                    <asp:BoundField HeaderText="Código" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
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
                        <asp:Panel ID="Panel_Solicitud" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Solicitud" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Tipo Solicitud" />
                                    <asp:BoundField HeaderText="Fecha" />
                                    <asp:BoundField HeaderText="Hora" />
                                    <asp:BoundField HeaderText="Rut Operador" />
                                    <asp:BoundField HeaderText="Estado Solicitud" />
                                    <asp:BoundField HeaderText="Glosa" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel8" runat="server" HeaderText="TabPanel8">
                    <HeaderTemplate>
                        Resumen Cuenta
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table class="auto-style2" style="width: 60%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label108" runat="server" CssClass="etiquetas_tab" Text="Ultimos Abonos"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label109" runat="server" CssClass="etiquetas_tab" Text="Clasificaciones"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label110" runat="server" CssClass="etiquetas_tab" Text="Fecha Solicitud"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_FechaSolicitud" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="8">
                                    <asp:Panel ID="Panel_UltimosAbonos" runat="server" Width="162px">
                                        <asp:GridView ID="Grilla_UltimosAbonos" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" Width="150px">
                                            <Columns>
                                                <asp:BoundField HeaderText="Tipo" />
                                                <asp:BoundField HeaderText="Fecha " />
                                                <asp:BoundField HeaderText="Monto " />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                                <td rowspan="8">
                                    <asp:Panel ID="Panel_UltimasClasificaciones" runat="server" Width="176px">
                                        <asp:GridView ID="Grilla_UltimasClasificaciones" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" Width="154px">
                                            <Columns>
                                                <asp:BoundField HeaderText="Mes" />
                                                <asp:BoundField HeaderText="Clasificación" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Label ID="Label112" runat="server" CssClass="etiquetas_tab" Text="Fecha Aprobación"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_FechaAprobacion" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label114" runat="server" CssClass="etiquetas_tab" Text="Fecha Verificación Particular"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_FechaVerificacionParticular" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label116" runat="server" CssClass="etiquetas_tab" Text="Fecha Verificación Laboral"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_FechaVerificacionLaboral" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label118" runat="server" CssClass="etiquetas_tab" Text="Fecha Rechazo"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_FechaRechazo" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label120" runat="server" CssClass="etiquetas_tab" Text="Total Cuenta Al"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_TotalCuentaAl" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label121" runat="server" CssClass="etiquetas_tab" Text="COMPRAS TOTALES"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_ComprasTotales" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label122" runat="server" CssClass="etiquetas_tab" Text="PAGOS TOTALES"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_PagosTotales" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel11" runat="server" HeaderText="TabPanel11">
                    <HeaderTemplate>
                        Comentarios
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Comentarios" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Comentarios" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Fecha ">
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hora">
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Glosa">
                                    <ItemStyle Width="500px" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel9" runat="server" HeaderText="TabPanel9">
                    <HeaderTemplate>
                        Pagos
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Pagos" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Pagos" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="720px">
                                <Columns>
                                    <asp:BoundField HeaderText="Tipo" />
                                    <asp:BoundField HeaderText="Tienda Pago" />
                                    <asp:BoundField HeaderText="Caja" />
                                    <asp:BoundField HeaderText="Nro.Comprobante" />
                                    <asp:BoundField HeaderText="Fecha Pago" />
                                    <asp:BoundField HeaderText="Monto Pagado" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel10">
                    <HeaderTemplate>
                        Ventas
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Ventas" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Ventas" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Plan" />
                                    <asp:BoundField HeaderText="Fecha" />
                                    <asp:BoundField HeaderText="Hora" />
                                    <asp:BoundField HeaderText="Caja" />
                                    <asp:BoundField HeaderText="Nro.Comprobante" />
                                    <asp:BoundField HeaderText="Cuotas" />
                                    <asp:BoundField HeaderText="Monto Compra" />
                                    <asp:BoundField HeaderText="A Pagar" />
                                    <asp:BoundField HeaderText="Estado" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel12" runat="server" HeaderText="TabPanel12">
                    <HeaderTemplate>
                        Repactaciones
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Repactaciones" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Repactaciones" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="726px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Tienda" />
                                    <asp:BoundField HeaderText="Caja" />
                                    <asp:BoundField HeaderText="Nro.Comprobante" />
                                    <asp:BoundField HeaderText="Fecha Proceso" />
                                    <asp:BoundField HeaderText="Pie" />
                                    <asp:BoundField HeaderText="Descuento" />
                                    <asp:BoundField HeaderText="Saldo Repactado" />
                                    <asp:BoundField HeaderText="Total" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel13" runat="server" HeaderText="TabPanel13">
                    <HeaderTemplate>
                        Deuda
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table class="tabla_tabcontainer">
                            <tr>
                                <td style="margin-left: 40px; width: 155px;">
                                    <asp:Label ID="Label55" runat="server" CssClass="etiquetas_tab" Text="Monto Capital"></asp:Label>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="LBL_MontoCapital" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                                <td style="width: 150px">&nbsp;</td>
                                <td style="width: 166px">
                                    <asp:Label ID="Label57" runat="server" CssClass="etiquetas_tab" Text="Interés Mora"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_InteresMora" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label59" runat="server" CssClass="etiquetas_tab" Text="Monto Interés"></asp:Label>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="LBL_MontoInteres" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                                <td style="width: 150px">&nbsp;</td>
                                <td style="width: 166px">
                                    <asp:Label ID="Label61" runat="server" CssClass="etiquetas_tab" Text="Gastos Cobranza"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_GastosCobranza" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label63" runat="server" CssClass="etiquetas_tab" Text="Monto Honorario"></asp:Label>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="LBL_MontoHonorario" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                                <td style="width: 150px">&nbsp;</td>
                                <td style="width: 166px">
                                    <asp:Label ID="Label65" runat="server" CssClass="etiquetas_tab" Text="Impuestos"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_Impuestos" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label67" runat="server" CssClass="etiquetas_tab" Text="Cobro Producto"></asp:Label>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="LBL_CobroProducto" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                                <td style="width: 150px">&nbsp;</td>
                                <td style="width: 166px">
                                    <asp:Label ID="Label69" runat="server" CssClass="etiquetas_tab" Text="Costas Judiciales"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_CostasJudicial" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label71" runat="server" CssClass="etiquetas_tab" Text="Comisión Avance"></asp:Label>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="LBL_ComisionAvance" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                                <td style="width: 150px">&nbsp;</td>
                                <td style="width: 166px">
                                    <asp:Label ID="Label73" runat="server" CssClass="etiquetas_tab" Text="Interés Periodo"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_InteresPeriodo" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label75" runat="server" CssClass="etiquetas_tab" Text="Administración"></asp:Label>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="LBL_Administracion" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                                <td style="width: 150px">&nbsp;</td>
                                <td style="width: 166px">
                                    <asp:Label ID="Label77" runat="server" CssClass="etiquetas_tab" Text="Otros Cobros"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_OtrosCobros" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 155px">
                                    <asp:Label ID="Label79" runat="server" CssClass="etiquetas_tab" Text="Seguros"></asp:Label>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="LBL_Seguros" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
                                </td>
                                <td style="width: 150px">&nbsp;</td>
                                <td style="width: 166px">
                                    <asp:Label ID="Label81" runat="server" CssClass="etiquetas_tab" Text="Saldo a Favor    ( - )"></asp:Label>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_SaldoFavor" runat="server" CssClass="etiquetas_tab" Text="0"></asp:Label>
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
                                    <asp:Label ID="LBL_TotalDeuda" runat="server" CssClass="etiquetas_tabtotales" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel14" runat="server" HeaderText="TabPanel14">
                    <HeaderTemplate>
                        Por Pagar
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_XPagar" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_XPagar" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Fecha Vencimiento" />
                                    <asp:BoundField HeaderText="Total Cuota" />
                                    <asp:BoundField HeaderText="Total Pendiente" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel15" runat="server" HeaderText="TabPanel15">
                    <HeaderTemplate>
                        Seguros
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Seguros" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Seguros" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="737px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Seguro" />
                                    <asp:BoundField HeaderText="Tienda" />
                                    <asp:BoundField HeaderText="Caja" />
                                    <asp:BoundField HeaderText="Folio" />
                                    <asp:BoundField HeaderText="Inicio Vig." />
                                    <asp:BoundField HeaderText="Termino Vig." />
                                    <asp:BoundField HeaderText="Motivo Anulación" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel16" runat="server" HeaderText="TabPanel16">
                    <HeaderTemplate>
                        SBIF
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Seguros0" runat="server" CssClass="panel_tab" ScrollBars="Vertical">
                            <asp:GridView ID="Grilla_Seguros0" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="390px" CssClass="grillas_tab">
                                <Columns>
                                    <asp:BoundField HeaderText="Mes" />
                                    <asp:BoundField HeaderText="Clasificación" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxtoolkit:tabcontainer>
            <br />
        </div>
</asp:Content>


