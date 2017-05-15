﻿Partial Class Mantencion_DatosClientes_ValidaCel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load    
        If Not IsPostBack Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "Popup", "<script>detectarPopupBlocker();</script>")
            'If IsDBNull(Session("rut")) = True Or Session("rut") = "" Then
            ' Response.Write("<script>window.alert('ERROR: SESION DE CONSULTA DE CLIENTE HA EXPIRADO, DEBE CONSULTAR NUEVAMENTE');</script>")
            ' Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
            'Else
            Me.TXT_Rut.Text = Session("rut")
            Me.TXT_Dv.Text = Session("dv")
            LlenaDDLEstadoCivil()
            LlenaDDLRegion()
            LlenaDDLDiaPago()
            LlenaDDLLugaresEnvio()
            ObtieneDatosCliente()
            '--------------------------------------
            Me.ButtonAut.Attributes.Add("OnClick", "Iniciar ( );")
            Dim RutCliente As String
            RutCliente = Trim(Session("rut")) + "-" + Trim(Session("dv"))
            Me.ruttitular.Text = RutCliente
            '--------------------------------------
            Me.TXT_TelefonoFijo.MaxLength = CType(Me.LBL_MaximoDigitoTelefono.Text, Integer)
            Me.LBL_DatosClienteError.Visible = True
        End If
        'End If
        Me.LBL_DatosClienteError.Text = "POR FAVOR ACTUALICE NUMERO TELEFONO CELULAR CLIENTE"
    End Sub
    Protected Sub DDL_RegionCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_RegionCliente.SelectedIndexChanged
        If Me.DDL_RegionCliente.Items(0).Text = "SIN REGION" Then
            Me.DDL_RegionCliente.Items.RemoveAt(0)
        End If
        If Me.DDL_RegionCliente.SelectedValue <> 0 Then
            LlenaDDLComuna(Me.DDL_RegionCliente.SelectedValue, "0", "cliente")
        ElseIf Me.DDL_RegionCliente.SelectedValue = 0 Then
            Me.DDL_ComunaCliente.Items.Insert(0, "SIN COMUNA")
        End If
    End Sub
    Protected Sub DDL_ReferenciaRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_ReferenciaRegion.SelectedIndexChanged
        If Me.DDL_ReferenciaRegion.Items(0).Text = "SIN REGION" Then
            Me.DDL_ReferenciaRegion.Items.RemoveAt(0)
        End If
        If Me.DDL_ReferenciaRegion.SelectedValue <> 0 Then
            LlenaDDLComuna(Me.DDL_ReferenciaRegion.SelectedValue, "0", "referencia")
        ElseIf Me.DDL_ReferenciaRegion.SelectedValue = 0 Then
            Me.DDL_ReferenciaComuna.Items.Insert(0, "SIN COMUNA")
        End If
    End Sub
    Protected Sub DDL_EmpleadorRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_EmpleadorRegion.SelectedIndexChanged
        If Me.DDL_EmpleadorRegion.Items(0).Text = "SIN REGION" Then
            Me.DDL_EmpleadorRegion.Items.RemoveAt(0)
        End If
        If Me.DDL_EmpleadorRegion.SelectedValue <> 0 Then
            LlenaDDLComuna(Me.DDL_EmpleadorRegion.SelectedValue, "0", "empleador")
        ElseIf Me.DDL_EmpleadorRegion.SelectedValue = 0 Then
            Me.DDL_EmpleadorComuna.Items.Insert(0, "SIN COMUNA")
        End If
    End Sub
    Protected Sub BTN_Cerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_Cerrar.Click
        'CIERRA VENTANA POPUP
        Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
    End Sub
    Private Sub LlenaDDLComuna(ByVal region As Integer, ByVal CODcomuna As Integer, ByVal tipocomuna As String)
        Dim DataDSComuna As New Data.DataSet
        DataDSComuna.Clear()
        Try
            Dim STRComuna As String = "execute procedure procw_lista_comunas (" & region & ")"
            Dim DATAComuna As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRComuna, Globales.conn)
            DATAComuna.Fill(DataDSComuna, "PRUEBA")
            If tipocomuna = "cliente" Then
                Me.DDL_ComunaCliente.DataTextField = DataDSComuna.Tables(0).Columns("column4").ToString()
                Me.DDL_ComunaCliente.DataValueField = DataDSComuna.Tables(0).Columns("column3").ToString()
                Me.LBL_MaximoDigitoTelefono.Text = DataDSComuna.Tables(0).Rows(0)(4)
                Me.DDL_ComunaCliente.DataSource = DataDSComuna.Tables(0)
                Me.DDL_ComunaCliente.DataBind()
                If CODcomuna > 0 Then
                    Me.DDL_ComunaCliente.SelectedValue = DDL_ComunaCliente.Items.FindByValue(CODcomuna).Value
                End If
            ElseIf tipocomuna = "referencia" Then
                Me.DDL_ReferenciaComuna.DataTextField = DataDSComuna.Tables(0).Columns("column4").ToString()
                Me.DDL_ReferenciaComuna.DataValueField = DataDSComuna.Tables(0).Columns("column3").ToString()
                Me.DDL_ReferenciaComuna.DataSource = DataDSComuna.Tables(0)
                Me.DDL_ReferenciaComuna.DataBind()
                If CODcomuna > 0 Then
                    Me.DDL_ReferenciaComuna.SelectedValue = DDL_ReferenciaComuna.Items.FindByValue(CODcomuna).Value
                End If
            ElseIf tipocomuna = "empleador" Then
                Me.DDL_EmpleadorComuna.DataTextField = DataDSComuna.Tables(0).Columns("column4").ToString()
                Me.DDL_EmpleadorComuna.DataValueField = DataDSComuna.Tables(0).Columns("column3").ToString()
                Me.DDL_EmpleadorComuna.DataSource = DataDSComuna.Tables(0)
                Me.DDL_EmpleadorComuna.DataBind()
                If CODcomuna > 0 Then
                    Me.DDL_EmpleadorComuna.SelectedValue = DDL_EmpleadorComuna.Items.FindByValue(CODcomuna).Value
                End If
            End If
        Catch EX As Exception
            ' MsgBox(EX)
            'Response.Write("<script>window.alert('Error al Obtener Datos DatosClientees');</script>")
        End Try
    End Sub
    Private Sub LlenaDDLEstadoCivil()
        Dim DataDSEstadoCivil As New Data.DataSet
        Try
            Dim STREstadoCivil As String = "execute procedure procw_listador01 ('ECIV')"
            Dim DATAEstadoCivil As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STREstadoCivil, Globales.conn)
            DATAEstadoCivil.Fill(DataDSEstadoCivil, "PRUEBA")
            Me.DDL_EstadoCivil.DataTextField = DataDSEstadoCivil.Tables(0).Columns("column4").ToString()
            Me.DDL_EstadoCivil.DataValueField = DataDSEstadoCivil.Tables(0).Columns("column3").ToString()
            Me.DDL_EstadoCivil.DataSource = DataDSEstadoCivil.Tables(0)
            Me.DDL_EstadoCivil.DataBind()
        Catch EX As Exception
            'MsgBox(EX)
        End Try
    End Sub
    Private Sub LlenaDDLDiaPago()
        Dim DataDSDiaPago As New Data.DataSet
        Try
            Dim STRDiaPago As String = "execute procedure procw_listador01 ('DPAG')"
            Dim DATADiaPago As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDiaPago, Globales.conn)
            DATADiaPago.Fill(DataDSDiaPago, "PRUEBA")
            Me.DDL_DiaPago.DataTextField = DataDSDiaPago.Tables(0).Columns("column4").ToString()
            Me.DDL_DiaPago.DataValueField = DataDSDiaPago.Tables(0).Columns("column3").ToString()
            Me.DDL_DiaPago.DataSource = DataDSDiaPago.Tables(0)
            Me.DDL_DiaPago.DataBind()
        Catch EX As Exception
            'MsgBox(EX)
        End Try
    End Sub
    Private Sub LlenaDDLRegion()
        Dim DataDSRegion As New Data.DataSet
        Try
            Dim STRRegion As String = "execute procedure procw_listador01 ('REGI')"
            Dim DATARegion As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRRegion, Globales.conn)
            DATARegion.Fill(DataDSRegion, "PRUEBA")
            Me.DDL_RegionCliente.DataTextField = DataDSRegion.Tables(0).Columns("column4").ToString()
            Me.DDL_RegionCliente.DataValueField = DataDSRegion.Tables(0).Columns("column3").ToString()
            Me.DDL_RegionCliente.DataSource = DataDSRegion.Tables(0)
            Me.DDL_RegionCliente.DataBind()
            Me.DDL_ReferenciaRegion.DataTextField = DataDSRegion.Tables(0).Columns("column4").ToString()
            Me.DDL_ReferenciaRegion.DataValueField = DataDSRegion.Tables(0).Columns("column3").ToString()
            Me.DDL_ReferenciaRegion.DataSource = DataDSRegion.Tables(0)
            Me.DDL_ReferenciaRegion.DataBind()
            Me.DDL_EmpleadorRegion.DataTextField = DataDSRegion.Tables(0).Columns("column4").ToString()
            Me.DDL_EmpleadorRegion.DataValueField = DataDSRegion.Tables(0).Columns("column3").ToString()
            Me.DDL_EmpleadorRegion.DataSource = DataDSRegion.Tables(0)
            Me.DDL_EmpleadorRegion.DataBind()
        Catch EX As Exception
            ' MsgBox(EX)    
        End Try
    End Sub
    Private Sub LlenaDDLLugaresEnvio()
        Dim DataDSLugarEnvio As New Data.DataSet
        Try
            Dim STRLugarEnvio As String = "execute procedure procw_listador01 ('LENV')"
            Dim DATALugarEnvio As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLugarEnvio, Globales.conn)
            DATALugarEnvio.Fill(DataDSLugarEnvio, "PRUEBA")
            Me.DDL_LugarEnvio.DataTextField = DataDSLugarEnvio.Tables(0).Columns("column4").ToString()
            Me.DDL_LugarEnvio.DataValueField = DataDSLugarEnvio.Tables(0).Columns("column3").ToString()
            Me.DDL_LugarEnvio.DataSource = DataDSLugarEnvio.Tables(0)
            Me.DDL_LugarEnvio.DataBind()
        Catch EX As Exception
            'MsgBox(EX)
        End Try
    End Sub
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
                Me.LBL_DatosClienteError.Visible = False
                If DataDSDatosCliente.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                    Me.TXT_TiendaOrigen.Text = ""
                Else
                    Me.TXT_TiendaOrigen.Text = DataDSDatosCliente.Tables(0).Rows(0)(2)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                    Me.LBL_FolioContrato.Text = ""
                Else
                    Me.LBL_FolioContrato.Text = DataDSDatosCliente.Tables(0).Rows(0)(3)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                    Me.TXT_Nombres.Text = ""
                Else
                    Me.TXT_Nombres.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(4))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                    Me.TXT_APaterno.Text = ""
                Else
                    Me.TXT_APaterno.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(5))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                    Me.TXT_AMaterno.Text = ""
                Else
                    Me.TXT_AMaterno.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(6))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(7) Is System.DBNull.Value Then 'sexo                  
                    Me.RBL_Sexo.SelectedValue = 0
                Else
                    Me.RBL_Sexo.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(7)).Selected = True
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(8) Is System.DBNull.Value Then ' fecha nacimiento
                    Me.TXT_FechaNac.Text = ""
                Else
                    Me.TXT_FechaNac.Text = DataDSDatosCliente.Tables(0).Rows(0)(8)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(9) Is System.DBNull.Value Then 'estado civil                  
                    Me.DDL_EstadoCivil.SelectedValue = 0
                Else
                    Me.DDL_EstadoCivil.SelectedValue = DDL_EstadoCivil.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(9)).Value
                    Try
                        If Trim(Me.DDL_EstadoCivil.SelectedItem.Text) = "SIN DATOS" Then
                            Me.DDL_EstadoCivil.SelectedIndex = 0
                            If DDL_EstadoCivil.Items.Count > 4 Then
                                DDL_EstadoCivil.Items.RemoveAt(4)
                            End If
                        ElseIf Trim(Me.DDL_EstadoCivil.SelectedItem.Text) <> "SIN DATOS" Then
                            If DDL_EstadoCivil.Items.Count > 4 Then
                                DDL_EstadoCivil.Items.RemoveAt(4)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(10) Is System.DBNull.Value Then 'calle
                    Me.TXT_CalleParticular.Text = ""
                Else
                    Me.TXT_CalleParticular.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(10))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(11) Is System.DBNull.Value Then 'n casa
                    Me.TXT_NumeroCasa.Text = ""
                Else
                    Me.TXT_NumeroCasa.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(11))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(12) Is System.DBNull.Value Then 'n depto
                    Me.TXT_NumeroDepto.Text = ""
                Else
                    Me.TXT_NumeroDepto.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(12))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(13) Is System.DBNull.Value Then 'n depto
                    Me.TXT_VillaPoblacion.Text = ""
                Else
                    Me.TXT_VillaPoblacion.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(13))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(14) Is System.DBNull.Value Then 'altura/calle
                    Me.TXT_AlturaCalle.Text = ""
                Else
                    Me.TXT_AlturaCalle.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(14))
                End If
                Dim RegionCliente As Integer
                If DataDSDatosCliente.Tables(0).Rows(0)(15) Is System.DBNull.Value Or DataDSDatosCliente.Tables(0).Rows(0)(15) = 0 Then 'REGION CLIENTE
                    Me.DDL_RegionCliente.Items.Insert(0, "SIN REGION")
                    RegionCliente = 0
                Else
                    Me.DDL_RegionCliente.SelectedValue = DDL_RegionCliente.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(15)).Value
                    RegionCliente = DataDSDatosCliente.Tables(0).Rows(0)(15)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(17) Is System.DBNull.Value Then 'n telefono fijo
                    Me.TXT_TelefonoFijo.Text = ""
                Else
                    Me.TXT_TelefonoFijo.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(17))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(18) Is System.DBNull.Value Then 'n telefono celular
                    Me.TXT_TelefonoCelular.Text = ""
                Else
                    Me.TXT_TelefonoCelular.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(18))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(19) Is System.DBNull.Value Then 'n telefono referencia
                    Me.TXT_ReferenciaNombre.Text = ""
                Else
                    Me.TXT_ReferenciaNombre.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(19))
                End If
                Dim RegionReferencia As Integer
                If DataDSDatosCliente.Tables(0).Rows(0)(20) Is System.DBNull.Value Or DataDSDatosCliente.Tables(0).Rows(0)(20) = 0 Then 'REGION REFERENCIA
                    Me.DDL_ReferenciaRegion.Items.Insert(0, "SIN REGION")
                    RegionReferencia = 0
                Else
                    Me.DDL_ReferenciaRegion.SelectedValue = DDL_ReferenciaRegion.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(20)).Value
                    RegionReferencia = Trim(DataDSDatosCliente.Tables(0).Rows(0)(20))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(22) Is System.DBNull.Value Then 'REFERENCIA FONO      TIPO         
                    Me.RBL_ReferenciaTipoTelefono.SelectedValue = 0
                Else
                    Me.RBL_ReferenciaTipoTelefono.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(22)).Selected = True
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(23) Is System.DBNull.Value Then 'n telefono referencia
                    Me.TXT_ReferenciaTelefono.Text = ""
                Else
                    Me.TXT_ReferenciaTelefono.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(23))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(24) Is System.DBNull.Value Then 'nombre empleador
                    Me.TXT_EmpleadorNombre.Text = ""
                Else
                    Me.TXT_EmpleadorNombre.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(24))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(25) Is System.DBNull.Value Then 'direccion empleador
                    Me.TXT_EmpleadorDireccion.Text = ""
                Else
                    Me.TXT_EmpleadorDireccion.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(25))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(26) Is System.DBNull.Value Then 'numero direccion empleador
                    Me.TXT_EmpleadorNumero.Text = ""
                Else
                    Me.TXT_EmpleadorNumero.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(26))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(27) Is System.DBNull.Value Then 'oficina/depto empleador
                    Me.TXT_EmpleadorOficina.Text = ""
                Else
                    Me.TXT_EmpleadorOficina.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(27))
                End If
                Dim RegionEmpleador As Integer
                If DataDSDatosCliente.Tables(0).Rows(0)(28) Is System.DBNull.Value Or DataDSDatosCliente.Tables(0).Rows(0)(28) = 0 Then 'REGION EMPLEADOR
                    Me.DDL_EmpleadorRegion.Items.Insert(0, "SIN REGION")
                    RegionEmpleador = 0
                Else
                    Me.DDL_EmpleadorRegion.SelectedValue = DDL_EmpleadorRegion.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(28)).Value
                    RegionEmpleador = DataDSDatosCliente.Tables(0).Rows(0)(28)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(30) Is System.DBNull.Value Then 'fono empleador
                    Me.TXT_EmpleadorTelefono.Text = ""
                Else
                    Me.TXT_EmpleadorTelefono.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(30))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(31) Is System.DBNull.Value Then 'anexo empleador
                    Me.TXT_EmpleadorAnexo.Text = ""
                Else
                    Me.TXT_EmpleadorAnexo.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(31))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(32) Is System.DBNull.Value Then 'cargo empleador
                    Me.TXT_EmpleadorCargo.Text = ""
                Else
                    Me.TXT_EmpleadorCargo.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(32))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(33) Is System.DBNull.Value Then    'DIA DE PAGO
                    Me.DDL_DiaPago.SelectedValue = 0
                Else
                    Me.DDL_DiaPago.SelectedValue = DDL_DiaPago.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(33)).Value
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(34) Is System.DBNull.Value Then 'LUGAR ENVIO 
                    Me.DDL_LugarEnvio.SelectedValue = "0"
                Else
                    If DataDSDatosCliente.Tables(0).Rows(0)(34) <> 3 Then
                        Me.DDL_LugarEnvio.Items.Insert(0, DataDSDatosCliente.Tables(0).Rows(0)(34)) ' INSERTA OPCION NO PRESENTE EN LUGARES DE ENVIO INICIAL
                    End If
                    Me.DDL_LugarEnvio.SelectedValue = DDL_LugarEnvio.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(34)).Value
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(35) Is System.DBNull.Value Then 'mail
                    Me.TXT_CorreoElectronico.Text = ""
                Else
                    Me.TXT_CorreoElectronico.Text = Trim(DataDSDatosCliente.Tables(0).Rows(0)(35))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(36) Is System.DBNull.Value Then 'edad
                    Me.TXT_Edad.Text = ""
                Else
                    Me.TXT_Edad.Text = CType(DataDSDatosCliente.Tables(0).Rows(0)(36), Integer)
                End If
                '*************************LLENA COMUNA 
                Dim ComunaCliente As Integer
                If DataDSDatosCliente.Tables(0).Rows(0)(16) Is System.DBNull.Value Then
                    ComunaCliente = 0
                Else
                    ComunaCliente = CType(DataDSDatosCliente.Tables(0).Rows(0)(16), Integer)
                End If
                LlenaDDLComuna(RegionCliente, ComunaCliente, "cliente")
                '****************************************               
                '*************************LLENA REGION/COMUNA REFERENCIA
                Dim ComunaReferencia As Integer
                If DataDSDatosCliente.Tables(0).Rows(0)(21) Is System.DBNull.Value Then
                    ComunaReferencia = 0
                Else
                    ComunaReferencia = CType(DataDSDatosCliente.Tables(0).Rows(0)(21), Integer)
                End If
                LlenaDDLComuna(RegionReferencia, ComunaReferencia, "referencia")
                '****************************************
                '*************************LLENA REGION/COMUNA EMPLEADOR
                Dim ComunaEmpleador As Integer
                If DataDSDatosCliente.Tables(0).Rows(0)(29) Is System.DBNull.Value Then
                    ComunaEmpleador = 0
                Else
                    ComunaEmpleador = CType(DataDSDatosCliente.Tables(0).Rows(0)(29), Integer)
                End If
                LlenaDDLComuna(RegionEmpleador, ComunaEmpleador, "empleador")
                '****************************************
            End If
            Session("comuna") = Me.DDL_ComunaCliente.SelectedItem.Text
            Session("estadocivil") = Me.DDL_EstadoCivil.SelectedItem.Text
            Session("sexo") = Me.RBL_Sexo.SelectedItem.Text.ToUpper
            Me.TXT_TelefonoCelular.Text = ""
            Me.TXT_TelefonoCelular.Focus()          
        Catch EX As Exception
            Me.LBL_DatosClienteError.Visible = True
            Me.LBL_DatosClienteError.Text = EX.Message
        End Try
    End Sub
    Protected Sub BTN_Grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_Grabar.Click
        If TXT_TelefonoCelular.Text = "11111111" Or TXT_TelefonoCelular.Text = "22222222" Or TXT_TelefonoCelular.Text = "33333333" Or
            TXT_TelefonoCelular.Text = "44444444" Or TXT_TelefonoCelular.Text = "55555555" Or TXT_TelefonoCelular.Text = "66666666" Or
            TXT_TelefonoCelular.Text = "77777777" Or TXT_TelefonoCelular.Text = "88888888" Or TXT_TelefonoCelular.Text = "99999999" Or
            TXT_TelefonoCelular.Text = "00000000" Or TXT_TelefonoCelular.Text = "" Or TXT_TelefonoCelular.Text.Length < 8 Then
            LBL_DatosClienteError.Visible = True
            LBL_DatosClienteError.Text = "NUMERO CELULAR INGRESADO NO ES VALIDO, POR FAVOR REINTENTE"
            TXT_TelefonoCelular.Focus()
        Else
            If Page.IsValid = True Then              
                    Try
                        Dim DATADSModificaDatosPersonalesPopUp As New Data.DataSet
                        DATADSModificaDatosPersonalesPopUp.Clear()
                        Dim RutCliente, usuario, codigotienda As Integer
                        RutCliente = Session("rut")
                        usuario = Session("usuario")
                    codigotienda = Session("sucursal")
                    Dim region_empleador, region_cliente, region_referencia As Integer
                    If Me.DDL_RegionCliente.SelectedValue = "SIN REGION" Then
                        region_cliente = 0
                    Else
                        region_cliente = DDL_RegionCliente.SelectedValue
                    End If
                    If Me.DDL_ReferenciaRegion.SelectedValue = "SIN REGION" Then
                        region_referencia = 0
                    Else
                        region_referencia = DDL_ReferenciaRegion.SelectedValue
                    End If
                    If Me.DDL_EmpleadorRegion.SelectedValue = "SIN REGION" Then
                        region_empleador = 0
                    Else
                        region_empleador = DDL_EmpleadorRegion.SelectedValue
                    End If
                    Dim STRModificaDatosPersonales As String = "execute procedure procw_mod_cliente  ('" & RutCliente & "','" _
                                                            & Trim(Me.TXT_Nombres.Text.ToUpper) & "','" & Trim(Me.TXT_APaterno.Text.ToUpper) & "','" & Trim(Me.TXT_AMaterno.Text.ToUpper) & "','" & Me.RBL_Sexo.SelectedValue & "','" _
                                                            & Me.DDL_EstadoCivil.SelectedValue & "','" & Trim(Me.TXT_CalleParticular.Text.ToUpper) & "','" & Trim(Me.TXT_NumeroCasa.Text.ToUpper) & "','" & Trim(Me.TXT_NumeroDepto.Text.ToUpper) & "','" _
                                                            & Trim(Me.TXT_VillaPoblacion.Text.ToUpper) & "','" & Trim(Me.TXT_AlturaCalle.Text.ToUpper) & "','" & region_cliente & "','" & Me.DDL_ComunaCliente.SelectedValue & "','" _
                                                            & Trim(Me.TXT_TelefonoFijo.Text.ToUpper) & "','" & Trim(Me.TXT_TelefonoCelular.Text.ToUpper) & "','" & Trim(Me.TXT_ReferenciaNombre.Text.ToUpper) & "','" & region_referencia & "','" _
                                                            & Me.DDL_ReferenciaComuna.Text.ToUpper & "','" & Me.RBL_ReferenciaTipoTelefono.SelectedValue & "','" & Me.TXT_ReferenciaTelefono.Text.ToUpper & "','" & Me.TXT_EmpleadorNombre.Text.ToUpper & "','" _
                                                            & Trim(Me.TXT_EmpleadorDireccion.Text.ToUpper) & "','" & Trim(Me.TXT_EmpleadorNumero.Text.ToUpper) & "','" & Trim(Me.TXT_EmpleadorOficina.Text.ToUpper) & "','" & region_empleador & "','" _
                                                            & Me.DDL_EmpleadorComuna.SelectedValue & "','" & Trim(Me.TXT_EmpleadorTelefono.Text.ToUpper) & "','" & Trim(Me.TXT_EmpleadorAnexo.Text.ToUpper) & "','" & Trim(Me.TXT_EmpleadorCargo.Text.ToUpper) & "','" _
                                                            & Trim(Me.TXT_CorreoElectronico.Text.ToUpper) & "','" & usuario & "','" & codigotienda & "')"
                    Dim DATAModificaDatosPersonales As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRModificaDatosPersonales, Globales.conn)
                    Me.TXT_PROC.Visible = False
                    Me.TXT_PROC.Text = STRModificaDatosPersonales.ToString
                    DATAModificaDatosPersonales.Fill(DATADSModificaDatosPersonalesPopUp, "PRUEBA")
                    If DATADSModificaDatosPersonalesPopUp.Tables(0).Rows(0)(0) = 1 Then
                        Me.LBL_DatosClienteError.Visible = True
                        Me.LBL_DatosClienteError.Text = DATADSModificaDatosPersonalesPopUp.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.LBL_DatosClienteError.Visible = True
                        Me.LBL_DatosClienteError.Text = DATADSModificaDatosPersonalesPopUp.Tables(0).Rows(0)(1) ' mensaje exito
                        Session("estadocivil") = Trim(Me.DDL_EstadoCivil.SelectedItem.Text)
                        Dim TipoConsulta As String                       
                        TipoConsulta = Request.QueryString("tipocon")
                        If TipoConsulta = "bloqueo" Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType(), "Bloqueo", "<script> LLamaBloqueos(); </script>")
                        ElseIf TipoConsulta = "verificacion" Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType(), "Verificacion", "<script> LLamaVerificacion(); </script>")
                        ElseIf TipoConsulta = "tarjeta" Then
                            Me.ButtonAut.Visible = True
                            Me.ButtonAut.Enabled = True ' HABILITA BOTON AUTENTIA
                            Me.ButtonAut.Focus()                          
                        End If
                        End If
                Catch EX As Exception
                    Me.LBL_DatosClienteError.Visible = True
                    Me.LBL_DatosClienteError.Text = EX.Message
                End Try               
            Else
                Me.LBL_DatosClienteError.Visible = True
                Me.LBL_DatosClienteError.Text = "HAY DATOS ERRONEOS EN FORMULARIO"
            End If
            End If            
    End Sub
    Function ValidacionSecundaria(ByRef valido As String) As String
        Dim flag As Integer = 0
        If TXT_TelefonoCelular.Text = "11111111" Or TXT_TelefonoCelular.Text = "22222222" Or TXT_TelefonoCelular.Text = "33333333" Or
            TXT_TelefonoCelular.Text = "44444444" Or TXT_TelefonoCelular.Text = "55555555" Or TXT_TelefonoCelular.Text = "66666666" Or
            TXT_TelefonoCelular.Text = "77777777" Or TXT_TelefonoCelular.Text = "88888888" Or TXT_TelefonoCelular.Text = "99999999" Or
            TXT_TelefonoCelular.Text = "00000000" Then
            LBL_DatosClienteError.Visible = True
            LBL_DatosClienteError.Text = "Numero Celular Cliente Ingresado no es Válido"
            TXT_TelefonoCelular.Focus()
            flag = 1
        End If
        If Me.RBL_ReferenciaTipoTelefono.SelectedValue = "C" Then
            If TXT_ReferenciaTelefono.Text = "11111111" Or TXT_ReferenciaTelefono.Text = "22222222" Or TXT_ReferenciaTelefono.Text = "33333333" Or
                TXT_ReferenciaTelefono.Text = "44444444" Or TXT_ReferenciaTelefono.Text = "55555555" Or TXT_ReferenciaTelefono.Text = "66666666" Or
                TXT_ReferenciaTelefono.Text = "77777777" Or TXT_ReferenciaTelefono.Text = "88888888" Or TXT_ReferenciaTelefono.Text = "99999999" Or
                TXT_ReferenciaTelefono.Text = "00000000" Then
                LBL_DatosClienteError.Visible = True
                LBL_DatosClienteError.Text = "Numero Celular Referencia Ingresado no es Válido"
                TXT_ReferenciaTelefono.Focus()
                flag = 1
            End If
        ElseIf Me.RBL_ReferenciaTipoTelefono.SelectedValue = "F" Then
            If TXT_ReferenciaTelefono.Text.Length <> CType(Me.LBL_MaximoDigitoTelefono.Text, Integer) Then
                LBL_DatosClienteError.Visible = True
                LBL_DatosClienteError.Text = "Numero Fijo Referencia Ingresado no es Válido"
                TXT_ReferenciaTelefono.Focus()
                flag = 1
            End If
        End If
        If Me.TXT_ReferenciaNombre.Text <> "" And (Me.DDL_ReferenciaRegion.SelectedIndex = -1 Or Me.DDL_ReferenciaComuna.SelectedIndex = -1) Then
            LBL_DatosClienteError.Visible = True
            LBL_DatosClienteError.Text = "Debe Ingresar Region y Comuna de Referencia"
            DDL_ReferenciaRegion.Focus()
            flag = 1
        End If
        If Me.TXT_EmpleadorNombre.Text <> "" And (Me.DDL_EmpleadorRegion.SelectedIndex = -1 Or Me.DDL_EmpleadorComuna.SelectedIndex = -1) Then
            LBL_DatosClienteError.Visible = True
            LBL_DatosClienteError.Text = "Debe Ingresar Region y Comuna de Empleador"
            DDL_EmpleadorRegion.Focus()
            flag = 1
        End If
        If Me.DDL_RegionCliente.SelectedIndex = -1 Or Me.DDL_ComunaCliente.SelectedIndex = -1 Then
            LBL_DatosClienteError.Visible = True
            LBL_DatosClienteError.Text = "Debe Ingresar Region y Comuna de Cliente"
            DDL_RegionCliente.Focus()
            flag = 1
        End If
        If Me.DDL_EstadoCivil.SelectedItem.Text = "SIN DATOS" Then
            LBL_DatosClienteError.Visible = True
            LBL_DatosClienteError.Text = "Debe Ingresar un Estado Civil válido"
            DDL_EstadoCivil.Focus()
            flag = 1
        End If
        If flag = 0 Then
            valido = "OK"
        Else
            valido = "ERROR"
        End If
        Return valido
    End Function
    Protected Sub ButtonAut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAut.Click
        If Me.ErcRes.Value = "0" Then
            GestionAutentia()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "Tarjeta", "<script> LLamaTarjeta(); </script>")
        Else
            Me.LBL_DatosClienteError.Visible = True
            Me.LBL_DatosClienteError.Text = "ERROR EN VALIDACION DE HUELLA DIGITAL"
            GestionAutentia()
            Me.ButtonAut.Enabled = False
        End If

    End Sub
    Private Sub GestionAutentia()
        Dim DataDSIngresaGestionAutentia As New Data.DataSet
        Dim RutCliente, CodSucursal, CodCaja, Responsable As Integer
        RutCliente = Session("rut")
        CodSucursal = Session("sucursal")
        CodCaja = Session("caja")
        Responsable = Session("usuario")
        Try
            Dim STRIngresaGestionAutentia As String = "INSERT INTO auten_huella (rut_cliente,auten_fec,auten_hor,auten_tip,auten_res,auten_det,auten_usu,auten_lin,auten_audit,auten_desc,auten_suc,auten_caj) VALUES " &
                                                      " ('" & RutCliente & "',current year to day,current hour to second,'TAR'," & Me.ErcRes.Value & "," & Me.ErcDet.Value & "," & Responsable & ",'0','" & Me.NroAudit.Value & "','" & Me.Mensaje.Value & "'," & CodSucursal & "," & CodCaja & ")"
            Dim DATASTRRechazaDoc As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRIngresaGestionAutentia, Globales.conn)
            DATASTRRechazaDoc.Fill(DataDSIngresaGestionAutentia, "PRUEBA")
        Catch ex As Exception
            Response.Write("<script>window.alert('ERROR GESTION AUTENTIA : " & ex.Message & "');</script>")
        End Try
    End Sub
End Class