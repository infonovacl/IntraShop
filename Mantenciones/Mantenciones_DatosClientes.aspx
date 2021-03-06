﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_DatosClientes.aspx.vb" Inherits="Mantencion_DatosClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Mantención Datos Cliente</title>
     <style type="text/css">
         .auto-style3 {
             height: 89px;
             width: 654px;
         }
         .auto-style4 {
             height: 20px;
         }
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
         .auto-style11 {
             height: 20px;
             width: 189px;
         }
         .auto-style12 {
             width: 690px;
             background-color: whitesmoke;
             height: 620px;
         }
         .auto-style17 {
             height: 22px;
             width: 219px;
         }
         .auto-style19 {
             width: 145px;
         }
         .auto-style20 {
             height: 20px;
             width: 145px;
         }
         .auto-style21 {
             width: 189px;
         }
         .auto-style22 {
             width: 154px;
         }
         .auto-style23 {
             height: 20px;
             width: 154px;
         }
         .auto-style24 {
             height: 17px;
         }
         .auto-style25 {
             width: 248px;
         }
         .auto-style26 {
             height: 22px;
             width: 248px;
         }
         .auto-style27 {
             height: 24px;
         }
         .auto-style28 {
             height: 16px;
         }
         .auto-style29 {
             width: 219px;
         }
         </style>
     </head>
