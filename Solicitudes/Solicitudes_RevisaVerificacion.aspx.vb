Partial Class Solicitudes_RevisaVerificacion
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_ConsultasDBError.Visible = False
        If Not IsPostBack Then
            ObtieneConsultasDataBusiness()
            HabilitaVerificacion()
        End If
    End Sub
    Private Sub HabilitaVerificacion()
        Dim DataDSLevantaRechazo As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            DataDSLevantaRechazo.Clear()
            Dim STRLevantaRechazo As String = "execute procedure procw_habi_verif ('" & RutCliente & "' )"
            Dim DATALevantaRechazo As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLevantaRechazo, Globales.conn)
            DATALevantaRechazo.Fill(DataDSLevantaRechazo, "PRUEBA")
            If DataDSLevantaRechazo.Tables(0).Rows(0)(0) = 1 Then
                Me.BTN_RevisionDataBusiness.Enabled = False   ''DESHABILITA BOTON 
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = DataDSLevantaRechazo.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.BTN_RevisionDataBusiness.Enabled = True
            End If
        Catch EX As Exception
            'Response.Write("<script>window.alert('Error al Obtener ConsultasDB');</script>")
        End Try
    End Sub
    Private Sub ObtieneConsultasDataBusiness()
        Dim DataDSConsultasDB As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            DataDSConsultasDB.Clear()
            Dim STRConsultasDB As String = "execute procedure procw_cons_db ('" & RutCliente & "' )"
            Dim DATAConsultasDB As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRConsultasDB, Globales.conn)
            DATAConsultasDB.Fill(DataDSConsultasDB, "PRUEBA")
            If DataDSConsultasDB.Tables(0).Rows(0)(0) = 1 Then
                Me.Panel_ConsultasDB.Visible = False
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = DataDSConsultasDB.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.Panel_ConsultasDB.Visible = True
                Me.LBL_ConsultasDBError.Visible = False
                Me.Grilla_ConsultasDB.DataSource = DataDSConsultasDB.Tables(0).DefaultView
                Me.Grilla_ConsultasDB.DataBind()
            End If
        Catch EX As Exception
            'Response.Write("<script>window.alert('Error al Obtener ConsultasDB');</script>")
        End Try
    End Sub
End Class
