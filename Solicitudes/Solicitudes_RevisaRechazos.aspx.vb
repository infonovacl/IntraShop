Partial Class Solicitudes_RevisaRechazos
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_ListaRechazosError.Visible = False
        If Not IsPostBack Then
            LlenaCheckBoxRechazos()
            ObtieneConsultasDataBusiness()
            LevantaRechazo()
        End If
    End Sub
    Private Sub LevantaRechazo()
        Dim DataDSLevantaRechazo As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            DataDSLevantaRechazo.Clear()
            Dim STRLevantaRechazo As String = "execute procedure procw_habirech ('" & RutCliente & "' )"
            Dim DATALevantaRechazo As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLevantaRechazo, Globales.conn)
            DATALevantaRechazo.Fill(DataDSLevantaRechazo, "PRUEBA")
            If DataDSLevantaRechazo.Tables(0).Rows(0)(0) = 1 Then
                Me.BTN_RevisionDataBusiness.Enabled = False
                Me.LBL_LevantaRechazoError.Visible = True
                Me.LBL_LevantaRechazoError.Text = DataDSLevantaRechazo.Tables(0).Rows(0)(1) ' mensaje de error
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
    Private Sub LlenaCheckBoxRechazos()
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            Dim DATADSConsultaSubEstadoPopUp As New Data.DataSet
            DATADSConsultaSubEstadoPopUp.Clear()
            Dim STRConsultaSubEstado As String = "execute procedure procw_cons_subest ('" & RutCliente & "','3')"
            Dim DATAConsultaSubEstado As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRConsultaSubEstado, Globales.conn)
            DATAConsultaSubEstado.Fill(DATADSConsultaSubEstadoPopUp, "PRUEBA")
            If DATADSConsultaSubEstadoPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_ListaRechazosError.Visible = True
                Me.LBL_ListaRechazosError.Text = DATADSConsultaSubEstadoPopUp.Tables(0).Rows(0)(1) ' mensaje de error              
            Else
                Dim x As Integer
                For x = 0 To DATADSConsultaSubEstadoPopUp.Tables(0).Rows.Count - 1
                    Dim item As New ListItem()
                    item.Text = DATADSConsultaSubEstadoPopUp.Tables(0).Rows(x)(3)
                    item.Value = DATADSConsultaSubEstadoPopUp.Tables(0).Rows(x)(2)
                    If DATADSConsultaSubEstadoPopUp.Tables(0).Rows(x)(5) = 1 Then
                        item.Selected = True
                    Else
                        item.Selected = False
                    End If
                    If DATADSConsultaSubEstadoPopUp.Tables(0).Rows(x)(4).ToString = "S" Then
                        item.Enabled = True
                    Else
                        item.Enabled = False
                    End If
                    Me.CHBL_RechazosCliente.Items.Add(item)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
