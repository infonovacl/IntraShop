<%@ Page Language="VB" MasterPageFile="~/Maestro.master" AutoEventWireup="false" CodeFile="Mantenciones_DatosCliente.aspx.vb" Inherits="DatosCliente" %>
<%@ MasterType virtualpath="~/Maestro.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
      <link href="../css/EstilosShop.css" rel="stylesheet" />
    <script type="text/javascript">   
    </script>
    <div style="height: 587px">       
        <cc2:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1"  Width="770px" >
            <cc2:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>Datos Personales</HeaderTemplate>
                <ContentTemplate><table cellspacing="1" class="auto-style3"><tr><td colspan="2"><asp:Label ID="Label15" runat="server" Text="Tienda Origen" CssClass="etiquetas_tab"></asp:Label></td><td colspan="2"><asp:Label ID="Label13" runat="server" Text="NUMERO FOLIO CONTRATO"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label14" runat="server" Text="0"></asp:Label></td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_TiendaOrigen" runat="server" Width="350px" CssClass="cajastexto_tab"></asp:TextBox></td><td colspan="2">&nbsp;</td></tr><tr><td style="height: 22px" colspan="2"><asp:Label ID="Label16" runat="server" style="text-decoration: underline" Text="Datos Personales" CssClass="etiquetas_tab"></asp:Label></td><td style="height: 22px" colspan="2"></td></tr><tr><td colspan="2"><asp:Label ID="Label17" runat="server" Text="Rut Cliente" CssClass="etiquetas_tab"></asp:Label></td><td colspan="2"><asp:Label ID="Label20" runat="server" Text="Nombres" CssClass="etiquetas_tab"></asp:Label></td></tr><tr><td colspan="2">
                    <asp:TextBox ID="TXT_Rut" runat="server" CssClass="cajastexto_tab"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TXT_Dv" runat="server" Width="20px" CssClass="cajastexto_tab"></asp:TextBox></td><td colspan="2"><asp:TextBox ID="TXT_Nombres" runat="server" Width="300px" CssClass="cajastexto_tab"></asp:TextBox></td></tr><tr><td colspan="2"><asp:Label ID="Label18" runat="server" Text="Apellido Paterno" CssClass="etiquetas_tab"></asp:Label></td><td colspan="2"><asp:Label ID="Label19" runat="server" Text="Apellido Materno" CssClass="etiquetas_tab"></asp:Label></td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_APaterno" runat="server" Width="300px" CssClass="cajastexto_tab"></asp:TextBox></td><td colspan="2"><asp:TextBox ID="TXT_AMaterno" runat="server" Width="300px" CssClass="cajastexto_tab"></asp:TextBox></td></tr><tr><td><asp:Label ID="Label21" runat="server" Text="Sexo" CssClass="etiquetas_tab"></asp:Label></td><td><asp:Label ID="Label24" runat="server" CssClass="etiquetas_tab" Text="Estado Civil"></asp:Label></td><td colspan="2"><asp:Label ID="Label22" runat="server" Text="Fecha Nacimiento" CssClass="etiquetas_tab"></asp:Label></td></tr><tr><td>
                    <asp:TextBox ID="TXT_Sexo" runat="server" CssClass="cajastexto_tab"></asp:TextBox></td><td><asp:TextBox ID="TXT_EstadoCivil" runat="server" CssClass="cajastexto_tab"></asp:TextBox></td><td colspan="2"><asp:TextBox ID="TXT_FechaNac" runat="server" CssClass="cajastexto_tab"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label23" runat="server" Text="Edad" CssClass="etiquetas_tab"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TXT_Edad" runat="server" Width="50px" CssClass="cajastexto_tab"></asp:TextBox></td></tr><tr><td colspan="2"><asp:Label ID="Label25" runat="server" style="text-decoration: underline" Text="Datos Domicilio Particular" CssClass="etiquetas_tab"></asp:Label></td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2"><asp:Label ID="Label26" runat="server" CssClass="etiquetas_tab" Text="Calle Particular"></asp:Label></td><td><asp:Label ID="Label29" runat="server" CssClass="etiquetas_tab" Text="Número"></asp:Label></td><td><asp:Label ID="Label30" runat="server" CssClass="etiquetas_tab" Text="Nro. Departamento"></asp:Label></td></tr><tr><td colspan="2">
                    <asp:TextBox ID="TXT_CalleParticular" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td><td><asp:TextBox ID="TXT_NumeroCasa" runat="server" CssClass="cajastexto_tab"></asp:TextBox></td><td><asp:TextBox ID="TXT_NumeroDepto" runat="server" CssClass="cajastexto_tab"></asp:TextBox></td></tr><tr><td colspan="2"><asp:Label ID="Label27" runat="server" CssClass="etiquetas_tab" Text="Villa / Población"></asp:Label></td><td colspan="2"><asp:Label ID="Label31" runat="server" CssClass="etiquetas_tab" Text="Altura Calle Principal"></asp:Label></td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_VillaPoblacion" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td><td colspan="2"><asp:TextBox ID="TXT_AlturaCalle" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td></tr><tr><td colspan="2"><asp:Label ID="Label28" runat="server" CssClass="etiquetas_tab" Text="Región"></asp:Label></td><td colspan="2"><asp:Label ID="Label32" runat="server" CssClass="etiquetas_tab" Text="Comuna"></asp:Label></td></tr><tr><td colspan="2">
                    <asp:TextBox ID="TXT_Region" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td><td colspan="2"><asp:TextBox ID="TXT_Comuna" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td></tr><tr><td><asp:Label ID="Label33" runat="server" CssClass="etiquetas_tab" Text="Teléfono Fijo"></asp:Label></td><td style="width: 165px"><asp:Label ID="Label34" runat="server" CssClass="etiquetas_tab" Text="Teléfono Celular"></asp:Label></td><td colspan="2">&nbsp;</td></tr><tr><td><asp:TextBox ID="TXT_TelefonoFijo" runat="server" CssClass="cajastexto_tab"></asp:TextBox></td><td style="width: 165px"><asp:TextBox ID="TXT_TelefonoCelular" runat="server" CssClass="cajastexto_tab"></asp:TextBox></td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2"><asp:Label ID="Label35" runat="server" CssClass="etiquetas_tab" style="text-decoration: underline" Text="Datos Referencia"></asp:Label></td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2"><asp:Label ID="Label36" runat="server" CssClass="etiquetas_tab" Text="Nombre y Apellido Referencia"></asp:Label></td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2">
                    <asp:TextBox ID="TXT_ReferenciaNombre" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td><td colspan="2">&nbsp;</td></tr><tr><td colspan="2"><asp:Label ID="Label37" runat="server" CssClass="etiquetas_tab" Text="Región"></asp:Label></td><td colspan="2"><asp:Label ID="Label38" runat="server" CssClass="etiquetas_tab" Text="Comuna"></asp:Label></td></tr><tr><td colspan="2"><asp:TextBox ID="TXT_ReferenciaRegion" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td><td colspan="2"><asp:TextBox ID="TXT_ReferenciaComuna" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td></tr><tr><td colspan="2"><asp:Label ID="Label39" runat="server" CssClass="etiquetas_tab" Text="Teléfono Referencia"></asp:Label>&nbsp;&nbsp;&nbsp; 
                    <asp:RadioButtonList ID="RBL_ReferenciaTipoTelefono" runat="server" RepeatDirection="Horizontal" Width="185px" CssClass="radiobuton_tab"><asp:ListItem>Fijo</asp:ListItem><asp:ListItem>Celular</asp:ListItem></asp:RadioButtonList></td><td colspan="2"><asp:TextBox ID="TXT_ReferenciaTelefono" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox></td></tr><tr><td colspan="4" style="text-align: center"><asp:Button ID="BTN_Grabar" runat="server" Text="Grabar" /></td></tr></table></ContentTemplate>
            </cc2:TabPanel>
            <cc2:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>Datos Laborales y Crédito</HeaderTemplate>
                <ContentTemplate>
                    <table cellspacing="1" class="auto-style3">
                        <tr>
                            <td colspan="2" style="height: 22px">
                                <asp:Label ID="Label43" runat="server" CssClass="etiquetas_tab" style="text-decoration: underline" Text="Datos Laborales"></asp:Label>
                            </td>
                            <td colspan="2" style="height: 22px"></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label44" runat="server" CssClass="etiquetas_tab" Text="Nombre Empleador"></asp:Label>
                            </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="TXT_EmpleadorNombre" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp; </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label46" runat="server" CssClass="etiquetas_tab" Text="Dirección Empleador"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label54" runat="server" CssClass="etiquetas_tab" Text="Número"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label55" runat="server" CssClass="etiquetas_tab" Text="Oficina / Depto."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="TXT_EmpleadorDireccion" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TXT_NumeroEmpleador" runat="server" CssClass="cajastexto_tab"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TXT_OficinaEmpleador" runat="server" CssClass="cajastexto_tab"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label58" runat="server" CssClass="etiquetas_tab" Text="Región"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="Label59" runat="server" CssClass="etiquetas_tab" Text="Comuna"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="TXT_EmpleadorRegion" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TXT_EmpleadorComuna" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        </tr>
                        <tr>
                            <td style="height: 22px">
                                <asp:Label ID="Label60" runat="server" CssClass="etiquetas_tab" Text="Teléfono Emp."></asp:Label>
                            </td>
                            <td style="height: 22px">
                                <asp:Label ID="Label61" runat="server" CssClass="etiquetas_tab" Text="Anexo"></asp:Label>
                            </td>
                            <td colspan="2" style="height: 22px"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TXT_EmpleadorTelefono" runat="server" CssClass="cajastexto_tab"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TXT_EmpleadorAnexo" runat="server" CssClass="cajastexto_tab"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label62" runat="server" CssClass="etiquetas_tab" Text="Cargo"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="TXT_EmpleadorCargo" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox>
                            </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label63" runat="server" CssClass="etiquetas_tab" style="text-decoration: underline" Text="Datos Crédito"></asp:Label>
                            </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label64" runat="server" CssClass="etiquetas_tab" Text="Día deseado de Pago"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="Label65" runat="server" CssClass="etiquetas_tab" Text="Lugar de Envío Estado de Cuenta"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="TXT_DiaPago" runat="server" CssClass="cajastexto_tab"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TXT_LugarEnvioEC" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label66" runat="server" CssClass="etiquetas_tab" Text="Correo Eléctronico"></asp:Label>
                            </td>
                            <td style="width: 165px">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 24px">
                                <asp:TextBox ID="TXT_CorreoElectronico" runat="server" CssClass="cajastexto_tab" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:Button ID="BTN_Grabar0" runat="server" Text="Grabar" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </cc2:TabPanel>
        </cc2:TabContainer>  
    </div>
</asp:Content>


