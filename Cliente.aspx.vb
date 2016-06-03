
Partial Class MenuPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Sub BTN_Buscar_Click(sender As Object, e As EventArgs) Handles BTN_Buscar.Click
        'Me.TXT_RutCliente.Text = Master.PropertyMasterTextBox2
        Master.PropertyMasterTextBox2.Text = Me.TXT_RutCliente.Text
        Session("rut") = Me.TXT_RutCliente.Text

    End Sub

    ' Protected Sub BTN_ProcesaTab_Click(sender As Object, e As EventArgs) Handles BTN_ProcesaTab.Click
    '     ProcesaTab(Me.LBL_TabIndice.Text)
    ' End Sub
    Protected Sub ProcesaTab(sender As Object, e As EventArgs) Handles BTN_ProcesaTab.Click
        Me.LBL_TabIndice2.Text = Me.LBL_TabIndice.Text
        ' MsgBox(Me.LBL_TabIndice.Text)
        ' MsgBox("Hola CTM")
    End Sub
End Class
