Imports PdfSharp
Imports PdfSharp.Drawing
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
        Dim font As XFont = New XFont("Times New Roman", 12, XFontStyle.Regular)
        If Me.Grilla_TramaEECC.Rows(0).Cells(0).Text.Substring(1, 2) = "E1" Then
            Dim rut As String = Me.Grilla_TramaEECC.Rows(0).Cells(0).Text.Substring(3, 9)
            Me.LBL_EECCError.Visible = True
            LBL_EECCError.Text = rut

        End If

        'gfx.DrawString(Trim(ClienteNombres), font, XBrushes.Black, New XVector(355, 126))
        'gfx.DrawString(Trim(ClienteAPaterno) & " " & Trim(ClienteAMaterno), font, XBrushes.Black, New XVector(65, 139))
        'gfx.DrawString(" " & Session("rut") & "-" & Session("dv"), font, XBrushes.Black, New XVector(480, 139))
        'gfx.DrawString(Trim(ClienteCalleParticular) & " NRO " & Trim(ClienteNumeroCasa) & " " & Trim(ClienteNumeroDepto), font, XBrushes.Black, New XVector(170, 152))
        'gfx.DrawString(Trim(ClienteComuna), font, XBrushes.Black, New XVector(80, 166))
    End Sub
End Class
