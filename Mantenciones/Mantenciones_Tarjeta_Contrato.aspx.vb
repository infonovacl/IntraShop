Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf.IO
Imports System
Imports System.IO

Partial Class Mantencion_Tarjeta_Contrato
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            VerPDFContrato()
        End If
    End Sub
    Protected Sub VerPDFContrato()
        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""600px"" height=""200px"">"
        embed += "If you are unable to view file, you can download from <a href = ""{0}"">here</a>"
        embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"
        Literal1.Text = String.Format(embed, ResolveUrl("~/Doc/contrato_family.pdf"))
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click

    End Sub
    Protected Sub BTN_Firmar_Click(sender As Object, e As EventArgs) Handles BTN_Firmar.Click
        Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/contrato_family.pdf") ' PDF fuente      
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
        gfx.DrawString(" " & Session("rut") & " - " & Session("dv"), font, XBrushes.Black, New XVector(260, 122))
        gfx.DrawString(Session("nombrecliente"), font, XBrushes.Black, New XVector(150, 158))

        pp = PDFDoc2.Pages(2) ' Pagina nro. 3
        gfx = XGraphics.FromPdfPage(pp)
        gfx.DrawString(" " & Session("rut") & " - " & Session("dv"), font, XBrushes.Black, New XVector(230, 530))
        gfx.DrawString(Session("nombrecliente"), font, XBrushes.Black, New XVector(230, 510))

        '****************************************************
        Dim _sImage As String = _hdnSignature.Value.Replace("data:image/jpeg;base64,", "")
        Dim _rgbBytes As Byte() = Convert.FromBase64String(_sImage)
        Dim _sImageFile As String = Guid.NewGuid().ToString().Replace("-", String.Empty)
        _sImageFile += ".jpg"

        Using imageFile As FileStream = New FileStream(Server.MapPath("~/Doc/" + _sImageFile), FileMode.Create)
            imageFile.Write(_rgbBytes, 0, _rgbBytes.Length)
            imageFile.Flush()
            imageFile.Dispose()

        End Using
        Dim XImage As XImage = XImage.FromFile(HttpContext.Current.Server.MapPath("~/Doc/" + _sImageFile)) ' inserta firma          
        gfx.DrawImage(XImage, 220, 590, 200, 70)
        PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/contrato_family_editado.pdf"))
        'Dim File As String = HttpContext.Current.Server.MapPath("~/Doc/" & _sImageFile)
        'If (System.IO.File.Exists(File)) Then
        ' System.IO.File.Delete(File)
        ' End If
    End Sub
End Class
