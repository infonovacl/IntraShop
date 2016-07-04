Partial Class Mantencion_Comentarios
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Panel_Comentarios.Visible = True
        Me.LBL_ComentariosError.Visible = False
        If Not IsPostBack Then
            ObtieneComentarios()
        End If
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click
        Try
            If Trim(Me.TXT_Comentario.Text) <> "" And IsNothing(Me.TXT_Comentario.Text) = False And Trim(Me.TXT_Comentario.Text).Length > 4 Then
                Dim DATADSInsertaComentariosPopUp As New Data.DataSet
                DATADSInsertaComentariosPopUp.Clear()
                Dim RutCliente, usuario As Integer
                RutCliente = Session("rut")
                usuario = Session("usuario")
                Dim STRInsertaComentarios As String = "execute procedure procw_ingr_comenta  ('" & RutCliente & "','" & Me.TXT_Comentario.Text.ToUpper & "','" & usuario & "')"
                Dim DATAInsertaComentarios As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRInsertaComentarios, Globales.conn)
                DATAInsertaComentarios.Fill(DATADSInsertaComentariosPopUp, "PRUEBA")
                If DATADSInsertaComentariosPopUp.Tables(0).Rows(0)(0) = 1 Then
                    Me.BTN_Grabar.Enabled = True
                    Me.Panel_Comentarios.Visible = False
                    Me.LBL_ComentariosError.Visible = True
                    Me.LBL_ComentariosError.Text = DATADSInsertaComentariosPopUp.Tables(0).Rows(0)(1) ' mensaje de error
                Else
                    ObtieneComentarios()
                End If
            Else
                Me.BTN_Grabar.Enabled = True
                Me.LBL_ComentariosError.Visible = True
                Me.LBL_ComentariosError.Text = "Debe Ingresar un Comentario Válido"
                Me.TXT_Comentario.Focus()
            End If
        Catch EX As Exception
            MsgBox(EX)
        End Try
    End Sub
    Private Sub ObtieneComentarios()
        Try
            Dim DATADSComentariosPopUp As New Data.DataSet
            DATADSComentariosPopUp.Clear()
            Me.Grilla_Comentarios.DataSource = Nothing
            Me.Grilla_Comentarios.DataBind()
            Me.TXT_Comentario.Text = ""
            Me.TXT_Comentario.Focus()
            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Dim STRComentarios As String = "execute procedure procw_cons_comenta ('" & RutCliente & "' )"
            Dim DATAComentarios As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRComentarios, Globales.conn)
            DATAComentarios.Fill(DATADSComentariosPopUp, "PRUEBA")
            If DATADSComentariosPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.BTN_Grabar.Enabled = False
                Me.LBL_ComentariosError.Visible = True
                Me.LBL_ComentariosError.Text = DATADSComentariosPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.Panel_Comentarios.Visible = True
                Me.BTN_Grabar.Enabled = True
                Me.LBL_ComentariosError.Visible = False
                Me.Grilla_Comentarios.DataSource = DATADSComentariosPopUp.Tables(0).DefaultView
                Me.Grilla_Comentarios.DataBind()
            End If
        Catch EX As Exception
        End Try
    End Sub
End Class
