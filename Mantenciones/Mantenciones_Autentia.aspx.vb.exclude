Imports System.IO
Imports System.Xml
Imports System
Imports System.Web.Services.Protocols
Imports System.Net
'Imports EFax
Imports System.ServiceModel.Description
Imports System.ServiceModel
Partial Class Mantencion_Autentia
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim RutCliente As String
            RutCliente = Trim(Session("rut")) + "-" + Trim(Session("dv"))
            Me.ruttitular.Text = RutCliente           
            Me.ButtonAut.Attributes.Add("OnClick", "Iniciar ( );")
        End If
    End Sub
    Protected Sub BTN_Cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_Cerrar.Click
        Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>") 'CIERRA VENTANA POPUP   
    End Sub
    Protected Sub ButtonAut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAut.Click
        'Dim Rut, Largo As Integer
        'Dim Dig As String
        'If Me.ErcDet.Value = "0" Then
        ''Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>") 'CIERRA VENTANA POPUP  
        'Else
        'Me.Mensaje.Text = ErcDet.Value
        'Me.ErcRes.Value = ""
        'Me.LabelMSJ.Text = Me.Descripcion.Value
        'Me.Mensaje.Text = "ERROR en Validacion de Huella (codigo vb)"
        '' Me.ButtonAut.Enabled = False
        'Me.ruttitular.Text = ""
        'Me.ruttitular.Focus()
        'End If
    End Sub
End Class
