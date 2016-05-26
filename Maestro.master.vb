
Partial Class Maestro
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            '  Me.Panel_Menu.Visible = True
            MsgBox("post back = false")
            If Me.Panel_Menu.Visible = True Then
                MsgBox("menu visible =true")
                ' Else
                '     MsgBox("login visible =false")
                '     Me.Panel_Login.Visible = False
            Else
                Me.Panel_Menu.Visible = True
            End If
        ElseIf IsPostBack Then
            MsgBox("post back = true")
            ' Me.Panel_Login.Visible = False
            ' Me.Panel_Menu.Visible = True
        End If
    End Sub
    Protected Sub BTN_Entrar_Click(sender As Object, e As EventArgs) Handles BTN_Entrar.Click
        'Me.Panel_Login.Style.Add("position", "absolute")
        'Me.Panel_Login.Style.Add("top", "0px")
        'Me.Panel_Login.Style.Add("left", "2px")
        Me.LBL_Usuario.Text = 13992731
        Me.LBL_Tienda.Text = 123
        Me.Panel_Login.Visible = False
        Me.Panel_Menu.Visible = True
        Me.Panel_Menu.Style.Add("position", "absolute")
        Me.Panel_Menu.Style.Add("top", "5px")
        Me.Panel_Menu.Style.Add("left", "2px")
        Me.Panel_Menu.Style.Add("height", "408px")
        Me.Panel_Menu.Style.Add("width", "205px")
        'Me.TVM_Principal_Load("")
        Me.TVM_Principal.ExpandAll()

    End Sub

End Class

