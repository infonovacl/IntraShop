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

        If IsPostBack = True Then
            MsgBox("Es un postback generado")

        ElseIf IsPostBack = False Then
            MsgBox("Primera carga de pagina")
        End If

    End Sub
    Protected Sub BTN_Entrar_Click(sender As Object, e As EventArgs) Handles BTN_Entrar.Click
        'Me.Panel_Login.Style.Add("position", "absolute")
        'Me.Panel_Login.Style.Add("top", "0px")
        'Me.Panel_Login.Style.Add("left", "2px")
        Me.Panel_Login.Visible = False
        Me.Panel_Menu.Visible = True
        Me.Panel_Menu.Style.Add("position", "absolute")
        Me.Panel_Menu.Style.Add("top", "2px")
        Me.Panel_Menu.Style.Add("left", "2px")
        Me.Panel_Menu.Style.Add("height", "408px")
        Me.Panel_Menu.Style.Add("width", "205px")
        'Me.TVM_Principal_Load("")
        Me.TVM_Principal.ExpandAll()

    End Sub
    Protected Sub TVM_Principal_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TVM_Principal.SelectedNodeChanged
        'MsgBox(Me.TVM_Principal.SelectedNode.Value)
        'TextBox t = (TextBox)cph_body.FindControl("txtOrigin"); 
        'Me.LBL_RutCliente.Text = (Me.ContentPlaceHolder1.FindControl("TXT_RutCliente"),textbox)
        'Dim mpContentPlaceHolder As ContentPlaceHolder
        ' Dim mpTextBox As TextBox
        'mpContentPlaceHolder =
        'CType(Master.FindControl("ContentPlaceHolder1"),
        'ContentPlaceHolder)
        ' If Not mpContentPlaceHolder Is Nothing Then
        Try
            'Me.TXT_RutMaster.Text = Me.ContentPlaceHolder1.FindControl("TXT_RutCliente") As textbox
            Me.TXT_RutMaster.Text = (Me.TVM_Principal.SelectedNode.Value)
            'MsgBox(Me.TXT_RutMaster.Text)
            'MsgBox(Me.TVM_Principal.SelectedNode.Value)
        Catch ex As Exception
            MsgBox(ex)
        End Try

        'If Not mpTextBox Is Nothing Then
        ' mpTextBox.Text = "TextBox found!"
        'End If
        'End If
    End Sub
End Class

