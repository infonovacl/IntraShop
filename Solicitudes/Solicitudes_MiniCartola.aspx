<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Solicitudes_MiniCartola.aspx.vb" Inherits="Solicitudes_MiniCartola" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>MiniCartola</title>
     <style type="text/css">      
         .auto-style1 {
             width: 346px;
             height: 12px;
             left: 5px;
         }
         .auto-style9 {
             width: 499px;
             left: 5px;
         }
         .auto-style11 {
             width: 99%;
             height: 244px;
         }
         .auto-style14 {
             height: 11px;
             text-align: left;
         }
         .auto-style16 {
             height: 9px;
         }
         .auto-style18 {
             height: 11px;
             text-align: left;
             width: 102px;
         }
         .auto-style31 {
             height: 14px;
             text-align: left;
             width: 102px;
         }
         .auto-style32 {
             height: 14px;
             text-align: right;
             width: 127px;
         }
         .auto-style33 {
             height: 14px;
         }
         .auto-style44 {
             text-align: left;
             width: 102px;
             height: 18px;
         }
         .auto-style45 {
             text-align: left;
             height: 18px;
         }
         .auto-style54 {
             text-align: right;
             width: 127px;
         }
         .auto-style56 {
             text-align: left;
             width: 122px;
         }
         .auto-style58 {
             text-align: left;
             width: 102px;
             height: 23px;
         }
         .auto-style60 {
             text-align: right;
             width: 127px;
             height: 23px;
         }
         .auto-style61 {
             height: 23px;
         }
         .auto-style66 {
             height: 9px;
             text-align: right;
             width: 127px;
         }
         .auto-style67 {
             text-align: left;
             width: 127px;
         }
         .auto-style68 {
             height: 9px;
             text-align: left;
             width: 127px;
         }
         .auto-style70 {
             height: 9px;
             text-align: left;
             width: 102px;
         }
         .auto-style71 {
             text-align: left;
             width: 102px;
         }
         .auto-style72 {
             height: 9px;
             text-align: left;
         }
         .auto-style74 {
             text-align: left;
             height: 16px;
         }
         </style>
     <script language="javascript"> 
        //if (navigator.appName == "Microsoft Internet Explorer")
        //{ 
        //  var PrintCommand = '<object ID="PrintCommandObject" WIDTH=0 HEIGHT=0
        //CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object>';
        //document.body.insertAdjacentHTML('beforeEnd', PrintCommand); 
        //PrintCommandObject.ExecWB(6, -1); PrintCommandObject.outerHTML = ""; 
        //} 
        //else { 
        //window.print();
      </script>
    </head>
<body style="width: 506px; height: 18px; left: 5px;">
    <form id="form1" runat="server" class="auto-style1">
    <div>
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
                <table class="auto-style9">
                    <caption>
                        <table class="auto-style11">
                            <tr>
                                <td class="auto-style74" colspan="4">
                                    <asp:Label ID="LBL_MiniCartolaError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" OnClientClick="javascript:window.close();" Text="CERRAR" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style71">
                                    <asp:Label ID="Label3" runat="server" CssClass="etiquetas" Text="Fecha Emisión"></asp:Label>
                                </td>
                                <td class="auto-style67">
                                    <asp:Label ID="LBL_FechaEmision" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style56">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style44">
                                    <asp:Label ID="Label1" runat="server" CssClass="etiquetas" Text="Nombre Cliente"></asp:Label>
                                </td>
                                <td class="auto-style45" colspan="3">
                                    <asp:Label ID="LBL_Nombre" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style44">&nbsp;</td>
                                <td class="auto-style45" colspan="3">
                                    <asp:Label ID="LBL_Nombre2" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18">
                                    <asp:Label ID="Label4" runat="server" CssClass="etiquetas" Text="Rut"></asp:Label>
                                </td>
                                <td class="auto-style14" colspan="3">
                                    <asp:Label ID="LBL_Rut" runat="server" CssClass="etiquetas"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" CssClass="etiquetas" Text="-"></asp:Label>
                                    <asp:Label ID="LBL_Dv" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style71">
                                    <asp:Label ID="Label6" runat="server" CssClass="etiquetas" Text="Cupo Aprobado"></asp:Label>
                                </td>
                                <td class="auto-style54">
                                    <asp:Label ID="LBL_CupoAprobado" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style58">
                                    <asp:Label ID="Label7" runat="server" CssClass="etiquetas" Text="Disponible"></asp:Label>
                                </td>
                                <td class="auto-style60">
                                    <asp:Label ID="LBL_Disponible" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style61"></td>
                            </tr>
                            <tr>
                                <td class="auto-style31">
                                    <asp:Label ID="Label9" runat="server" CssClass="etiquetas" Text="Cargos del Mes"></asp:Label>
                                </td>
                                <td class="auto-style32">
                                    <asp:Label ID="LBL_CargosMes" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style33"></td>
                            </tr>
                            <tr>
                                <td class="auto-style70">
                                    <asp:Label ID="Label10" runat="server" CssClass="etiquetas" Text="Monto Atrasado"></asp:Label>
                                </td>
                                <td class="auto-style66">
                                    <asp:Label ID="LBL_MontoAtrasado" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style70">
                                    <asp:Label ID="Label11" runat="server" CssClass="etiquetas" Text="Monto a Cancelar"></asp:Label>
                                </td>
                                <td class="auto-style66">
                                    <asp:Label ID="LBL_MontoCancelar" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style71">
                                    <asp:Label ID="Label17" runat="server" CssClass="etiquetas" Text="Fecha Pago"></asp:Label>
                                </td>
                                <td class="auto-style67">
                                    <asp:Label ID="LBL_FechaPago" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style72" colspan="2">
                                    <asp:Label ID="Label18" runat="server" CssClass="etiquetas" Text="Vencimientos "></asp:Label>
                                    <asp:Label ID="Label19" runat="server" CssClass="etiquetas" Text="Proximos 5 Meses"></asp:Label>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style70">
                                    <asp:Label ID="LBL_FechaVenc1" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style66">
                                    <asp:Label ID="LBL_MontoVenc1" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style70">
                                    <asp:Label ID="LBL_FechaVenc2" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style66">
                                    <asp:Label ID="LBL_MontoVenc2" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style70">
                                    <asp:Label ID="LBL_FechaVenc3" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style66">
                                    <asp:Label ID="LBL_MontoVenc3" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style16"></td>
                            </tr>
                            <tr>
                                <td class="auto-style70">
                                    <asp:Label ID="LBL_FechaVenc4" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style66">
                                    <asp:Label ID="LBL_MontoVenc4" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style70">
                                    <asp:Label ID="LBL_FechaVenc5" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style66">
                                    <asp:Label ID="LBL_MontoVenc5" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style16"></td>
                            </tr>
                            <tr>
                                <td class="auto-style70">
                                    <asp:Label ID="LBL_FechaVenc6" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style66">
                                    <asp:Label ID="LBL_MontoVenc6" runat="server" CssClass="etiquetas"></asp:Label>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style72" colspan="3">
                                    <asp:GridView ID="GrillaCuotas" runat="server" AutoGenerateColumns="False" Visible="False">
                                        <Columns>
                                            <asp:BoundField DataField="fecha" HeaderText="fecha" />
                                            <asp:BoundField DataField="valor_cuota" HeaderText="valor" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </caption>
                </table>             
                    </ContentTemplate>             
        </asp:UpdatePanel>                            
        <br />
        <br />    
    </div>
    </form>
    </body>
</html>
