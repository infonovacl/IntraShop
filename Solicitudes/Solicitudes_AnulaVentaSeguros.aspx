﻿<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Solicitudes_AnulaVentaSeguros.aspx.vb" Inherits="Solicitudes_AnulaVentaSeguros" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Venta Anulación de Seguros</title>
     <style type="text/css">      
         .auto-style1 {
             width: 760px;
             height: 10px;
             left: 5px;
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
             width: 100%;
         }
         .auto-style12 {
             width: 422px;
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
                <table class="auto-style11">
                    <tr>
                        <td class="auto-style12">
                            <asp:Label ID="Label2" runat="server" CssClass="etiquetasimportante" Text="Seguros PENDIENTES de ser contratados por el Cliente" Width="500px"></asp:Label>
                            <br />
                            <asp:Panel ID="Panel_ConsultasDB0" runat="server" CssClass="panel_tab" Height="140px" ScrollBars="Vertical" Width="754px">
                                <asp:GridView ID="Grilla_SeguroXContratar" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="737px">
                                    <Columns>
                                        <asp:CheckBoxField DataField="column4"/>
                                        <asp:BoundField HeaderText="Seguro" DataField="column1" />
                                        <asp:BoundField HeaderText="Descripción" DataField="column2" />
                                        <asp:BoundField HeaderText="Póliza" DataField="column3" />
                                        <asp:BoundField HeaderText="Folio" DataField="column5"></asp:BoundField>
                                        <asp:BoundField HeaderText="Moneda" DataField="column6"></asp:BoundField>
                                        <asp:BoundField HeaderText="Prima" DataField="column7" />
                                        <asp:BoundField HeaderText="Tipo Seguro" DataField="column8" />
                                        <asp:BoundField HeaderText="Descrip. Tipo Seguro" DataField="column9" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="LBL_SegurosXContratarError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" CssClass="etiquetasimportante" Text="Seguros Posibles de Anular"></asp:Label>
                <br />
                <asp:Panel ID="Panel_ConsultasDB" runat="server" CssClass="panel_tab" Height="140px" ScrollBars="Vertical" Width="754px">
                    <asp:GridView ID="Grilla_ConsultasDB" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="737px">
                        <Columns>
                            <asp:BoundField DataField="column4" DataFormatString="{0:d}" HeaderText="Fecha" />
                            <asp:BoundField DataField="column5" HeaderText="Hora" />
                            <asp:BoundField DataField="column6" HeaderText="Motivo" />
                            <asp:BoundField DataField="column7" HeaderText="Edad">
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="column8" DataFormatString="{0:N0}" HeaderText="Score">
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="column9" HeaderText="Antec." />
                            <asp:BoundField DataField="column10" HeaderText="Dirección" />
                            <asp:BoundField DataField="column11" HeaderText="Ciudad" />
                            <asp:BoundField DataField="column12" HeaderText="Cod.Motivo" Visible="False" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:Label ID="LBL_ConsultasDBError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                <br />
                <table align="center" class="auto-style7">
                    <tr>
                        <td class="auto-style9">
                            &nbsp;<asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
