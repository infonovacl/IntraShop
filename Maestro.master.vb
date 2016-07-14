Partial Class Maestro
    Inherits System.Web.UI.MasterPage
    Public Property PropertyMasterTextBox2() As TextBox
        Get
            Return TXT_RutMaster
        End Get
        Set(value As TextBox)
            TXT_RutMaster = value
        End Set
    End Property
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False And Session("usuario_validado") = "si" Then
            Me.LBL_LoginError.Visible = True
            Me.LBL_LoginError.Text = ""
            Me.Panel_menu.Visible = True
            Me.Panel_menu.Style.Add("position", "absolute")
            Me.Panel_menu.Style.Add("top", "1px")
            Me.Panel_menu.Style.Add("height", "412px")
            Me.Panel_menu.Style.Add("width", "210px")
            Me.TVM_Principal.ExpandAll()
            Me.UsuarioNombre.Text = Session("nombreusuario")
            Me.CTienda.Text = Session("tienda")
            Me.Caja.Text = Session("caja")
            Me.CajaNombreTienda.Text = Session("nombretienda")
        ElseIf IsPostBack = False And Session("usuario_validado") = "no" Then
            Response.Write("<script>window.open(""Bienvenida.aspx"", ""_self"")</script>")
            Me.Panel_menu.Visible = False
        ElseIf IsPostBack = True And Session("usuario_validado") = "si" Then
            Me.Panel_menu.Visible = True
            Me.Panel_menu.Style.Add("position", "absolute")
            Me.Panel_menu.Style.Add("top", "1px")
            Me.Panel_menu.Style.Add("height", "412px")
            Me.Panel_menu.Style.Add("width", "210px")
            Me.TVM_Principal.ExpandAll()
        End If
    End Sub
    Protected Sub BTN_Entrar_Click(sender As Object, e As EventArgs) Handles BTN_Entrar.Click
        Me.LBL_LoginError.Visible = False
        Me.LBL_LoginError.Text = ""
        If Page.IsValid = True Then
            Dim partes() As String
            partes = Split(Me.TXT_UsuarioRut.Text, "-")
            Try
                Dim DATADSLogin As New Data.DataSet
                DATADSLogin.Clear()
                Dim RutCliente As Integer
                RutCliente = Session("rut")
                Dim STRLogin As String = "execute procedure procw_login  ('" & CType(partes(0), Integer) & "','" & partes(1) & "','" & Me.TXT_UsuarioContraseña.Text & "')"
                Dim DATALogin As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLogin, Globales.conn)
                DATALogin.Fill(DATADSLogin, "PRUEBA")
                If DATADSLogin.Tables(0).Rows(0)(0) = 1 Then
                    Me.LBL_LoginError.Visible = True
                    Me.LBL_LoginError.Text = DATADSLogin.Tables(0).Rows(0)(1) 'mensaje de error
                    Session("usuario_validado") = "no"
                    Me.Panel_menu.Visible = False
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
                    Session("tienda") = Trim(DATADSLogin.Tables(0).Rows(0)(2)) ' codigo tienda
                    Session("caja") = Trim(DATADSLogin.Tables(0).Rows(0)(7)) 'nro caja
                    If DATADSLogin.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                        nombretienda = ""
                    Else
                        If Trim(DATADSLogin.Tables(0).Rows(0)(6)).Length > 8 Then
                            nombretienda = Trim(DATADSLogin.Tables(0).Rows(0)(6)).Substring(0, 8)
                        Else
                            nombretienda = Trim(DATADSLogin.Tables(0).Rows(0)(6))
                        End If
                    End If
                    Session("nombretienda") = nombretienda
                    Session("usuario") = CType(partes(0), Integer) 'rut
                        Me.Panel_Login.Visible = False
                        Me.Panel_menu.Visible = True
                        Me.Panel_menu.Style.Add("position", "absolute")
                        Me.Panel_menu.Style.Add("top", "1px")
                        Me.Panel_menu.Style.Add("height", "412px")
                        Me.Panel_menu.Style.Add("width", "210px")
                        Me.TVM_Principal.ExpandAll()
                        'If DATADSComentariosPopUp.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                        ' Me.TXT_TiendaOrigen.Text = ""
                        ' Else
                        ' Me.TXT_TiendaOrigen.Text = DATADSComentariosPopUp.Tables(0).Rows(0)(2)
                        Response.Write("<script>window.open(""Cliente.aspx"", ""_self"")</script>")
                        Me.LBL_LoginError.Visible = False
                    End If
            Catch EX As Exception
                MsgBox(EX)
            End Try
        End If
    End Sub
    Protected Sub TXT_UsuarioRut_TextChanged(sender As Object, e As EventArgs) Handles TXT_UsuarioRut.TextChanged
        Me.LBL_LoginError.Visible = False
        Me.LBL_LoginError.Text = ""
    End Sub
End Class
