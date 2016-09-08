Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        MsgBox(Me.Login1.UserName.ToString)
    End Sub
End Class
