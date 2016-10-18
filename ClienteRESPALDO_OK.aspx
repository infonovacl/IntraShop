<%@ Page Language="VB" MasterPageFile="~/Maestro.master" EnableEventValidation="false" ValidateRequest="false" EnableViewState="true" AutoEventWireup ="false" CodeFile="ClienteRESPALDO_OK.aspx.vb" Inherits="Cliente" %>
<%@ MasterType virtualpath="~/Maestro.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1- strict.dtd"> 
      <link href="css/EstilosShop.css" rel="stylesheet" />
    <style type="text/css"> 
        .completionList {
        border:solid 1px Gray;
        margin:0px;
        font-family:Arial;
        font-size:11px;
        padding:3px;
        height: 150px;
        overflow:auto;
        background-color: #FFFFFF;     
        } 
        .listItem {
        color: #191919;
        } 
        .itemHighlighted {
        background-color: #ADD6FF;       
        }
        .auto-style5 {
            width: 235px;
        }
        .auto-style6 {
            width: 220px;
            height: 12px;
        }
        .auto-style8 {
            width: 380px;
            height: 12px;
        }
        .auto-style9 {
            width: 50px;
            height: 12px;
        }
        .loading
        {
            background-image: url(imagenes/cargando_textbox.gif);
            background-position: right;
            background-repeat: no-repeat;
        }        
        .auto-style19 {
            left: 0px;
            bottom: 2px;
            width: 220px;
            height: 12px;
        }
        .auto-style20 {
            width: 19px;
            height: 19px;
        }
        .style1
        {
            width: 55px;
        }    
        </style>
    <script script language="javascript" type="text/javascript">
        function pageLoad(sender, e) {
            var objTpDummy =
                document.getElementById('<%= TabPanel17.ClientID %>' + '_tab');
            objTpDummy.style.display = 'none';
            //document.getElementById("TXT_ConsultaRutCliente").focus();
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
        function BuscaNombre() {
            window.open('/Consultas/Consultas_BuscaXNombre.aspx', 'BuscaCliente', 'top=150,width=650,height=310,left=220', scrollbars = 'NO', resizable = 'NO');          
        }
    </script>
         
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table class="tablas">
                    <tr>
                        <td class="auto-style6">
                            <asp:Label ID="Label1" runat="server" CssClass="etiquetas" Text="Rut Cliente"></asp:Label>
                            <asp:TextBox ID="TXT_ConsultaRutCliente" runat="server" ClientIDMode="Static" 
                                CssClass="cajastextoparametro" MaxLength="8" Width="73px"></asp:TextBox>
                            <asp:Label ID="Label26" runat="server" CssClass="etiquetas" Text="-"></asp:Label>
                            <asp:TextBox ID="TXT_ConsultaDV" runat="server" CssClass="cajastextoparametro" 
                                MaxLength="1" ReadOnly="True" Width="16px"></asp:TextBox>
                        </td>
                        <td class="auto-style9">
                        </td>
                        <td class="auto-style19">
                            <asp:Button ID="BTN_Buscar" runat="server" CssClass="botones" Text="BUSCAR" />
                            <asp:Button ID="BTN_Limpiar" runat="server" CssClass="botones" Text="LIMPIAR" />
                        </td>
                        <td class="auto-style8">
                            <asp:TextBox ID="TXT_ConsultaNombreCompleto" runat="server" 
                                CssClass="cajastextoparametro" ReadOnly="True" Width="300px"></asp:TextBox>
                            <asp:ImageButton ID="BTN_BuscaXNombre" runat="server" Height="20px" 
                                ImageUrl="~/Imagenes/lupa.jpg" OnClientClick="BuscaNombre()" Width="20px" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table class="tablas">
                    <tr>
                        <td style="width: 82px">
                            <asp:Label ID="Label2" runat="server" CssClass="etiquetas" Text="Tienda "></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="TXT_ConsultaNumeroSucursal" runat="server" 
                                CssClass="cajastexto" ReadOnly="True" Width="50px"></asp:TextBox>
                        </td>
                        <td style="width: 64px">
                            <asp:TextBox ID="TXT_ConsultaNombreSucursal" runat="server" 
                                CssClass="cajastexto" ReadOnly="True" Width="90px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="etiquetas" 
                                Text="Folio Contrato "></asp:Label>
                        </td>
                        <td style="width: 61px">
                            <asp:TextBox ID="TXT_ConsultaFolioContrato" runat="server" 
                                CssClass="cajastexto" ReadOnly="True" Width="60px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="etiquetas" 
                                Text="Última Mantención "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ConsultaFechaUltimaMantención" runat="server" 
                                CssClass="cajastexto" ReadOnly="True" Width="90px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; width: 82px;">
                            <asp:Label ID="Label3" runat="server" CssClass="etiquetas" 
                                Text="Estado Cliente "></asp:Label>
                        </td>
                        <td colspan="2" style="height: 20px">
                            <asp:TextBox ID="TXT_ConsultaEstadoGeneral" runat="server" 
                                CssClass="cajastexto" ReadOnly="True" Width="170px"></asp:TextBox>
                        </td>
                        <td style="height: 20px; width: 90px;">
                            <asp:Label ID="Label5" runat="server" CssClass="etiquetas" Text="Fecha "></asp:Label>
                        </td>
                        <td style="height: 20px; width: 65px;">
                            <asp:TextBox ID="TXT_ConsultaFechaEstadoGeneral" runat="server" 
                                CssClass="cajastexto" ReadOnly="True" Width="60px"></asp:TextBox>
                        </td>
                        <td colspan="2" style="height: 20px; text-align: center; width:340px;">
                            <asp:Label ID="LBL_MensajeContratos" runat="server" CssClass="etiquetasmensaje"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <table class="tablas">
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" CssClass="etiquetas" Text="Día de Pago "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaDiaPago" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" CssClass="etiquetas" Text="Fecha pago "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaFechaPago" runat="server" CssClass="cajastexto" 
                            ReadOnly="True" Width="120px"></asp:TextBox>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="Label15" runat="server" CssClass="etiquetas" 
                            Text="Días de Mora "></asp:Label>
                    </td>
                    <td style="text-align: right">
                        <asp:TextBox ID="TXT_ConsultaDiasMora" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" CssClass="etiquetas" 
                            Text="Línea de Crédito "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaLineaCredito" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="100px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" CssClass="etiquetas" Text="A pago "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaMontoAPago" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="120px">0</asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" CssClass="etiquetas" 
                            Text="Cupo Disponible "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaCupoDisponible" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="100px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label13" runat="server" CssClass="etiquetas" 
                            Text="Pagos del Período "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaPagosPeriodo" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="120px">0</asp:TextBox>
                    </td>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="LBL_MensajeAvance" runat="server" CssClass="etiquetasmensaje"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" CssClass="etiquetas" 
                            Text="Total deuda  "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaTotalDeuda" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="100px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" CssClass="etiquetas" Text="Saldo "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaSaldo" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="120px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="LBL_TabIndice" runat="server" CssClass="etiquetas" 
                            style="display:none"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <table class="tablas">
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" CssClass="etiquetas" Text="Calle "></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TXT_ConsultaDireccCalle" runat="server" CssClass="cajastexto" 
                            ReadOnly="True" Width="220px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label19" runat="server" CssClass="etiquetas" Text="Número "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaDireccNumero" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="82px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label22" runat="server" CssClass="etiquetas" Text="Depto. "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaDireccDepto" runat="server" 
                            CssClass="cajastextonumerico" ReadOnly="True" Width="65px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label23" runat="server" CssClass="etiquetas" 
                            Text="Teléfono Particular "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaTeleFonoParticular" runat="server" 
                            CssClass="cajastexto" ReadOnly="True" Width="95px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" CssClass="etiquetas" Text="Villa "></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TXT_ConsultaDireccVilla" runat="server" CssClass="cajastexto" 
                            ReadOnly="True" Width="220px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label20" runat="server" CssClass="etiquetas" Text="Región "></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="TXT_ConsultaDireccRegion" runat="server" CssClass="cajastexto" 
                            ReadOnly="True" Width="215px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label24" runat="server" CssClass="etiquetas" 
                            Text="Teléfono Celular "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaTeleFonoCelular" runat="server" 
                            CssClass="cajastexto" ReadOnly="True" Width="95px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18" runat="server" CssClass="etiquetas" Text="Altura "></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TXT_ConsultaDireccAltura" runat="server" CssClass="cajastexto" 
                            ReadOnly="True" Width="220px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label21" runat="server" CssClass="etiquetas" Text="Comuna "></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="TXT_ConsultaDireccComuna" runat="server" CssClass="cajastexto" 
                            ReadOnly="True" Width="215px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label25" runat="server" CssClass="etiquetas" 
                            Text="Tarjeta Entregada "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TXT_ConsultaTarjetaEntregada" runat="server" 
                            CssClass="cajastexto" ReadOnly="True" Width="95px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div>
                <table class="tablas">
                    <tr>
                        <td style="width: 70px">
                            <asp:Label ID="LBL_Vencimiento1" runat="server" CssClass="etiquetas">-</asp:Label>
                        </td>
                        <td style="width: 70px">
                            <asp:Label ID="LBL_Vencimiento2" runat="server" CssClass="etiquetas">-</asp:Label>
                        </td>
                        <td style="width: 70px">
                            <asp:Label ID="LBL_Vencimiento3" runat="server" CssClass="etiquetas">-</asp:Label>
                        </td>
                        <td style="width: 70px">
                            <asp:Label ID="LBL_Vencimiento4" runat="server" CssClass="etiquetas">-</asp:Label>
                        </td>
                        <td style="width: 70px">
                            <asp:Label ID="LBL_Vencimiento5" runat="server" CssClass="etiquetas">-</asp:Label>
                        </td>
                        <td style="width: 70px">
                            <asp:Label ID="LBL_Vencimiento6" runat="server" CssClass="etiquetas">-</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LBL_MensajeError" runat="server" CssClass="etiquetasmensaje"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 70px">
                            <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota1" runat="server" 
                                CssClass="cajastextonumerico" ReadOnly="True" Width="70px"></asp:TextBox>
                        </td>
                        <td style="width: 70px">
                            <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota2" runat="server" 
                                CssClass="cajastextonumerico" ReadOnly="True" Width="70px"></asp:TextBox>
                        </td>
                        <td style="width: 70px">
                            <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota3" runat="server" 
                                CssClass="cajastextonumerico" ReadOnly="True" Width="70px"></asp:TextBox>
                        </td>
                        <td style="width: 70px">
                            <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota4" runat="server" 
                                CssClass="cajastextonumerico" ReadOnly="True" Width="70px"></asp:TextBox>
                        </td>
                        <td style="width: 70px">
                            <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota5" runat="server" 
                                CssClass="cajastextonumerico" ReadOnly="True" Width="70px"></asp:TextBox>
                        </td>
                        <td style="width: 70px">
                            <asp:TextBox ID="TXT_ConsultaValorVencimientoCuota6" runat="server" 
                                CssClass="cajastextonumerico" ReadOnly="True" Width="70px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="LBL_MensajeAvance1" runat="server" CssClass="etiquetasmensaje"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>            
        <asp:Button ID="BTN_ProcesaTab" runat="server" style="display:none" Text="Button" /> 
    </ContentTemplate>
    </asp:UpdatePanel>                             
 <asp:UpdatePanel ID="UpdatePanel_TabConsulta" runat="server" UpdateMode="Conditional">
 <ContentTemplate>
  <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_TabConsulta" DisplayAfter="20">
            <ProgressTemplate>
                <div class="update_tabcliente">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>         
            <div ID="div_TabConsultas">
                <cc1:TabContainer ID="Tab_Consultas" runat="server" ActiveTabIndex="0" 
                    BorderColor="#FFCC00" BorderStyle="Outset" Height="212px" 
                    OnClientActiveTabChanged="clientActiveTabChanged" ViewStateMode="Enabled" 
                    Width="770px">
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            Estados
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Estados" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Estados" runat="server" AutoGenerateColumns="False" 
                                    CssClass="grillaschicas_tab" Height="16px" Width="737px">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" 
                                            SelectText="" ShowSelectButton="True" />
                                        <asp:BoundField DataField="column3" DataFormatString="{0:d}" HeaderText="Fecha">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
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
                            <asp:Panel ID="Panel_EstadosDetalle" runat="server" Visible="False" 
                                Width="754px">
                                <asp:Label ID="Label123" runat="server" CssClass="etiquetas_tab" 
                                    Text="Descripción Sub-Estado "></asp:Label>
                                <asp:TextBox ID="TXT_EstadoDescripcionSubEstado" runat="server" 
                                    CssClass="cajastexto_tab" ReadOnly="True" Width="350px">BLOQUEADO</asp:TextBox>
                                    <br />
                                <asp:ImageButton ID="IBTN_EstadosSubEstados" runat="server" 
                                    CssClass="boton_volver" ImageUrl="~/Imagenes/mano_volver.jpg" />
                            </asp:Panel>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Laboral
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table ID="TBL_Laboral" runat="server" class="tabla_tabcontainer" 
                                style="width: 752px">
                                <tr>
                                    <td style="margin-left: 40px; width: 155px;">
                                        <asp:Label ID="Label83" runat="server" CssClass="etiquetas_tab" 
                                            Text="Empleador"></asp:Label>
                                    </td>
                                    <td style="width: 328px; ">
                                        <asp:TextBox ID="TXT_LaboralEmpleador" runat="server" CssClass="cajastexto_tab" 
                                            ReadOnly="True" Width="280px"></asp:TextBox>
                                    </td>
                                    <td style="width: 172px">
                                        <asp:Label ID="Label95" runat="server" CssClass="etiquetas_tab" 
                                            Text="Antigüedad"></asp:Label>
                                    </td>
                                    <td style="text-align: right; width: 209px;">
                                        <asp:TextBox ID="TXT_LaboralAntiguedad" runat="server" 
                                            CssClass="cajastexto_tab" ReadOnly="True" Width="220px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label85" runat="server" CssClass="etiquetas_tab" 
                                            Text="Dirección"></asp:Label>
                                    </td>
                                    <td style="width: 328px; ">
                                        <asp:TextBox ID="TXT_LaboralDireccion" runat="server" CssClass="cajastexto_tab" 
                                            ReadOnly="True" Width="280px"></asp:TextBox>
                                    </td>
                                    <td style="width: 172px">
                                        <asp:Label ID="Label96" runat="server" CssClass="etiquetas_tab" 
                                            Text="Total Ingresos"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 209px;">
                                        <asp:TextBox ID="TXT_LaboralIngresos" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="150px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px; height: 23px;">
                                        <asp:Label ID="Label87" runat="server" CssClass="etiquetas_tab" Text="Región"></asp:Label>
                                    </td>
                                    <td style="width: 328px; height: 23px;">
                                        <asp:TextBox ID="TXT_LaboralRegion" runat="server" CssClass="cajastexto_tab" 
                                            ReadOnly="True" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: 172px; height: 23px;">
                                    </td>
                                    <td style="text-align: right; height: 23px; width: 209px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label89" runat="server" CssClass="etiquetas_tab" Text="Comuna"></asp:Label>
                                    </td>
                                    <td style="width: 328px; ">
                                        <asp:TextBox ID="TXT_LaboralComuna" runat="server" CssClass="cajastexto_tab" 
                                            ReadOnly="True" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: 172px">
                                    </td>
                                    <td style="text-align: right; width: 209px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label91" runat="server" CssClass="etiquetas_tab" Text="Teléfono"></asp:Label>
                                    </td>
                                    <td style="width: 328px; ">
                                        <asp:TextBox ID="TXT_LaboralTelefono" runat="server" CssClass="cajastexto_tab" 
                                            ReadOnly="True" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: 172px">
                                    </td>
                                    <td style="text-align: right; width: 209px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label93" runat="server" CssClass="etiquetas_tab" Text="Anexo"></asp:Label>
                                    </td>
                                    <td style="width: 328px; ">
                                        <asp:TextBox ID="TXT_LaboralAnexo" runat="server" CssClass="cajastexto_tab" 
                                            ReadOnly="True" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: 172px">
                                    </td>
                                    <td style="text-align: right; width: 209px;">
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="LBL_LaboralError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Contratos
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Contratos" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Contratos" runat="server" AutoGenerateColumns="False" 
                                    CssClass="grillaschicas_tab" Height="16px" Width="737px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" DataFormatString="{0:d}" 
                                            HeaderText="Fecha Firma">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
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
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                        <HeaderTemplate>
                            Modificaciones
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Modificaciones" runat="server" CssClass="panel_tab" 
                                ScrollBars="Both">
                                <asp:GridView ID="Grilla_Modificaciones" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
                                    Width="737px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" HeaderText="Modificación de" />
                                        <asp:BoundField DataField="column9" HeaderText="Dato Antiguo" />
                                        <asp:BoundField DataField="column8" HeaderText="Dato Nuevo" />
                                        <asp:BoundField DataField="column4" DataFormatString="{0:d}" HeaderText="Fecha">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column5" HeaderText="Hora" />
                                        <asp:BoundField DataField="column6" HeaderText="Tienda" />
                                        <asp:BoundField DataField="column7" HeaderText="Responsable" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_ModificacionesError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />                           
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
                        <HeaderTemplate>
                            Descuentos
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Descuentos" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Descuentos" runat="server" AutoGenerateColumns="False" 
                                    CssClass="grillaschicas_tab" Height="16px" Width="737px">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" 
                                            ShowSelectButton="True" />
                                        <asp:BoundField DataField="column4" HeaderText="Tienda" />
                                        <asp:BoundField DataField="column5" HeaderText="Caja" />
                                        <asp:BoundField DataField="column6" HeaderText="Nro. Comprobante" />
                                        <asp:BoundField DataField="column7" DataFormatString="{0:d}" 
                                            HeaderText="Fecha Pago" />
                                        <asp:BoundField DataField="column8" DataFormatString="{0:N0}" 
                                            HeaderText="Total Descuento">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column9" HeaderText="Estado" />
                                        <asp:BoundField DataField="column10" HeaderText="Código" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_DescuentosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            <table ID="TBL_DescuentosDetalle" runat="server" cellspacing="1" 
                                class="auto-style3" style="width: 760px" visible="False">
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label124" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Capital"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosMontoCapital" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label131" runat="server" CssClass="etiquetas_tab" 
                                            Text="Interés Mora"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosInteresMora" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label138" runat="server" CssClass="etiquetas_tab" 
                                            Text="Saldo  a Favor Inicial"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosSaldoFavorInicial" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label125" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Interés"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosMontoInteres" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label132" runat="server" CssClass="etiquetas_tab" 
                                            Text="Gastos Cobranza"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosGastosCobranza" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label139" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto del Abono"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosMontoAbono" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label126" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Honorarios"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosMontoHonorarios" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label133" runat="server" CssClass="etiquetas_tab" 
                                            Text="Impuesto"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosImpuesto" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label140" runat="server" CssClass="etiquetas_tab" 
                                            Text="Saldo a Favor Final"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosSaldoFavorFinal" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label127" runat="server" CssClass="etiquetas_tab" 
                                            Text="Cobro Producto"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosCobroProducto" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label134" runat="server" CssClass="etiquetas_tab" 
                                            Text="Cobros Grales."></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosCobrosGrales" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label141" runat="server" CssClass="etiquetas_tab" 
                                            Text="Fecha de Proceso"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosFechaProceso" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label128" runat="server" CssClass="etiquetas_tab" 
                                            Text="Comisión Avance"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosComisionAvance" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label135" runat="server" CssClass="etiquetas_tab" 
                                            Text="Costas Judiciales"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosCostasJudiciales" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label142" runat="server" CssClass="etiquetas_tab" 
                                            Text="Estado del Abono"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosEstadoAbono" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label129" runat="server" CssClass="etiquetas_tab" 
                                            Text="Administración"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosAdministracion" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label136" runat="server" CssClass="etiquetas_tab" 
                                            Text="Interés Periodo"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosInteresPeriodo" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                    </td>
                                    <td runat="server">
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label130" runat="server" CssClass="etiquetas_tab" Text="Seguros"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosSeguros" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label137" runat="server" CssClass="etiquetas_tab" 
                                            Text="Cargos Pagados"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_DescuentosCargosPagados" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                    </td>
                                    <td runat="server">
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="LBL_DescuentosDetalleError" runat="server" 
                                CssClass="etiquetas_tab"></asp:Label>
                                <br />
                                <asp:ImageButton ID="IBTN_DescuentosDetalle" runat="server" 
                                CssClass="boton_volver" ImageUrl="~/Imagenes/mano_volver.jpg" />
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel6">
                        <HeaderTemplate>
                            Antec.Comerciales
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_ConsultasDB" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical" Width="754px">
                                <asp:GridView ID="Grilla_ConsultasDB" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
                                    Width="737px">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" 
                                            ShowSelectButton="True" />
                                        <asp:BoundField DataField="column4" DataFormatString="{0:d}" HeaderText="Fecha">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column5" HeaderText="Hora" />
                                        <asp:BoundField DataField="column6" HeaderText="Motivo" />
                                        <asp:BoundField DataField="column7" HeaderText="Edad">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column8" DataFormatString="{0:N0}" 
                                            HeaderText="Score">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column9" HeaderText="Antec." />
                                        <asp:BoundField DataField="column10" HeaderText="Dirección" />
                                        <asp:BoundField DataField="column11" HeaderText="Ciudad" />
                                        <asp:BoundField DataField="column12" HeaderText="Cod.Motivo" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_ConsultasDBError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            <asp:Panel ID="Panel_ConsultasDBDetalles" runat="server" CssClass="panel_tab" 
                                Height="160px" ScrollBars="Vertical" Visible="False">
                                <asp:GridView ID="Grilla_ConsultasDBDetalles" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
                                    Width="737px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" HeaderText="Tipo Consulta" />
                                        <asp:BoundField DataField="column4" DataFormatString="{0:d}" 
                                            HeaderText="Fecha Consulta Detalle" />
                                        <asp:BoundField DataField="column5" HeaderText="Empresa" />
                                        <asp:BoundField DataField="column6" HeaderText="Descripción 1" />
                                        <asp:BoundField DataField="column7" HeaderText="Descripción 2" />
                                    </Columns>
                                </asp:GridView>
                                            <br />
                                        </asp:Panel>
                            <asp:Label ID="LBL_ConsultasDBDetalleError" runat="server" 
                                CssClass="etiquetas_tab"></asp:Label>
                                <br />
                                <asp:ImageButton ID="IBTN_ConsultasDBDetalle" runat="server" 
                                CssClass="boton_volver" ImageUrl="~/Imagenes/mano_volver.jpg" />
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel7">
                        <HeaderTemplate>
                            Solicitudes
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Solicitudes" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Solicitudes" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
                                    Width="737px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" HeaderText="Tipo Solicitud" />
                                        <asp:BoundField DataField="column4" DataFormatString="{0:d}" HeaderText="Fecha">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column5" DataFormatString="{0:HH:mm}" 
                                            HeaderText="Hora" />
                                        <asp:BoundField DataField="column6" HeaderText="Rut Operador" />
                                        <asp:BoundField DataField="column7" HeaderText="Estado Solicitud" />
                                        <asp:BoundField DataField="column8" HeaderText="Glosa" />
                                        <asp:BoundField DataField="column9" HeaderText="Autoriza Aumento LCRED" />
                                        <asp:BoundField DataField="column10" HeaderText="Aumento Autorizado LCRED" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_SolicitudesError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />                            
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel8" runat="server" HeaderText="TabPanel8">
                        <HeaderTemplate>
                            Resumen Cuenta
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table class="auto-style2" style="width: 765px; height: 174px;">
                                <tr>
                                    <td style="width: 224px">
                                        <asp:Label ID="Label108" runat="server" CssClass="etiquetas_tab" 
                                            Text="Últimos Abonos"></asp:Label>
                                    </td>
                                    <td style="width: 226px">
                                        <asp:Label ID="Label109" runat="server" CssClass="etiquetas_tab" 
                                            Text="Clasificaciones"></asp:Label>
                                    </td>
                                    <td style="width: 693px">
                                        <asp:Label ID="Label110" runat="server" CssClass="etiquetas_tab" 
                                            Text="Fecha Solicitud"></asp:Label>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="TXT_ResumenFecSolicitud" runat="server" 
                                            CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td rowspan="8" style="width: 224px">
                                        <asp:Panel ID="Panel_ResumenUltimosAbonos" runat="server" Height="180px" 
                                            ScrollBars="Vertical" Width="245px">
                                            <asp:GridView ID="Grilla_ResumenUltimosAbonos" runat="server" 
                                                AutoGenerateColumns="False" CssClass="grillaschicas_tab" Width="225px">
                                                <Columns>
                                                    <asp:BoundField DataField="column3" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="column5" DataFormatString="{0:d}" 
                                                        HeaderText="Fecha ">
                                                    <ItemStyle Width="70px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="column6" DataFormatString="{0:N0}" 
                                                        HeaderText="Monto ">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                        <asp:Label ID="LBL_ResumenUltAbonosError" runat="server" 
                                            CssClass="etiquetas_tab"></asp:Label>
                                    </td>
                                    <td rowspan="8" style="width: 226px">
                                        <asp:Panel ID="Panel_ResumenUltimasClasificaciones" runat="server" 
                                            Height="180px" ScrollBars="Vertical" Width="135px">
                                            <asp:GridView ID="Grilla_ResumenUltimasClasificaciones" runat="server" 
                                                AutoGenerateColumns="False" CssClass="grillaschicas_tab" Width="102px">
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
                                        <asp:Label ID="Label112" runat="server" CssClass="etiquetas_tab" 
                                            Text="Fecha Aprobación"></asp:Label>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="TXT_ResumenFecAprobacion" runat="server" 
                                            CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 693px">
                                        <asp:Label ID="Label114" runat="server" CssClass="etiquetas_tab" 
                                            Text="Fecha Verificación Particular"></asp:Label>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="TXT_ResumenFecVerifParticular" runat="server" 
                                            CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 693px">
                                        <asp:Label ID="Label116" runat="server" CssClass="etiquetas_tab" 
                                            Text="Fecha Verificación Laboral"></asp:Label>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="TXT_ResumenFecVerifLaboral" runat="server" 
                                            CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 693px">
                                        <asp:Label ID="Label118" runat="server" CssClass="etiquetas_tab" 
                                            Text="Fecha Rechazo"></asp:Label>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="TXT_ResumenFecRechazo" runat="server" 
                                            CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 693px">
                                    </td>
                                    <td style="width: 250px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 693px">
                                        <asp:Label ID="Label120" runat="server" CssClass="etiquetas_tab" 
                                            Text="Total Cuenta Al"></asp:Label>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="TXT_ResumenTotalCuentaAl" runat="server" 
                                            CssClass="cajastexto_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 693px">
                                        <asp:Label ID="Label121" runat="server" CssClass="etiquetas_tab" 
                                            Text="COMPRAS TOTALES"></asp:Label>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="TXT_ResumenComprasTotales" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 693px">
                                        <asp:Label ID="Label122" runat="server" CssClass="etiquetas_tab" 
                                            Text="PAGOS TOTALES"></asp:Label>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="TXT_ResumenPagosTotales" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel11" runat="server" HeaderText="TabPanel11">
                        <HeaderTemplate>
                            Comentarios
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Comentarios" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Comentarios" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
                                    Width="737px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" DataFormatString="{0:d}" 
                                            HeaderText="Fecha ">
                                        <ItemStyle Width="70px" />
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
                        <br />
                        <br />
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel9" runat="server" HeaderText="TabPanel9">
                        <HeaderTemplate>
                            Pagos
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Pagos" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Pagos" runat="server" AutoGenerateColumns="False" 
                                    CssClass="grillaschicas_tab" Height="16px" Width="720px">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" 
                                            ShowSelectButton="True" />
                                        <asp:BoundField DataField="column3" HeaderText="Origen Pago" />
                                        <asp:BoundField DataField="column4" HeaderText="Tipo" />
                                        <asp:BoundField DataField="column5" HeaderText="Tienda Pago" />
                                        <asp:BoundField DataField="column6" HeaderText="Caja" />
                                        <asp:BoundField DataField="column7" HeaderText="Nro.Comprobante" />
                                        <asp:BoundField DataField="column8" DataFormatString="{0:d}" 
                                            HeaderText="Fecha Pago">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column9" DataFormatString="{0:N0}" 
                                            HeaderText="Monto Pagado">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column1" HeaderText="Cód. Sucursal">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_PagosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            <table ID="TBL_DetallePagos" runat="server" cellspacing="1" class="auto-style3" 
                                style="width: 760px" visible="False">
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label143" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Capital"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosMontoCapital" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label144" runat="server" CssClass="etiquetas_tab" 
                                            Text="Interés Mora"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosInteresMora" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label145" runat="server" CssClass="etiquetas_tab" 
                                            Text="Saldo  a Favor Inicial"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosSaldoFavorInicial" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label146" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Interés"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosMontoInteres" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label147" runat="server" CssClass="etiquetas_tab" 
                                            Text="Gastos Cobranza"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosGastosCobranza" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label148" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto del Abono"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosMontoAbono" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label149" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Honorarios"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosMontoHonorarios" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label1522" runat="server" CssClass="etiquetas_tab" 
                                            Text="Impuesto"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosImpuesto" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label151" runat="server" CssClass="etiquetas_tab" 
                                            Text="Saldo a Favor Final"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosSaldoFavorFinal" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label152" runat="server" CssClass="etiquetas_tab" 
                                            Text="Cobro Producto"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosCobroProducto" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label153" runat="server" CssClass="etiquetas_tab" 
                                            Text="Cobros Grales."></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosCobrosGrales" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label154" runat="server" CssClass="etiquetas_tab" 
                                            Text="Fecha de Proceso"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosFechaProceso" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label155" runat="server" CssClass="etiquetas_tab" 
                                            Text="Comisión Avance"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosComisionAvance" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label156" runat="server" CssClass="etiquetas_tab" 
                                            Text="Costas Judiciales"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosCostasJudiciales" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label157" runat="server" CssClass="etiquetas_tab" 
                                            Text="Estado del Abono"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosEstadoAbono" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label158" runat="server" CssClass="etiquetas_tab" 
                                            Text="Administración"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosAdministracion" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label159" runat="server" CssClass="etiquetas_tab" 
                                            Text="Interés Periodo"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosInteresPeriodo" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                    </td>
                                    <td runat="server">
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label162" runat="server" CssClass="etiquetas_tab" Text="Seguros"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosSeguros" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label161" runat="server" CssClass="etiquetas_tab" 
                                            Text="Cargos Pagados"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="TXT_PagosCargosPagados" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                    </td>
                                    <td runat="server">
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="LBL_PagosDetalleError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                                <asp:ImageButton ID="IBTN_PagosDetalle" runat="server" 
                                CssClass="boton_volver" ImageUrl="~/Imagenes/mano_volver.jpg" />
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel10">
                        <HeaderTemplate>
                            Ventas
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Ventas" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Ventas" runat="server" AutoGenerateColumns="False" 
                                    CssClass="grillaschicas_tab" Height="16px" Width="737px">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" 
                                            ShowSelectButton="True" />
                                        <asp:BoundField DataField="column4" HeaderText="Descripción Venta" />
                                        <asp:BoundField DataField="column5" HeaderText="Sucursal" />
                                        <asp:BoundField DataField="column6" DataFormatString="{0:d}" HeaderText="Fecha">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column7" HeaderText="Hora" />
                                        <asp:BoundField DataField="column8" HeaderText="Caja" />
                                        <asp:BoundField DataField="column9" HeaderText="Nro.Comp." />
                                        <asp:BoundField DataField="column10" HeaderText="Cuotas" />
                                        <asp:BoundField DataField="column11" DataFormatString="{0:N0}" 
                                            HeaderText="Venta Capital">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column12" DataFormatString="{0:N0}" 
                                            HeaderText="Venta Financ.">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column13" DataFormatString="{0:d}" 
                                            HeaderText="Fec. 1er Venc.">
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
                            <asp:Panel ID="Panel_VentasDetalle" runat="server" CssClass="panel_tab" 
                                Height="160px" ScrollBars="Vertical" Visible="False">
                                <asp:GridView ID="Grilla_VentasDetalle" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
                                    Width="737px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" HeaderText="Nro. Cuota">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column4" DataFormatString="{0:d}" 
                                            HeaderText="Fecha Vencimiento" />
                                        <asp:BoundField DataField="column5" DataFormatString="{0:N0}" 
                                            HeaderText="Monto Capital">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column6" DataFormatString="{0:N0}" 
                                            HeaderText="Monto Interés">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column7" DataFormatString="{0:N0}" 
                                            HeaderText="Monto Honorarios">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column8" DataFormatString="{0:N0}" 
                                            HeaderText="Cobro Producto">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column9" DataFormatString="{0:N0}" 
                                            HeaderText="Monto Total">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column10" HeaderText="Estado Cuota" />
                                    </Columns>
                                </asp:GridView>
                                            <br />
                                        </asp:Panel>
                            <asp:Label ID="LBL_VentasDetalleError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                                <asp:ImageButton ID="IBTN_VentasDetalle" runat="server" 
                                CssClass="boton_volver" ImageUrl="~/Imagenes/mano_volver.jpg" />
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel12" runat="server" HeaderText="TabPanel12">
                        <HeaderTemplate>
                            Repactaciones
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Repactaciones" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Repactaciones" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
                                    Width="726px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" HeaderText="Tipo Repactación" />
                                        <asp:BoundField DataField="column4" HeaderText="Sucursal" />
                                        <asp:BoundField DataField="column5" HeaderText="Caja" />
                                        <asp:BoundField DataField="column6" HeaderText="Nro. Abono" />
                                        <asp:BoundField DataField="column7" DataFormatString="{0:d}" 
                                            HeaderText="Fecha Repactación" />
                                        <asp:BoundField DataField="column8" DataFormatString="{0:N0}" 
                                            HeaderText="Pie" />
                                        <asp:BoundField DataField="column9" DataFormatString="{0:N0}" 
                                            HeaderText="Descuento" />
                                        <asp:BoundField DataField="column10" DataFormatString="{0:N0}" 
                                            HeaderText="A Repactar" />
                                        <asp:BoundField DataField="column11" DataFormatString="{0:N0}" 
                                            HeaderText="Total">
                                        <ItemStyle Width="70px" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                    <br />
                                </asp:Panel>
                            <asp:Label ID="LBL_RepactacionesError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel13" runat="server" HeaderText="TabPanel13">
                        <HeaderTemplate>
                            Deuda
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table ID="TBL_Deuda" runat="server" class="tabla_tabcontainer">
                                <tr>
                                    <td style="margin-left: 40px; width: 155px;">
                                        <asp:Label ID="Label55" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Capital"></asp:Label>
                                    </td>
                                    <td style="width: 84px; text-align: right;">
                                        <asp:TextBox ID="TXT_DeudaMontoCapital" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                    </td>
                                    <td style="width: 166px">
                                        <asp:Label ID="Label57" runat="server" CssClass="etiquetas_tab" 
                                            Text="Interés Mora"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:TextBox ID="TXT_DeudaInteresMora" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px; height: 23px;">
                                        <asp:Label ID="Label59" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Interés"></asp:Label>
                                    </td>
                                    <td style="width: 84px; text-align: right; height: 23px;">
                                        <asp:TextBox ID="TXT_DeudaMontoInteres" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td style="width: 150px; height: 23px;">
                                    </td>
                                    <td style="width: 166px; height: 23px;">
                                        <asp:Label ID="Label61" runat="server" CssClass="etiquetas_tab" 
                                            Text="Gastos Cobranza"></asp:Label>
                                    </td>
                                    <td style="text-align: right; height: 23px;">
                                        <asp:TextBox ID="TXT_DeudaGastosCobranza" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label63" runat="server" CssClass="etiquetas_tab" 
                                            Text="Monto Honorario"></asp:Label>
                                    </td>
                                    <td style="width: 84px; text-align: right;">
                                        <asp:TextBox ID="TXT_DeudaMontoHonorario" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                    </td>
                                    <td style="width: 166px">
                                        <asp:Label ID="Label65" runat="server" CssClass="etiquetas_tab" 
                                            Text="Impuestos"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:TextBox ID="TXT_DeudaImpuestos" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label67" runat="server" CssClass="etiquetas_tab" 
                                            Text="Cobro Producto"></asp:Label>
                                    </td>
                                    <td style="width: 84px; text-align: right;">
                                        <asp:TextBox ID="TXT_DeudaCobroProducto" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                    </td>
                                    <td style="width: 166px">
                                        <asp:Label ID="Label69" runat="server" CssClass="etiquetas_tab" 
                                            Text="Costas Judiciales"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:TextBox ID="TXT_DeudaCostasJudiciales" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label71" runat="server" CssClass="etiquetas_tab" 
                                            Text="Comisión Avance"></asp:Label>
                                    </td>
                                    <td style="width: 84px; text-align: right;">
                                        <asp:TextBox ID="TXT_DeudaComisionAvance" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                    </td>
                                    <td style="width: 166px">
                                        <asp:Label ID="Label73" runat="server" CssClass="etiquetas_tab" 
                                            Text="Interés Periodo"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:TextBox ID="TXT_DeudaInteresPeriodo" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label75" runat="server" CssClass="etiquetas_tab" 
                                            Text="Administración"></asp:Label>
                                    </td>
                                    <td style="width: 84px; text-align: right;">
                                        <asp:TextBox ID="TXT_DeudaAdministracion" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                    </td>
                                    <td style="width: 166px">
                                        <asp:Label ID="Label77" runat="server" CssClass="etiquetas_tab" 
                                            Text="Otros Cobros"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:TextBox ID="TXT_DeudaOtrosCobros" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                        <asp:Label ID="Label79" runat="server" CssClass="etiquetas_tab" Text="Seguros"></asp:Label>
                                    </td>
                                    <td style="width: 84px; text-align: right;">
                                        <asp:TextBox ID="TXT_DeudaSeguros" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                    </td>
                                    <td style="width: 166px">
                                        <asp:Label ID="Label81" runat="server" CssClass="etiquetas_tab" 
                                            Text="Saldo a Favor    ( - )"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:TextBox ID="TXT_DeudaSaldoFavor" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 155px">
                                    </td>
                                    <td style="width: 84px; text-align: right;">
                                    </td>
                                    <td style="width: 150px">
                                    </td>
                                    <td style="border-style: outset none none none; border-top-width: 2px;">
                                        <asp:Label ID="Label82" runat="server" CssClass="etiquetas_tabtotales" 
                                            Text="TOTAL DEUDA"></asp:Label>
                                    </td>
                                    <td style="border-top-width: 2px; text-align: right; border-left-style: none; border-right-style: none; border-top-style: outset; border-bottom-style: none;">
                                        <asp:TextBox ID="TXT_DeudaTotal" runat="server" 
                                            CssClass="cajastextonumerico_tab" ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="LBL_DeudaError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel14" runat="server" HeaderText="TabPanel14">
                        <HeaderTemplate>
                            Por Pagar
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_XPagar" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_XPagar" runat="server" AutoGenerateColumns="False" 
                                    CssClass="grillaschicas_tab" Height="16px" ShowFooter="True" Width="737px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" DataFormatString="{0:d}" 
                                            HeaderText="Fecha Venc.">
                                        <FooterStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column4" HeaderText="Tienda" />
                                        <asp:BoundField DataField="column5" HeaderText="Nro. Boleta" />
                                        <asp:BoundField DataField="column6" HeaderText="Nro. Cuota" />
                                        <asp:BoundField DataField="column7" DataFormatString="{0:N0}" 
                                            HeaderText="Capital">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column8" DataFormatString="{0:N0}" 
                                            HeaderText="Interés">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column9" DataFormatString="{0:N0}" 
                                            HeaderText="Honorario">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column10" DataFormatString="{0:N0}" 
                                            HeaderText="Cobros">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column11" DataFormatString="{0:N0}" 
                                            HeaderText="Total Cuota">
                                        <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column12" DataFormatString="{0:N0}" 
                                            HeaderText="Pendiente">
                                        <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column13" DataFormatString="{0:N0}" 
                                            HeaderText="Abonado">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_XPagarError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel15" runat="server" HeaderText="TabPanel15">
                        <HeaderTemplate>
                            Seguros
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_Seguros" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical">
                                <asp:GridView ID="Grilla_Seguros" runat="server" AutoGenerateColumns="False" 
                                    CssClass="grillaschicas_tab" Height="16px" Width="737px">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" 
                                            ShowSelectButton="True" />
                                        <asp:BoundField DataField="column3" HeaderText="Cód.">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column4" HeaderText="Seguro" />
                                        <asp:BoundField DataField="column5" HeaderText="Compañia" />
                                        <asp:BoundField DataField="column6" HeaderText="Tienda" />
                                        <asp:BoundField DataField="column7" HeaderText="Caja" />
                                        <asp:BoundField DataField="column8" HeaderText="Folio" />
                                        <asp:BoundField DataField="column9" DataFormatString="{0:d}" 
                                            HeaderText="Inicio Vig.">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column10" DataFormatString="{0:d}" 
                                            HeaderText="Termino Vig.">
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column11" HeaderText="Motivo Anulación" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="LBL_SegurosError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                            <asp:Panel ID="Panel_SegurosDetalle" runat="server" CssClass="panel_tab" 
                                Height="170px" ScrollBars="Vertical" Visible="False">
                                <asp:GridView ID="Grilla_SegurosDetalle" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" 
                                    Width="737px">
                                    <Columns>
                                        <asp:BoundField DataField="column3" HeaderText="Descrip. Seguro" />
                                        <asp:BoundField DataField="column4" DataFormatString="{0:d}" 
                                            HeaderText="Fecha Vencimiento">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column5" DataFormatString="{0:N0}" 
                                            HeaderText="Monto">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column6" HeaderText="Estado">
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="column7" DataFormatString="{0:d}" 
                                            HeaderText="Estado Cuota" />
                                    </Columns>
                                </asp:GridView>
                                            <br />
                                        </asp:Panel>
                            <asp:Label ID="LBL_SegurosDetalleError" runat="server" CssClass="etiquetas_tab"></asp:Label>
                                <br />
                                <asp:ImageButton ID="IBTN_SegurosDetalle" runat="server" 
                                CssClass="boton_volver" ImageUrl="~/Imagenes/mano_volver.jpg" />
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel16" runat="server" HeaderText="TabPanel16">
                        <HeaderTemplate>
                            SBIF
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel_SBIF" runat="server" CssClass="panel_tab" 
                                ScrollBars="Vertical" Width="300px">
                                <asp:GridView ID="Grilla_SBIF" runat="server" AutoGenerateColumns="False" 
                                    CssClass="grillaschicas_tab" Height="16px" Width="258px">
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
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel17" runat="server" HeaderText="TabPanel17">
                        <HeaderTemplate>
                            PaloBlanco
                        </HeaderTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
    <br />
            </div>
                    </ContentTemplate>                   
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BTN_ProcesaTab" EventName="Click" />
     </Triggers>                  
        </asp:UpdatePanel> 
        </ContentTemplate>
    </asp:UpdatePanel>         
</asp:Content>
