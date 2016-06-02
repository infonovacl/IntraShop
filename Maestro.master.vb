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
            ' MsgBox("Es un postback generado")
            Me.Panel_Login.Visible = False
            Me.Panel_Menu.Visible = True
            Me.Panel_Menu.Style.Add("position", "absolute")
            Me.Panel_menu.Style.Add("top", "1px")
            ' Me.Panel_menu.Style.Add("left", "1px")
            Me.Panel_menu.Style.Add("height", "412px")
            Me.Panel_menu.Style.Add("width", "210px")
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
                Me.Panel_menu.Style.Add("position", "absolute")
                Me.Panel_menu.Style.Add("top", "1px")
                '  Me.Panel_menu.Style.Add("left", "1px")
                Me.Panel_menu.Style.Add("height", "412px")
                Me.Panel_menu.Style.Add("width", "210px")
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
        ' ¿ Me.BTN_Entrar.PostBackUrl = "~/Cliente.aspx"
        ' Dim node As TreeNode
        ' For Each node In Me.TVM_Principal.Nodes(0).ChildNodes
        ' Select Case node.Text
        ' Case "Tarjeta"
        ' node.Selected = True
        ' node.NavigateUrl = "~/Cliente.aspx"
        ' node.Select()
        ' Case Else
        ' ' Do nothing.
        'End Select
        'Next
    End Sub

    'Sub Button_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
    ' Iterate through the child nodes of the root node and find
    ' the nodes for Chapter One and Chapter Two.
    'Dim node As TreeNode
    'For Each node In Me.TVM_Principal.Nodes(0).ChildNodes
    ' Select the appropriate node based on which button was clicked.
    'Select Case node.Text
    'Case "Tarjeta"
    '' If the button clicked was "Chapter One", select the node using the Selected property.
    'If e.CommandName = "Tarjeta" Then
    '                   ' Select the node using the Selected property.
    '                   node.Select = True
    ' End If
    ' ' Case "Chapter Two"
    ' '' If the button clicked was "Chapter Two", select the node 
    ' '' using the Selected method.
    ' 'If e.CommandName = "Chapter Two" Then
    ' '' Select the node using the Select method.
    ' 'node.Select()
    ' 'End If
    ' Case Else
    ' ' Do nothing.
    ' End Select
    ' Next
    ' End Sub
    Protected Sub TVM_Principal_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TVM_Principal.SelectedNodeChanged
        Try
            Session("nodo_seleccionado") = Me.TVM_Principal.SelectedNode.Value
        Catch ex As Exception

        End Try
    End Sub

End Class

