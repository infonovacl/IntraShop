Partial Class Consultas_BuscaXNombre
    Inherits System.Web.UI.Page
    Public rutbuscado As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Panel_BuscaXNombre.Visible = True
        Me.TXT_BuscaXNombre.Focus()
    End Sub
    Private Sub ObtieneNombres()
        Try
            Me.Grilla_BuscaXNombre.Columns(6).Visible = True
            Dim DATADSBuscaxNombrePopUp As New Data.DataSet
            DATADSBuscaxNombrePopUp.Clear()
            Me.Grilla_BuscaXNombre.DataSource = Nothing
            Me.Grilla_BuscaXNombre.DataBind()
            Dim STRBuscaxNombre As String = "execute procedure procw_busca_nombre ('" & TXT_BuscaXNombre.Text & "' )"
            Dim DATABuscaxNombre As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRBuscaxNombre, Globales.conn)
            DATABuscaxNombre.Fill(DATADSBuscaxNombrePopUp, "PRUEBA")
            If DATADSBuscaxNombrePopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_BuscarXNombreError.Visible = True
                Me.LBL_BuscarXNombreError.Text = DATADSBuscaxNombrePopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_ClienteSeleccionado.Text = ""
                Me.LBL_Rut.Text = ""
                Me.LBL_BuscarXNombreError.Visible = False
                Me.Grilla_BuscaXNombre.DataSource = DATADSBuscaxNombrePopUp.Tables(0).DefaultView
                Me.Grilla_BuscaXNombre.DataBind()
                Me.Grilla_BuscaXNombre.Columns(6).Visible = False
            End If
        Catch EX As Exception
            MsgBox(EX)
        End Try
    End Sub
    Protected Sub Grilla_BuscaxNombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grilla_BuscaXNombre.SelectedIndexChanged
        Dim IndiceGrillaBuscaxNombre As Integer = 0
        Me.Grilla_BuscaXNombre.Columns(6).Visible = True
        Try
            IndiceGrillaBuscaxNombre = Me.Grilla_BuscaXNombre.SelectedIndex.ToString()
            Me.LBL_ClienteSeleccionado.Text = Trim(Me.Grilla_BuscaXNombre.Rows(IndiceGrillaBuscaxNombre).Cells(6).Text)
            Me.LBL_Rut.Text = Trim(Me.Grilla_BuscaXNombre.Rows(IndiceGrillaBuscaxNombre).Cells(1).Text)
            Me.Grilla_BuscaXNombre.Columns(6).Visible = False
        Catch EX As Exception
            MsgBox(EX)
        End Try
    End Sub
    Protected Sub BTN_BuscarXNombre_Click(sender As Object, e As EventArgs) Handles BTN_BuscarXNombre.Click
        If Me.TXT_BuscaXNombre.Text <> "" And IsNumeric(Me.TXT_BuscaXNombre.Text) = False And Me.TXT_BuscaXNombre.Text.Length > 3 Then
            ObtieneNombres()
        Else
            Me.LBL_BuscarXNombreError.Visible = True
            Me.LBL_BuscarXNombreError.Text = "DEBE INGRESAR UN NOMBRE VÁLIDO"
            Me.TXT_BuscaXNombre.Focus()
        End If
    End Sub

End Class
