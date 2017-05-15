Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf.IO
Imports System
Imports System.IO
Partial Class Mantencion_FirmaDoc
    Inherits System.Web.UI.Page
    Dim ClienteNombres, ClienteAPaterno, ClienteAMaterno, ClienteSexo, ClienteFechaNac, ClienteEstadoCivil As String
    Dim ClienteCalleParticular, ClienteNumeroCasa, ClienteNumeroDepto, ClienteComuna, ClienteTelefonoFijo, ClienteTelefonoCelular, ClienteCorreoElectronico As String    
    Private Sub ObtieneDatosCliente()
        Dim DataDSDatosCliente As New Data.DataSet
        Dim RutCliente As Integer = Session("rut")
        Try
            Dim STRDatosCliente As String = "execute procedure procw_cons_mant ('" & RutCliente & "')"
            Dim DATADatosCliente As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDatosCliente, Globales.conn)
            DATADatosCliente.Fill(DataDSDatosCliente, "PRUEBA")
            If DataDSDatosCliente.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_DatosClienteError.Visible = True
                Me.LBL_DatosClienteError.Text = DataDSDatosCliente.Tables(0).Rows(0)(1) ' mensaje de error
            Else               
                If DataDSDatosCliente.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                    ClienteNombres = ""
                Else
                    ClienteNombres = Trim(DataDSDatosCliente.Tables(0).Rows(0)(4))                 
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                    ClienteAPaterno = ""
                Else
                    ClienteAPaterno = Trim(DataDSDatosCliente.Tables(0).Rows(0)(5))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                    ClienteAMaterno = ""
                Else
                    ClienteAMaterno = Trim(DataDSDatosCliente.Tables(0).Rows(0)(6))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(7) Is System.DBNull.Value Then 'sexo                  
                    ClienteSexo = 0
                Else
                    ClienteSexo = DataDSDatosCliente.Tables(0).Rows(0)(7)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(8) Is System.DBNull.Value Then ' fecha nacimiento
                    ClienteFechaNac = ""
                Else
                    ClienteFechaNac = DataDSDatosCliente.Tables(0).Rows(0)(8)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(9) Is System.DBNull.Value Then 'estado civil                  
                    ClienteEstadoCivil = 0
                Else
                    ClienteEstadoCivil = DataDSDatosCliente.Tables(0).Rows(0)(9)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(10) Is System.DBNull.Value Then 'calle
                    ClienteCalleParticular = ""
                Else
                    ClienteCalleParticular = Trim(DataDSDatosCliente.Tables(0).Rows(0)(10))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(11) Is System.DBNull.Value Then 'n casa
                    ClienteNumeroCasa = ""
                Else
                    ClienteNumeroCasa = DataDSDatosCliente.Tables(0).Rows(0)(11)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(12) Is System.DBNull.Value Then 'n depto
                    ClienteNumeroDepto = ""
                Else
                    ClienteNumeroDepto = DataDSDatosCliente.Tables(0).Rows(0)(12)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(17) Is System.DBNull.Value Then 'n telefono fijo
                    ClienteTelefonoFijo = ""
                Else
                    ClienteTelefonoFijo = DataDSDatosCliente.Tables(0).Rows(0)(17)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(18) Is System.DBNull.Value Then 'n telefono celular
                    ClienteTelefonoCelular = ""
                Else
                    ClienteTelefonoCelular = DataDSDatosCliente.Tables(0).Rows(0)(18)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(35) Is System.DBNull.Value Then 'mail
                    ClienteCorreoElectronico = ""
                Else
                    ClienteCorreoElectronico = Trim(DataDSDatosCliente.Tables(0).Rows(0)(35))
                End If             
                ClienteComuna = Session("comuna")
                ClienteEstadoCivil = Session("estadocivil")
                ClienteSexo = Session("sexo")
            End If
        Catch EX As Exception
            Me.LBL_DatosClienteError.Text = EX.Message
        End Try
    End Sub       
    Protected Sub BTN_FirmarContrato_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_FirmarContrato.Click
        ObtieneDatosCliente()
        Try
            If Me._hdnSignature.Value <> Nothing Then
                Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/Contrato/contrato_template.pdf") ' PDF fuente      
                Dim PDFDoc As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_original, PdfDocumentOpenMode.Import)
                Dim PDFNewDoc As PdfSharp.Pdf.PdfDocument = New PdfSharp.Pdf.PdfDocument() 'PDF destino con datos y firma de cliente 
                Dim Pg As Integer       'copio pdf original y lo guardo con otro nombre 
                For Pg = 0 To PDFDoc.Pages.Count - 1
                    PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
                Next
                PDFNewDoc.Save(HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_" & Session("rut") & "_" & Session("dv") & ".pdf"))

                Dim ruta_pdf_cliente As String = HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_" & Session("rut") & "_" & Session("dv") & ".pdf") ' PDF destino 
                Dim PDFDoc2 As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_cliente, PdfDocumentOpenMode.Modify)
                Dim pp As PdfSharp.Pdf.PdfPage = PDFDoc2.Pages(0) '= PDFNewDoc.AddPage(PDFDoc.Pages(0))
                Dim gfx As XGraphics = XGraphics.FromPdfPage(pp)
                Dim font As XFont = New XFont("Times New Roman", 12, XFontStyle.Regular)
                gfx.DrawString(Trim(ClienteNombres), font, XBrushes.Black, New XVector(355, 126))
                gfx.DrawString(Trim(ClienteAPaterno) & " " & Trim(ClienteAMaterno), font, XBrushes.Black, New XVector(65, 139))
                gfx.DrawString(" " & Session("rut") & "-" & Session("dv"), font, XBrushes.Black, New XVector(480, 139))
                gfx.DrawString(Trim(ClienteCalleParticular) & " NRO " & Trim(ClienteNumeroCasa) & " " & Trim(ClienteNumeroDepto), font, XBrushes.Black, New XVector(170, 152))
                gfx.DrawString(Trim(ClienteComuna), font, XBrushes.Black, New XVector(80, 166))

                pp = PDFDoc2.Pages(8) ' Pagina nro. 9
                gfx = XGraphics.FromPdfPage(pp)
                gfx.DrawString(Now.Day, font, XBrushes.Black, New XVector(130, 740))
                gfx.DrawString(Now.Month, font, XBrushes.Black, New XVector(170, 740))
                gfx.DrawString(Now.Year, font, XBrushes.Black, New XVector(220, 740))
                '****************************************************
                Dim _sImage As String = _hdnSignature.Value.Replace("data:image/jpeg;base64,", "")
                Dim _rgbBytes As Byte() = Convert.FromBase64String(_sImage)
                Dim _sImageFile As String = Guid.NewGuid().ToString().Replace("-", String.Empty)
                _sImageFile += ".jpg"

                Using imageFile As FileStream = New FileStream(Server.MapPath("~/Doc/Contrato/" + _sImageFile), FileMode.Create)
                    imageFile.Write(_rgbBytes, 0, _rgbBytes.Length)
                    imageFile.Flush()
                    imageFile.Dispose()
                End Using

                Dim XImage As XImage = XImage.FromFile(HttpContext.Current.Server.MapPath("~/Doc/Contrato/" + _sImageFile)) ' inserta firma          
                gfx.DrawImage(XImage, 210, 535, 200, 100)
                PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_" & Session("rut") & "_" & Session("dv") & ".pdf"))

                Dim Img64Contrato As String = HttpContext.Current.Server.MapPath("~/Doc/Contrato/" & _sImageFile) 'BORRAR IMAGEN 64 
                BorraFirmaUsada(Img64Contrato)                             
                Me.IMG_ContratoFirmado.Visible = True
                Me.IMG_ContratoRechazado.Visible = False
                Me.LINK_VerContrato.Enabled = True
                Me.BTN_FirmarContrato.Enabled = False
                Me.BTN_CAPFirmaCON.Disabled = True
                GrabaFirmaContrato()
                If Not IsClientScriptBlockRegistered("popup") Then
                    RegisterClientScriptBlock("popup", "<script language='javascript'>my_window=window.open('/Mantenciones/Mantenciones_VerContrato.aspx','VerContrato','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()</script>")
                End If
            Else
                Me.LBL_ContratoError.Text = "FIRMA NO VALIDA, POR FAVOR REINTENTE"
                Me.IMG_ContratoRechazado.Visible = True
                Me.IMG_ContratoFirmado.Visible = False
            End If
        Catch ex As Exception
            Me.LBL_ContratoError.Text = ex.Message
            Me.IMG_ContratoRechazado.Visible = True
        End Try
    End Sub
    Private Sub GrabaFirmaContrato()
        Dim DataDSGrabaFirmaContrato As New Data.DataSet
        Dim RutCliente, CodSucursal, CodCaja, Responsable As Integer
        Dim CodAutorizacion As String
        RutCliente = Session("rut")
        CodSucursal = Session("sucursal")
        CodCaja = Session("caja")
        Responsable = Session("usuario")
        CodAutorizacion = "" ' despues se dara algoritmo para este item 
        Try
            Dim STRGrabaFirmaContrato As String = "execute procedure procw_guarda_documento ('" & RutCliente & "','CON',current year to day," & Responsable & "," & CodSucursal & "," & CodCaja & ",'" & CodAutorizacion & "')"
            Dim DATAGrabaFirmaContrato As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRGrabaFirmaContrato, Globales.conn)
            DATAGrabaFirmaContrato.Fill(DataDSGrabaFirmaContrato, "PRUEBA")
            If DataDSGrabaFirmaContrato.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_ContratoError.Visible = True
                Me.LBL_ContratoError.Text = DataDSGrabaFirmaContrato.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_ContratoError.Visible = True
                Me.LBL_ContratoError.Text = DataDSGrabaFirmaContrato.Tables(0).Rows(0)(1) ' mensaje exito
                ValidaDocsAFirmar()
            End If        
        Catch ex As Exception
            Me.LBL_ContratoError.Visible = True
            Me.LBL_ContratoError.Text = "ERROR GUARDANDO CONTRATO"
        End Try
    End Sub
    Private Sub GrabaFirmaSeguroProteccion()
        Dim DataDSGrabaFirmaSeguroProteccion As New Data.DataSet
        Dim RutCliente, CodSucursal, CodCaja, Responsable As Integer
        Dim CodAutorizacion As String
        RutCliente = Session("rut")
        CodSucursal = Session("sucursal")
        CodCaja = Session("caja")
        Responsable = Session("usuario")
        CodAutorizacion = "" ' despues se dara algoritmo para este item 
        Try
            Dim STRGrabaFirmaSeguroProteccion As String = "execute procedure procw_guarda_documento ('" & RutCliente & "','SDE',current year to day," & Responsable & "," & CodSucursal & "," & CodCaja & ",'" & CodAutorizacion & "')"
            Dim DATAGrabaFirmaSeguroProteccion As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRGrabaFirmaSeguroProteccion, Globales.conn)
            DATAGrabaFirmaSeguroProteccion.Fill(DataDSGrabaFirmaSeguroProteccion, "PRUEBA")
            If DataDSGrabaFirmaSeguroProteccion.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_SeguroProteccionError.Visible = True
                Me.LBL_SeguroProteccionError.Text = DataDSGrabaFirmaSeguroProteccion.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_SeguroProteccionError.Visible = True
                Me.LBL_SeguroProteccionError.Text = DataDSGrabaFirmaSeguroProteccion.Tables(0).Rows(0)(1) ' mensaje exito
                ValidaDocsAFirmar()
            End If
        Catch ex As Exception
            Me.LBL_SeguroProteccionError.Visible = True
            Me.LBL_SeguroProteccionError.Text = "ERROR GUARDANDO SEGURO PROTECCION"
        End Try
    End Sub
    Private Sub GrabaFirmaSeguroVida()
        Dim DataDSGrabaFirmaSeguroVida As New Data.DataSet
        Dim RutCliente, CodSucursal, CodCaja, Responsable As Integer
        Dim CodAutorizacion As String
        RutCliente = Session("rut")
        CodSucursal = Session("sucursal")
        CodCaja = Session("caja")
        Responsable = Session("usuario")
        CodAutorizacion = "" ' despues se dara algoritmo para este item 
        Try
            Dim STRGrabaFirmaSeguroVida As String = "execute procedure procw_guarda_documento ('" & RutCliente & "','SVI',current year to day," & Responsable & "," & CodSucursal & "," & CodCaja & ",'" & CodAutorizacion & "')"
            Dim DATAGrabaFirmaSeguroVida As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRGrabaFirmaSeguroVida, Globales.conn)
            DATAGrabaFirmaSeguroVida.Fill(DataDSGrabaFirmaSeguroVida, "PRUEBA")
            If DataDSGrabaFirmaSeguroVida.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_SeguroVidaError.Visible = True
                Me.LBL_SeguroVidaError.Text = DataDSGrabaFirmaSeguroVida.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_SeguroVidaError.Visible = True
                Me.LBL_SeguroVidaError.Text = DataDSGrabaFirmaSeguroVida.Tables(0).Rows(0)(1) ' mensaje exito
                ValidaDocsAFirmar()
            End If
        Catch ex As Exception
            Me.LBL_SeguroProteccionError.Visible = True
            Me.LBL_SeguroProteccionError.Text = "ERROR GUARDANDO SEGURO VIDA"
        End Try
    End Sub
    Protected Sub BTN_Cerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_Cerrar.Click
        Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>") 'CIERRA VENTANA POPUP   
    End Sub     
    Protected Sub BTN_FirmarSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_FirmarSV.Click
        ObtieneDatosCliente()
        Try
            If Me._hdnSignatureSV.Value <> Nothing Then
                Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/SeguroVida/seguro_vida_template.pdf") ' PDF fuente      
                Dim PDFDoc As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_original, PdfDocumentOpenMode.Import)
                Dim PDFNewDoc As PdfSharp.Pdf.PdfDocument = New PdfSharp.Pdf.PdfDocument() 'PDF destino con datos y firma de cliente 
                Dim Pg As Integer       'copio pdf original y lo guardo con otro nombre 
                For Pg = 0 To PDFDoc.Pages.Count - 1
                    PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
                Next
                PDFNewDoc.Save(HttpContext.Current.Server.MapPath("~/Doc/SeguroVida/seguro_vida_" & Session("rut") & "_" & Session("dv") & ".pdf"))

                Dim ruta_pdf_cliente As String = HttpContext.Current.Server.MapPath("~/Doc/SeguroVida/seguro_vida_" & Session("rut") & "_" & Session("dv") & ".pdf") ' PDF destino 
                Dim PDFDoc2 As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_cliente, PdfDocumentOpenMode.Modify)
                Dim pp As PdfSharp.Pdf.PdfPage = PDFDoc2.Pages(0) ' pagina 1
                Dim gfx As XGraphics = XGraphics.FromPdfPage(pp)
                Dim font As XFont = New XFont("Arial", 10, XFontStyle.Regular)
                gfx.DrawString(Trim(ClienteAPaterno) & " " & Trim(ClienteAMaterno) & " " & Trim(ClienteNombres), font, XBrushes.Black, New XVector(65, 200))
                gfx.DrawString(" " & Session("rut") & "-" & Session("dv"), font, XBrushes.Black, New XVector(480, 200))
                gfx.DrawString(Trim(ClienteCalleParticular) & " NRO " & Trim(ClienteNumeroCasa) & " " & Trim(ClienteNumeroDepto), font, XBrushes.Black, New XVector(65, 225))
                gfx.DrawString(Trim(ClienteComuna), font, XBrushes.Black, New XVector(380, 225))

                gfx.DrawString(Trim(ClienteTelefonoFijo), font, XBrushes.Black, New XVector(65, 250))
                gfx.DrawString(Trim(ClienteTelefonoCelular), font, XBrushes.Black, New XVector(270, 250))
                gfx.DrawString(Trim(ClienteCorreoElectronico), font, XBrushes.Black, New XVector(380, 250))

                gfx.DrawString(Trim(ClienteFechaNac.ToString.Replace("-", "   ")), font, XBrushes.Black, New XVector(63, 273))

                If Trim(ClienteSexo) = "FEMENINO" Then
                    gfx.DrawString("X", font, XBrushes.Black, New XVector(187, 273))
                ElseIf Trim(ClienteSexo) = "MASCULINO" Then
                    gfx.DrawString("X", font, XBrushes.Black, New XVector(150, 273))
                End If
                'gfx.DrawString(Trim(ClienteSexo), font, XBrushes.Black, New XVector(190, 273)) Then

                If Trim(ClienteEstadoCivil) = "SOLTERO (A)" Then
                    gfx.DrawString("X", font, XBrushes.Black, New XVector(300, 273))
                ElseIf Trim(ClienteEstadoCivil) = "CASADO (A)" Then
                    gfx.DrawString("X", font, XBrushes.Black, New XVector(255, 273))
                ElseIf Trim(ClienteEstadoCivil) = "VIUDO (A)" Then
                    gfx.DrawString("X", font, XBrushes.Black, New XVector(345, 273))
                End If
                'gfx.DrawString(Trim(ClienteEstadoCivil), font, XBrushes.Black, New XVector(255, 273))

                pp = PDFDoc2.Pages(1) ' Pagina nro. 2
                gfx = XGraphics.FromPdfPage(pp)
                gfx.DrawString(Now.Day & "     " & Now.Month & "         " & Now.Year, font, XBrushes.Black, New XVector(78, 283))
                '****************************************************                            
                'gfx.DrawString(Now.Day, font, XBrushes.Black, New XVector(110, 690))
                'gfx.DrawString(Now.Month, font, XBrushes.Black, New XVector(160, 690))
                'gfx.DrawString(Now.Year, font, XBrushes.Black, New XVector(200, 690))
                '****************************************************
                Dim _sImageSV As String = _hdnSignatureSV.Value.Replace("data:image/jpeg;base64,", "")
                Dim _rgbBytesSV As Byte() = Convert.FromBase64String(_sImageSV)
                Dim _sImageFileSV As String = Guid.NewGuid().ToString().Replace("-", String.Empty)
                _sImageFileSV += ".jpg"
                Using imageFileSV As FileStream = New FileStream(Server.MapPath("~/Doc/SeguroVida/" + _sImageFileSV), FileMode.Create)
                    imageFileSV.Write(_rgbBytesSV, 0, _rgbBytesSV.Length)
                    imageFileSV.Flush()
                    imageFileSV.Dispose()
                End Using
                Dim XImage As XImage = XImage.FromFile(HttpContext.Current.Server.MapPath("~/Doc/SeguroVida/" + _sImageFileSV)) ' inserta firma          
                gfx.DrawImage(XImage, 465, 210, 120, 70)
                PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/SeguroVida/seguro_vida_" & Session("rut") & "_" & Session("dv") & ".pdf"))

                Dim Img64SV As String = HttpContext.Current.Server.MapPath("~/Doc/SeguroVida/" & _sImageFileSV) 'BORRAR IMAGEN 64           
                BorraFirmaUsada(Img64SV)
                Me.IMG_SeguroVidaFirmado.Visible = True
                Me.IMG_SeguroVidaRechazado.Visible = False
                Me.LINK_VerSV.Enabled = True
                Me.BTN_FirmarSV.Enabled = False
                Me.BTN_CAPFirmaSV.Disabled = True
                GrabaFirmaSeguroVida()
                If Not IsClientScriptBlockRegistered("popup") Then
                    RegisterClientScriptBlock("popup", "<script language='javascript'>my_window=window.open('/Mantenciones/Mantenciones_VerSeguroVida.aspx','VerSeguroVida','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()</script>")
                End If
            Else
                Me.LBL_SeguroVidaError.Text = "FIRMA NO VALIDA, POR FAVOR REINTENTE"
                Me.IMG_SeguroVidaFirmado.Visible = False
                Me.IMG_SeguroVidaRechazado.Visible = True
            End If
        Catch ex As Exception
            Me.LBL_SeguroVidaError.Text = ex.Message '"ERROR FIRMANDO SEGURO VIDA"
        End Try
    End Sub
    Private Function BorraFirmaUsada(ByVal RutArchivo)
        Try
            If (System.IO.File.Exists(RutArchivo) = True) Then
                System.IO.File.Delete(RutArchivo)
            End If
        Catch ex As Exception
            'Me.LBL_DatosClienteError.Text = ex.Message
        End Try
    End Function   
    Protected Sub BTN_FirmarSP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_FirmarSP.Click
        ObtieneDatosCliente()
        Try
            If Me._hdnSignatureSP.Value <> Nothing Then
                Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/SeguroProteccion/seguro_proteccion_template.pdf") ' PDF fuente      
                Dim PDFDoc As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_original, PdfDocumentOpenMode.Import)
                Dim PDFNewDoc As PdfSharp.Pdf.PdfDocument = New PdfSharp.Pdf.PdfDocument() 'PDF destino con datos y firma de cliente 
                Dim Pg As Integer       'copio pdf original y lo guardo con otro nombre 
                For Pg = 0 To PDFDoc.Pages.Count - 1
                    PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
                Next
                PDFNewDoc.Save(HttpContext.Current.Server.MapPath("~/Doc/SeguroProteccion/seguro_proteccion_" & Session("rut") & "_" & Session("dv") & ".pdf"))

                Dim ruta_pdf_cliente As String = HttpContext.Current.Server.MapPath("~/Doc/SeguroProteccion/seguro_proteccion_" & Session("rut") & "_" & Session("dv") & ".pdf") ' PDF destino 
                Dim PDFDoc2 As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_cliente, PdfDocumentOpenMode.Modify)
                Dim pp As PdfSharp.Pdf.PdfPage = PDFDoc2.Pages(0) ' pagina 1
                Dim gfx As XGraphics = XGraphics.FromPdfPage(pp)
                Dim font As XFont = New XFont("Times New Roman", 10, XFontStyle.Regular)
                gfx.DrawString(Trim(Session("nombretienda")), font, XBrushes.Black, New XVector(355, 228))
                gfx.DrawString(Trim(ClienteAPaterno) & " " & Trim(ClienteAMaterno) & " " & Trim(ClienteNombres), font, XBrushes.Black, New XVector(65, 278))
                gfx.DrawString(" " & Session("rut") & "-" & Session("dv"), font, XBrushes.Black, New XVector(65, 305))
                gfx.DrawString(Trim(ClienteCalleParticular) & " NRO " & Trim(ClienteNumeroCasa) & " " & Trim(ClienteNumeroDepto), font, XBrushes.Black, New XVector(65, 355))
                gfx.DrawString(Trim(ClienteComuna), font, XBrushes.Black, New XVector(450, 355))

                gfx.DrawString(Trim(ClienteTelefonoCelular), font, XBrushes.Black, New XVector(450, 330))
                If Trim(ClienteTelefonoCelular) = "" Then
                    gfx.DrawString(Trim(ClienteTelefonoFijo), font, XBrushes.Black, New XVector(450, 330))
                End If
                gfx.DrawString(Trim(ClienteCorreoElectronico), font, XBrushes.Black, New XVector(65, 378))
                gfx.DrawString(Trim(ClienteFechaNac), font, XBrushes.Black, New XVector(65, 330))
                gfx.DrawString(Trim(ClienteSexo), font, XBrushes.Black, New XVector(305, 378))
                gfx.DrawString(Trim(ClienteEstadoCivil), font, XBrushes.Black, New XVector(305, 330))

                pp = PDFDoc2.Pages(9) ' Pagina nro. 10
                gfx = XGraphics.FromPdfPage(pp)
                gfx.DrawString(Now.Day & "-" & Now.Month & "-" & Now.Year, font, XBrushes.Black, New XVector(195, 380))
                '****************************************************
                Dim _sImageSP As String = _hdnSignatureSP.Value.Replace("data:image/jpeg;base64,", "")
                Dim _rgbBytesSP As Byte() = Convert.FromBase64String(_sImageSP)
                Dim _sImageFileSP As String = Guid.NewGuid().ToString().Replace("-", String.Empty)
                _sImageFileSP += ".jpg"

                Using imageFileSP As FileStream = New FileStream(Server.MapPath("~/Doc/SeguroProteccion/" + _sImageFileSP), FileMode.Create)
                    imageFileSP.Write(_rgbBytesSP, 0, _rgbBytesSP.Length)
                    imageFileSP.Flush()
                    imageFileSP.Dispose()
                End Using

                Dim XImage As XImage = XImage.FromFile(HttpContext.Current.Server.MapPath("~/Doc/SeguroProteccion/" + _sImageFileSP)) ' inserta firma          
                gfx.DrawImage(XImage, 210, 180, 200, 100)
                PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/SeguroProteccion/seguro_proteccion_" & Session("rut") & "_" & Session("dv") & ".pdf"))

                Dim Img64Sp As String = HttpContext.Current.Server.MapPath("~/Doc/SeguroProteccion/" & _sImageFileSP) 'BORRAR IMAGEN 64                            
                BorraFirmaUsada(Img64Sp)              
                Me.IMG_SeguroProteccionFirmado.Visible = True
                Me.IMG_SeguroProteccionRechazado.Visible = False
                Me.LINK_VerSP.Enabled = True
                Me.BTN_FirmarSP.Enabled = False
                Me.BTN_CAPFirmaSP.Disabled = True
                GrabaFirmaSeguroProteccion()
                If Not IsClientScriptBlockRegistered("popup") Then
                    RegisterClientScriptBlock("popup", "<script language='javascript'>my_window=window.open('/Mantenciones/Mantenciones_VerSeguroProteccion.aspx','VerSeguroProteccion','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()</script>")
                End If
            Else
                Me.LBL_SeguroProteccionError.Text = "FIRMA NO VALIDA, POR FAVOR REINTENTE"
                Me.IMG_SeguroProteccionRechazado.Visible = True
                Me.IMG_SeguroProteccionFirmado.Visible = False
            End If
        Catch ex As Exception
            Me.LBL_SeguroProteccionError.Text = ex.Message
        End Try
    End Sub
    Protected Sub RevisoArchivoContrato()
        Try
            Dim ExisteContrato() = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Doc/Contrato/"), "Contrato_" & Session("rut") & "*.pdf", System.IO.SearchOption.TopDirectoryOnly) 'HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_FamilyShop_" & Session("rut") & "*.pdf")
            If (ExisteContrato.Length > 0) Then
                Me.LINK_VerContrato.Enabled = True
            Else
                Me.LINK_VerContrato.Enabled = False
            End If
        Catch ex As Exception
            Me.LBL_ContratoError.Text = ex.Message
        End Try
    End Sub
    Protected Sub RevisoArchivoSeguroProteccion()
        Try
            Dim ExisteContrato() = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Doc/SeguroProteccion/"), "seguro_proteccion_" & Session("rut") & "*.pdf", System.IO.SearchOption.TopDirectoryOnly) 'HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_FamilyShop_" & Session("rut") & "*.pdf")
            If (ExisteContrato.Length > 0) Then
                Me.LINK_VerSP.Enabled = True
            Else
                Me.LINK_VerSP.Enabled = False
            End If
        Catch ex As Exception
            Me.LBL_SeguroProteccionError.Text = ex.Message
        End Try
    End Sub
    Protected Sub RevisoArchivoSeguroVida()
        Try
            Dim ExisteContrato() = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Doc/SeguroVida/"), "seguro_vida_" & Session("rut") & "*.pdf", System.IO.SearchOption.TopDirectoryOnly) 'HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_FamilyShop_" & Session("rut") & "*.pdf")
            If (ExisteContrato.Length > 0) Then
                Me.LINK_VerSV.Enabled = True
            Else
                Me.LINK_VerSV.Enabled = False
            End If
        Catch ex As Exception
            Me.LBL_SeguroVidaError.Text = ex.Message
        End Try
    End Sub   
    Protected Sub RBL_Documentos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBL_Documentos.SelectedIndexChanged
        Me.Panel_FirmaContrato.Visible = False
        Me.Panel_FirmaSeguroProteccion.Visible = False
        Me.Panel_FirmaSeguroVida.Visible = False
        If Me.RBL_Documentos.SelectedValue = 0 Then 'CONTRATO
            IntroDocumento("CON")
            RevisoArchivoContrato()
        ElseIf Me.RBL_Documentos.SelectedValue = 1 Then 'SEGURO PROTECCION (DESGRAVAMEN)
            IntroDocumento("SDE")
            RevisoArchivoSeguroProteccion()
        ElseIf Me.RBL_Documentos.SelectedValue = 2 Then ' SEGURO VIDA
            IntroDocumento("SVI")
            RevisoArchivoSeguroVida()
        End If
        MultiView_FirmaDocs.ActiveViewIndex = Int32.Parse(Me.RBL_Documentos.SelectedValue)
    End Sub
    Protected Sub IntroDocumento(ByVal TipoDoc As String)
        Dim DataDSIntroDocumento As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            Dim STRIntroDocumento As String = "execute procedure procw_mensaje_firma ('" & RutCliente & "','" & TipoDoc & "')"
            Dim DATAIntroDocumento As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRIntroDocumento, Globales.conn)
            DATAIntroDocumento.Fill(DataDSIntroDocumento, "PRUEBA")
            If TipoDoc = "CON" Then
                If DataDSIntroDocumento.Tables(0).Rows(0)(0) = 0 Then
                    Me.TXT_IntroContrato.Visible = True
                    Me.TXT_IntroContrato.Text = Trim(DataDSIntroDocumento.Tables(0).Rows(0)(2)) + Environment.NewLine + Trim(DataDSIntroDocumento.Tables(0).Rows(0)(3)) + Environment.NewLine + Trim(DataDSIntroDocumento.Tables(0).Rows(0)(4))
                ElseIf DataDSIntroDocumento.Tables(0).Rows(0)(0) = 1 Then
                    Me.TXT_IntroContrato.Visible = True
                    Me.TXT_IntroContrato.Text = Trim(DataDSIntroDocumento.Tables(0).Rows(0)(1)) ' mensaje contrato
                End If
            ElseIf TipoDoc = "SDE" Then
                If DataDSIntroDocumento.Tables(0).Rows(0)(0) = 0 Then
                    Me.TXT_IntroSeguroProteccion.Visible = True
                    Me.TXT_IntroSeguroProteccion.Text = Trim(DataDSIntroDocumento.Tables(0).Rows(0)(2)) + Environment.NewLine + Trim(DataDSIntroDocumento.Tables(0).Rows(0)(3)) + Environment.NewLine + Trim(DataDSIntroDocumento.Tables(0).Rows(0)(4))
                ElseIf DataDSIntroDocumento.Tables(0).Rows(0)(0) = 1 Then
                    Me.TXT_IntroSeguroProteccion.Visible = True
                    Me.TXT_IntroSeguroProteccion.Text = Trim(DataDSIntroDocumento.Tables(0).Rows(0)(1)) ' mensaje seguro proteccion
                End If
            ElseIf TipoDoc = "SVI" Then
                If DataDSIntroDocumento.Tables(0).Rows(0)(0) = 0 Then
                    Me.TXT_IntroSeguroVida.Visible = True
                    Me.TXT_IntroSeguroVida.Text = Trim(DataDSIntroDocumento.Tables(0).Rows(0)(2)) + Environment.NewLine + Trim(DataDSIntroDocumento.Tables(0).Rows(0)(3)) + Environment.NewLine + Trim(DataDSIntroDocumento.Tables(0).Rows(0)(4))
                ElseIf DataDSIntroDocumento.Tables(0).Rows(0)(0) = 1 Then
                    Me.TXT_IntroSeguroVida.Visible = True
                    Me.TXT_IntroSeguroVida.Text = Trim(DataDSIntroDocumento.Tables(0).Rows(0)(1)) ' mensaje seguro vida
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BTN_ContratoAcepta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_ContratoAcepta.Click
        Me.BTN_RechazaContrato.Enabled = False
        Me.Panel_FirmaContrato.Visible = True
    End Sub
    Protected Sub BTN_SeguroProteccionAcepta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_SeguroProteccionAcepta.Click
        Me.BTN_RechazaSeguroProteccion.Enabled = False
        Me.Panel_FirmaSeguroProteccion.Visible = True
    End Sub
    Protected Sub BTN_SeguroVidaAcepta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_SeguroVidaAcepta.Click
        Me.BTN_RechazaSeguroVida.Enabled = False
        Me.Panel_FirmaSeguroVida.Visible = True
    End Sub
    Protected Sub BTN_RechazaSeguroProteccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_RechazaSeguroProteccion.Click
        RechazoDocumento("SDE")
    End Sub
    Protected Sub BTN_RechazaSeguroVida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_RechazaSeguroVida.Click
        RechazoDocumento("SVI")
    End Sub
    Protected Sub BTN_RechazaContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_RechazaContrato.Click
        RechazoDocumento("CON")
    End Sub
    Private Sub RechazoDocumento(ByVal TipoDoc As String)
        Dim DataDSRechazaDoc As New Data.DataSet
        Dim RutCliente, CodSucursal, CodCaja, Responsable As Integer
        RutCliente = Session("rut")
        CodSucursal = Session("sucursal")
        CodCaja = Session("caja")
        Responsable = Session("usuario")
        Try
            Dim STRRechazaDoc As String = "execute procedure procw_rechaza_documento ('" & RutCliente & "','" & TipoDoc & "'," & Responsable & "," & CodSucursal & "," & CodCaja & ")"
            'Me.TXT_IntroSeguroProteccion.Text = STRRechazaDoc
            Dim DATASTRRechazaDoc As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRRechazaDoc, Globales.conn)
            DATASTRRechazaDoc.Fill(DataDSRechazaDoc, "PRUEBA")
            If DataDSRechazaDoc.Tables(0).Rows(0)(0) = 1 Then
                Response.Write("<script>window.alert('ERROR : " & DataDSRechazaDoc.Tables(0).Rows(0)(1) & "');</script>")
                Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
            ElseIf DataDSRechazaDoc.Tables(0).Rows(0)(0) = 0 Then
                Response.Write("<script>window.alert('MENSAJE : " & DataDSRechazaDoc.Tables(0).Rows(0)(1) & "');</script>")
                Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
            End If
        Catch ex As Exception
            Response.Write("<script>window.alert('ERROR : " & ex.Message & "');</script>")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            ValidaDocsAFirmar()
            'Dim RutCliente As String
            'RutCliente = Trim(Session("rut")) + "-" + Trim(Session("dv"))
            'Me.ruttitular.Text = RutCliente           
        End If
    End Sub
    Protected Sub ValidaDocsAFirmar()
        Dim DataDSDocsFirmados As New Data.DataSet
        Dim RutCliente As Integer = Session("rut")
        Try
            Dim STRDocsFirmados As String = "execute procedure procw_doctos_pendientes ('" & RutCliente & "')"
            Dim DATADocsFirmados As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDocsFirmados, Globales.conn)
            DATADocsFirmados.Fill(DataDSDocsFirmados, "PRUEBA")
            If DataDSDocsFirmados.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_DatosClienteError.Visible = True
                Me.LBL_DatosClienteError.Text = DataDSDocsFirmados.Tables(0).Rows(0)(1) ' mensaje de error                  
            Else
                If DataDSDocsFirmados.Tables(0).Rows(0)(2) = 0 Then ' Contrato si 0 = firmado
                    Me.IMG_ContratoFirmado.Visible = True
                    Me.IMG_ContratoRechazado.Visible = False
                    Me.RBL_Documentos.Items(0).Enabled = False
                    Me.RBL_Documentos.Items(1).Enabled = True
                    If DataDSDocsFirmados.Tables(0).Rows(0)(3) = 0 Then ' Seguro Desgravamen si 0 = firmado
                        Me.IMG_SeguroProteccionFirmado.Visible = True
                        Me.IMG_SeguroProteccionRechazado.Visible = False
                        Me.RBL_Documentos.Items(1).Enabled = False
                        If DataDSDocsFirmados.Tables(0).Rows(0)(4) = 0 Then ' Seguro Vida si 0 = firmado
                            Me.IMG_SeguroVidaFirmado.Visible = True
                            Me.IMG_SeguroVidaRechazado.Visible = False
                            Me.RBL_Documentos.Items(2).Enabled = False
                        Else                                             'si es mayor a 0 indica el código del contrato pendiente de firma
                            Me.IMG_SeguroVidaFirmado.Visible = False
                            Me.IMG_SeguroVidaRechazado.Visible = True
                            Me.RBL_Documentos.Items(2).Enabled = True   ' se habilita solo si firmo en contrato y el seg. desgravamen
                        End If
                    Else                                                'si es mayor a 0 indica el código del contrato pendiente de firma
                        Me.IMG_SeguroProteccionFirmado.Visible = False
                        Me.IMG_SeguroProteccionRechazado.Visible = True
                        Me.RBL_Documentos.Items(1).Enabled = True
                    End If
                Else            'SINO TIENE FIRMADO CONTRATO  'si es mayor a 0 indica el código del contrato pendiente de firma
                    Me.IMG_ContratoFirmado.Visible = False
                    Me.IMG_ContratoRechazado.Visible = True
                    Me.RBL_Documentos.Items(0).Enabled = True
                    Me.RBL_Documentos.Items(1).Enabled = False
                    Me.RBL_Documentos.Items(2).Enabled = False
                End If
            End If
        Catch ex As Exception
            Me.LBL_DatosClienteError.Visible = True
            Me.LBL_DatosClienteError.Text = ex.Message
        End Try
    End Sub
    Protected Sub LINK_VerPREContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LINK_VerPREContrato.Click
        ObtieneDatosCliente()
        Try
            Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/Contrato/contrato_template.pdf") ' PDF fuente      
            Dim PDFDoc As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_original, PdfDocumentOpenMode.Import)
            Dim PDFNewDoc As PdfSharp.Pdf.PdfDocument = New PdfSharp.Pdf.PdfDocument() 'PDF destino con datos y firma de cliente 
            Dim Pg As Integer       'copio pdf original y lo guardo con otro nombre 
            For Pg = 0 To PDFDoc.Pages.Count - 1
                PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
            Next
            PDFNewDoc.Save(HttpContext.Current.Server.MapPath("~/Doc/Contrato/Pre_Contrato_" & Session("rut") & "_" & Session("dv") & ".pdf"))

            Dim ruta_pdf_cliente As String = HttpContext.Current.Server.MapPath("~/Doc/Contrato/Pre_Contrato_" & Session("rut") & "_" & Session("dv") & ".pdf") ' PDF destino 
            Dim PDFDoc2 As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_cliente, PdfDocumentOpenMode.Modify)
            Dim pp As PdfSharp.Pdf.PdfPage = PDFDoc2.Pages(0) '= PDFNewDoc.AddPage(PDFDoc.Pages(0))
            Dim gfx As XGraphics = XGraphics.FromPdfPage(pp)
            Dim font As XFont = New XFont("Times New Roman", 12, XFontStyle.Regular)
            gfx.DrawString(Trim(ClienteNombres), font, XBrushes.Black, New XVector(355, 126))
            gfx.DrawString(Trim(ClienteAPaterno) & " " & Trim(ClienteAMaterno), font, XBrushes.Black, New XVector(65, 139))
            gfx.DrawString(" " & Session("rut") & "-" & Session("dv"), font, XBrushes.Black, New XVector(480, 139))
            gfx.DrawString(Trim(ClienteCalleParticular) & " NRO " & Trim(ClienteNumeroCasa) & " " & Trim(ClienteNumeroDepto), font, XBrushes.Black, New XVector(170, 152))
            gfx.DrawString(Trim(ClienteComuna), font, XBrushes.Black, New XVector(80, 166))

            pp = PDFDoc2.Pages(8) ' Pagina nro. 9
            gfx = XGraphics.FromPdfPage(pp)
            gfx.DrawString(Now.Day, font, XBrushes.Black, New XVector(130, 740))
            gfx.DrawString(Now.Month, font, XBrushes.Black, New XVector(170, 740))
            gfx.DrawString(Now.Year, font, XBrushes.Black, New XVector(220, 740))
            PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/Contrato/Pre_Contrato_" & Session("rut") & "_" & Session("dv") & ".pdf"))
            If Not IsClientScriptBlockRegistered("popup") Then
                RegisterClientScriptBlock("popup", "<script language='javascript'>my_window=window.open('/Mantenciones/Mantenciones_VerPreContrato.aspx','VerPREContrato','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()</script>")
            End If
        Catch ex As Exception
            Me.LBL_DatosClienteError.Text = "ERROR PRE-VISUALIZANDO CONTRATO"
        End Try

    End Sub
    Protected Sub BTN_PEPAcepta_Click(sender As Object, e As EventArgs) Handles BTN_PEPAcepta.Click
        ObtieneDatosCliente()
        Try
            If Me._hdnSignature.Value <> Nothing Then
                Dim ruta_pdf_original As String = HttpContext.Current.Server.MapPath("~/Doc/PEP/Declaracion_vinculo_template.pdf") ' PDF fuente      
                Dim PDFDoc As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_original, PdfDocumentOpenMode.Import)
                Dim PDFNewDoc As PdfSharp.Pdf.PdfDocument = New PdfSharp.Pdf.PdfDocument() 'PDF destino con datos y firma de cliente 
                Dim Pg As Integer       'copio pdf original y lo guardo con otro nombre 
                For Pg = 0 To PDFDoc.Pages.Count - 1
                    PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
                Next
                PDFNewDoc.Save(HttpContext.Current.Server.MapPath("~/Doc/PEP/Declaracion_vinculo_" & Session("rut") & "_" & Session("dv") & ".pdf"))

                Dim ruta_pdf_cliente As String = HttpContext.Current.Server.MapPath("~/Doc/PEP/Declaracion_vinculo_" & Session("rut") & "_" & Session("dv") & ".pdf") ' PDF destino 
                Dim PDFDoc2 As PdfSharp.Pdf.PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(ruta_pdf_cliente, PdfDocumentOpenMode.Modify)
                Dim pp As PdfSharp.Pdf.PdfPage = PDFDoc2.Pages(0) '= PDFNewDoc.AddPage(PDFDoc.Pages(0))
                Dim gfx As XGraphics = XGraphics.FromPdfPage(pp)
                Dim font As XFont = New XFont("Times New Roman", 12, XFontStyle.Regular)
                gfx.DrawString(Trim(ClienteNombres), font, XBrushes.Black, New XVector(355, 126))
                gfx.DrawString(Trim(ClienteAPaterno) & " " & Trim(ClienteAMaterno), font, XBrushes.Black, New XVector(65, 139))
                gfx.DrawString(" " & Session("rut") & "-" & Session("dv"), font, XBrushes.Black, New XVector(480, 139))
                gfx.DrawString(Trim(ClienteCalleParticular) & " NRO " & Trim(ClienteNumeroCasa) & " " & Trim(ClienteNumeroDepto), font, XBrushes.Black, New XVector(170, 152))
                gfx.DrawString(Trim(ClienteComuna), font, XBrushes.Black, New XVector(80, 166))

                'pp = PDFDoc2.Pages(8) ' Pagina nro. 9
                'gfx = XGraphics.FromPdfPage(pp)
                gfx.DrawString(Now.Day, font, XBrushes.Black, New XVector(130, 740))
                gfx.DrawString(Now.Month, font, XBrushes.Black, New XVector(170, 740))
                gfx.DrawString(Now.Year, font, XBrushes.Black, New XVector(220, 740))
                '****************************************************
                Dim _sImage As String = _hdnSignature.Value.Replace("data:image/jpeg;base64,", "")
                Dim _rgbBytes As Byte() = Convert.FromBase64String(_sImage)
                Dim _sImageFile As String = Guid.NewGuid().ToString().Replace("-", String.Empty)
                _sImageFile += ".jpg"

                Using imageFile As FileStream = New FileStream(Server.MapPath("~/Doc/PEP/" + _sImageFile), FileMode.Create)
                    imageFile.Write(_rgbBytes, 0, _rgbBytes.Length)
                    imageFile.Flush()
                    imageFile.Dispose()
                End Using

                Dim XImage As XImage = XImage.FromFile(HttpContext.Current.Server.MapPath("~/Doc/PEP/" + _sImageFile)) ' inserta firma          
                gfx.DrawImage(XImage, 210, 535, 200, 100)
                PDFDoc2.Save(HttpContext.Current.Server.MapPath("~/Doc/PEP/Declaracion_vinculo_" & Session("rut") & "_" & Session("dv") & ".pdf"))

                Dim Img64PEP As String = HttpContext.Current.Server.MapPath("~/Doc/PEP/" & _sImageFile) 'BORRAR IMAGEN 64 
                BorraFirmaUsada(Img64PEP)
                Me.IMG_PEPFirmado.Visible = True
                Me.IMG_PEPRechazado.Visible = False
                Me.LINK_VerPEP.Enabled = True
                Me.BTN_FirmarPEP.Enabled = False
                Me.BTN_CAPFirmaCON.Disabled = True
                GrabaFirmaPEP()
                If Not IsClientScriptBlockRegistered("popup") Then
                    RegisterClientScriptBlock("popup", "<script language='javascript'>my_window=window.open('/Mantenciones/Mantenciones_VerPEP.aspx','VerPEP','top=120 ,left=240,width=600,height=580',scrollbars='NO',resizable='NO',toolbar='NO');my_window.focus()</script>")
                End If
            Else
                Me.LBL_PEPError.Text = "FIRMA NO VALIDA, POR FAVOR REINTENTE"
                Me.IMG_PEPRechazado.Visible = True
                Me.IMG_PEPFirmado.Visible = False
            End If
        Catch ex As Exception
            Me.LBL_PEPError.Text = ex.Message
            Me.IMG_PEPRechazado.Visible = True
        End Try
    End Sub
    Private Sub GrabaFirmaPEP()
        Dim DataDSGrabaFirmaPEP As New Data.DataSet
        Dim RutCliente, CodSucursal, CodCaja, Responsable As Integer
        Dim CodAutorizacion As String
        RutCliente = Session("rut")
        CodSucursal = Session("sucursal")
        CodCaja = Session("caja")
        Responsable = Session("usuario")
        CodAutorizacion = "" ' despues se dara algoritmo para este item 
        Try
            Dim STRGrabaFirmaPEP As String = "execute procedure procw_guarda_documento ('" & RutCliente & "','PEP',current year to day," & Responsable & "," & CodSucursal & "," & CodCaja & ",'" & CodAutorizacion & "')"
            Dim DATAGrabaFirmaPEP As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRGrabaFirmaPEP, Globales.conn)
            DATAGrabaFirmaPEP.Fill(DataDSGrabaFirmaPEP, "PRUEBA")
            If DataDSGrabaFirmaPEP.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_PEPError.Visible = True
                Me.LBL_PEPError.Text = DataDSGrabaFirmaPEP.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.LBL_PEPError.Visible = True
                Me.LBL_PEPError.Text = DataDSGrabaFirmaPEP.Tables(0).Rows(0)(1) ' mensaje exito
                ValidaDocsAFirmar()
            End If
        Catch ex As Exception
            Me.LBL_PEPError.Visible = True
            Me.LBL_PEPError.Text = "ERROR GUARDANDO PEP"
        End Try
    End Sub
    Protected Sub RevisoArchivoPEP()
        Try
            Dim ExistePEP() = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Doc/PEP/"), "Declaracion_vinculo_" & Session("rut") & "*.pdf", System.IO.SearchOption.TopDirectoryOnly) 'HttpContext.Current.Server.MapPath("~/Doc/Contrato/Contrato_FamilyShop_" & Session("rut") & "*.pdf")
            If (ExistePEP.Length > 0) Then
                Me.LINK_VerPEP.Enabled = True
            Else
                Me.LINK_VerPEP.Enabled = False
            End If
        Catch ex As Exception
            Me.LBL_PEPError.Text = ex.Message
        End Try
    End Sub
End Class
