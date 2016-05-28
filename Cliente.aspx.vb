
Partial Class MenuPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Sub BTN_Buscar_Click(sender As Object, e As EventArgs) Handles BTN_Buscar.Click
        'Me.TXT_RutCliente.Text = Master.PropertyMasterTextBox2
        Master.PropertyMasterTextBox2.Text = Me.TXT_RutCliente.Text
    End Sub
    Protected Sub Tab_Consultas_ActiveTabChanged(sender As Object, e As EventArgs) Handles Tab_Consultas.ActiveTabChanged
        MsgBox("Procedimiento : " & Me.Tab_Consultas.ActiveTabIndex.ToString & " para el rut " & Me.TXT_RutCliente.Text & "")
        Select Case Me.Tab_Consultas.ActiveTabIndex.ToString
            Case 0
                Me.Grilla_Estados.DataBind()
        End Select
    End Sub
End Class
