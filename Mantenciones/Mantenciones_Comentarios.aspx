<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_Comentarios.aspx.vb" Inherits="Mantencion_Comentarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Sistema Web - Comentarios</title>
     <style type="text/css">      
         .auto-style1 {
             width: 775px;
             height: 236px;
         }
         .auto-style3 {
             width: 100%;
         }
         .auto-style4 {
             text-align: center;
             height: 34px;
         }
         </style>
    </head>
<body style="width: 775px; height: 313px;">
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="False">
            <ContentTemplate>
                <asp:Panel ID="Panel_Comentarios" runat="server" CssClass="panel_tab" ScrollBars="Vertical">               
                    <asp:GridView ID="Grilla_Comentarios" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="730px">
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
                <table class="auto-style3">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="etiquetas_tab" Text="Ingrese Comentario"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TXT_Comentario" runat="server" CssClass="cajastexto_tab" Width="500px" ViewStateMode="Enabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4"><asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" OnClientClick="javascript:window.close();" />
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
