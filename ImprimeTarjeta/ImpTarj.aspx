<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpTarj.aspx.cs" Inherits="ImpTarj" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript">

        function hide() {
                var mostrar = document.getElementById("Panel1");
                mostrar.style.display = "inline";
        }
        function imprimir() {
            var data = document.getElementById('<%= TextBox1.ClientID %>').value;
            var Evolis = new ActiveXObject("EvolisDLL.Class");
            var result = Evolis.Procesar(1, data, false);
            if (result=="OK"){
                alert("Impresion realizada exitosamente");
		var ventana = window.self;
	    	ventana.opener = window.self; 
	    	ventana.close();
            }
            else {
                alert("No es posible imprimir la tarjeta");
		var ventana = window.self;
	    	ventana.opener = window.self; 
	    	ventana.close();
            }
        }
	function cerrar() { 
	    var ventana = window.self;
	    ventana.opener = window.self; 
	    ventana.close();
	} 
    </script>
    <style type="text/css">
        .auto-style {
            font-weight: bold;
            font-size: 10px;
            color: #013c88;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            width: 101px;
            background-color: #def3fa;
            height: 24px;
        }

        .auto-style2 {
            width: 27px;
            height: 26px;
            font-weight: bold;
            font-family: Verdana, Arial, Helvetica, sans-serif;
        }

        .Panel1 {
            display: none;
            font-weight: bold;
            font-size: 10px;
            color: #013c88;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            width: 101px;
            background-color: #def3fa;
            height: 24px;
        }
        .auto-style3 {
            font-weight: bold;
            font-size: 10px;
            color: #013c88;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            width: 162px;
            background-color: #def3fa;
            height: 24px;
        }
        .auto-style4 {
            font-weight: bold;
            font-size: 10px;
            color: #013c88;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            width: 118px;
            background-color: #def3fa;
            height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div style="width: 1469px">
            <img alt="" class="auto-style2" src="images/icon-tarjeta-blue.png" />
            <asp:Label ID="Label3" runat="server" Text="Tarjeta" class="auto-style2"></asp:Label>
            <br />
            <table border="0" style="width: 1071px">
                <tr>
                    <td class="auto-style">Nombre</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
                    <td class="auto-style">Rut</td>
                    <td class="auto-style">
                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style">Fecha Solicitud</td>
                    <td class="auto-style">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                    <td class="auto-style4">Version de Tarjeta</td>
                    <td class="auto-style">
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
            <table border="0" style="width: 1071px">
                <tr>
                    <td class="auto-style">Tipo de Tarjeta</td>
                    <td class="auto-style">
                        <asp:DropDownList ID="TipoTarjeta" runat="server" onchange="hide()" Height="16px" Width="112px">
                            <asp:ListItem Value="1" Text="Titular"/>
                            <asp:ListItem Value="2" Text="Adicional"/>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="true" style="display:none">
            <asp:GridView ID="GridView" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1072px" class="auto-style">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </asp:Panel>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        
        <asp:Button ID="Button1" runat="server" Text="Generar" OnClick="Button1_Click1" />
        <input name="button" type="button" onclick="imprimir();" value="Imprimir" />
        <input name="button" type="button" onclick="cerrar();" value="Cerrar" />
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="385px" style="display:none"/>
    </div>
    </form>
</body>
</html>
