Partial Class Mantencion_Tarjeta_Contrato
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            VerPDFContrato()
        End If
    End Sub
    Protected Sub VerPDFContrato()
        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""600px"" height=""700px"">"
        embed += "If you are unable to view file, you can download from <a href = ""{0}"">here</a>"
        embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"
        Literal1.Text = String.Format(embed, ResolveUrl("~/Doc/contrato_family.pdf"))
    End Sub
End Class
