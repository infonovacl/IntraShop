﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_DatosClientes.aspx.vb" Inherits="Mantencion_DatosClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Sistema Web - Comentarios</title>
     <style type="text/css">
         .auto-style1 {
             width: 690px;
             background-color: lightblue;
             height: 560px;
         }
         .auto-style3 {
             height: 89px;
             width: 654px;
         }
         .auto-style4 {
             height: 20px;
         }
         .auto-style5 {
             width: 162px;
         }
         .auto-style6 {
             height: 20px;
             width: 162px;
         }
         </style>
     </head>
<body style="width: 775px; height: 313px;">
    <form id="form1" runat="server">
    <div class="auto-style1">       
        <cc2:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"  Width="680px" Height="490px" >
            <cc2:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Datos Personales
                </HeaderTemplate>               
                
<ContentTemplate>
    <table cellspacing="1" class="auto-style3"><tr><td colspan="2"><asp:Label ID="Label15" runat="server" CssClass="etiquetas_popup" Text="Tienda Origen"></asp:Label>
        </td><td colspan="2"><asp:Label ID="Label13" runat="server" Text="NUMERO FOLIO CONTRATO"></asp:Label>
            <asp:Label ID="Label14" runat="server" Text="0"></asp:Label>
        </td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_TiendaOrigen" runat="server" CssClass="cajastexto_popup" Width="330px"></asp:TextBox>
            </td><td colspan="2"></td></tr><tr><td style="height: 22px" colspan="2">
            <asp:Label ID="Label16" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Personales"></asp:Label>
        </td><td style="height: 22px" colspan="2"></td></tr><tr><td colspan="2"><asp:Label ID="Label17" runat="server" CssClass="etiquetas_popup" Text="Rut Cliente"></asp:Label>
        </td><td colspan="2"><asp:Label ID="Label20" runat="server" CssClass="etiquetas_popup" Text="Nombres"></asp:Label>
        </td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_Rut" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
            &nbsp;-
            <asp:TextBox ID="TXT_Dv" runat="server" CssClass="cajastexto_popup" Width="20px"></asp:TextBox>
            </td><td colspan="2">
