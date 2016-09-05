﻿Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf.IO
Imports System
Imports System.IO
Partial Class Mantencion_Tarjetas
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            VerPDFContrato()
        End If
    End Sub
    Protected Sub BTN_Cerrar_Click(sender As Object, e As EventArgs) Handles BTN_Cerrar.Click
        'CIERRA VENTANA POPUP       
        If Not IsClientScriptBlockRegistered("Cierra") Then
            RegisterClientScriptBlock("Cierra", "<script language='javascript'>window.close();</script>")
        End If
    End Sub
    Protected Sub VerPDFContrato()
        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""595px"" height=""515px"">"
        embed += "Si no puede ver el archivo, ud. puede descargar desde <a href = ""{0}"">Acá</a>"
        embed += " o descargar desde <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> para ver el archivo."
        embed += "</object>"
        Try
            Dim File As String = HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_FamilyShop_" & Session("rut") & "_" & Session("dv") & ".pdf")
            'Dim File As String = HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_FamilyShop_15742915_9.pdf")
            If (System.IO.File.Exists(File)) Then
                'System.IO.File.Delete(File)
                Me.Literal1.Text = String.Format(embed, ResolveUrl("~/Doc/Contrato/Contrato_FamilyShop_" & Session("rut") & "_" & Session("dv") & ".pdf"))
                'Me.Literal1.Text = String.Format(embed, ResolveUrl("~/Doc/Contrato/Contrato_FamilyShop_15742915_9.pdf"))
            Else
                LBL_VerPDFError.Text = "ERROR CARGANDO ARCHIVO PDF : ARCHIVO NO EXISTE"
            End If
        Catch ex As Exception
            LBL_VerPDFError.Text = "ERROR CARGANDO ARCHIVO PDF"
        End Try
    End Sub
End Class