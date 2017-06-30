Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Partial Class Maestro
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If IsPostBack = False And Page.User.Identity.IsAuthenticated = False Then
            'Response.Write("<script>window.alert('MENSAJE1');</script>")
            'Page.User.Identity.IsAuthenticated = False
            Me.Panel_Login.Visible = False
            Me.Panel_menu.Visible = False
        ElseIf IsPostBack = False And Page.User.Identity.IsAuthenticated = True Then ' POSTBACK DESDE LOGIN
            'Response.Redirect("Cliente.aspx", "_self")
            'Response.Write("<script>window.alert('MENSAJE2');</script>")
            Me.UsuarioNombre.Text = Session("nombreusuario")
            Me.CTienda.Text = Session("codtienda")
            Me.Caja.Text = Session("caja")
            Me.CajaNombreTienda.Text = Session("nombretienda")
        ElseIf IsPostBack = True Then
            ' Response.Write("<script>window.alert('POST BACK TRU');</script>")
        End If
    End Sub
    Protected Sub LNKB_CerrarSesion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LNKB_CerrarSesion.Click
        Me.Panel_Login.Visible = False
        Me.Panel_menu.Visible = False
        Session.Clear()
        Session.Abandon()
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class
