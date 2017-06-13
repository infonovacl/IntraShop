Partial Class Consultas_GestionCobranza
    Inherits System.Web.UI.Page
    Sub CargaInicial()
        Dim DataDSFacturaciones As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            Dim STRFacturaciones As String = "execute procedure procw_fechas_eecc ('" & RutCliente & "')"
            Dim DATAFacturaciones As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRFacturaciones, Globales.conn)
            DATAFacturaciones.Fill(DataDSFacturaciones, "PRUEBA")
            If DataDSFacturaciones.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_FacturacionesError.Visible = True
                Me.LBL_FacturacionesError.Text = DataDSFacturaciones.Tables(0).Rows(0)(1) ' mensaje de error
                Me.BTN_VerEECC.Enabled = False
            Else
                Me.LBL_FacturacionesError.Visible = False
                Me.DDL_Facturaciones.DataTextField = DataDSFacturaciones.Tables(0).Columns("column3").ToString() '.Substring(0, length:=4)
                Me.DDL_Facturaciones.DataValueField = DataDSFacturaciones.Tables(0).Columns("column3").ToString() '.Substring(0, length:=4)
                Me.DDL_Facturaciones.DataSource = DataDSFacturaciones.Tables(0)
                Me.DDL_Facturaciones.DataBind()
                ' Me.DDL_Facturaciones.DataTextField.Substring(0, length:=4)
                ' Me.DDL_Facturaciones.DataValueField.Substring(0, length:=4)
            End If
        Catch EX As Exception
            Me.LBL_FacturacionesError.Visible = True
            Me.LBL_FacturacionesError.Text = EX.Message
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargaInicial()
        End If
    End Sub
    Protected Sub BTN_Cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_Cerrar.Click
        'Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
    End Sub
    Protected Sub BTN_VerEECC_Click(sender As Object, e As EventArgs) Handles BTN_VerEECC.Click
        ' Me.LBL_FechaEECC.Text = CType(Me.DDL_Facturaciones.SelectedItem.Text, Date).ToShortDateString
        Dim DataDSEECC As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            Dim STREECC As String = "execute procedure procw_imprime_eecc ('" & RutCliente & "','" & Me.DDL_Facturaciones.SelectedItem.Text & "')"
            Dim DATAEECC As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STREECC, Globales.conn)
            DATAEECC.Fill(DataDSEECC, "PRUEBA")
            If DataDSEECC.Tables(0).Rows(0)(0) = 1 Or DataDSEECC.Tables(0).Rows.Count = 0 Then
                Me.LBL_EECCError.Visible = True
                Me.LBL_EECCError.Text = DataDSEECC.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_EECCError.Visible = False
                Me.Grilla_TramaEECC.DataSource = DataDSEECC.Tables(0).DefaultView
                Me.Grilla_TramaEECC.DataBind()
                ' Me.DDL_Facturaciones.DataTextField.Substring(0, length:=4)
                ' Me.DDL_Facturaciones.DataValueField.Substring(0, length:=4)
            End If
        Catch EX As Exception
            Me.LBL_EECCError.Visible = True
            Me.LBL_EECCError.Text = EX.Message
        End Try
    End Sub
End Class
