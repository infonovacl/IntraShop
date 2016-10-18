<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Mantenciones_Comentarios.aspx.vb" Inherits="Mantencion_Comentarios" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Comentarios</title>
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
             width: 768px;
             background-color: lightgrey;
             height: 360px;
             left: 5px;
         }
         </style>
    </head>
<body style="width: 761px; height: 6px; left: 5px;">
    <form id="form1" runat="server" class="auto-style1">
    <div class="div_popup">       
                <asp:Panel ID="Panel_Comentarios" runat="server" CssClass="panel_tab" ScrollBars="Vertical">               
                    <asp:GridView ID="Grilla_Comentarios" runat="server" AutoGenerateColumns="False" EnableViewState="true" CssClass="grillas_tab" Height="16px" Width="730px">
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
                <table class="auto-style3">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="etiquetas_tab" Text="Ingrese Comentario"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TXT_Comentario" runat="server" CssClass="cajastexto_tab" Width="450px" ViewStateMode="Enabled"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="LBL_ComentariosError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                        </td>
                    </tr>
                </table>             
                        <table class="auto-style3">
                            <tr>
                                <td class="auto-style4">
                                    <br />
                                    <asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" Enabled="False" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" />
                                </td>
                            </tr>
                        </table>                                  
        <br />    
    </div>
    </form>
    </body>
</html>