<asp:TextBox ID="TXT_Nombres" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td></tr><tr><td colspan="2"><asp:Label ID="Label18" runat="server" CssClass="etiquetas_popup" Text="Apellido Paterno"></asp:Label>
            </td><td colspan="2"><asp:Label ID="Label19" runat="server" CssClass="etiquetas_popup" Text="Apellido Materno"></asp:Label>
            </td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_APaterno" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td><td colspan="2"><asp:TextBox ID="TXT_AMaterno" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td></tr><tr><td>
            <asp:Label ID="Label21" runat="server" CssClass="etiquetas_popup" Text="Sexo"></asp:Label>
            </td><td class="auto-style5"><asp:Label ID="Label24" runat="server" CssClass="etiquetas_popup" Text="Estado Civil"></asp:Label>
            </td><td><asp:Label ID="Label22" runat="server" CssClass="etiquetas_popup" Text="Fecha Nacimiento"></asp:Label>
            </td><td><asp:Label ID="Label23" runat="server" CssClass="etiquetas_popup" Text="Edad"></asp:Label>
            </td></tr><tr><td class="auto-style4"><asp:TextBox ID="TXT_Sexo" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
            </td><td class="auto-style6"><asp:TextBox ID="TXT_EstadoCivil" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
            </td><td class="auto-style4">
             <asp:TextBox ID="TXT_FechaNac" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
            </td><td class="auto-style4"><asp:TextBox ID="TXT_Edad" runat="server" CssClass="cajastexto_popup" Width="50px"></asp:TextBox>
            </td></tr><tr><td colspan="2"><asp:Label ID="Label25" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Domicilio Particular"></asp:Label>
            </td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2"><asp:Label ID="Label26" runat="server" CssClass="etiquetas_popup" Text="Calle Particular"></asp:Label>
        </td><td><asp:Label ID="Label29" runat="server" CssClass="etiquetas_popup" Text="Número"></asp:Label>
        </td><td>
            <asp:Label ID="Label30" runat="server" CssClass="etiquetas_popup" Text="Nro. Departamento"></asp:Label>
        </td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_CalleParticular" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td><td><asp:TextBox ID="TXT_NumeroCasa" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
            </td><td><asp:TextBox ID="TXT_NumeroDepto" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
            </td></tr><tr><td colspan="2"><asp:Label ID="Label27" runat="server" CssClass="etiquetas_popup" Text="Villa / Población"></asp:Label>
            </td><td colspan="2"><asp:Label ID="Label31" runat="server" CssClass="etiquetas_popup" Text="Altura Calle Principal"></asp:Label>
            </td></tr>
            <tr><td colspan="2"><asp:TextBox ID="TXT_VillaPoblacion" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td><td colspan="2"><asp:TextBox ID="TXT_AlturaCalle" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td></tr><tr><td colspan="2"><asp:Label ID="Label28" runat="server" CssClass="etiquetas_popup" Text="Región"></asp:Label>
            </td><td colspan="2"><asp:Label ID="Label32" runat="server" CssClass="etiquetas_popup" Text="Comuna"></asp:Label>
            </td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_Region" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td><td colspan="2">
             <asp:TextBox ID="TXT_Comuna" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td></tr><tr><td><asp:Label ID="Label33" runat="server" CssClass="etiquetas_popup" Text="Teléfono Fijo"></asp:Label>
            </td><td class="auto-style5"><asp:Label ID="Label34" runat="server" CssClass="etiquetas_popup" Text="Teléfono Celular"></asp:Label>
            </td><td colspan="2">&nbsp;</td></tr><tr><td><asp:TextBox ID="TXT_TelefonoFijo" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
        </td><td class="auto-style5"><asp:TextBox ID="TXT_TelefonoCelular" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
        </td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2">
         <asp:Label ID="Label35" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Referencia"></asp:Label>
        </td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2"><asp:Label ID="Label36" runat="server" CssClass="etiquetas_popup" Text="Nombre y Apellido Referencia"></asp:Label>
        </td><td><asp:Label ID="Label39" runat="server" CssClass="etiquetas_popup" Text="Teléfono Referencia"></asp:Label>
        </td><td><asp:RadioButtonList ID="RBL_ReferenciaTipoTelefono" runat="server" CssClass="radiobuton_tab" Height="16px" RepeatDirection="Horizontal" Width="141px"><asp:ListItem>Fijo</asp:ListItem>
            <asp:ListItem>Celular</asp:ListItem>
            </asp:RadioButtonList>
        </td></tr><tr><td colspan="2">
            <asp:TextBox ID="TXT_ReferenciaNombre" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td><td colspan="2">
    <asp:TextBox ID="TXT_ReferenciaTelefono" runat="server" CssClass="cajastexto_popup"></asp:TextBox>
            </td></tr><tr><td colspan="2"><asp:Label ID="Label37" runat="server" CssClass="etiquetas_popup" Text="Región"></asp:Label>
            </td><td colspan="2"><asp:Label ID="Label38" runat="server" CssClass="etiquetas_popup" Text="Comuna"></asp:Label>
            </td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_ReferenciaRegion" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td><td colspan="2"><asp:TextBox ID="TXT_ReferenciaComuna" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>
            </td></tr></table>
                </ContentTemplate>                          
</cc2:TabPanel>
            <cc2:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Datos Laborales y Crédito
                </HeaderTemplate>               
                
