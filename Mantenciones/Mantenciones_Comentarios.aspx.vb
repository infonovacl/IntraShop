Partial Class Mantencion_Comentarios
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            Dim DATAComentarios As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRComentarios, conn)
            DATAComentarios.Fill(DATADSComentariosPopUp, "PRUEBA")
            If DATADSComentariosPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.Panel_Comentarios.Visible = False
                Me.LBL_ComentariosError.Visible = True
                Me.LBL_ComentariosError.Text = DATADSComentariosPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.Panel_Comentarios.Visible = True
                Me.LBL_ComentariosError.Visible = False
                Me.Grilla_Comentarios.DataSource = DATADSComentariosPopUp.Tables(0).DefaultView
                Me.Grilla_Comentarios.DataBind()
            End If
        Catch EX As Exception
        End Try
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click
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
            Dim DATAComentarios As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRComentarios, conn)
            DATAComentarios.Fill(DATADSComentariosPopUp, "PRUEBA")
            If DATADSComentariosPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.Panel_Comentarios.Visible = False
                Me.LBL_ComentariosError.Visible = True
                Me.LBL_ComentariosError.Text = DATADSComentariosPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.Panel_Comentarios.Visible = True
                Me.LBL_ComentariosError.Visible = False
                Me.Grilla_Comentarios.DataSource = DATADSComentariosPopUp.Tables(0).DefaultView
                Me.Grilla_Comentarios.DataBind()
            End If
        Catch EX As Exception
        End Try
    End Sub
End Class
