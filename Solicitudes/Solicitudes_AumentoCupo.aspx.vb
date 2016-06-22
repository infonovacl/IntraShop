Partial Class Solicitudes_AumentoCupo
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_AumentoCupoError.Visible = False
        If Not IsPostBack Then
            ObtieneSolicitud()
        End If
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click
        Try
            Dim DATADSSolicitaAumentoCupoPopUp As New Data.DataSet
            DATADSSolicitaAumentoCupoPopUp.Clear()
            Dim RutCliente, usuario, caja, tienda As Integer
            RutCliente = Session("rut")
            usuario = Session("usuario")
            tienda = Session("tienda")
            caja = Session("caja")
            Dim STRSolicitaAumentoCupo As String = "execute procedure procw_solic_aumcupo  ('" & RutCliente & "','" & tienda & "','" & caja & "','" & Today.ToShortDateString & "','" & usuario & "')"
            Dim DATASolicitaAumentoCupo As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSolicitaAumentoCupo, conn)
            DATASolicitaAumentoCupo.Fill(DATADSSolicitaAumentoCupoPopUp, "PRUEBA")
            If DATADSSolicitaAumentoCupoPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_AumentoCupoError.Visible = True
                Me.LBL_AumentoCupoError.Text = DATADSSolicitaAumentoCupoPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_AumentoCupoError.Visible = True
                Me.LBL_AumentoCupoError.Text = "AUMENTO DE CUPO CURSADO" ' mensaje de error
            End If
        Catch EX As Exception
        End Try
    End Sub
    Private Sub ObtieneSolicitud()
        Try
            Dim DATADSAumentoCupoPopUp As New Data.DataSet
            DATADSAumentoCupoPopUp.Clear()

            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Dim STRAumentoCupo As String = "execute procedure procw_cons_aumcupo ('" & RutCliente & "' )"
            Dim DATAAumentoCupo As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRAumentoCupo, conn)
            DATAAumentoCupo.Fill(DATADSAumentoCupoPopUp, "PRUEBA")
            If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_AumentoCupoError.Visible = True
                Me.LBL_AumentoCupoError.Text = DATADSAumentoCupoPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_AumentoCupoError.Visible = False
                If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                    Me.LBL_FechaSolicitud.Text = ""
                Else
                    Me.LBL_FechaSolicitud.Text = DATADSAumentoCupoPopUp.Tables(0).Rows(0)(2)
                End If
                If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                    Me.LBL_HoraSolicitud.Text = ""
                Else
                    Me.LBL_HoraSolicitud.Text = DATADSAumentoCupoPopUp.Tables(0).Rows(0)(3)
                End If
                If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                    Me.LBL_MontoActualLineaCredito.Text = "0"
                Else
                    Me.LBL_MontoActualLineaCredito.Text = Format(CType(DATADSAumentoCupoPopUp.Tables(0).Rows(0)(4), Integer), "###,###,##0")
                End If
                If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                    Me.LBL_LineaCreditoSolicitada.Text = "0"
                Else
                    Me.LBL_LineaCreditoSolicitada.Text = Format(CType(DATADSAumentoCupoPopUp.Tables(0).Rows(0)(5), Integer), "###,###,##0")
                End If
                If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                    Me.LBL_EstadoEvaluacion.Text = ""
                Else
                    Me.LBL_EstadoEvaluacion.Text = DATADSAumentoCupoPopUp.Tables(0).Rows(0)(6)
                End If
            End If
        Catch EX As Exception
        End Try
    End Sub
End Class
