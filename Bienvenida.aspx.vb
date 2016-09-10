Imports System.Data
Imports System.Configuration
Imports System.Web.Security
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        Try
            Dim partes() As String
            partes = Split(Me.Login1.UserName, "-")
            Dim DATADSLogin As New Data.DataSet
            DATADSLogin.Clear()
            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Globales.conn.Open()
            Dim STRLogin As String = "execute procedure procw_login  ('" & CType(partes(0), Integer) & "','" & partes(1) & "','" & Trim(Me.Login1.Password) & "')"
            Dim DATALogin As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLogin, Globales.conn)
            DATALogin.Fill(DATADSLogin, "PRUEBA")
            Globales.conn.Close()
            If DATADSLogin.Tables(0).Rows(0)(0) = 1 Then
                Me.Login1.FailureText = DATADSLogin.Tables(0).Rows(0)(1) 'mensaje de error
                Session("usuario_validado") = "no"
                Login1.FailureText = "Usuario y/o contraseña no son correctos."
                e.Authenticated = False
            Else
                Session("usuario_validado") = "si"
                Dim nombre, apellido, nombretienda As String
                If DATADSLogin.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                    nombre = ""
                Else
                    If Trim(DATADSLogin.Tables(0).Rows(0)(5)).Length > 7 Then
                        nombre = Trim(DATADSLogin.Tables(0).Rows(0)(5)).Substring(0, 8)
                    Else
                        nombre = Trim(DATADSLogin.Tables(0).Rows(0)(5))
                    End If
                End If
                If DATADSLogin.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                    apellido = ""
                Else
                    If Trim(DATADSLogin.Tables(0).Rows(0)(3)).Length > 11 Then
                        apellido = Trim(DATADSLogin.Tables(0).Rows(0)(3)).Substring(0, 12)
                    Else
                        apellido = Trim(DATADSLogin.Tables(0).Rows(0)(3))
                    End If
                End If
                Session("nombreusuario") = nombre & " " & apellido
                'Label mpLabel = (Label)Page.Master.FindControl("Label_welcome")
                'Dim nusuario As Label = Me.Page.Master.FindControl("usuarionombre")
                'nusuario.Text = nombre & " " & apellido
                Me.Master.PropertyMasterLabelUsuario.Text = nombre & " " & apellido
                Session("sucursal") = Trim(DATADSLogin.Tables(0).Rows(0)(2)) ' codigo tienda
                Session("caja") = Trim(DATADSLogin.Tables(0).Rows(0)(7)) 'nro caja
                If DATADSLogin.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                    nombretienda = ""
                Else
                    If Trim(DATADSLogin.Tables(0).Rows(0)(6)).Length > 21 Then
                        nombretienda = Trim(DATADSLogin.Tables(0).Rows(0)(6)).Substring(0, 21)
                    Else
                        nombretienda = Trim(DATADSLogin.Tables(0).Rows(0)(6))
                    End If
                End If
                Session("nombretienda") = nombretienda
                Session("usuario") = CType(partes(0), Integer) 'rut  
                e.Authenticated = True
            End If
        Catch EX As Exception
            MsgBox(EX)
        End Try
        'Dim userid As String
        'Select Case userId
        ' Case -1
        ' Login1.FailureText = "Username and/or password is incorrect."
        ' Exit Select
        ' Case -2
        ' Login1.FailureText = "Account has not been activated."
        ' Exit Select
        ' Case Else
        ' FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
        ' Exit Select
        'End Select
    End Sub
End Class
