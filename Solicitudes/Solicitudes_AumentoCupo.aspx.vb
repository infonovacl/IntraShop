Partial Class Solicitudes_AumentoCupo
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_AumentoCupoError.Visible = False
        If Not IsPostBack Then
            ObtieneSolicitud()
        End If
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click
        If Me.TXT_LineaCreditoSolicitada.Text <> "" And IsNumeric(Me.TXT_LineaCreditoSolicitada.Text) = True Then
            If CType(Me.TXT_LineaCreditoSolicitada.Text, Integer) > CType(Me.LBL_MontoActualLineaCredito.Text, Integer) Then
                Try
                    Dim DATADSSolicitaAumentoCupoPopUp As New Data.DataSet
                    DATADSSolicitaAumentoCupoPopUp.Clear()
                    Dim RutCliente, usuario, caja, tienda As Integer
                    RutCliente = Session("rut")
                    usuario = Session("usuario")
                    tienda = Session("tienda")
                    caja = Session("caja")
                    Dim STRSolicitaAumentoCupo As String = "execute procedure procw_solic_aumcupo  ('" & RutCliente & "','" & tienda & "','" & caja & "','" & Today.ToShortDateString & "','" & usuario & "')"
                    Dim DATASolicitaAumentoCupo As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSolicitaAumentoCupo, Globales.conn)
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
            Else
                Me.LBL_AumentoCupoError.Visible = True
                Me.LBL_AumentoCupoError.Text = "LINEA DE CREDITO SOLICITADA ES MENOR O IGUAL A LA ACTUAL" ' mensaje de error
                Me.TXT_LineaCreditoSolicitada.Focus()
            End If
        Else
            Me.LBL_AumentoCupoError.Visible = True
            Me.LBL_AumentoCupoError.Text = "LINEA DE CREDITO SOLICITADA NO VALIDA" ' mensaje de error
            Me.TXT_LineaCreditoSolicitada.Focus()
        End If
    End Sub
    Private Sub ObtieneSolicitud()
        Try
            Dim DATADSAumentoCupoPopUp As New Data.DataSet
            DATADSAumentoCupoPopUp.Clear()
            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Dim STRAumentoCupo As String = "execute procedure procw_cons_aumcupo ('" & RutCliente & "' )"
            Dim DATAAumentoCupo As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRAumentoCupo, Globales.conn)
            DATAAumentoCupo.Fill(DATADSAumentoCupoPopUp, "PRUEBA")
            If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.BTN_Grabar.Enabled = False
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
                    Me.LBL_HoraSolicitud.Text = Format(DATADSAumentoCupoPopUp.Tables(0).Rows(0)(3), "HH:mm:ss")
                End If
                If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                    Me.LBL_MontoActualLineaCredito.Text = "0"
                Else
                    Me.LBL_MontoActualLineaCredito.Text = Format(CType(DATADSAumentoCupoPopUp.Tables(0).Rows(0)(4), Integer), "###,###,##0")
                End If
                If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                    Me.TXT_LineaCreditoSolicitada.Text = ""
                Else
                    Me.TXT_LineaCreditoSolicitada.Text = Format(CType(DATADSAumentoCupoPopUp.Tables(0).Rows(0)(5), Integer), "###,###,##0")
                End If
                If DATADSAumentoCupoPopUp.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                    Me.LBL_EstadoEvaluacion.Text = ""
                Else
                    Me.LBL_EstadoEvaluacion.Text = DATADSAumentoCupoPopUp.Tables(0).Rows(0)(6)
                End If
            End If
            Me.TXT_LineaCreditoSolicitada.Focus()
        Catch EX As Exception
        End Try
    End Sub
End Class
