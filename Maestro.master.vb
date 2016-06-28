Partial Class Maestro
    Inherits System.Web.UI.MasterPage
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Public Property PropertyMasterTextBox2() As TextBox
        Get
            Return TXT_RutMaster
        End Get
        Set(value As TextBox)
            TXT_RutMaster = value
        End Set
    End Property
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_LoginError.Visible = True
        Me.LBL_LoginError.Text = ""
        Me.TXT_UsuarioRut.Focus()
        If IsPostBack = True And Session("usuario_validado") = "si" Then
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
                Dim DATADSLoginPopUp As New Data.DataSet
                DATADSLoginPopUp.Clear()
                Dim RutCliente As Integer
                RutCliente = Session("rut")
                Dim STRLogin As String = "execute procedure procw_login  ('" & CType(partes(0), Integer) & "','" & partes(1) & "','" & Me.TXT_UsuarioContraseña.Text & "')"
                Dim DATALogin As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLogin, conn)
                DATALogin.Fill(DATADSLoginPopUp, "PRUEBA")
                If DATADSLoginPopUp.Tables(0).Rows(0)(0) = 1 Then
                    Me.LBL_LoginError.Visible = True
                    Me.LBL_LoginError.Text = DATADSLoginPopUp.Tables(0).Rows(0)(1) 'mensaje de error
                    Session("usuario_validado") = "no"
                Else
                    Session("usuario_validado") = "si"
                    Me.Panel_Login.Visible = False
                        Me.Panel_menu.Visible = True
                        Me.Panel_menu.Style.Add("position", "absolute")
                        Me.Panel_menu.Style.Add("top", "1px")
                        Me.Panel_menu.Style.Add("height", "412px")
                        Me.Panel_menu.Style.Add("width", "210px")
                        Me.TVM_Principal.ExpandAll()
                        Me.LBL_UsuarioRutRegistrado.Text = Session("usuario")
                    Me.LBL_UsuarioCodigoTiendaRegistrado.Text = Session("Tienda")
                    'If DATADSComentariosPopUp.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                    ' Me.TXT_TiendaOrigen.Text = ""
                    ' Else
                    ' Me.TXT_TiendaOrigen.Text = DATADSComentariosPopUp.Tables(0).Rows(0)(2)
                    Response.Write("<script>window.open(""Cliente.aspx"", ""_self"")</script>")
                    Me.LBL_UsuarioRutRegistrado.Text = CType(partes(0), Integer) '''rut
                    Session("usuario") = Me.LBL_UsuarioRutRegistrado.Text
                    Session("tienda") = "15"
                    Session("caja") = "101"
                    Me.LBL_LoginError.Visible = False
                End If
            Catch EX As Exception
            End Try
        End If
    End Sub
    Protected Sub TXT_UsuarioRut_TextChanged(sender As Object, e As EventArgs) Handles TXT_UsuarioRut.TextChanged
        Me.LBL_LoginError.Visible = False
        Me.LBL_LoginError.Text = ""
    End Sub
End Class
