<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="true" CodeFile="Solicitudes_MiniCartolaDetalle.aspx.vb" Inherits="Solicitudes_MiniCartolaDetalle" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <title>MiniCartola</title>    
     <style type="text/css">   
         @page 
    {
       
        margin: 0mm;  /* this affects the margin in the printer settings */
    }
   
         .auto-style1 {
             width: 299px;
             height: 541px;
             left: 0px;
             font-size: medium;
             font-family: Arial, Helvetica, sans-serif;
         }
         .auto-style9 {
             width: 499px;
             left: 0px;
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
         #div_print
         {
             width: 290px;
         }
         .style2
         {
             width: 100%;
         }
         .style4
         {
             text-align: right;
         }
         .style5
         {
             width: 141px;
             height: 13px;
             font-weight: bold;
         }
         .style7
         {
             text-align: right;
             height: 13px;
         }
         .style8
         {
             height: 13px;
             width: 80px;
         }
         .style9
         {
             width: 80px;
         }
         .style10
         {
             width: 141px;
             font-weight: bold;
         }
         .style12
         {
             text-align: right;
             font-size: xx-small;
         }
         .style13
         {
             width: 110px;
         }
         .style14
         {
             width: 61px;
         }
         .style15
         {
             width: 147px;
         }
         .style16
         {
             width: 115px;
         }
         .style17
         {
             font-size: x-small;
         }
         .style18
         {
             width: 141px;
             font-size: xx-small;
             font-weight: bold;
         }
         </style>   
    </head>
<body style="width: 302px; height: 511px; left: 0px;">
    <form id="form1" runat="server" class="auto-style1">
    <div   id="div_print" 
        
        
        
        
        style="font-family: Arial; font-size: small; font-style: normal; position: absolute; top: 16px; left: 10px; right: 565px; text-align: left;">   
                                    <asp:Label ID="LBL_MiniCartolaError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>
                                    <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones" Text="CERRAR" 
                                        Visible="False" />
                                    <br />
                                    <table class="style2">
                                        <tr>
                                            <td class="style16">
                                    <asp:Label ID="Label4" runat="server" CssClass="" Text="RUT" Font-Bold="True" 
                                                    style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                    <asp:Label ID="LBL_Rut" runat="server" CssClass="" 
                                                    style="font-size: small; font-weight: 700;"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" CssClass="" Text="-"></asp:Label>
                                    <asp:Label ID="LBL_Dv" runat="server" CssClass="" 
                                                    style="font-size: small; font-weight: 700;"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="LBL_NombreS" runat="server" CssClass="" 
                                        style="font-size: x-small; font-weight: 700;"></asp:Label>
                                            <br />
                                    <asp:Label ID="LBL_ApellidoP" runat="server" CssClass="" 
                                        style="font-size: x-small; font-weight: 700;"></asp:Label>
                                    &nbsp;<asp:Label ID="LBL_ApellidoM" runat="server" CssClass="" 
                                        style="font-size: x-small; font-weight: 700;"></asp:Label>
                                            <br />
                                    <table class="style2">
                                        <tr>
                                            <td class="style13">
                                    <asp:Label ID="Label3" runat="server" CssClass="" Text="Fecha Emision" 
                                                    style="font-size: xx-small; font-weight: 700;"></asp:Label>
                                            </td>
                                            <td class="style14">
                                                &nbsp;</td>
                                            <td class="style12">
                                    <asp:Label ID="LBL_FechaEmision" runat="server" 
                                        style="font-size: x-small; text-align: right" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                    <asp:Label ID="Label6" runat="server" CssClass="" Text="Cupo Aprobado" 
                                                    style="font-size: xx-small; font-weight: 700;"></asp:Label>
                                            </td>
                                            <td class="style14">
                                                &nbsp;</td>
                                            <td class="style12">
                                    <asp:Label ID="LBL_CupoAprobado" runat="server" 
                                        style="font-size: x-small; text-align: right" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                    <asp:Label ID="Label7" runat="server" CssClass="" Text="Disponible" 
                                                    style="font-size: xx-small; font-weight: 700"></asp:Label>
                                            </td>
                                            <td class="style14">
                                                &nbsp;</td>
                                            <td class="style12">
                                    <asp:Label ID="LBL_Disponible" runat="server" 
                                        style="font-size: x-small; text-align: right" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GrillaTrx" runat="server" 
                    AutoGenerateColumns="False" Height="116px" Width="285px" BorderStyle="None" Visible="False" 
                                        GridLines="None" style="font-size: small">
                                        <Columns>
                                            <asp:BoundField DataField="column1" HeaderText="FECHA" >
                                            <ControlStyle BorderStyle="None" />
                                            <HeaderStyle BorderStyle="None" Font-Names="Arial" Font-Size="XX-Small" 
                                                HorizontalAlign="Left" />
                                            <ItemStyle BorderStyle="None" Font-Names="Arial" Font-Size="XX-Small" 
                                                HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="column2" HeaderText="DESCRIPCION" >
                                            <HeaderStyle BorderStyle="None" Font-Names="Arial" Font-Size="XX-Small" 
                                                HorizontalAlign="Left" />
                                            <ItemStyle BorderStyle="None" Font-Names="Arial" Font-Size="XX-Small" 
                                                HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField 
                                                HeaderText="A PAGO" DataField="column3" >
                                            <HeaderStyle BorderStyle="None" Font-Names="Arial" Font-Size="XX-Small" 
                                                HorizontalAlign="Right" />
                                            <ItemStyle BorderStyle="None" Font-Names="Arial" Font-Size="XX-Small" 
                                                HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EditRowStyle HorizontalAlign="Left" />
                                        <PagerStyle BorderStyle="None" />
                                        <RowStyle BorderStyle="None" />
                                    </asp:GridView>
                                    <table class="style2">
                                        <tr>
                                            <td class="style18">
                                    <asp:Label ID="Label9" runat="server" CssClass="" Text="Cargos del Mes"></asp:Label>
                                            </td>
                                            <td class="style9">
                                                &nbsp;</td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_CargosMes" runat="server" 
                                        style="font-size: x-small" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                    <asp:Label ID="Label10" runat="server" CssClass="" Text="Monto Atrasado" 
                                                    style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style8">
                                            </td>
                                            <td class="style7">
                                    <asp:Label ID="LBL_MontoAtrasado" runat="server" 
                                        style="font-size: x-small" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style10">
                                    <asp:Label ID="Label11" runat="server" CssClass="" Text="Monto a Cancelar" 
                                                    style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style9">
                                                &nbsp;</td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_MontoCancelar" runat="server" 
                                        style="font-size: x-small; font-weight: 700;" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style10">
                                    <asp:Label ID="Label17" runat="server" CssClass="" 
                                Text="Cancelar Hasta" style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style9">
                                                &nbsp;</td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_FechaPago" runat="server" 
                                        style="font-size: x-small; font-weight: 700;" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
&nbsp;<asp:Label ID="Label18" runat="server" Text="VENCIMIENTOS PROXIMOS 5 MESES" 
                                        style="font-size: xx-small; font-weight: 700"></asp:Label>
                                            &nbsp;<table class="style2">
                                        <tr>
                                            <td class="style15">
                                    <asp:Label ID="LBL_FechaVenc1" runat="server" CssClass="" 
                                        style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_MontoVenc1" runat="server" CssClass="" 
                                        style="font-size: x-small; "></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style15">
                                    <asp:Label ID="LBL_FechaVenc2" runat="server" CssClass="" 
                                        style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_MontoVenc2" runat="server" CssClass="" 
                                        style="font-size: x-small; text-align: right;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style15">
                                    <asp:Label ID="LBL_FechaVenc3" runat="server" CssClass="" 
                                        style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_MontoVenc3" runat="server" CssClass="" 
                                        style="font-size: x-small; text-align: right"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style15">
                                    <asp:Label ID="LBL_FechaVenc4" runat="server" CssClass="" 
                                        style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_MontoVenc4" runat="server" CssClass="" 
                                        style="font-size: x-small; text-align: right;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style15">
                                    <asp:Label ID="LBL_FechaVenc5" runat="server" CssClass="" 
                                        style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_MontoVenc5" runat="server" CssClass="style17" 
                                        style="text-align: right"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style15">
                                    <asp:Label ID="LBL_FechaVenc6" runat="server" CssClass="" 
                                        style="font-size: xx-small"></asp:Label>
                                            </td>
                                            <td class="style4">
                                    <asp:Label ID="LBL_MontoVenc6" runat="server" CssClass="style17" 
                                        style="text-align: right"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;<br />
                                    <asp:GridView ID="GrillaCuotas" runat="server" AutoGenerateColumns="False" Visible="False">
                                        <Columns>
                                            <asp:BoundField DataField="fecha" HeaderText="fecha" />
                                            <asp:BoundField DataField="valor_cuota" HeaderText="valor" />
                                        </Columns>
                                    </asp:GridView>
                                <br />
                <br />
                               
    </div>
    </form>
    </body>
</html>
