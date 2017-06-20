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
                ' Me.DDL_Facturaciones.DataTextField.Substring(0, length:=4)
                ' Me.DDL_Facturaciones.DataValueField.Substring(0, length:=4)
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
                Me.LBL_EECCError.Visible = True
                Me.LBL_EECCError.Text = DataDSEECC.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_EECCError.Visible = False
                Me.Grilla_TramaEECC.DataSource = DataDSEECC.Tables(0).DefaultView
                Me.Grilla_TramaEECC.DataBind()
                GeneraPDFEECC()
                ' Me.DDL_Facturaciones.DataTextField.Substring(0, length:=4)
                ' Me.DDL_Facturaciones.DataValueField.Substring(0, length:=4)
            End If
        Catch EX As Exception
            Me.LBL_EECCError.Visible = True
            Me.LBL_EECCError.Text = EX.Message
        End Try
    End Sub
    Private Sub GeneraPDFEECC()
        Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_template.pdf") ' PDF fuente      
        Dim PDFDoc As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_original, PdfDocumentOpenMode.Import)
        Dim PDFNewDoc As PdfSharp.Pdf.PdfDocument = New PdfSharp.Pdf.PdfDocument() 'PDF destino con datos y firma de cliente 
        Dim Pg As Integer       'copio pdf original y lo guardo con otro nombre 
        For Pg = 0 To PDFDoc.Pages.Count - 1
            PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
        Next
        PDFNewDoc.Save(HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_" & Session("rut") & "_" & Session("dv") & "_" & DDL_Facturaciones.SelectedItem.Text & ".pdf"))

        Dim ruta_pdf_cliente As String = HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_" & Session("rut") & "_" & Session("dv") & "_" & DDL_Facturaciones.SelectedItem.Text & ".pdf") ' PDF destino 
        Dim PDFDoc2 As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_cliente, PdfDocumentOpenMode.Modify)
        Dim pp As PdfSharp.Pdf.PdfPage = PDFDoc2.Pages(0) '= PDFNewDoc.AddPage(PDFDoc.Pages(0))
        Dim gfx As XGraphics = XGraphics.FromPdfPage(pp)
        Dim font As XFont = New XFont("Tahoma", 7, XFontStyle.Regular)
        Dim L As Integer
        For L = 0 To Grilla_TramaEECC.Rows.Count - 1
            If Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(0, 2) = "E1" Then
                Dim rut As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(3, 8)
                Dim dv As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(11, 1)
                Dim nombres As String = Me.Grilla_TramaEECC.Rows(L).Cells(0).Text.Substring(20, 50)
                gfx.DrawString(Trim(nombres), font, XBrushes.Black, New XVector(180, 50))
                gfx.DrawString(Trim(rut) & "-" & Trim(dv), font, XBrushes.Black, New XVector(180, 62))
                Dim fecha_pago As String = Me.Grilla_TramaEECC.Rows(0).Cells(0).Text.Substring(12, 8)
                ConvierteStringAFecha(fecha_pago)
                gfx.DrawString(Trim(fecha_pago), font, XBrushes.Black, New XVector(180, 75))
                Me.LBL_FacturacionesError.Visible = True
                LBL_FacturacionesError.Text = nombres
            End If
        Next
        Dim FormatoDerecha As New XStringFormat
        FormatoDerecha.Alignment = XStringAlignment.Far
        FormatoDerecha.LineAlignment = XLineAlignment.Center

        Dim RECT_D3_Monto_Operacion As New XRect(313, 328, 40, 10) 'izquierda,abajo,ancho,alto
        gfx.DrawRectangle(XBrushes.SeaShell, RECT_D3_Monto_Operacion)

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

                gfx.DrawString(Trim(sucursal), font, XBrushes.Black, New XVector(32, 328 + L_D1))
                gfx.DrawString(Trim(fecha_trans), font, XBrushes.Black, New XVector(115, 328 + L_D1))
                gfx.DrawString(Trim(descripcion), font, XBrushes.Black, New XVector(173, 328 + L_D1))
                'gfx.DrawString(Trim(Format(monto_operacion, "###,#0")), font, XBrushes.Black, New XVector(325, 328 + L_D1))
                gfx.DrawString(Trim(Format(monto_operacion, "###,#0")), font, XBrushes.Black, New XRect(313, 335 + L_D1, 74, 10), FormatoDerecha)
                gfx.DrawString(Trim(Format(monto_total_a_pagar, "###,#0")), font, XBrushes.Black, New XVector(365, 328 + L_D1))
                gfx.DrawString(Trim(numero_cuota & " / " & total_cuotas), font, XBrushes.Black, New XVector(450, 335 + L_D1))
                gfx.DrawString(Trim(Format(monto_cuota, "###,#0")), font, XBrushes.Black, New XVector(530, 335 + L_D1))
                L_D1 = L_D1 + 8 ' SIGUIENTE LINEA
            End If
        Next

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

                gfx.DrawString(Trim(sucursal), font, XBrushes.Black, New XVector(32, 450 + L_D2))
                gfx.DrawString(Trim(fecha_trans), font, XBrushes.Black, New XVector(115, 450 + L_D2))
                gfx.DrawString(Trim(descripcion), font, XBrushes.Black, New XVector(173, 450 + L_D2))
                gfx.DrawString(Trim(Format(monto_operacion, "###,#0")), font, XBrushes.Black, New XRect(313, 443 + L_D2, 40, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                gfx.DrawString(Trim(Format(monto_total_a_pagar, "###,#0")), font, XBrushes.Black, New XRect(355, 443 + L_D2, 62, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                gfx.DrawString(Trim(numero_cuota & " / " & total_cuotas), font, XBrushes.Black, New XVector(450, 450 + L_D2))
                ' gfx.DrawString(Trim(Format(monto_cuota, "###,#0")), font, XBrushes.Black, New XVector(530, 450 + L_D2))
                gfx.DrawString(Trim(Format(monto_cuota, "###,#0")), font, XBrushes.Black, New XRect(505, 443 + L_D2, 74, 10), FormatoDerecha)
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

                gfx.DrawString(Trim(sucursal), font, XBrushes.Black, New XVector(32, 511 + L_D3))
                gfx.DrawString(Trim(fecha_trans), font, XBrushes.Black, New XVector(115, 511 + L_D3))
                gfx.DrawString(Trim(descripcion), font, XBrushes.Black, New XVector(173, 511 + L_D3))
                gfx.DrawString(Trim(Format(monto_operacion, "###,#0")), font, XBrushes.Black, New XRect(313, 504 + L_D3, 40, 10), FormatoDerecha) 'izquierda,abajo,ancho,alto
                gfx.DrawString(Trim(Format(monto_operacion, "###,#0")), font, XBrushes.Black, New XRect(355, 504 + L_D3, 67, 10), FormatoDerecha)
                gfx.DrawString(Trim(numero_cuota & " / " & total_cuotas), font, XBrushes.Black, New XVector(450, 511 + L_D3))
                gfx.DrawString(Trim(Format(monto_cuota, "###,#0")), font, XBrushes.Black, New XRect(505, 504 + L_D3, 75, 10), FormatoDerecha)
                L_D3 = L_D3 + 8
            End If
        Next
        PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/EECC/eecc_" & Session("rut") & "_" & Session("dv") & "_" & DDL_Facturaciones.SelectedItem.Text & ".pdf"))
    End Sub
    Private Function ConvierteStringAFecha(ByRef fecha As String) As Date
        Dim dia As String
        Dim mes As String
        Dim año As Integer
        dia = fecha.ToString.Substring(6, 2)
        mes = fecha.ToString.Substring(4, 2)
        año = fecha.ToString.Substring(0, 4)
        fecha = dia & "-" & mes & "-" & año
        Return fecha
    End Function
End Class
