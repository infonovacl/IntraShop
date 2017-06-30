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
            Dim STRLogin As String = "execute procedure procw_login  ('" & CType(partes(0), Integer) & "','" & partes(1) & "','" & Trim(Me.Login1.Password) & "')"
            Dim DATALogin As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLogin, Globales.conn)
            DATALogin.Fill(DATADSLogin, "PRUEBA")
            If DATADSLogin.Tables(0).Rows(0)(0) = 1 Then
                Me.Login1.FailureText = DATADSLogin.Tables(0).Rows(0)(1) 'mensaje de error                       
                e.Authenticated = False
            Else
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
                Session("codtienda") = Trim(DATADSLogin.Tables(0).Rows(0)(2)) ' codigo tienda
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
                ' Response.Redirect("Cliente.aspx")
            End If
        Catch EX As Exception
            Me.Login1.FailureText = EX.Message
            e.Authenticated = False
        End Try
    End Sub
    Protected Sub Login1_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoggedIn
        Response.Redirect("Cliente.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Focus()
        Page.Form.DefaultFocus = Login1.FindControl("Username").ClientID
    End Sub
End Class
