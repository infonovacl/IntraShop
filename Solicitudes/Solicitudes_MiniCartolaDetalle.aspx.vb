Imports System.windows.forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Partial Class Solicitudes_MiniCartolaDetalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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
            Dim STRMiniCartola As String = "execute procedure procw_cons_saldo ('" & RutCliente & "')"
            Dim DATAMiniCartola As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRMiniCartola, Globales.conn)
            DATAMiniCartola.Fill(DATADSMiniCartolaPopUp, "PRUEBA")
            If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_MiniCartolaError.Visible = True
                Me.LBL_MiniCartolaError.Text = DATADSMiniCartolaPopUp.Tables(0).Rows(0)(1) ' mensaje de error
                Me.BTN_Cerrar.Visible = True
            Else
                Me.BTN_Cerrar.Visible = False
                Me.LBL_MiniCartolaError.Visible = True
                Me.LBL_MiniCartolaError.Text = ""
                Me.LBL_Rut.Text = RutCliente
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                    Me.LBL_Dv.Text = ""
                Else
                    Me.LBL_Dv.Text = DATADSMiniCartolaPopUp.Tables(0).Rows(0)(2)
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(23) Is System.DBNull.Value Then
                    Me.LBL_NombreS.Text = ""
                Else
                    Me.LBL_NombreS.Text = DATADSMiniCartolaPopUp.Tables(0).Rows(0)(23).ToString.ToUpper
                End If

                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(24) Is System.DBNull.Value Then
                    Me.LBL_ApellidoP.Text = ""
                Else
                    Me.LBL_ApellidoP.Text = DATADSMiniCartolaPopUp.Tables(0).Rows(0)(24).ToString.ToUpper
                End If
                If DATADSMiniCartolaPopUp.Tables(0).Rows(0)(25) Is System.DBNull.Value Then
                    Me.LBL_ApellidoM.Text = ""
                Else
                    Me.LBL_ApellidoM.Text = DATADSMiniCartolaPopUp.Tables(0).Rows(0)(25).ToString.ToUpper
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
                Catch ex As Exception
                End Try
                '******************** grilla transacciones estado de cuenta  *************************

                Dim DataDSTrx As New Data.DataSet
                Try
                    DataDSTrx.Clear()
                    Dim STRTrx As String = "execute procedure procw_detalle_cartola ('" & RutCliente & "', '" & Me.LBL_FechaPago.Text & "' )"
                    Dim DATATrx As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRTrx, Globales.conn)
                    DATATrx.Fill(DataDSTrx, "PRUEBA")
                    If DataDSTrx.Tables(0).Rows.Count = 0 Then
                        ' Me.LBL_MiniCartolaError.Visible = True
                        'Me.LBL_MiniCartolaError.Text = "Sin detalle"
                    Else
                        'Me.LBL_MiniCartolaError.Text = DataDSTrx.Tables(0).Rows.Count
                        Me.GrillaTrx.DataSource = DataDSTrx.Tables(0).DefaultView
                        Me.GrillaTrx.DataBind()
                        Me.GrillaTrx.Visible = True
                    End If
                Catch EX0 As Exception
                    Me.LBL_MiniCartolaError.Visible = True
                    Me.LBL_MiniCartolaError.Text = EX0.Message
                End Try

                '*************************************************************************************
                'Response.Write("<script>printDiv();</script>")
                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyKey", "printDiv();", True)
                '  Dim PrintDialog1 As New PrintDialog()
                '  Dim HojaImpresion As New PrintDocument()
                '  AddHandler HojaImpresion.PrintPage, AddressOf Me.HojaImpresion_PrintPage
                ' HojaImpresion.DefaultPageSettings.PrinterSettings = PrintDialog1.PrinterSettings
               
                'PrintDialog1.Document = HojaImpresion
                ' If PrintDialog1.ShowDialog = DialogResult.OK Then
                ' HojaImpresion.Print()
                'End If
                Response.Write("<script>window.print();window.onfocus=function(){ window.close();}</script>")
            End If

        Catch EX As Exception
            Me.LBL_MiniCartolaError.Visible = True
            Me.LBL_MiniCartolaError.Text = EX.Message
        End Try
    End Sub
    Protected Sub BTN_Cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_Cerrar.Click
        ' Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
    End Sub
    '    Private Sub HojaImpresion_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles HojaImpresion.PrintPage
    Private Sub HojaImpresion_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            ' la posición superior

            'imprimimos la fecha y hora
            prFont = New Font("Arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(Date.Now.ToShortDateString.ToString & " " & _
                                Date.Now.ToShortTimeString.ToString, prFont, Brushes.Black, 1, 3)

            'imprimimos el nombre del cliente
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString("Nombre del Cliente", prFont, Brushes.Black, 5, 5)
            'indicamos que hemos llegado al final de la pagina
            e.HasMorePages = False
        Catch ex As Exception
            'Me.LBL_MiniCartolaError.Text = ex.Message
        End Try


    End Sub

End Class
