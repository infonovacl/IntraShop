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
            MsgBox("Es un postback generado")
            Me.Panel_Login.Visible = False
            Me.Panel_Menu.Visible = True
            Me.Panel_Menu.Style.Add("position", "absolute")
            Me.Panel_Menu.Style.Add("top", "2px")
            Me.Panel_Menu.Style.Add("left", "2px")
            Me.Panel_Menu.Style.Add("height", "408px")
            Me.Panel_Menu.Style.Add("width", "205px")
            Me.TVM_Principal.ExpandAll()
            Me.TXT_RutMaster.Text = Session("rut")
            Try
                Me.TVM_Principal.SelectedNode.Value = Session("nodo_seleccionado")
            Catch ex As Exception
            End Try
        ElseIf IsPostBack = False Then
            If Session("iniciado") = Nothing Then
                Session("iniciado") = "si"
                Try
                    Me.TVM_Principal.SelectedNode.Value = Session("nodo_seleccionado")
                Catch ex As Exception
                End Try
            ElseIf Session("iniciado") = "si" Then
                ' MsgBox("Primera carga de pagina")
                Me.Panel_Login.Visible = False
                Me.Panel_Menu.Visible = True
                Me.Panel_Menu.Style.Add("position", "absolute")
                Me.Panel_Menu.Style.Add("top", "2px")
                Me.Panel_Menu.Style.Add("left", "2px")
                Me.Panel_Menu.Style.Add("height", "408px")
                Me.Panel_Menu.Style.Add("width", "205px")
                Me.TVM_Principal.ExpandAll()
                Me.TXT_RutMaster.Text = Session("rut")
                Try
                    Me.TVM_Principal.SelectedNode.Value = Session("nodo_seleccionado")
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Protected Sub BTN_Entrar_Click(sender As Object, e As EventArgs) Handles BTN_Entrar.Click
        ' Session("iniciado") = "si"
        ' Me.BTN_Entrar.Enabled = False
        'Me.Panel_Login.Style.Add("position", "absolute")
        'Me.Panel_Login.Style.Add("top", "0px")
        'Me.Panel_Login.Style.Add("left", "2px")
        ' Me.Panel_Login.Visible = False
        ' Me.Panel_Menu.Visible = True

        'Me.TVM_Principal_Load("")


    End Sub

    Protected Sub TVM_Principal_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TVM_Principal.SelectedNodeChanged
        Try
            Session("nodo_seleccionado") = Me.TVM_Principal.SelectedNode.Value
        Catch ex As Exception

        End Try
    End Sub
End Class

