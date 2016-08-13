Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf.IO

Partial Class Mantencion_Tarjeta_Contrato
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            VerPDFContrato()
        End If
    End Sub
    Protected Sub VerPDFContrato()
        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""600px"" height=""500px"">"
        embed += "If you are unable to view file, you can download from <a href = ""{0}"">here</a>"
        embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"
        Literal1.Text = String.Format(embed, ResolveUrl("~/Doc/contrato_family.pdf"))
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click
        Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/contrato_family.pdf") ' PDF fuente 
        MsgBox(ruta_pdf_original)
        Dim PDFDoc As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_original, PdfDocumentOpenMode.Import)

        Dim PDFNewDoc As PdfSharp.Pdf.PdfDocument = New PdfSharp.Pdf.PdfDocument() 'PDF destino con datos y firma de cliente 

        Dim Pg As Integer       'copio pdf original y lo guardo con otro nombre 
        For Pg = 0 To PDFDoc.Pages.Count - 1
            PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
        Next
        PDFNewDoc.Save(HttpContext.Current.Server.MapPath("~/Doc/contrato_family_editado.pdf"))

        Dim ruta_pdf_cliente As String = HttpContext.Current.Server.MapPath("~/Doc/contrato_family_editado.pdf") ' PDF destino 
        Dim PDFDoc2 As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_cliente, PdfDocumentOpenMode.Modify)
        Dim pp As PdfSharp.Pdf.PdfPage = PDFDoc2.Pages(0) '= PDFNewDoc.AddPage(PDFDoc.Pages(0))
        Dim gfx As XGraphics = XGraphics.FromPdfPage(pp)
        Dim font As XFont = New XFont("Arial", 10, XFontStyle.Regular)
        gfx.DrawString("Hello, World!", font, XBrushes.Black, New XRect(0, 0, pp.Width, pp.Height), XStringFormats.TopCenter)
        gfx.DrawString(" " & Session("rut") & " - " & Session("dv"), font, XBrushes.Black, New XVector(255, 125))
        gfx.DrawString(Session("nombrecliente"), font, XBrushes.Black, New XVector(150, 158))

        pp = PDFDoc2.Pages(2) '= PDFNewDoc.AddPage(PDFDoc.Pages(0))

        gfx.DrawString("Hello, World!", font, XBrushes.Black, New XRect(0, 0, pp.Width, pp.Height), XStringFormats.TopCenter)
        gfx.DrawString(" " & Session("rut") & " - " & Session("dv"), font, XBrushes.Black, New XVector(500, 125))
        gfx.DrawString(Session("nombrecliente"), font, XBrushes.Black, New XVector(550, 158))
        'Session("rut")
        'Session("dv")
        PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/contrato_family_editado.pdf"))
    End Sub
End Class
