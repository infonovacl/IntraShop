
Partial Class MenuPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Sub BTN_Buscar_Click(sender As Object, e As EventArgs) Handles BTN_Buscar.Click
        'Me.TXT_RutCliente.Text = Master.PropertyMasterTextBox2
        Master.PropertyMasterTextBox2.Text = Me.TXT_RutCliente.Text
    End Sub
End Class
