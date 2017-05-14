<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Consultas_BuscaXNombre2.aspx.vb" Inherits="Consultas_BuscaXNombre" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>Busqueda Cliente X Nombre</title>
    
     <style type="text/css">      
         .auto-style1 {
             width: 593px;
             height: 16px;
             left: 5px;
         }
         .auto-style3 {
             width: 599px;
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
             width: 644px;
             background-color: whitesmoke;
             height: 342px;
         }
         .auto-style8 {
             height: 21px;
         }
         .auto-style9 {
             position: absolute;
             left: 272px;
             top: 420px;
             height: 34px;
         }
         .auto-style10 {
             width: 598px;
             left: 5px;
             height: 20px;
         }
         .auto-style20 {
            width: 19px;
            height: 19px;
        }
        .auto-style20 {
            text-align: center;
        }
         .style1
         {
             width: 100%;
         }
         .style2
         {
             width: 97px;
         }
         .style3
         {
             width: 354px;
         }
         .style4
         {
             width: 31px;
         }
         </style>
    <script script language="javascript" type="text/javascript"> 
        function MandaRut() {
            try {
                var rutbuscado = document.getElementById("LBL_Rut").innerText;
                window.opener.document.getElementById('TXT_ConsultaRutCliente').innerText = rutbuscado;
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.dispose();
                self.close();                
            }
            catch (e) {
                alert(e.name + " - " + e.message);
            }
        }     
    </script> 
    </head>
<body onunload="Sys.WebForms.PageRequestManager.getInstance().abortPostBack()"  style="width: 627px; height: 2px; left: 5px;" >
    <form id="form1" runat="server" class="auto-style1" defaultbutton="BTN_BuscarXNombre" defaultfocus="TXT_BuscaXNombre">
    <div class="auto-style7">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            AsyncPostBackTimeout="120" EnableViewState="False" LoadScriptsBeforeUI="False" ScriptMode="Release">
                    </asp:ScriptManager>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="20">
            <ProgressTemplate>
                <div class="update">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label1" runat="server" CssClass="etiquetas" 
                                Text="Nombre Cliente"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="TXT_BuscaXNombre" runat="server" CssClass="cajastexto" 
                                Width="300px"></asp:TextBox>
                        </td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BTN_BuscarXNombre" runat="server" CssClass="botones" 
                                Text="BUSCAR" />
                        </td>
                    </tr>
                </table>
                <br />              
                <asp:Panel ID="Panel_BuscaXNombre" runat="server" CssClass="auto-style5" ScrollBars="Vertical" Height="173px" Width="634px">               
                    <asp:GridView ID="Grilla_BuscaXNombre" runat="server" AutoGenerateColumns="False" CssClass="grillaschicas_tab" Height="16px" Width="613px">
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
                   </ContentTemplate>             
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_BuscarXNombre" EventName="Click" />                                 
            </Triggers>
        </asp:UpdatePanel>      
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style8">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" 
                                ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                            <asp:Label ID="Label2" runat="server" CssClass="etiquetasimportante" 
                                        Text="Cliente Seleccionado:"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="LBL_ClienteSeleccionado" runat="server" 
                                        CssClass="etiquetasimportante"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Grilla_BuscaXNombre" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" 
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="LBL_BuscarXNombreError" runat="server" 
                                        CssClass="etiquetasmensajeerror"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BTN_BuscarXNombre" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>                                       
                        <table class="auto-style10">
                            <tr>
                                <td class="auto-style4">
                                            <asp:Button ID="BTN_Enviar" runat="server" CssClass="botones" 
                                                OnClientClick="MandaRut();return false; " Text="ENVIAR Y CERRAR" 
                                                Width="140px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>                               
        <br />
                               
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="False" 
            UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="LBL_Rut" runat="server" CssClass="etiquetasimportante"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Grilla_BuscaXNombre" 
                    EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
                               
        <br />    
    </div>
    </form>
    </body>
</html>
