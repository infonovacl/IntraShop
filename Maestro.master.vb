
Partial Class Maestro
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Sub BTN_Entrar_Click(sender As Object, e As EventArgs) Handles BTN_Entrar.Click
        'Me.Panel_Login.Style.Add("position", "absolute")
        'Me.Panel_Login.Style.Add("top", "0px")
        'Me.Panel_Login.Style.Add("left", "2px")
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
    Protected Sub TVM_Principal_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TVM_Principal.SelectedNodeChanged

    End Sub
End Class

