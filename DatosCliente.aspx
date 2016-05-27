<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DatosCliente.aspx.vb" Inherits="DatosCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/EstilosShop.css" rel="stylesheet" />
    <link href="css/Maestro.css" rel="stylesheet" />
    <title>Datos del Cliente</title>
</head>
<body>
    <form id="form1" runat="server" class="contenedor">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <br />
            <br />
            <br />
            hola madafaka</asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="Panel1_ModalPopupExtender" runat="server" BehaviorID="Panel1_ModalPopupExtender" RepositionMode="RepositionOnWindowResizeAndScroll" TargetControlID="Panel1">
        </ajaxToolkit:ModalPopupExtender>
    </form>
</body>
</html>
