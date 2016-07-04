Partial Class Solicitudes_CambioDiaPago
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_CambioDiaPagoError.Visible = False
        If Not IsPostBack Then
            Me.TXT_DiaActualPago.Text = Session("diapago")
            ObtieneDiasPago()
        End If
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click
        Try
            Dim DATADSSolicitaCambioDiaPagoPopUp As New Data.DataSet
            DATADSSolicitaCambioDiaPagoPopUp.Clear()
            Dim RutCliente, usuario, caja, tienda As Integer
            RutCliente = Session("rut")
            usuario = Session("usuario")
            tienda = Session("tienda")
            caja = Session("caja")
            Dim STRSolicitaCambioDiaPago As String = "execute procedure procw_mod_diapago  ('" & RutCliente & "','" & usuario & "','" & tienda & "','" & DDL_NuevoDiaPago.SelectedValue & "')"
            Dim DATASolicitaCambioDiaPago As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSolicitaCambioDiaPago, Globales.conn)
            DATASolicitaCambioDiaPago.Fill(DATADSSolicitaCambioDiaPagoPopUp, "PRUEBA")
            If DATADSSolicitaCambioDiaPagoPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_CambioDiaPagoError.Visible = True
                Me.LBL_CambioDiaPagoError.Text = DATADSSolicitaCambioDiaPagoPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_CambioDiaPagoError.Visible = True
                Me.LBL_CambioDiaPagoError.Text = "CAMBIO DE DIA DE PAGO CURSADO" ' mensaje de error
            End If
        Catch EX As Exception
        End Try
    End Sub
    Private Sub ObtieneDiasPago()
        Try
            Dim DATADSCambioDiaPagoPopUp As New Data.DataSet
            DATADSCambioDiaPagoPopUp.Clear()
            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Dim STRCambioDiaPago As String = "execute procedure procw_cons_diapago ('" & RutCliente & "' )"
            Dim DATACambioDiaPago As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRCambioDiaPago, Globales.conn)
            DATACambioDiaPago.Fill(DATADSCambioDiaPagoPopUp, "PRUEBA")
            If DATADSCambioDiaPagoPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_CambioDiaPagoError.Visible = True
                Me.LBL_CambioDiaPagoError.Text = DATADSCambioDiaPagoPopUp.Tables(0).Rows(0)(1) ' mensaje de error
                Me.DDL_NuevoDiaPago.Enabled = False
                Me.BTN_Grabar.Enabled = False
            Else
                Me.DDL_NuevoDiaPago.Enabled = True
                Me.BTN_Grabar.Enabled = True
                Me.DDL_NuevoDiaPago.DataTextField = DATADSCambioDiaPagoPopUp.Tables(0).Columns("column3").ToString()
                Me.DDL_NuevoDiaPago.DataValueField = DATADSCambioDiaPagoPopUp.Tables(0).Columns("column3").ToString()
                Me.DDL_NuevoDiaPago.DataSource = DATADSCambioDiaPagoPopUp.Tables(0)
                Me.DDL_NuevoDiaPago.DataBind()
            End If
        Catch EX As Exception
        End Try
    End Sub
End Class
