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
        If IsPostBack = True And Session("iniciado") = "si" Then
            'MsgBox("Es un postback generado")
            Me.Panel_Login.Visible = False
            Me.Panel_menu.Visible = True
            Me.Panel_menu.Style.Add("position", "absolute")
            Me.Panel_menu.Style.Add("top", "1px")
            Me.Panel_menu.Style.Add("height", "412px")
            Me.Panel_menu.Style.Add("width", "210px")
            Me.TVM_Principal.ExpandAll()
        ElseIf IsPostBack = False Then
            If Session("iniciado") = Nothing Then
                Session("iniciado") = "si"
            ElseIf Session("iniciado") = "si" Then
                'MsgBox("Primera carga de pagina")
                Me.Panel_Login.Visible = False
                Me.Panel_menu.Visible = True
                Me.Panel_menu.Style.Add("position", "absolute")
                Me.Panel_menu.Style.Add("top", "1px")
                Me.Panel_menu.Style.Add("height", "412px")
                Me.Panel_menu.Style.Add("width", "210px")
                Me.TVM_Principal.ExpandAll()
                Me.LBL_UsuarioRutRegistrado.Text = Session("usuario")
                Me.LBL_UsuarioCodigoTiendaRegistrado.Text = Session("Tienda")
            End If
        End If
    End Sub
    Protected Sub BTN_Entrar_Click(sender As Object, e As EventArgs) Handles BTN_Entrar.Click
        Try
            Dim DATADSLoginPopUp As New Data.DataSet
            DATADSLoginPopUp.Clear()
            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Dim STRLogin As String = "execute procedure procw_login  ('" & RutCliente & "' )"
            Dim DATALogin As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLogin, conn)
            DATALogin.Fill(DATADSLoginPopUp, "PRUEBA")
            If DATADSLoginPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_LoginError.Visible = True
                Me.LBL_LoginError.Text = DATADSLoginPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                'If DATADSComentariosPopUp.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                ' Me.TXT_TiendaOrigen.Text = ""
                ' Else
                ' Me.TXT_TiendaOrigen.Text = DATADSComentariosPopUp.Tables(0).Rows(0)(2)
                ' End If              
                Me.LBL_UsuarioRutRegistrado.Text = Me.TXT_UsuarioRut.Text
                Session("usuario") = Me.LBL_UsuarioRutRegistrado.Text
                Session("tienda") = "15"
                Session("caja") = "101"
                Response.Write("<script>window.open(""Cliente.aspx"", ""_self"")</script>")
                Me.LBL_LoginError.Visible = False
            End If
        Catch EX As Exception
        End Try
    End Sub
End Class
