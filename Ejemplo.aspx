<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Ejemplo.aspx.vb" Inherits="MenuPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/EstilosShop.css" rel="stylesheet" />
     <style type="text/css">
         .auto-style1 {
             width: 783px;
         }
     </style>
    </head>
<body style="width: 982px; height: 4px;">
    <form id="form1" runat="server" class="auto-style1">
    <div>
    
        <table class="tablas">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Text="Rut Cliente :" CssClass="cajastextoparametro"></asp:Label>
&nbsp;
                    <asp:TextBox ID="TXT_RutCliente" runat="server" Height="16px" CssClass="cajastextoparametro" Width="73px">9608468</asp:TextBox>
                    &nbsp;<asp:Label ID="Label26" runat="server" Text="-" CssClass="cajastextoparametro"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server" MaxLength="1" Width="16px" CssClass="cajastextoparametro">4</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BTN_Buscar" runat="server" Text="BUSCAR" />
&nbsp;&nbsp;
                    <asp:Button ID="BTN_Buscar0" runat="server" Text="LIMPIAR" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TXT_Apellidos" runat="server" Width="430px" CssClass="cajastextoparametro">ALEJANDRO BERNARDO GROSS ERGAS</asp:TextBox>
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
                        <asp:TextBox ID="TXT_FolioContrato" runat="server" CssClass="cajastexto" Height="16px" Width="100px">63137</asp:TextBox>
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
                        *</td>
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
                    <asp:TextBox ID="TXT_DireccCalle" runat="server" Width="250px" CssClass="cajastexto">BUSTOS</asp:TextBox>
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
                    <asp:TextBox ID="TXT_DireccVilla" runat="server" Width="250px" CssClass="cajastexto">LAS ARAUCARIAS</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label20" runat="server" Text="Región " CssClass="etiquetas"></asp:Label>
                    </td>
                <td colspan="3">
                    <asp:TextBox ID="TXT_DireccRegion" runat="server" Width="260px" CssClass="cajastexto">R. METROPOLITANA</asp:TextBox>
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
                    <asp:TextBox ID="TXT_DireccAltura" runat="server" Width="250px" CssClass="cajastexto">MANQUEHUE</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label21" runat="server" Text="Comuna " CssClass="etiquetas"></asp:Label>
                    </td>
                <td colspan="3">
                    <asp:TextBox ID="TXT_DireccComuna" runat="server" Width="260px" CssClass="cajastexto">COMUNA</asp:TextBox>
                </td>
                <td>
                        <asp:Label ID="Label25" runat="server" Text="Tarjeta Entregada " CssClass="etiquetas"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TXT_TarjetaEntregada" runat="server" Width="100px" CssClass="cajastexto"></asp:TextBox>
                </td>
            </tr>
        </table>
    </form>
    </body>
</html>
