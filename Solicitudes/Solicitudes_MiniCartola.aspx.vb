Partial Class Solicitudes_MiniCartola
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_MiniCartolaError.Visible = False
        If IsPostBack = False Then
            ObtieneMiniCartola()
        End If
    End Sub
    Private Sub ObtieneMiniCartola()
        Try
            Dim DATADSMiniCartolaPopUp As New Data.DataSet
            DATADSMiniCartolaPopUp.Clear()
            Dim RutCliente As Integer
            RutCliente = Session("rut")
            Dim STRMiniCartola As String = "execute procedure procw_cons_saldo  ('" & RutCliente & "')"
            Dim DATAMiniCartola As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRMiniCartola, conn)
            DATAMiniCartola.Fill(DATADSMiniCartolaPopUp, "PRUEBA")
            If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_MiniCartolaError.Visible = True
                Me.LBL_MiniCartolaError.Text = DATADSMiniCartolaPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_MiniCartolaError.Visible = True
                Me.LBL_MiniCartolaError.Text = "IMPRIMIENDO..." ' mensaje de error
                Me.LBL_Rut.Text = RutCliente
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                    Me.LBL_Dv.Text = ""
                Else
                    Me.LBL_Dv.Text = DATADSMiniCartolaPopUp.Tables(0).Rows(0)(2)
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                    Me.LBL_Nombre.Text = ""
                Else
                    Me.LBL_Nombre.Text = DATADSMiniCartolaPopUp.Tables(0).Rows(0)(3)
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                    Me.LBL_FechaEmision.Text = ""
                Else
                    Me.LBL_FechaEmision.Text = Trim(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(4))
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                    Me.LBL_CupoAprobado.Text = "0"
                Else
                    Me.LBL_CupoAprobado.Text = Format(CType(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(5), Integer), "###,###,##0")
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                    Me.LBL_Disponible.Text = "0"
                Else
                    Me.LBL_Disponible.Text = Format(CType(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(6), Integer), "###,###,##0")
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(7) Is System.DBNull.Value Then
                    Me.LBL_CargosMes.Text = "0"
                Else
                    Me.LBL_CargosMes.Text = Format(CType(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(7), Integer), "###,###,##0")
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(8) Is System.DBNull.Value Then
                    Me.LBL_MontoAtrasado.Text = "0"
                Else
                    Me.LBL_MontoAtrasado.Text = Format(CType(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(8), Integer), "###,###,##0")
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(9) Is System.DBNull.Value Then
                    Me.LBL_MontoCancelar.Text = "0"
                Else
                    Me.LBL_MontoCancelar.Text = Format(CType(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(9), Integer), "###,###,##0")
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(10) Is System.DBNull.Value Then
                    Me.LBL_FechaPago.Text = ""
                Else
                    Me.LBL_FechaPago.Text = Trim(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(10))
                End If
                '**********************************grilla cuotas
                Dim miDataTable As New Data.DataTable
                miDataTable.Columns.Add("fecha")
                miDataTable.Columns.Add("valor_cuota")
                For i = 0 To 10 Step 2
                    If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(11 + i) IsNot System.DBNull.Value Then
                        Dim dRow As Data.DataRow = miDataTable.NewRow()
                        dRow("fecha") = Trim(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(11 + i)) '21
                        dRow("valor_cuota") = Trim(DATADSMiniCartolaPopUp.Tables(0).Rows(0)(12 + i)) '22
                        miDataTable.Rows.Add(dRow)
                    Else
                    End If
                Next
                GrillaCuotas.DataSource = miDataTable
                GrillaCuotas.DataBind()
                Try
                    If Me.GrillaCuotas.Rows(0).Cells(0).Text IsNot System.DBNull.Value Then
                        Me.LBL_FechaVenc1.Text = Me.GrillaCuotas.Rows(0).Cells(0).Text
                        Me.LBL_MontoVenc1.Text = Format(CType(Me.GrillaCuotas.Rows(0).Cells(1).Text, Integer), "###,###,##0")
                    End If
                    If Me.GrillaCuotas.Rows(1).Cells(0).Text IsNot System.DBNull.Value Then
                        Me.LBL_FechaVenc2.Text = Me.GrillaCuotas.Rows(1).Cells(0).Text
                        Me.LBL_MontoVenc2.Text = Format(CType(Me.GrillaCuotas.Rows(1).Cells(1).Text, Integer), "###,###,##0")
                    End If
                    If Me.GrillaCuotas.Rows(2).Cells(0).Text IsNot System.DBNull.Value Then
                        Me.LBL_FechaVenc3.Text = Me.GrillaCuotas.Rows(2).Cells(0).Text
                        Me.LBL_MontoVenc3.Text = Format(CType(Me.GrillaCuotas.Rows(2).Cells(1).Text, Integer), "###,###,##0")
                    End If
                    If Me.GrillaCuotas.Rows(3).Cells(0).Text IsNot System.DBNull.Value Then
                        Me.LBL_FechaVenc4.Text = Me.GrillaCuotas.Rows(3).Cells(0).Text
                        Me.LBL_MontoVenc4.Text = Format(CType(Me.GrillaCuotas.Rows(3).Cells(1).Text, Integer), "###,###,##0")
                    End If
                    If Me.GrillaCuotas.Rows(4).Cells(0).Text IsNot System.DBNull.Value Then
                        Me.LBL_FechaVenc5.Text = Me.GrillaCuotas.Rows(4).Cells(0).Text
                        Me.LBL_MontoVenc5.Text = Format(CType(Me.GrillaCuotas.Rows(4).Cells(1).Text, Integer), "###,###,##0")
                    End If
                    If Me.GrillaCuotas.Rows(5).Cells(0).Text IsNot System.DBNull.Value Then
                        Me.LBL_FechaVenc6.Text = Me.GrillaCuotas.Rows(5).Cells(0).Text
                        Me.LBL_MontoVenc6.Text = Format(CType(Me.GrillaCuotas.Rows(5).Cells(1).Text, Integer), "###,###,##0")
                    End If

                    'Me.LBL_FechaVenc1.Text = Me.GrillaCuotas.Rows(0).Cells(0).Text
                    'Me.LBL_FechaVenc2.Text = Me.GrillaCuotas.Rows(1).Cells(0).Text
                    'Me.LBL_FechaVenc3.Text = Me.GrillaCuotas.Rows(2).Cells(0).Text
                    'Me.LBL_FechaVenc4.Text = Me.GrillaCuotas.Rows(3).Cells(0).Text
                    'Me.LBL_FechaVenc5.Text = Me.GrillaCuotas.Rows(4).Cells(0).Text
                    'Me.LBL_FechaVenc6.Text = Me.GrillaCuotas.Rows(5).Cells(0).Text
                    'Me.LBL_MontoVenc1.Text = Me.GrillaCuotas.Rows(0).Cells(1).Text
                    'Me.LBL_MontoVenc2.Text = Me.GrillaCuotas.Rows(1).Cells(1).Text
                    'Me.LBL_MontoVenc3.Text = Me.GrillaCuotas.Rows(2).Cells(1).Text
                    'Me.LBL_MontoVenc4.Text = Me.GrillaCuotas.Rows(3).Cells(1).Text
                    'Me.LBL_MontoVenc5.Text = Me.GrillaCuotas.Rows(4).Cells(1).Text
                    'Me.LBL_MontoVenc6.Text = Me.GrillaCuotas.Rows(5).Cells(1).Text
                Catch ex As Exception
                End Try
            End If
        Catch EX As Exception
            MsgBox(EX)
        End Try
    End Sub
End Class
