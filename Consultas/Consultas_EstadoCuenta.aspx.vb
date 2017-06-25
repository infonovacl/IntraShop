Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Drawing.Layout
Imports PdfSharp.Pdf.IO
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
                Me.LBL_FacturacionesError.Visible = True
                Me.LBL_FacturacionesError.Text = DataDSEECC.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_FacturacionesError.Visible = False
                Me.Grilla_TramaEECC.DataSource = DataDSEECC.Tables(0).DefaultView
                Me.Grilla_TramaEECC.DataBind()
                GeneraPDFEECC()
                MuestraPDF()
            End If
        Catch EX As Exception
            Me.Literal1.Visible = False
            Me.LBL_FacturacionesError.Visible = True
            Me.LBL_FacturacionesError.Text = EX.Message
        End Try
    End Sub
    Private Sub MuestraPDF()
        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""670px"" height=""420px"">"
        embed += "Si no puede ver el archivo, ud. puede descargar desde <a href = ""{0}"">Acá</a>"
        embed += " o descargar desde <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> para ver el archivo."
        embed += "</object>"
        Try
            Dim File As String = HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_" & Session("rut") & "_" & Session("dv") & "_" & DDL_Facturaciones.SelectedItem.Text & ".pdf")
            If (System.IO.File.Exists(File)) Then
                Me.Literal1.Text = String.Format(embed, ResolveUrl("~/Doc/EECC/eecc_" & Session("rut") & "_" & Session("dv") & "_" & DDL_Facturaciones.SelectedItem.Text & ".pdf"))
            Else
                LBL_VerPDFError.Text = "ERROR CARGANDO ARCHIVO PDF : ARCHIVO NO EXISTE"
            End If
        Catch ex As Exception
            LBL_VerPDFError.Text = "ERROR CARGANDO ARCHIVO PDF"
        End Try
    End Sub
    Private Sub GeneraPDFEECC()
        'Session("rut") = Me.TXT_ConsultaRutCliente.Text '**********************Variables session
        'Session("dv") = Me.TXT_ConsultaDV.Text
        'Session("nombrecliente") = Me.TXT_ConsultaNombreCompleto.Text
        Me.Literal1.Visible = True
        Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_template.pdf") ' PDF fuente      
        Dim PDFDoc As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_original, PdfDocumentOpenMode.Import)
        Dim PDFNewDoc As PdfSharp.Pdf.PdfDocument = New PdfSharp.Pdf.PdfDocument() 'PDF destino con datos y firma de cliente 
        Dim Pg As Integer       'copio pdf original y lo guardo con otro nombre 
        For Pg = 0 To PDFDoc.Pages.Count - 1
            PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
        Next
        PDFNewDoc.Save(HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_" & Session("rut") & "_" & Session("dv") & "_" & DDL_Facturaciones.SelectedItem.Text & ".pdf"))

        Dim FormatoDerecha As New XStringFormat
        FormatoDerecha.Alignment = XStringAlignment.Far
        FormatoDerecha.LineAlignment = XLineAlignment.Center

        Dim mayor_vencimiento, mayor_pago As Integer

        Dim ruta_pdf_cliente As String = HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_" & Session("rut") & "_" & Session("dv") & "_" & DDL_Facturaciones.SelectedItem.Text & ".pdf") ' PDF destino 
        Dim PDFDoc2 As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_cliente, PdfDocumentOpenMode.Modify)
        Dim pp As PdfSharp.Pdf.PdfPage = PDFDoc2.Pages(0) '= PDFNewDoc.AddPage(PDFDoc.Pages(0))
        Dim gfx As XGraphics = XGraphics.FromPdfPage(pp)
        Dim font As XFont = New XFont("Tahoma", 7, XFontStyle.Regular)
        Dim font_grande As XFont = New XFont("Tahoma", 18, XFontStyle.Regular)
        Dim L As Integer
        For L = 0 To Grilla_TramaEECC.Rows.Count - 1
            If Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(0, 2) = "E1" Then
                Me.Grilla_TramaEECC.Rows(L).Cells(0).Text = Trim(Me.Grilla_TramaEECC.Rows(L).Cells(0).Text).Replace(" ", "0")
                Try
                    Dim rut As String = Session("rut")
                    Dim dv As String = Session("dv")
                    Dim nombres As String = Session("nombrecliente")
                    Dim fecha_pago As String = DDL_Facturaciones.SelectedItem.Text
                    ConvierteStringAFecha(fecha_pago)
                    gfx.DrawString(Trim(nombres), font, XBrushes.Black, New XVector(180, 50))
                    gfx.DrawString(Trim(rut) & "-" & Trim(dv), font, XBrushes.Black, New XVector(180, 62))
                    gfx.DrawString(Trim(fecha_pago), font, XBrushes.Black, New XVector(180, 75))

                    Dim cupo_aprobado As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(10, 9) '228
                    Dim cupo_utilizado As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(19, 9) '237
                    Dim cupo_disponible As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(28, 9) '246
                    gfx.DrawString(Trim(Format(cupo_aprobado, "###,#0")), font, XBrushes.Black, New XRect(105, 108, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(cupo_utilizado, "###,#0")), font, XBrushes.Black, New XRect(195, 108, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(cupo_disponible, "###,#0")), font, XBrushes.Black, New XRect(285, 108, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto

                    Dim cupo_aprobado_avance As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(37, 9)
                    Dim cupo_utilizado_avance As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(46, 9)
                    Dim cupo_disponible_avance As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(55, 9)
                    gfx.DrawString(Trim(Format(cupo_aprobado_avance, "###,#0")), font, XBrushes.Black, New XRect(105, 120, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(cupo_utilizado_avance, "###,#0")), font, XBrushes.Black, New XRect(195, 120, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(cupo_disponible_avance, "###,#0")), font, XBrushes.Black, New XRect(285, 120, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    Dim cae_prepago As Decimal = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(73, 9)
                    gfx.DrawString(Trim(Format(cae_prepago, "###,##0") & "%").Replace(".", ","), font_grande, XBrushes.Black, New XRect(440, 115, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto

                    Dim tasa_interes_cuotas As Decimal = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(82, 9)
                    Dim tasa_interes_avance As Decimal = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(91, 9)
                    Dim cae_cuotas As Decimal = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(100, 9)
                    Dim cae_avance As Decimal = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(109, 9)
                    gfx.DrawString(Trim(Format(tasa_interes_cuotas, "###,##0") & "%").Replace(".", ","), font, XBrushes.Black, New XRect(115, 153, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(tasa_interes_avance, "###,##0") & "%").Replace(".", ","), font, XBrushes.Black, New XRect(245, 153, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(cae_cuotas, "###,##0") & "%").Replace(".", ","), font, XBrushes.Black, New XRect(115, 165, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(cae_avance, "###,##0") & "%").Replace(".", ","), font, XBrushes.Black, New XRect(245, 165, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto

                    Dim fecha_fact_desde As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(118, 8)
                    ConvierteStringAFecha(fecha_fact_desde)
                    Dim fecha_fact_hasta As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(126, 8)
                    ConvierteStringAFecha(fecha_fact_hasta)
                    Dim fecha_fact_desde_ant As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(134, 8)
                    ConvierteStringAFecha(fecha_fact_desde_ant)
                    Dim fecha_fact_hasta_ant As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(142, 8)
                    ConvierteStringAFecha(fecha_fact_hasta_ant)
                    gfx.DrawString(Trim(fecha_fact_desde), font, XBrushes.Black, New XVector(475, 162))
                    gfx.DrawString(Trim(fecha_fact_hasta), font, XBrushes.Black, New XVector(530, 162))
                    gfx.DrawString(Trim(fecha_fact_desde_ant), font, XBrushes.Black, New XVector(170, 223))
                    gfx.DrawString(Trim(fecha_fact_hasta_ant), font, XBrushes.Black, New XVector(290, 223))

                    Dim saldo_adeudado_periodo_ant As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(150, 9)
                    Dim monto_facturado_periodo_ant As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(159, 9)
                    Dim monto_pagado_periodo_ant As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(168, 9)
                    Dim saldo_adeudado_final_periodo_ant As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(177, 9)
                    gfx.DrawString(Trim(Format(saldo_adeudado_periodo_ant, "###,#0")), font, XBrushes.Black, New XRect(285, 232, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(monto_facturado_periodo_ant, "###,#0")), font, XBrushes.Black, New XRect(285, 244, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(monto_pagado_periodo_ant, "###,#0")), font, XBrushes.Black, New XRect(285, 257, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(saldo_adeudado_final_periodo_ant, "###,#0")), font, XBrushes.Black, New XRect(285, 269, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto

                    Dim costo_prepago As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(186, 9)
                    Dim pago_minimo As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(195, 9)
                    Dim a_cancelar As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(204, 9)
                    gfx.DrawString(Trim(Format(costo_prepago, "###,#0")), font, XBrushes.Black, New XRect(190, 587, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(pago_minimo, "###,#0")), font, XBrushes.Black, New XRect(190, 600, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(a_cancelar, "###,#0")), font, XBrushes.Black, New XRect(190, 612, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto

                    'Dim fecha_vecto1 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(214, 8)
                    'ConvierteStringAFecha(fecha_vecto1)
                    Dim monto_vecto1 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(221, 9)
                    Dim fecha_vecto2 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(230, 8)
                    ConvierteStringAFecha(fecha_vecto2)
                    Dim monto_vecto2 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(238, 9)
                    Dim fecha_vecto3 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(247, 8)
                    ConvierteStringAFecha(fecha_vecto3)
                    Dim monto_vecto3 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(255, 9)
                    Dim fecha_vecto4 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(264, 8)
                    ConvierteStringAFecha(fecha_vecto4)
                    Dim monto_vecto4 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(272, 9)
                    Dim fecha_vecto5 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(281, 8)
                    ConvierteStringAFecha(fecha_vecto5)
                    Dim monto_vecto5 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(289, 9)
                    If monto_vecto1 > 0 Then
                        gfx.DrawString(Trim(Format(monto_vecto1, "###,#0")), font, XBrushes.Black, New XRect(0, 653, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    End If
                    If monto_vecto2 > 0 Then
                        gfx.DrawString(Trim(fecha_vecto2), font, XBrushes.Black, New XVector(100, 648))
                        gfx.DrawString(Trim(Format(monto_vecto2, "###,#0")), font, XBrushes.Black, New XRect(57, 653, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    End If
                    If monto_vecto3 > 0 Then
                        gfx.DrawString(Trim(fecha_vecto3), font, XBrushes.Black, New XVector(160, 648))
                        gfx.DrawString(Trim(Format(monto_vecto3, "###,#0")), font, XBrushes.Black, New XRect(122, 653, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    End If
                    If monto_vecto4 > 0 Then
                        gfx.DrawString(Trim(fecha_vecto4), font, XBrushes.Black, New XVector(225, 648))
                        gfx.DrawString(Trim(Format(monto_vecto4, "###,#0")), font, XBrushes.Black, New XRect(187, 653, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    End If
                    If monto_vecto5 > 0 Then
                        gfx.DrawString(Trim(fecha_vecto5), font, XBrushes.Black, New XVector(290, 648))
                        gfx.DrawString(Trim(Format(monto_vecto5, "###,#0")), font, XBrushes.Black, New XRect(252, 653, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    End If

                    Dim fecha_proxima_fact_desde As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(298, 8)
                    ConvierteStringAFecha(fecha_proxima_fact_desde)
                    Dim fecha_proxima_fact_hasta As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(306, 8)
                    ConvierteStringAFecha(fecha_proxima_fact_hasta)
                    Dim interes_moratorio As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(314, 9)
                    Dim gastos_cobranza As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(323, 9)
                    gfx.DrawString(Trim(fecha_proxima_fact_desde), font, XBrushes.Black, New XVector(160, 690))
                    gfx.DrawString(Trim(fecha_proxima_fact_hasta), font, XBrushes.Black, New XVector(225, 690))
                    gfx.DrawString(Trim(Format(interes_moratorio, "###,#0")), font, XBrushes.Black, New XRect(253, 713, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(gastos_cobranza, "###,#0")), font, XBrushes.Black, New XRect(253, 725, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto               
                Catch ex As Exception
                    Me.LBL_FacturacionesError.Visible = True
                    Me.LBL_FacturacionesError.Text = "ERROR EN DATOS DE CABECERA Y PIE"
                End Try
                '******************************GRAFICO********************************
                mayor_vencimiento = 0
                mayor_pago = 0
                Try
                    Dim monto_fact1 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(340, 9)
                    mayor_vencimiento = monto_fact1
                    Dim monto_fact2 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(366, 9)
                    If monto_fact2 > mayor_vencimiento Then
                        mayor_vencimiento = monto_fact2
                    End If
                    Dim monto_fact3 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(392, 9)
                    If monto_fact3 > mayor_vencimiento Then
                        mayor_vencimiento = monto_fact3
                    End If
                    Dim monto_fact4 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(418, 9)
                    If monto_fact4 > mayor_vencimiento Then
                        mayor_vencimiento = monto_fact4
                    End If
                    Dim monto_fact5 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(444, 9)
                    If monto_fact5 > mayor_vencimiento Then
                        mayor_vencimiento = monto_fact5
                    End If
                    Dim monto_pag1 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(349, 9)
                    mayor_pago = monto_pag1
                    Dim monto_pag2 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(375, 9)
                    If monto_pag2 > mayor_pago Then
                        mayor_pago = monto_pag2
                    End If
                    Dim monto_pag3 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(401, 9)
                    If monto_pag3 > mayor_pago Then
                        mayor_pago = monto_pag3
                    End If
                    Dim monto_pag4 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(427, 9)
                    If monto_pag4 > mayor_pago Then
                        mayor_pago = monto_pag4
                    End If
                    Dim monto_pag5 As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(444, 9)
                    If monto_pag5 > mayor_pago Then
                        mayor_pago = monto_pag5
                    End If
                    Dim valor_tramo As Integer
                    If mayor_vencimiento > mayor_pago Then
                        valor_tramo = (mayor_vencimiento / 4)
                    Else
                        valor_tramo = (mayor_pago / 4)
                    End If
                    'valor_tramo = Math.Round((valor_tramo / 1000) + 1) * 1000
                    gfx.DrawString(Trim(Format(valor_tramo, "###,#0")), font, XBrushes.Gray, New XRect(305, 670, 80, 10), FormatoDerecha)     'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(valor_tramo * 2, "###,#0")), font, XBrushes.Gray, New XRect(305, 649, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(valor_tramo * 3, "###,#0")), font, XBrushes.Gray, New XRect(305, 629, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(valor_tramo * 4, "###,#0")), font, XBrushes.Gray, New XRect(305, 608, 80, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    'Dim graf_Facturado_1 As New XRect(395, 613, 10, 80)     'izquierda,abajo,ancho,alto '695 ES EL PISO - 613 ES EL TECHO = DIF 82
                    'gfx.DrawRectangle(XBrushes.LightGray, graf_Facturado_1) 'fijo     , var ,fijo ,var
                    'Dim graf_Pagado_1 As New XRect(405, 695, 10, 70)        'izquierda,abajo,ancho,alto
                    'gfx.DrawRectangle(XBrushes.Black, graf_Pagado_1)
                    '*******************
                    ' 100% = 82 alto
                    ' monto_fact  = x
                    Dim porcentaje As Integer
                    Dim porcentaje_columna As Integer
                    '*********************************************************
                    Try
                        If monto_fact1 > 0 Then
                            porcentaje = (monto_fact1 / (valor_tramo * 4)) * 100 ' ((50260/ (45458*4))*100=27,64% --> 28%
                            porcentaje_columna = 82 * (porcentaje / 100) '82 * (28/100) =22,96 % -->  23%
                            Dim graf_Facturado_1 As New XRect(395, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.LightGray, graf_Facturado_1)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If monto_pag1 > 0 Then
                            porcentaje = (monto_pag1 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Pagado_1 As New XRect(405, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.Black, graf_Pagado_1)
                        End If
                    Catch ex As Exception
                    End Try
                    '*********************************************************
                    Try
                        If monto_fact2 > 0 Then
                            porcentaje = (monto_fact2 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Facturado_2 As New XRect(435, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.LightGray, graf_Facturado_2)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If monto_pag2 > 0 Then
                            porcentaje = (monto_pag2 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Pagado_2 As New XRect(445, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.Black, graf_Pagado_2)
                        End If
                    Catch ex As Exception
                    End Try
                    '*********************************************************
                    Try
                        If monto_fact3 > 0 Then
                            porcentaje = (monto_fact3 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Facturado_3 As New XRect(470, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.LightGray, graf_Facturado_3)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If monto_pag3 > 0 Then
                            porcentaje = (monto_pag3 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Pagado_3 As New XRect(480, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.Black, graf_Pagado_3)
                        End If
                    Catch ex As Exception
                    End Try
                    '**********************************************************
                    Try
                        If monto_fact4 > 0 Then
                            porcentaje = (monto_fact4 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Facturado_4 As New XRect(505, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.LightGray, graf_Facturado_4)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If monto_pag4 > 0 Then
                            porcentaje = (monto_pag4 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Pagado_4 As New XRect(515, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.Black, graf_Pagado_4)
                        End If
                    Catch ex As Exception
                    End Try
                    '**********************************************************
                    Try
                        If monto_fact5 > 0 Then
                            porcentaje = (monto_fact5 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Facturado_5 As New XRect(547, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.LightGray, graf_Facturado_5)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If monto_pag5 > 0 Then
                            porcentaje = (monto_pag5 / (valor_tramo * 4)) * 100
                            porcentaje_columna = 82 * (porcentaje / 100)
                            Dim graf_Pagado_5 As New XRect(557, 613 + (82 - porcentaje_columna), 10, 80.7 - (82 - porcentaje_columna))
                            gfx.DrawRectangle(XBrushes.Black, graf_Pagado_5)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        Dim graf_fecha1 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(332, 8)
                        Dim fecha1 As Date = ConvierteStringAFecha(graf_fecha1)
                        If Trim(Format(fecha1, "MMM-yy")) <> "ene-01" Then
                            gfx.DrawString(Trim(Format(fecha1, "MMM-yy")), font, XBrushes.Black, New XVector(397, 705))
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        Dim graf_fecha2 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(358, 8)
                        Dim fecha2 As Date = ConvierteStringAFecha(graf_fecha2)
                        If Trim(Format(fecha2, "MMM-yy")) <> "ene-01" Then
                            gfx.DrawString(Trim(Format(fecha2, "MMM-yy")), font, XBrushes.Black, New XVector(434, 705))
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        Dim graf_fecha3 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(384, 8)
                        Dim fecha3 As Date = ConvierteStringAFecha(graf_fecha3)
                        If Trim(Format(fecha3, "MMM-yy")) <> "ene-01" Then
                            gfx.DrawString(Trim(Format(fecha3, "MMM-yy")), font, XBrushes.Black, New XVector(471, 705))
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        Dim graf_fecha4 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(410, 8)
                        Dim fecha4 As Date = ConvierteStringAFecha(graf_fecha4)
                        If Trim(Format(fecha4, "MMM-yy")) <> "ene-01" Then
                            gfx.DrawString(Trim(Format(fecha4, "MMM-yy")), font, XBrushes.Black, New XVector(508, 705))
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        Dim graf_fecha5 As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(436, 8)
                        Dim fecha5 As Date = ConvierteStringAFecha(graf_fecha5)
                        If Trim(Format(fecha5, "MMM-yy")) <> "ene-01" Then
                            gfx.DrawString(Trim(Format(fecha5, "MMM-yy")), font, XBrushes.Black, New XVector(545, 705))
                        End If
                    Catch ex As Exception
                    End Try
                Catch ex As Exception
                    Me.LBL_FacturacionesError.Visible = True
                    Me.LBL_FacturacionesError.Text = "ERROR EN DATOS DE GRAFICO"
                End Try
            End If
        Next
        Try
            '**************************D1
            Dim L_D1 As Integer = 0
            For L = 0 To Grilla_TramaEECC.Rows.Count - 1
                If Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(0, 2) = "D1" Then
                    Dim sucursal As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(20, 35)
                    Dim fecha_trans As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(55, 8)
                    ConvierteStringAFecha(fecha_trans)
                    Dim monto_operacion As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(72, 9)
                    Dim monto_total_a_pagar As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(81, 9)
                    Dim descripcion As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(90, 40)
                    Dim numero_cuota As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(130, 3)
                    Dim total_cuotas As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(133, 3)
                    Dim monto_cuota As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(136, 9)

                    gfx.DrawString(Trim(sucursal), font, XBrushes.Black, New XVector(32, 321 + L_D1))
                    gfx.DrawString(Trim(fecha_trans), font, XBrushes.Black, New XVector(115, 321 + L_D1))
                    gfx.DrawString(Trim(descripcion), font, XBrushes.Black, New XVector(173, 321 + L_D1))
                    gfx.DrawString(Trim(Format(monto_operacion, "###,#0")), font, XBrushes.Black, New XRect(313, 313 + L_D1, 40, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(monto_total_a_pagar, "###,#0")), font, XBrushes.Black, New XRect(355, 313 + L_D1, 62, 10), FormatoDerecha)
                    gfx.DrawString(Trim(numero_cuota & " / " & total_cuotas), font, XBrushes.Black, New XVector(450, 321 + L_D1))
                    gfx.DrawString(Trim(Format(monto_cuota, "###,#0")), font, XBrushes.Black, New XRect(505, 313 + L_D1, 75, 10), FormatoDerecha)
                    L_D1 = L_D1 + 8 ' SIGUIENTE LINEA
                End If
            Next
            '**************************D2
            Dim L_D2 As Integer = 0
            For L = 0 To Grilla_TramaEECC.Rows.Count - 1
                If Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(0, 2) = "D2" Then
                    Dim sucursal As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(20, 35)
                    Dim fecha_trans As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(55, 8)
                    ConvierteStringAFecha(fecha_trans)
                    Dim monto_operacion As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(72, 9)
                    Dim monto_total_a_pagar As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(81, 9)
                    Dim descripcion As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(90, 40)
                    Dim numero_cuota As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(130, 3)
                    Dim total_cuotas As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(133, 3)
                    Dim monto_cuota As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(136, 9)

                    gfx.DrawString(Trim(sucursal), font, XBrushes.Black, New XVector(32, 454 + L_D2))
                    gfx.DrawString(Trim(fecha_trans), font, XBrushes.Black, New XVector(115, 454 + L_D2))
                    gfx.DrawString(Trim(descripcion), font, XBrushes.Black, New XVector(173, 454 + L_D2))
                    gfx.DrawString(Trim(Format(monto_operacion, "###,#0")), font, XBrushes.Black, New XRect(313, 446 + L_D2, 40, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(monto_total_a_pagar, "###,#0")), font, XBrushes.Black, New XRect(355, 446 + L_D2, 62, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(numero_cuota & " / " & total_cuotas), font, XBrushes.Black, New XVector(450, 454 + L_D2))
                    gfx.DrawString(Trim(Format(monto_cuota, "###,#0")), font, XBrushes.Black, New XRect(505, 446 + L_D2, 74, 10), FormatoDerecha)
                    L_D2 = L_D2 + 8
                End If
            Next
            '**************************D3
            Dim L_D3 As Integer = 0
            For L = 0 To Grilla_TramaEECC.Rows.Count - 1
                If Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(0, 2) = "D3" Then
                    Dim sucursal As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(20, 35)
                    Dim fecha_trans As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(55, 8)
                    ConvierteStringAFecha(fecha_trans)
                    Dim monto_operacion As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(72, 9)
                    Dim monto_total_a_pagar As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(81, 9)
                    Dim descripcion As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(90, 40)
                    Dim numero_cuota As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(130, 3)
                    Dim total_cuotas As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(133, 3)
                    Dim monto_cuota As Integer = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(136, 9)

                    gfx.DrawString(Trim(sucursal), font, XBrushes.Black, New XVector(32, 516 + L_D3))
                    gfx.DrawString(Trim(fecha_trans), font, XBrushes.Black, New XVector(115, 516 + L_D3))
                    gfx.DrawString(Trim(descripcion), font, XBrushes.Black, New XVector(173, 516 + L_D3))
                    gfx.DrawString(Trim(Format(monto_operacion, "###,#0")), font, XBrushes.Black, New XRect(313, 508 + L_D3, 40, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                    gfx.DrawString(Trim(Format(monto_total_a_pagar, "###,#0")), font, XBrushes.Black, New XRect(355, 508 + L_D3, 62, 10), FormatoDerecha)
                    gfx.DrawString(Trim(numero_cuota & " / " & total_cuotas), font, XBrushes.Black, New XVector(450, 516 + L_D3))
                    gfx.DrawString(Trim(Format(monto_cuota, "###,#0")), font, XBrushes.Black, New XRect(505, 508 + L_D3, 75, 10), FormatoDerecha)
                    L_D3 = L_D3 + 8
                End If
            Next
        Catch ex As Exception
            Me.LBL_FacturacionesError.Visible = True
            Me.LBL_FacturacionesError.Text = "ERROR EN DATOS DE DETALLE"
        End Try
        Try
            PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_" & Session("rut") & "_" & Session("dv") & "_" & DDL_Facturaciones.SelectedItem.Text & ".pdf"))
        Catch ex As Exception
            Me.LBL_FacturacionesError.Visible = True
            Me.LBL_FacturacionesError.Text = "ERROR GRABANDO PDF"
        End Try
    End Sub
    Private Function ConvierteStringAFecha(ByRef fecha As String) As Date
        Try
            Dim dia As String
            Dim mes As String
            Dim año As Integer
            dia = fecha.ToString.Substring(6, 2)
            mes = fecha.ToString.Substring(4, 2)
            año = fecha.ToString.Substring(0, 4)
            fecha = dia & "-" & mes & "-" & año
            Return fecha
        Catch ex As Exception
        End Try
    End Function
    Protected Sub DDL_Facturaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_Facturaciones.SelectedIndexChanged
        Me.Literal1.Visible = False
    End Sub
End Class
