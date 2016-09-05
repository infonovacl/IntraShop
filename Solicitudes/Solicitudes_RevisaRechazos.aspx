<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Solicitudes_RevisaRechazos.aspx.vb" Inherits="Solicitudes_RevisaRechazos" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Revision de Rechazos</title>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="False" LoadScriptsBeforeUI="False" ScriptMode="Release">
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
                            <asp:Panel ID="Panel_Rechazos" runat="server" CssClass="panel_tab" Height="250px" ScrollBars="Vertical" Width="400px">
                                <asp:CheckBoxList ID="CHBL_RechazosCliente" runat="server" CssClass="etiquetas_tab">
                                </asp:CheckBoxList>
                            </asp:Panel>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <asp:Label ID="LBL_ListaRechazosError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" CssClass="etiquetasimportante" Text="CONSULTAS DataBusiness"></asp:Label>
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
                <asp:Label ID="LBL_LevantaRechazoError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                <br />
                <table align="center" class="auto-style7">
                    <tr>
                        <td class="auto-style9">
                            <asp:Button ID="BTN_RevisionDataBusiness" runat="server" CssClass="botones" Enabled="False" Text="ANTEC. COMERCIALES" Width="180px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BTN_Cerrar0" runat="server" CssClass="botones" OnClientClick="javascript:window.close();" Text="CERRAR" />
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
