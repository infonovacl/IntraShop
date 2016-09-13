Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Partial Class Maestro
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If IsPostBack = False And Page.User.Identity.IsAuthenticated = False Then
        ' Session.Clear()
        ' Session.Abandon()
        'FormsAuthentication.SignOut()
        'FormsAuthentication.RedirectToLoginPage()
        'End If
        If IsPostBack = False And Page.User.Identity.IsAuthenticated = True Then
            Me.UsuarioNombre.Text = Session("nombreusuario")
            Me.CTienda.Text = Session("sucursal")
            Me.Caja.Text = Session("caja")
            Me.CajaNombreTienda.Text = Session("nombretienda")
            'Me.LBL_LoginError.Visible = True
            'Me.LBL_LoginError.Text = ""
            Me.Panel_menu.Visible = True
            Me.Panel_menu.Style.Add("position", "absolute")
            Me.Panel_menu.Style.Add("top", "1px")
            Me.Panel_menu.Style.Add("height", "370px")
            Me.Panel_menu.Style.Add("width", "210px")
            Me.Panel_Login.Visible = True
            Me.Panel_Login.Style.Add("position", "absolute")
            Me.Panel_Login.Style.Add("top", "372px")
            Me.Panel_Login.Style.Add("height", "25px")
            Me.Panel_Login.Style.Add("width", "210px")
            Me.TVM_Principal.ExpandAll()
        ElseIf IsPostBack = True And Page.User.Identity.IsAuthenticated = True Then
            If Me.Panel_menu.Visible = False Then
                Me.Panel_menu.Visible = True
                Me.Panel_menu.Style.Add("position", "absolute")
                Me.Panel_menu.Style.Add("top", "1px")
                Me.Panel_menu.Style.Add("height", "370px")
                Me.Panel_menu.Style.Add("width", "210px")
                Me.Panel_Login.Visible = True
                Me.Panel_Login.Style.Add("position", "absolute")
                Me.Panel_Login.Style.Add("top", "372px")
                Me.Panel_Login.Style.Add("height", "25px")
                Me.Panel_Login.Style.Add("width", "210px")
                Me.TVM_Principal.ExpandAll()
            End If
        End If
    End Sub
    Protected Sub LNKB_CerrarSesion_Click(sender As Object, e As EventArgs) Handles LNKB_CerrarSesion.Click
        Session.Clear()
        Session.Abandon()
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class