<body style="width: 694px; height: 313px;">
    <form id="form1" runat="server">
    <div class="auto-style12">                 
        <asp:ScriptManager runat="server" ID="ScriptManagerDatosClientes" EnableViewState="False" LoadScriptsBeforeUI="False" ScriptMode="Release">
        </asp:ScriptManager>        
                <cc2:TabContainer ID="Tab_DatosClientes" runat="server" ActiveTabIndex="1" Height="510px" Width="680px">
                    <cc2:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            Datos Personales
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table align="left" cellspacing="1" class="auto-style3">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label15" runat="server" CssClass="etiquetas_popup" Text="Tienda Origen"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="Label13" runat="server" Text="NUMERO FOLIO CONTRATO" CssClass="etiquetasimportante"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="LBL_FolioContrato" runat="server" Text="0" CssClass="etiquetasimportante"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_TiendaOrigen" runat="server" CssClass="cajastexto_popup" Width="250px" ReadOnly="True" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 22px">
                                        <asp:Label ID="Label16" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Personales"></asp:Label>
                                    </td>
                                    <td colspan="2" style="height: 22px"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label17" runat="server" CssClass="etiquetas_popup" Text="Rut Cliente"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="Label20" runat="server" CssClass="etiquetas_popup" Text="Nombres"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_Rut" runat="server" CssClass="cajastexto_popup" ReadOnly="True" Width="80px" Enabled="False"></asp:TextBox>
                                        &nbsp;-
                                        <asp:TextBox ID="TXT_Dv" runat="server" CssClass="cajastexto_popup" Width="20px" ReadOnly="True" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_Nombres" runat="server" CssClass="cajastexto_popup" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Nombres" CssClass="etiquetasmensajeerror" Display="Dynamic" ErrorMessage="Error" SetFocusOnError="True" ToolTip="Debe Ingresar Datos"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_Nombres" CssClass="etiquetasmensajeerror" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar sólo Caracteres Válidos" ValidationExpression="^[a-zA-Z ]*$">Error</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label18" runat="server" CssClass="etiquetas_popup" Text="Apellido Paterno"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="Label19" runat="server" CssClass="etiquetas_popup" Text="Apellido Materno"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_APaterno" runat="server" CssClass="cajastexto_popup" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXT_APaterno" CssClass="etiquetasmensajeerror" Display="Dynamic" ErrorMessage="Error" SetFocusOnError="True" ToolTip="Debe Ingresar Datos"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TXT_APaterno" CssClass="etiquetasmensajeerror" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar sólo Caracteres Válidos" ValidationExpression="^[a-zA-Z ]*$">Error</asp:RegularExpressionValidator>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_AMaterno" runat="server" CssClass="cajastexto_popup" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TXT_AMaterno" CssClass="etiquetasmensajeerror" Display="Dynamic" ErrorMessage="Error" SetFocusOnError="True" ToolTip="Debe Ingresar Datos"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXT_AMaterno" CssClass="etiquetasmensajeerror" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar sólo Caracteres Válidos" ValidationExpression="^[a-zA-Z ]*$">Error</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style21">
                                        <asp:Label ID="Label21" runat="server" CssClass="etiquetas_popup" Text="Sexo"></asp:Label>
                                    </td>
                                    <td class="auto-style22">
                                        <asp:Label ID="Label24" runat="server" CssClass="etiquetas_popup" Text="Estado Civil"></asp:Label>
                                    </td>
                                    <td class="auto-style19">
                                        <asp:Label ID="Label22" runat="server" CssClass="etiquetas_popup" Text="Fecha Nacimiento"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" CssClass="etiquetas_popup" Text="Edad"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style11">
                                        <asp:RadioButtonList ID="RBL_Sexo" runat="server" CssClass="radiobuton_tab" Height="16px" RepeatDirection="Horizontal" Width="171px" Enabled="False">
                                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td class="auto-style23">
                                        <asp:DropDownList ID="DDL_EstadoCivil" runat="server" CssClass="dropdown_tab" ViewStateMode="Enabled" Width="120px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style20">
                                        <asp:TextBox ID="TXT_FechaNac" runat="server" CssClass="cajastexto_popup" ReadOnly="True" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="TXT_Edad" runat="server" CssClass="cajastexto_popup" Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label25" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Domicilio Particular"></asp:Label>
                                    </td>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label26" runat="server" CssClass="etiquetas_popup" Text="Calle Particular"></asp:Label>
                                    </td>
                                    <td class="auto-style19">
                                        <asp:Label ID="Label29" runat="server" CssClass="etiquetas_popup" Text="Número"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label30" runat="server" CssClass="etiquetas_popup" Text="Nro. Departamento"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_CalleParticular" runat="server" CssClass="cajastexto_popup" Width="250px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style19">
                                        <asp:TextBox ID="TXT_NumeroCasa" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXT_NumeroDepto" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label27" runat="server" CssClass="etiquetas_popup" Text="Villa / Población"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="Label31" runat="server" CssClass="etiquetas_popup" Text="Altura Calle Principal"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_VillaPoblacion" runat="server" CssClass="cajastexto_popup" Width="250px"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_AlturaCalle" runat="server" CssClass="cajastexto_popup" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style24">
                                        <asp:Label ID="Label28" runat="server" CssClass="etiquetas_popup" Text="Región"></asp:Label>
                                    </td>
                                    <td colspan="2" class="auto-style24">
                                        <asp:Label ID="Label32" runat="server" CssClass="etiquetas_popup" Text="Comuna"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="DDL_RegionCliente" runat="server" AutoPostBack="True" CssClass="dropdown_tab" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                     
                                                <asp:DropDownList ID="DDL_ComunaCliente" runat="server" CssClass="dropdown_tab" Width="250px">
                                                </asp:DropDownList>
                                          
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style21">
                                        <asp:Label ID="Label33" runat="server" CssClass="etiquetas_popup" Text="Teléfono Fijo"></asp:Label>
                                        &nbsp;<asp:Label ID="Label67" runat="server" CssClass="etiquetas_popup" Text="("></asp:Label>
                                        <asp:Label ID="Label68" runat="server" CssClass="etiquetas_popup" Text="Máx."></asp:Label>
                                        &nbsp;<asp:Label ID="LBL_MaximoDigitoTelefono" runat="server" CssClass="etiquetas_popup" Text="0"></asp:Label>
                                        &nbsp;<asp:Label ID="Label69" runat="server" CssClass="etiquetas_popup" Text="Dígitos)"></asp:Label>
                                    </td>
                                    <td class="auto-style22">
                                        <asp:Label ID="Label34" runat="server" CssClass="etiquetas_popup" Text="Teléfono Celular"></asp:Label>
                                    </td>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style21">
                                        <asp:TextBox ID="TXT_TelefonoFijo" runat="server" CssClass="cajastexto_popup" Width="90px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TXT_TelefonoFijo" CssClass="etiquetasmensajeerror" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar Valores Numéricos" ValidationExpression="^[0-9]*">Error</asp:RegularExpressionValidator>
                                    </td>
                                    <td class="auto-style22">
                                        <asp:TextBox ID="TXT_TelefonoCelular" runat="server" CssClass="cajastexto_popup" MaxLength="8" Width="90px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TXT_TelefonoCelular" CssClass="etiquetasmensajeerror" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar Valores Numéricos" ValidationExpression="^[0-9]*">Error</asp:RegularExpressionValidator>
                                    </td>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label35" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Referencia"></asp:Label>
                                    </td>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label36" runat="server" CssClass="etiquetas_popup" Text="Nombre y Apellido Referencia"></asp:Label>
                                    </td>
                                    <td class="auto-style19">
                                        <asp:Label ID="Label39" runat="server" CssClass="etiquetas_popup" Text="Teléfono Referencia"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RBL_ReferenciaTipoTelefono" runat="server" CssClass="radiobuton_tab" Height="16px" RepeatDirection="Horizontal" Width="141px">
                                            <asp:ListItem Value="F">Fijo</asp:ListItem>
                                            <asp:ListItem Value="C">Celular</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_ReferenciaNombre" runat="server" CssClass="cajastexto_popup" Width="200px"></asp:TextBox>
                                        &nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TXT_ReferenciaNombre" CssClass="etiquetasmensajeerror" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar sólo Caracteres Válidos" ValidationExpression="^[a-zA-Z ]*$">Error</asp:RegularExpressionValidator>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_ReferenciaTelefono" runat="server" CssClass="cajastexto_popup" MaxLength="9"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TXT_ReferenciaTelefono" CssClass="etiquetasmensajeerror" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar Valores Numéricos" ValidationExpression="^[0-9]*">Error</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style28">
                                        <asp:Label ID="Label37" runat="server" CssClass="etiquetas_popup" Text="Región"></asp:Label>
                                    </td>
                                    <td colspan="2" class="auto-style28">
                                        <asp:Label ID="Label38" runat="server" CssClass="etiquetas_popup" Text="Comuna"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="DDL_ReferenciaRegion" runat="server" AutoPostBack="True" CssClass="dropdown_tab" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="DDL_ReferenciaComuna" runat="server" CssClass="dropdown_tab" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <br /><br />
                        </ContentTemplate>
                    </cc2:TabPanel>
                    <cc2:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Datos Laborales y Crédito
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table cellspacing="1" class="auto-style3">
                                <tr>
                                    <td colspan="2" style="height: 22px">
                                        <asp:Label ID="Label43" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Laborales"></asp:Label>
                                    </td>
                                    <td colspan="2" style="height: 22px"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label44" runat="server" CssClass="etiquetas_popup" Text="Nombre Empleador"></asp:Label>
                                    </td>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_EmpleadorNombre" runat="server" CssClass="cajastexto_popup" Width="250px"></asp:TextBox>
                                        &nbsp;</td>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label46" runat="server" CssClass="etiquetas_popup" Text="Dirección Empleador"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label54" runat="server" CssClass="etiquetas_popup" Text="Número"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label55" runat="server" CssClass="etiquetas_popup" Text="Oficina / Depto."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_EmpleadorDireccion" runat="server" CssClass="cajastexto_popup" Width="250px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXT_EmpleadorNumero" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXT_EmpleadorOficina" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style25">
                                        <asp:Label ID="Label58" runat="server" CssClass="etiquetas_popup" Text="Región"></asp:Label>
                                    </td>
                                    <td class="auto-style29">&nbsp;</td>
                                    <td colspan="2">
                                        <asp:Label ID="Label59" runat="server" CssClass="etiquetas_popup" Text="Comuna"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="DDL_EmpleadorRegion" runat="server" AutoPostBack="True" CssClass="dropdown_tab" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="DDL_EmpleadorComuna" runat="server" CssClass="dropdown_tab" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style26">
                                        <asp:Label ID="Label60" runat="server" CssClass="etiquetas_popup" Text="Teléfono Emp."></asp:Label>
                                    </td>
                                    <td class="auto-style17">
                                        <asp:Label ID="Label61" runat="server" CssClass="etiquetas_popup" Text="Anexo"></asp:Label>
                                    </td>
                                    <td colspan="2" style="height: 22px"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style25">
                                        <asp:TextBox ID="TXT_EmpleadorTelefono" runat="server" CssClass="cajastexto_popup" Width="90px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TXT_EmpleadorTelefono" CssClass="etiquetasmensajeerror" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar Valores Numéricos" ValidationExpression="^[0-9]*">Error</asp:RegularExpressionValidator>
                                    </td>
                                    <td class="auto-style29">
                                        <asp:TextBox ID="TXT_EmpleadorAnexo" runat="server" CssClass="cajastexto_popup" Width="90px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TXT_EmpleadorAnexo" CssClass="etiquetasmensajeerror" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar Valores Numéricos" ValidationExpression="^[0-9]*">Error</asp:RegularExpressionValidator>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label62" runat="server" CssClass="etiquetas_popup" Text="Cargo"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXT_EmpleadorCargo" runat="server" CssClass="cajastexto_popup" Width="250px"></asp:TextBox>
                                    </td>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label63" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Crédito"></asp:Label>
                                    </td>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label64" runat="server" CssClass="etiquetas_popup" Text="Día deseado de Pago"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="Label65" runat="server" CssClass="etiquetas_popup" Text="Lugar de Envío Estado de Cuenta"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style27">
                                        <asp:DropDownList ID="DDL_DiaPago" runat="server" CssClass="dropdown_tab" Width="140px" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2" class="auto-style27">
                                        <asp:DropDownList ID="DDL_LugarEnvio" runat="server" CssClass="dropdown_tab" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style25">
                                        <asp:Label ID="Label66" runat="server" CssClass="etiquetas_popup" Text="Correo Eléctronico"></asp:Label>
                                    </td>
                                    <td class="auto-style29">&nbsp;</td>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 24px">
                                        <asp:TextBox ID="TXT_CorreoElectronico" runat="server" CssClass="cajastexto_popup" Width="250px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TXT_CorreoElectronico" CssClass="etiquetasmensajeerror" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ToolTip="Debe Ingresar una email Válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Error</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 24px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">&nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc2:TabPanel>
                </cc2:TabContainer>
                <asp:Label ID="LBL_DatosClienteError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                <table class="auto-style7" align="center">
                    <tr>
                        <td class="auto-style9"><asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />                         
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                         
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" />
                        </td>
                    </tr>
                </table>
    </div>
    </form>
    </body>
</html>
