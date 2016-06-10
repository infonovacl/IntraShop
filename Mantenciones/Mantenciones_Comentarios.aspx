<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_Comentarios.aspx.vb" Inherits="Mantencion_Comentarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title></title>
     <style type="text/css">
         .auto-style1 {
             width: 962px;
             height: 292px;
         }
         .auto-style3 {
             width: 100%;
         }
         .auto-style4 {
             text-align: center;
             height: 34px;
         }
         .auto-style5 {
             background-color: white;
         }
         .auto-style6 {
             background-color: whitesmoke;
             height: 302px;
         }
     </style>
    </head>
<body style="width: 982px; height: 313px;">
    <form id="form1" runat="server" class="auto-style1">
    <div class="auto-style6">
    
        <asp:Panel ID="Panel_Comentarios" runat="server" CssClass="auto-style5" Height="221px" ScrollBars="Vertical" Width="954px">
            <asp:GridView ID="Grilla_Comentarios" runat="server" AutoGenerateColumns="False" CssClass="grillas_tab" EmptyDataText="No hay resultados en busqueda" Height="16px" ShowHeaderWhenEmpty="True" Width="934px">
                <Columns>
                    <asp:BoundField DataField="column3" HeaderText="Fecha " DataFormatString="{0:d}" >
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="column4" HeaderText="Hora">
                    <ItemStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="column5" HeaderText="Glosa" >
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
                    <asp:TextBox ID="TXT_Comentario" runat="server" CssClass="cajastexto_tab" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="BTN_Grabar" runat="server" CssClass="botones" Text="GRABAR" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" />
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
    </body>
</html>
