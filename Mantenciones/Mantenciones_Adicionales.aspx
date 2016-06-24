<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Mantenciones_Adicionales.aspx.vb" Inherits="Mantencion_Adicionales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Adicionales</title>
     <style type="text/css">      
         .auto-style1 {
             width: 760px;
             height: 236px;
             left: 5px;
         }
         .auto-style3 {
             width: 760px;
               left: 5px;
         }
         .auto-style4 {
             text-align: center;
             height: 34px;
         }
         .auto-style5 {
             width: 100%;
         }
         .auto-style6 {
             height: 22px;
         }
         .auto-style14 {
             width: 166px;
         }
         .auto-style15 {
             height: 22px;
             width: 166px;
         }
         .auto-style16 {
             width: 41px;
         }
         .auto-style17 {
             height: 22px;
             width: 41px;
         }
         .auto-style18 {
             width: 760px;
             left: 5px;
             height: 2px;
         }
         .auto-style19 {
             text-align: center;
         }
         </style>
    </head>
<body style="width: 761px; height: 6px; left: 5px;">
    <form id="form1" runat="server" class="auto-style1">
    <div class="div_popup">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="20">
            <ProgressTemplate>
                <div class="update">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
            <ContentTemplate>
                <asp:Panel ID="Panel_Adicionales" runat="server" CssClass="panel_tab" ScrollBars="Vertical">               
                    <asp:GridView ID="Grilla_Adicionales" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="730px">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" ShowSelectButton="True" />
                            <asp:BoundField DataField="column3" HeaderText="Rut Adicional">
                            </asp:BoundField>
                            <asp:BoundField DataField="column4" HeaderText="Dv">
                            </asp:BoundField>
                            <asp:BoundField DataField="column5" HeaderText="Nombre">
                            </asp:BoundField>
                            <asp:BoundField DataField="column6" HeaderText="A. Paterno" />
                            <asp:BoundField DataField="column7" HeaderText="A. Materno" />
                            <asp:BoundField DataField="column8" HeaderText="Parentesco" />
                            <asp:BoundField DataField="column9" DataFormatString="{0:d}" HeaderText="Fecha Nac." />
                            <asp:BoundField DataField="column10" HeaderText="Estado" />
                            <asp:BoundField DataField="column11" HeaderText="Ver. Tarjeta" />
                            <asp:BoundField DataField="column12" DataFormatString="{0:d}" HeaderText="Fecha Ing." />
                            <asp:BoundField DataField="column13" HeaderText="Sexo" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:Panel ID="Panel_AdicionalesDetalle" runat="server" CssClass="panel_tab" ScrollBars="Vertical" Visible="False">
                    <table cellspacing="1" class="auto-style5">
                        <tr>
                            <td class="auto-style14">
                                <asp:Label ID="Label84" runat="server" CssClass="etiquetas_tab" Text="Tarjetas Adicionales"></asp:Label>
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">
                                <asp:Label ID="Label83" runat="server" CssClass="etiquetas_tab" Text="Empleador"></asp:Label>
                            </td>
                            <td class="auto-style17">&nbsp;</td>
                            <td class="auto-style6"></td>
                            <td class="auto-style6"></td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:TextBox ID="TXT_AdicionalRut" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="80px"></asp:TextBox>
                                &nbsp;<asp:Label ID="Label92" runat="server" CssClass="etiquetas_tab" Text="-"></asp:Label>
                                &nbsp;<asp:TextBox ID="TXT_AdicionalDv" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="20px"></asp:TextBox>
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">
                                <asp:Label ID="Label85" runat="server" CssClass="etiquetas_tab" Text="Nombres"></asp:Label>
                            </td>
                            <td class="auto-style17">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label86" runat="server" CssClass="etiquetas_tab" Text="Apellido Paterno"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label87" runat="server" CssClass="etiquetas_tab" Text="Apellido Materno"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:TextBox ID="TXT_AdicionalNombres" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="180px"></asp:TextBox>
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TXT_AdicionalAPaterno" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="180px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TXT_AdicionalAMaterno" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Label ID="Label88" runat="server" CssClass="etiquetas_tab" Text="Fecha Nacimiento"></asp:Label>
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                            <td>
                                <asp:Label ID="Label89" runat="server" CssClass="etiquetas_tab" Text="Sexo"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label90" runat="server" CssClass="etiquetas_tab" Text="Parentesco"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:TextBox ID="TXT_AdicionalFechaNacimiento" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="80px"></asp:TextBox>
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TXT_AdicionalSexo" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="80px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TXT_AdicionalParentesco" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Label ID="Label91" runat="server" CssClass="etiquetas_tab" Text="Estado Vigente"></asp:Label>
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                            <td>
                                <asp:Label ID="Label93" runat="server" CssClass="etiquetas_tab" Text="Fecha Ingreso"></asp:Label>
                            </td>
                            <td class="auto-style19" rowspan="2">
                                <asp:ImageButton ID="IBTN_AdicionalesDetalle" runat="server" CssClass="boton_volver" ImageUrl="~/Imagenes/mano_volver.jpg" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:DropDownList ID="DDL_EstadoAdicionales" runat="server" CssClass="dropdown_tab" ViewStateMode="Enabled" Width="140px">
                                    <asp:ListItem Value="0">VIGENTE</asp:ListItem>
                                    <asp:ListItem Value="1">NO VIGENTE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TXT_AdicionalFechaIng" runat="server" CssClass="cajastexto_tab" ReadOnly="True" Width="80px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <table class="auto-style3">
                    <tr>
                        <td>
                            <asp:Label ID="LBL_AdicionalesError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                        </td>
                    </tr>
                </table>             
                        <table class="auto-style3">
                            <tr>
                                <td class="auto-style4">
                                    <br />
                                    <asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" OnClientClick="javascript:window.close();" Text="CERRAR" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>             
        </asp:UpdatePanel>                            
        <br />    
    </div>
    </form>
    </body>
</html>
