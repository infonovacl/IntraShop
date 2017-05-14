Partial Class Solicitudes_RevisaVerificacion
    Inherits System.Web.UI.Page
    Dim Ciudad As String
    Dim Direccion As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load       
        If Not IsPostBack Then
            ObtieneConsultasDataBusiness()
            HabilitaVerificacion()
        End If
    End Sub
    Private Sub HabilitaVerificacion()
        Dim DataDSLevantaRechazo As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            DataDSLevantaRechazo.Clear()
            Dim STRLevantaRechazo As String = "execute procedure procw_habi_verif ('" & RutCliente & "' )"
            Dim DATALevantaRechazo As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLevantaRechazo, Globales.conn)
            DATALevantaRechazo.Fill(DataDSLevantaRechazo, "PRUEBA")
            If DataDSLevantaRechazo.Tables(0).Rows(0)(0) = 1 Then
                Me.BTN_AntecComerciales.Enabled = False   ''DESHABILITA BOTON 
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = DataDSLevantaRechazo.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.BTN_AntecComerciales.Enabled = True
            End If
        Catch EX As Exception
            Me.LBL_ConsultasDBError.Visible = True
            Me.LBL_ConsultasDBError.Text = EX.Message
        End Try
    End Sub
    Private Sub ObtieneConsultasDataBusiness()
        Dim DataDSConsultasDB As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try          
            DataDSConsultasDB.Clear()
            Dim STRConsultasDB As String = "execute procedure procw_cons_db ('" & RutCliente & "' )"
            Dim DATAConsultasDB As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRConsultasDB, Globales.conn)
            DATAConsultasDB.Fill(DataDSConsultasDB, "PRUEBA")
            If DataDSConsultasDB.Tables(0).Rows(0)(0) = 1 Then
                Me.Panel_ConsultasDB.Visible = False
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = DataDSConsultasDB.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.Panel_ConsultasDB.Visible = True
                Me.LBL_ConsultasDBError.Visible = False
                Me.Grilla_ConsultasDB.DataSource = DataDSConsultasDB.Tables(0).DefaultView
                Me.Grilla_ConsultasDB.DataBind()
            End If
        Catch EX2 As Exception
            Me.LBL_ConsultasDBError.Visible = True
            Me.LBL_ConsultasDBError.Text = EX2.Message
        End Try
    End Sub
    'Protected Sub BTN_Cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_Cerrar.Click
    'Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
    'End Sub
    Protected Sub BTN_AntecComerciales_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_AntecComerciales.Click
        Me.BTN_AntecComerciales.Enabled = False
        Dim RutCliente As String
        RutCliente = Session("rut") + Session("dv")
        Dim respuesta As Integer = RevisaSinacofi(RutCliente)
        '''''If respuesta = 1 Then
        ObtieneConsultasDataBusiness()

        '----------------------- agregado AA
        Dim DataDSVerificacion As New Data.DataSet
        Dim CodSucursal, CodCaja, Responsable As Integer
        Dim Antecedentes As String
        Dim RutClienteSinDv As Integer
        RutClienteSinDv = Session("rut")
        CodSucursal = Session("sucursal")
        CodCaja = Session("caja")
        Responsable = Session("usuario")
        Antecedentes = Session("Antec")

        Try
            DataDSVerificacion.Clear()
            Dim STRVerificacion As String = "execute procedure procw_solicitud (" & RutClienteSinDv & "," & CodSucursal & "," & CodCaja & ",current year to day," & Responsable & ",'" & Antecedentes & "')"
            Dim DATAVerificacion As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRVerificacion, Globales.conn)
            DATAVerificacion.Fill(DataDSVerificacion, "PRUEBA")
            If DataDSVerificacion.Tables(0).Rows(0)(0) = 1 Then
                Me.BTN_AntecComerciales.Enabled = False                
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = DataDSVerificacion.Tables(0).Rows(0)(1) ' mensaje de error          
            End If
        Catch EX As Exception
            Me.LBL_ConsultasDBError.Visible = True
            Me.LBL_ConsultasDBError.Text = EX.Message
        End Try
        '----------------------------------------
        Me.LBL_ConsultasDBError.Visible = True
        Me.LBL_ConsultasDBError.Text = "CONSULTA FINALIZADA"      
    End Sub
    Private Function RevisaSinacofi(ByVal Rutdigito As String) As Integer
        Dim Sxml, Antec, URL, VNombre, RutResp, sexo, direcc As String
        Dim Vedad As Integer
        Dim RetornoWS As Integer
        Dim myErr As Object
        Dim Vfecnac, fechadetalle As String
        Dim protestos, morosidad, consultas, Monto As Integer
        Dim oHttReq As MSXML.XMLHTTPRequest
        Dim XMLRetorno As String
        Dim objNodeListP As MSXML.IXMLDOMNodeList
        Dim node As MSXML.IXMLDOMNode
        Dim XMLRespuesta As MSXML.DOMDocument
        Dim XMLConsulta As MSXML.DOMDocument
        Dim Soap As String = "<?xml version=""1.0"" encoding=""utf-8""?> <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://infomax.cl/webservices/""><soapenv:Header/><soapenv:Body><web:ejecutaServicio><web:reqmsg><XCReqQry inst=""0770"" clnt=""761181386"" user=""761181386"" pswd=""sinacofi"" flag=""00"" rutc=""761181386"" rutu=""27"" tipc=""N"" rqid=""0"" rsid=""0""> <XCReqQrySvc srvc=""ADVANCED"" vers=""00"" prm1=""" & Rutdigito & """ prm2=""""/></XCReqQry></web:reqmsg></web:ejecutaServicio> </soapenv:Body></soapenv:Envelope>"
        Dim DATADSDB, DATADSErr, DATADSCli2, DATADSDet, DATADSDet1, DATADSDet2, DATADSDBDet As New Data.DataSet

        Antec = ""
        VNombre = ""

        Dim FecNac As Date
        Dim Edad As String
        Dim NombreRazonSocialXML As String
        Dim ScoreXML As String
        Dim FechaNacXML As String
        Dim EdadXML As String

        'Reviso si hay consultas el mismo dia
        Try
            Dim SQLDB = "SELECT DISTINCT antecedentes, edad, fec_nac , otros_datos1,score FROM consulta_db WHERE rut_cliente = " & Session("rut") & " AND fecha = today"
            Dim DATADB As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(SQLDB, Globales.conn)
            DATADB.Fill(DATADSDB, "PRUEBA")
            If DATADSDB.Tables(0).Rows.Count > 0 Then
                If DATADSDB.Tables(0).Rows(0)(0) Is System.DBNull.Value Then
                    Antec = ""
                Else
                    Antec = DATADSDB.Tables(0).Rows(0)(0)
                    Edad = DATADSDB.Tables(0).Rows(0)(1)
                    FecNac = DATADSDB.Tables(0).Rows(0)(2)
                    VNombre = DATADSDB.Tables(0).Rows(0)(3)
                    Session("Score") = DATADSDB.Tables(0).Rows(0)(4)
                End If
            Else
                Antec = ""
            End If
        Catch EX As Exception
            'MsgBox(EX.Message)
        End Try
        If Antec = "" Then ' SI NO REGISTRA CONSULTAS HOY
            XMLConsulta = New MSXML.DOMDocument
            oHttReq = New MSXML.XMLHTTPRequest
            'URL = "http://168.231.200.31/InfoMAXWS/InfoMAX.asmx" 'Desarrollo
            URL = "https://informes.infomax.cl/InfoMAXWS/InfoMAX.asmx" ' Produccion
            ' cargar el código SOAP para El Webservice
            XMLConsulta.loadXML(Soap)
            ' Enviar el comando de forma síncrona (se espera a que se reciba la respuesta)
            oHttReq.open("POST", URL, False)
            oHttReq.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
            oHttReq.setRequestHeader("SOAPAction", "http://infomax.cl/webservices/ejecutaServicio")
            Sxml = XMLConsulta.xml
            Try
                oHttReq.send(Sxml)
                XMLRetorno = oHttReq.responseText
            Catch Ex As Exception
                XMLRetorno = Ex.Message
            End Try
            XMLRespuesta = New MSXML.DOMDocument
            XMLRespuesta.loadXML(XMLRetorno)
            If (XMLRespuesta.parseError.errorCode <> 0) Then
                myErr = XMLRespuesta.parseError
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = myErr.srcText
                Me.LBL_ConsultasDBError.Text = "ERROR en respuesta del Servicio"
                ' grabo en tabla de errores
                Try
                    Dim SQLDBerr = "INSERT INTO consulta_dberr (rut_cliente,fecha,hora,motivo,error,mensaje,sucursal,caja,rut_resp)"
                    SQLDBerr = SQLDBerr & " VALUES ( " & Session("rut") & ",  current year to day , current hour to second , 'VER'," & XMLRespuesta.parseError.errorCode & ",'" & myErr.srcText & "'," & Session("sucursal") & "," & Session("caja") & "," & Session("usuario") & ")"
                    Dim DATADBerr As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(SQLDBerr, Globales.conn)
                    DATADBerr.Fill(DATADSErr, "PRUEBA")
                Catch EX As Exception
                    MsgBox(EX.Message)
                End Try
                Return -1
            Else
                objNodeListP = XMLRespuesta.selectNodes("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry")
                For Each node In objNodeListP
                    RetornoWS = node.selectSingleNode("@stcd").text
                    Me.LBL_ConsultasDBError.Visible = True
                    Me.LBL_ConsultasDBError.Text = node.selectSingleNode("@stds").text
                Next node
                If RetornoWS = 0 Then
                    RutResp = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//RUT").text
                    ScoreXML = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//Score").text
                    protestos = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//Protestos/NumProtestos").text
                    morosidad = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//Protestos/NumMOrosidades").text
                    objNodeListP = XMLRespuesta.getElementsByTagName("soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//XCInformacionComplementaria/ConsultasRut")
                    If objNodeListP.length >= 0 Then
                        consultas = objNodeListP.length
                    Else
                        consultas = 0
                    End If
                    NombreRazonSocialXML = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//NombreRSocial").text
                    FechaNacXML = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//FechaNacimiento").text
                    EdadXML = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//Edad").text
                    direcc = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//DireccionPpal").text
                    sexo = XMLRespuesta.selectSingleNode("/soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//CodSexo").text
                    direcc = CambiaN(direcc)
                    NombreRazonSocialXML = CambiaN(NombreRazonSocialXML)
                    BuscaCiudad(direcc)
                Else
                    ' grabo en tabla de errores
                    Try
                        Dim SQLDBerr = "INSERT INTO consulta_dberr (rut_cliente,fecha,hora,motivo,error,mensaje,sucursal,caja,rut_resp)"
                        SQLDBerr = SQLDBerr & " VALUES ( " & Session("rut") & ",  current year to day , current hour to second , 'VER'," & RetornoWS & ",'" & Me.LBL_ConsultasDBError.Text & "'," & Session("sucursal") & "," & Session("caja") & "," & Session("usuario") & ")"
                        Dim DATADBerr As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(SQLDBerr, Globales.conn)
                        DATADBerr.Fill(DATADSErr, "PRUEBA")
                    Catch EX As Exception
                        '   MsgBox(EX.Message)
                    End Try
                    Return -1
                End If
            End If
            If protestos > 0 Or morosidad > 0 Then
                Session("Antec") = "SI"
            Else
                Session("Antec") = "NO"
            End If
            If FechaNacXML = "" Or Trim(FechaNacXML) = "" Then
                FechaNacXML = "01-01-1900"
                Vfecnac = FechaNacXML
            Else
                FechaNacXML = ArmaFecha(FechaNacXML)
                Vfecnac = FechaNacXML
                FecNac = Vfecnac
            End If
            VNombre = NombreRazonSocialXML
            VNombre = CambiaN(VNombre)
            Desarma(VNombre)
            Session("Score") = ScoreXML
            If EdadXML = "" Then
                Edad = "0"
                Vedad = 0
            Else
                Edad = EdadXML
                Vedad = EdadXML
            End If
            Try  ' la variable sesion "FechaTrx" es today u otra fecha ??
                Dim SQLDB = "INSERT INTO consulta_db (rut_cliente,fecha,hora,motivo,score,edad,antecedentes,otros_datos1,otros_datos2,otros_datos3,fec_nac,sucursal,caja,rut_resp,origen)"
                SQLDB = SQLDB & " VALUES ( " & Session("rut") & ",current year to day , current hour to second , 'VER'," & ScoreXML & "," & EdadXML & ",'" & Session("Antec") & "','" & VNombre & "','" & Direccion & "','" & Ciudad & "','" & Vfecnac & "'," & Session("sucursal") & "," & Session("caja") & "," & Session("usuario") & ",'S')"
                Dim DATADB As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(SQLDB, Globales.conn)
                DATADB.Fill(DATADSCli2, "PRUEBA")
            Catch EX As Exception
                'MsgBox(EX.Message)
            End Try
            If Vedad = 0 Or Format(CType(Vfecnac, Date), "dd/MM/yyyy") = "01-01-1900" Or Vfecnac = "" Then
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = "Cliente No Registra Edad ..."
                '' IngresaRechazo(Session("rut"), FechaActual, HoraActual, "Cliente No Registra Edad ", Vedad) ''************** Falta funcion IngresaRechazo
                Return -1
            End If
            If protestos > 0 Then
                ' protestos
                Monto = 0
                objNodeListP = XMLRespuesta.selectNodes("soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//XCInformacionComplementaria/Protestos/Detalle")
                For Each node In objNodeListP
                    fechadetalle = ArmaFecha(node.selectSingleNode("@FechaProtesto").text)
                    Monto = Mid(node.selectSingleNode("@Monto").text, 1, InStr(1, node.selectSingleNode("@Monto").text, "."))
                    Try
                        Dim SQLDBDet = "INSERT INTO consulta_dbdet (rut_cliente,fecha,hora,motivo,tipo,fechacons,empresa,desc1,desc2)"
                        SQLDBDet = SQLDBDet & " VALUES ( " & Session("rut") & ",  current year to day , current hour to second , 'VER','PR','" & fechadetalle & "','" & CambiaN(node.selectSingleNode("@NomAcre").text) & "','" & node.selectSingleNode("@TipDoc").text & "','" & Monto & "' )"
                        Dim DATADBDet As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(SQLDBDet, Globales.conn)
                        DATADBDet.Fill(DATADSDet, "PRUEBA")
                    Catch EX As Exception
                        '       MsgBox(EX.Message)
                    End Try
                Next
            End If
            If morosidad > 0 Then
                Monto = 0
                objNodeListP = XMLRespuesta.selectNodes("soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//XCInformacionComplementaria/Morosidad/Detalle")
                For Each node In objNodeListP
                    fechadetalle = ArmaFecha(node.selectSingleNode("@FechaVenc").text)
                    Monto = Mid(node.selectSingleNode("@Monto").text, 1, InStr(1, node.selectSingleNode("@Monto").text, "."))
                    Try
                        Dim SQLDBDet1 = "INSERT INTO consulta_dbdet (rut_cliente,fecha,hora,motivo,tipo,fechacons,empresa,desc1,desc2)"
                        SQLDBDet1 = SQLDBDet1 & " VALUES ( " & Session("rut") & ",  current year to day , current hour to second , 'VER','MO','" & fechadetalle & "','" & CambiaN(node.selectSingleNode("@NomAcre").text) & "','" & node.selectSingleNode("@TipCred").text & "','" & Monto & "' )"
                        Dim DATADBDet1 As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(SQLDBDet1, Globales.conn)
                        DATADBDet1.Fill(DATADSDet1, "PRUEBA")
                    Catch EX As Exception
                        '      MsgBox(EX.Message)
                    End Try
                Next
            End If
            Session("ConsDB") = 0
            If consultas > 0 Then
                Session("ConsDB") = consultas
                objNodeListP = XMLRespuesta.selectNodes("soap:Envelope/soap:Body/ejecutaServicioResponse/ejecutaServicioResult/XCRspQry//XCInformacionComplementaria/ConsultasRut")
                For Each node In objNodeListP
                    fechadetalle = ArmaFecha(node.selectSingleNode("@FechaCons").text)
                    Try
                        Dim SQLDBDet2 = "INSERT INTO consulta_dbdet (rut_cliente,fecha,hora,motivo,tipo,fechacons,empresa,desc1)"
                        SQLDBDet2 = SQLDBDet2 & " VALUES ( " & Session("rut") & ",current year to day, current hour to second , 'VER','CN','" & fechadetalle & "','" & CambiaN(node.selectSingleNode("@Instit").text) & "','" & CambiaN(node.selectSingleNode("@Instit").text) & "' )"
                        Dim DATADBDet2 As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(SQLDBDet2, Globales.conn)
                        DATADBDet2.Fill(DATADSDet2, "PRUEBA")
                    Catch EX As Exception
                        '     MsgBox(EX.Message)
                    End Try
                Next
            End If
            If Session("Antec") = "NO" Then
                ' saca los datos
                Desarma(VNombre)
                Return 0
            Else
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = "Cliente Registra Antecedentes Comerciales "
                Return 1
            End If
        Else
            ' busco la cantidad de consultas
            Try
                Dim SQLDBDet = "SELECT count(*) FROM consulta_dbdet WHERE rut_cliente = " & Session("rut") & " AND fecha =  current year to day  AND tipo = 'CN' "
                Dim DATADBDet As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(SQLDBDet, Globales.conn)
                DATADBDet.Fill(DATADSDBDet, "PRUEBA")
                If DATADSDBDet.Tables(0).Rows.Count = 0 Or DATADSDBDet.Tables(0).Rows(0)(0) Is System.DBNull.Value Then
                    Session("ConsDB") = 0
                Else
                    Session("ConsDB") = DATADSDBDet.Tables(0).Rows(0)(0)
                End If
            Catch EX As Exception
                'MsgBox(EX.Message)
            End Try
            Vedad = Edad
            Vfecnac = FecNac
            If Vedad = 0 Or Format(CType(Vfecnac, Date), "dd/MM/yyyy") = "01-01-1900" Or Vfecnac = "" Then
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = "Cliente No Registra Edad ..."
                ''  IngresaRechazo(Session("rut"), FechaActual, HoraActual, "Cliente No Registra Edad ", Vedad) ''************** Falta funcion IngresaRechazo
                Return -1
            End If
            If Antec = "NO" Then
                ' saca los datos
                Desarma(VNombre)
                Return 0
            Else
                Me.LBL_ConsultasDBError.Visible = True
                Me.LBL_ConsultasDBError.Text = "Cliente Registra Antecedentes Comerciales "
                Return 1
            End If
        End If
    End Function
    Private Function BuscaCiudad(ByVal DireccCompleta As String)
        Dim guion, i, ultimo As Integer
        For i = 1 To Len(DireccCompleta)
            guion = InStr(i, DireccCompleta, "-")
            If guion > 0 Then
                ultimo = guion
            End If
        Next
        guion = ultimo
        If guion > 0 Then
            Ciudad = Trim(Mid(DireccCompleta, guion + 1)) 'ciudad
            Direccion = Mid(DireccCompleta, 1, guion - 1) 'direccion
        End If
        Return ""
    End Function
    Function ArmaFecha(ByVal Texto As String)
        Dim Fecha As String
        If Texto = "" Then
            Fecha = "01-01-1900"
        Else
            Fecha = Mid(Texto, 7, 2) & "-" & Mid(Texto, 5, 2) & "-" & Mid(Texto, 1, 4)
        End If
        Return Fecha
    End Function
    Function CambiaN(ByVal NombreconN As String)
        Dim NombresinN As String
        Dim NombresinComa As String
        Dim NombreconComa As String
        Dim i, n As Integer

        NombresinN = ""
        NombreconN = UCase(NombreconN)
        For i = 1 To Len(NombreconN)
            n = InStr(i, NombreconN, "Ñ")
            If n > 0 And n = i Then
                NombresinN = NombresinN & "N"
            Else
                NombresinN = NombresinN & Mid(NombreconN, i, 1)
            End If
        Next
        NombresinComa = ""
        NombreconComa = UCase(NombresinN)
        For i = 1 To Len(NombreconComa)
            n = InStr(i, NombreconComa, "'")
            If n > 0 And n = i Then
                NombresinComa = NombresinComa & " "
            Else
                NombresinComa = NombresinComa & Mid(NombreconComa, i, 1)
            End If
        Next
        Return NombresinComa
    End Function
    Private Function Desarma(ByVal NombreCompleto As String)
        Dim uno, dos, tres, mas As Integer
        Dim VNom, VAPat, VAMat As String

        uno = InStr(1, NombreCompleto, " ")
        If uno > 0 Then
            dos = InStr(uno + 1, NombreCompleto, " ")
            If dos > 0 Then
                tres = InStr(dos + 1, NombreCompleto, " ")
                If tres > 0 Then    'nombre completo		
                    mas = InStr(tres + 1, NombreCompleto, " ", )
                    If mas <= 0 Then
                        VAMat = Mid(NombreCompleto, tres + 1)
                        VAPat = Mid(NombreCompleto, dos + 1, tres - dos)
                        VNom = Mid(NombreCompleto, 1, dos - 1)
                    Else 'vienen cuatro nombres
                        VAMat = Mid(NombreCompleto, tres + 1)
                        VAPat = Mid(NombreCompleto, dos + 1, mas - tres + 1)
                        VNom = Mid(NombreCompleto, 1, uno - 1)
                    End If
                Else
                    VAMat = Mid(NombreCompleto, dos + 1)
                    VAPat = Mid(NombreCompleto, uno + 1, dos - uno)
                    VNom = Mid(NombreCompleto, 1, uno - 1)
                End If
            Else
                VAPat = Mid(NombreCompleto, uno + 1)
                VNom = Mid(NombreCompleto, 1, uno - 1)
            End If
        End If
        Return ""
    End Function
End Class
