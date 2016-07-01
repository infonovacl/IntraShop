Partial Class Solicitudes_CambioDiaPago
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_CambioDiaPagoError.Visible = False
        If IsPostBack = False Then
            ObtieneMiniCartola()
        End If
    End Sub
    Private Sub ObtieneMiniCartola()
        Try
            Dim DATADSSolicitaCambioDiaPagoPopUp As New Data.DataSet
            DATADSSolicitaCambioDiaPagoPopUp.Clear()
            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Dim STRSolicitaCambioDiaPago As String = "execute procedure procw_cons_saldo  ('" & RutCliente & "')"
            Dim DATASolicitaCambioDiaPago As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSolicitaCambioDiaPago, conn)
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
End Class
