Partial Class Consultas_BuscaXNombre
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Public rutbuscado As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Panel_BuscaXNOmbre.Visible = True
        Me.LBL_BuscarXNombreError.Visible = False
        Me.TXT_BuscaXNombre.Focus()
    End Sub
    Private Sub ObtieneNombres()
        Try
            Dim DATADSBuscaxNombrePopUp As New Data.DataSet
            DATADSBuscaxNombrePopUp.Clear()
            Me.Grilla_BuscaXNombre.DataSource = Nothing
            Me.Grilla_BuscaXNombre.DataBind()
            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Dim STRBuscaxNombre As String = "execute procedure procw_busca_nombre ('" & TXT_BuscaXNombre.Text & "' )"
            Dim DATABuscaxNombre As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRBuscaxNombre, conn)
            DATABuscaxNombre.Fill(DATADSBuscaxNombrePopUp, "PRUEBA")
            If DATADSBuscaxNombrePopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.Panel_BuscaXNombre.Visible = True
                Me.LBL_BuscarXNombreError.Visible = True
                Me.LBL_BuscarXNombreError.Text = DATADSBuscaxNombrePopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.Panel_BuscaXNombre.Visible = True
                Me.LBL_BuscarXNombreError.Visible = False
                Me.Grilla_BuscaXNombre.DataSource = DATADSBuscaxNombrePopUp.Tables(0).DefaultView
                Me.Grilla_BuscaXNombre.DataBind()
                Me.Grilla_BuscaXNombre.Columns(6).Visible = False
            End If
        Catch EX As Exception
        End Try
    End Sub
    Protected Sub Grilla_BuscaxNombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grilla_BuscaXNombre.SelectedIndexChanged
        Dim IndiceGrillaBuscaxNombre As Integer = 0
        Me.Grilla_BuscaXNombre.Columns(6).Visible = True
        Try
            IndiceGrillaBuscaxNombre = Me.Grilla_BuscaXNombre.SelectedIndex.ToString()
            Me.LBL_ClienteSeleccionado.Text = Me.Grilla_BuscaXNombre.Rows(IndiceGrillaBuscaxNombre).Cells(6).Text
            Session("rutbuscado") = Me.Grilla_BuscaXNombre.Rows(IndiceGrillaBuscaxNombre).Cells(1).Text
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
