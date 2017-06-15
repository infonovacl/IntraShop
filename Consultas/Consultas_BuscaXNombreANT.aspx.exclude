<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Consultas_BuscaXNombre.aspx.vb" Inherits="Consultas_BuscaXNombre" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Busqueda Cliente X Nombre</title>
     <style type="text/css">      
         .auto-style1 {
             width: 629px;
             height: 16px;
             left: 5px;
         }
         .auto-style3 {
             width: 610px;
               left: 5px;
         }
         .auto-style4 {
             text-align: center;
             height: 34px;
         }
         .auto-style5 {
             background-color: white;
         }
         .auto-style7 {
             width: 615px;
             background-color: whitesmoke;
             height: 342px;
         }
         .auto-style8 {
             height: 21px;
         }
         .auto-style9 {
             position: absolute;
             left: 272px;
             top: 438px;
         }
         .auto-style10 {
             width: 610px;
             left: 5px;
             height: 15px;
         }
         </style>
    <script script language="javascript" type="text/javascript"> 
        function MandaRut() {
           var rutbuscado = document.getElementById("LBL_Rut").innerText;
           window.opener.document.getElementById('TXT_ConsultaRutCliente').innerText = rutbuscado;         
           window.close();
                            } 
    </script> 
    </head>
<body style="width: 627px; height: 2px; left: 5px;" >
    <form id="form1" runat="server" class="auto-style1" defaultbutton="BTN_BuscarXNombre" defaultfocus="TXT_BuscaXNombre">
    <div class="auto-style7">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="120">
                    </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="20">
            <ProgressTemplate>
                <div class="update">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="etiquetas" Text="Nombre Cliente"></asp:Label>
                &nbsp;
                <asp:TextBox ID="TXT_BuscaXNombre" runat="server" CssClass="cajastexto" Width="350px"  ></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BTN_BuscarXNombre" runat="server" CssClass="botones" Text="BUSCAR" />
                <br />
                <br />
                <asp:Panel ID="Panel_BuscaXNombre" runat="server" CssClass="auto-style5" ScrollBars="Vertical" Height="173px" Width="600px">               
                    <asp:GridView ID="Grilla_BuscaXNombre" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="582px">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/mano.jpg" ShowSelectButton="True" />
                            <asp:BoundField DataField="column3" HeaderText="Rut Cliente">
                            </asp:BoundField>
                            <asp:BoundField DataField="column4" HeaderText="Dv">
                            </asp:BoundField>
                            <asp:BoundField DataField="column5" HeaderText="Nombre">
                            </asp:BoundField>
                            <asp:BoundField DataField="column6" HeaderText="A. Paterno" />
                            <asp:BoundField DataField="column7" HeaderText="A. Materno" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style8">
                            <asp:Label ID="Label2" runat="server" CssClass="etiquetasimportante" Text="Cliente Seleccionado"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="LBL_ClienteSeleccionado" runat="server" CssClass="etiquetasimportante"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBL_BuscarXNombreError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                            &nbsp; 
                            <div class="auto-style9">
                                <asp:Label ID="LBL_Rut" runat="server" CssClass="etiquetasimportante"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>             
                        <table class="auto-style10">
                            <tr>
                                <td class="auto-style4">
                                    <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" OnClientClick="MandaRut()" Text="ENVIAR/CERRAR" Width="140px" />
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