<ContentTemplate>
    <table cellspacing="1" class="auto-style3"><tr><td colspan="2" style="height: 22px"><asp:Label ID="Label43" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Laborales"></asp:Label></td><td colspan="2" style="height: 22px"></td></tr><tr><td colspan="2"><asp:Label ID="Label44" runat="server" CssClass="etiquetas_popup" Text="Nombre Empleador"></asp:Label></td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_EmpleadorNombre" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp; </td><td colspan="2"></td></tr><tr>
        <td colspan="2"><asp:Label ID="Label46" runat="server" CssClass="etiquetas_popup" Text="Dirección Empleador"></asp:Label></td><td><asp:Label ID="Label54" runat="server" CssClass="etiquetas_popup" Text="Número"></asp:Label></td><td><asp:Label ID="Label55" runat="server" CssClass="etiquetas_popup" Text="Oficina / Depto."></asp:Label></td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_EmpleadorDireccion" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox></td><td><asp:TextBox ID="TXT_NumeroEmpleador" runat="server" CssClass="cajastexto_popup"></asp:TextBox></td><td><asp:TextBox ID="TXT_OficinaEmpleador" runat="server" CssClass="cajastexto_popup"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="Label58" runat="server" CssClass="etiquetas_popup" Text="Región"></asp:Label></td><td>&nbsp;</td><td colspan="2"><asp:Label ID="Label59" runat="server" CssClass="etiquetas_popup" Text="Comuna"></asp:Label></td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_EmpleadorRegion" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox></td><td colspan="2"><asp:TextBox ID="TXT_EmpleadorComuna" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox></td></tr><tr><td style="height: 22px"><asp:Label ID="Label60" runat="server" CssClass="etiquetas_popup" Text="Teléfono Emp."></asp:Label></td><td style="height: 22px">
        <asp:Label ID="Label61" runat="server" CssClass="etiquetas_popup" Text="Anexo"></asp:Label></td><td colspan="2" style="height: 22px"></td></tr><tr><td><asp:TextBox ID="TXT_EmpleadorTelefono" runat="server" CssClass="cajastexto_popup"></asp:TextBox></td><td><asp:TextBox ID="TXT_EmpleadorAnexo" runat="server" CssClass="cajastexto_popup"></asp:TextBox></td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td colspan="2"><asp:Label ID="Label62" runat="server" CssClass="etiquetas_popup" Text="Cargo"></asp:Label></td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td colspan="2">
        <asp:TextBox ID="TXT_EmpleadorCargo" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox></td><td colspan="2"></td></tr><tr><td colspan="2"><asp:Label ID="Label63" runat="server" CssClass="etiquetas_popup" style="text-decoration: underline" Text="Datos Crédito"></asp:Label></td><td colspan="2"></td></tr><tr><td colspan="2"><asp:Label ID="Label64" runat="server" CssClass="etiquetas_popup" Text="Día deseado de Pago"></asp:Label></td><td colspan="2"><asp:Label ID="Label65" runat="server" CssClass="etiquetas_popup" Text="Lugar de Envío Estado de Cuenta"></asp:Label></td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_DiaPago" runat="server" CssClass="cajastexto_popup"></asp:TextBox></td>
<td colspan="2"><asp:TextBox ID="TXT_LugarEnvioEC" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox></td></tr><tr><td><asp:Label ID="Label66" runat="server" CssClass="etiquetas_popup" Text="Correo Eléctronico"></asp:Label></td><td style="width: 165px">&nbsp;</td><td colspan="2"></td></tr><tr><td colspan="4" style="height: 24px"><asp:TextBox ID="TXT_CorreoElectronico" runat="server" CssClass="cajastexto_popup" Width="300px"></asp:TextBox></td></tr>       
    <tr>
        <td colspan="4" style="height: 24px">&nbsp;</td>
    </tr>
    <tr><td colspan="4" style="text-align: center"><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager></td></tr></table>
                </ContentTemplate>             
</cc2:TabPanel>
        </cc2:TabContainer>  
        <asp:Button runat="server" Text="Grabar" ID="BTN_Grabar0"></asp:Button>

        <br />
    </div>
    </form>
    </body>
</html>
