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
        Me.LBL_UsuarioRutRegistrado.Text = Me.TXT_UsuarioRut.Text
        Session("usuario") = Me.LBL_UsuarioRutRegistrado.Text
        Session("tienda") = "15"
        Session("caja") = "101"
        Response.Write("<script>window.open(""Cliente.aspx"", ""_self"")</script>")
        'Dim node As TreeNode
        'For Each node In Me.TVM_Principal.Nodes(0).ChildNodes
        ' Select Case node.Text
        ' Case "Tarjeta"
        ' node.Selected = True
        ' node.NavigateUrl = "~/Cliente.aspx"
        ' node.Select()
        '     End Select
        ' Next
    End Sub
End Class

