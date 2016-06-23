Partial Class Solicitudes_Bloqueos
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_ListaBloqueosError.Visible = False
        If Not IsPostBack Then
            LlenaCheckBoxBloqueos()
            ObtieneConsultasDataBusiness()
            HabilitaBotones()
        End If
    End Sub
    Private Sub HabilitaBotones()
        Dim DataDSHabilitaBotones As New Data.DataSet
        Dim RutCliente As Integer
        Me.BTN_RevisionDataBusiness.Enabled = False
        Me.BTN_RevisionDataBusiness.Enabled = False
        RutCliente = Session("rut")
        Try
            DataDSHabilitaBotones.Clear()
            Dim STRHabilitaBotones As String = "execute procedure procw_habirech ('" & RutCliente & "' )"
            Dim DATAHabilitaBotones As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRHabilitaBotones, conn)
            DATAHabilitaBotones.Fill(DataDSHabilitaBotones, "PRUEBA")
            If DataDSHabilitaBotones.Tables(0).Rows(0)(0) = 1 Then
                Me.BTN_RevisionDataBusiness.Enabled = False
                Me.BTN_SolicitaDesbloqueo.Enabled = False
                Me.LBL_HabilitaBotonesError.Visible = True
                Me.LBL_HabilitaBotonesError.Text = DataDSHabilitaBotones.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                If DataDSHabilitaBotones.Tables(0).Rows(0)(3) = 1 Then
                    Me.BTN_RevisionDataBusiness.Enabled = True
                End If
                If DataDSHabilitaBotones.Tables(0).Rows(0)(4) = 1 Then
                    Me.BTN_SolicitaDesbloqueo.Enabled = True
                End If
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
            Dim DATAConsultasDB As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRConsultasDB, conn)
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
    Private Sub LlenaCheckBoxBloqueos()
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            Dim DATADSConsultaSubEstadoPopUp As New Data.DataSet
            DATADSConsultaSubEstadoPopUp.Clear()
            Dim STRConsultaSubEstado As String = "execute procedure procw_cons_subest ('" & RutCliente & "','4')"
            Dim DATAConsultaSubEstado As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRConsultaSubEstado, conn)
            DATAConsultaSubEstado.Fill(DATADSConsultaSubEstadoPopUp, "PRUEBA")
            If DATADSConsultaSubEstadoPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_ListaBloqueosError.Visible = True
                Me.LBL_ListaBloqueosError.Text = DATADSConsultaSubEstadoPopUp.Tables(0).Rows(0)(1) ' mensaje de error              
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
                    Me.CHBL_BloqueosCliente.Items.Add(item)
                Next
                Dim y As Integer
                For y = 0 To DATADSConsultaSubEstadoPopUp.Tables(0).Rows.Count - 1
                    If DATADSConsultaSubEstadoPopUp.Tables(0).Rows(y)(4).ToString = "S" Then
                        CHBL_BloqueosCliente.Items(y).Attributes.Add("style", "color: red;")
                    Else
                        CHBL_BloqueosCliente.Items(y).Attributes.Add("style", "color: blue;")
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BTN_SolicitaDesbloqueo_Click(sender As Object, e As EventArgs) Handles BTN_SolicitaDesbloqueo.Click
    End Sub
End Class
