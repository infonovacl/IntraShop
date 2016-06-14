Partial Class Mantencion_DatosClientes
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.TXT_Rut.Text = Session("rut")
            Me.TXT_Dv.Text = Session("dv")
            LlenaDDLEstadoCivil()
            LlenaDDLRegion()
            LlenaDDLDiaPago()
            ObtieneDatosCliente()
        End If
    End Sub
    Private Sub LlenaDDLComuna(ByVal region As Integer, ByVal CODcomuna As Integer, ByVal tipocomuna As String)
        Dim DataDSComuna As New Data.DataSet
        DataDSComuna.Clear()
        Try
            Dim STRComuna As String = "execute procedure procw_lista_comunas (" & region & ")"
            Dim DATAComuna As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRComuna, conn)
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
            MsgBox(EX)
            'Response.Write("<script>window.alert('Error al Obtener Datos DatosClientees');</script>")
        End Try
    End Sub
    Private Sub LlenaDDLEstadoCivil()
        Dim DataDSEstadoCivil As New Data.DataSet
        Try
            Dim STREstadoCivil As String = "execute procedure procw_listador01 ('ECIV')"
            Dim DATAEstadoCivil As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STREstadoCivil, conn)
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
            Dim DATADiaPago As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDiaPago, conn)
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
            Dim DATARegion As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRRegion, conn)
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
            MsgBox(EX)
            'Response.Write("<script>window.alert('Error al Obtener Datos DatosClientees');</script>")
        End Try
    End Sub
    Private Sub ObtieneDatosCliente()
        Dim DataDSDatosCliente As New Data.DataSet
        Dim RutCliente As Integer = Session("rut")
        Try
            Dim STRDatosCliente As String = "execute procedure procw_cons_mant ('" & RutCliente & "' )"
            Dim DATADatosCliente As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDatosCliente, conn)
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
                    Me.TXT_Nombres.Text = DataDSDatosCliente.Tables(0).Rows(0)(4)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                    Me.TXT_APaterno.Text = ""
                Else
                    Me.TXT_APaterno.Text = DataDSDatosCliente.Tables(0).Rows(0)(5)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                    Me.TXT_AMaterno.Text = ""
                Else
                    Me.TXT_AMaterno.Text = DataDSDatosCliente.Tables(0).Rows(0)(6)
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
                    'Me.DDL_EstadoCivil.SelectedIndex = DDL_EstadoCivil.Items.IndexOf(DDL_EstadoCivil.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(9)))
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(10) Is System.DBNull.Value Then 'calle
                    Me.TXT_CalleParticular.Text = ""
                Else
                    Me.TXT_CalleParticular.Text = DataDSDatosCliente.Tables(0).Rows(0)(10)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(11) Is System.DBNull.Value Then 'n casa
                    Me.TXT_NumeroCasa.Text = ""
                Else
                    Me.TXT_NumeroCasa.Text = DataDSDatosCliente.Tables(0).Rows(0)(11)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(12) Is System.DBNull.Value Then 'n depto
                    Me.TXT_NumeroDepto.Text = ""
                Else
                    Me.TXT_NumeroDepto.Text = DataDSDatosCliente.Tables(0).Rows(0)(12)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(13) Is System.DBNull.Value Then 'n depto
                    Me.TXT_VillaPoblacion.Text = ""
                Else
                    Me.TXT_VillaPoblacion.Text = DataDSDatosCliente.Tables(0).Rows(0)(13)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(14) Is System.DBNull.Value Then 'altura/calle
                    Me.TXT_AlturaCalle.Text = ""
                Else
                    Me.TXT_AlturaCalle.Text = DataDSDatosCliente.Tables(0).Rows(0)(14)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(15) Is System.DBNull.Value Then 'REGION CLIENTE
                    Me.DDL_RegionCliente.SelectedValue = 0
                Else
                    Me.DDL_RegionCliente.SelectedValue = DDL_RegionCliente.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(15)).Value
                End If
                '*************************LLENA COMUNA 
                LlenaDDLComuna(DataDSDatosCliente.Tables(0).Rows(0)(15), DataDSDatosCliente.Tables(0).Rows(0)(16), "cliente")
                '****************************************
                If DataDSDatosCliente.Tables(0).Rows(0)(17) Is System.DBNull.Value Then 'n telefono
                    Me.TXT_TelefonoFijo.Text = ""
                Else
                    Me.TXT_TelefonoFijo.Text = DataDSDatosCliente.Tables(0).Rows(0)(17)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(18) Is System.DBNull.Value Then 'n telefono
                    Me.TXT_TelefonoCelular.Text = ""
                Else
                    Me.TXT_TelefonoCelular.Text = DataDSDatosCliente.Tables(0).Rows(0)(18)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(19) Is System.DBNull.Value Then 'n telefono
                    Me.TXT_ReferenciaNombre.Text = ""
                Else
                    Me.TXT_ReferenciaNombre.Text = DataDSDatosCliente.Tables(0).Rows(0)(19)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(20) Is System.DBNull.Value Then 'REGION CLIENTE
                    Me.DDL_ReferenciaRegion.SelectedValue = 0
                Else
                    Me.DDL_ReferenciaRegion.SelectedValue = DDL_ReferenciaRegion.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(20)).Value
                End If
                '*************************LLENA REGION/COMUNA REFERENCIA
                LlenaDDLComuna(DataDSDatosCliente.Tables(0).Rows(0)(20), DataDSDatosCliente.Tables(0).Rows(0)(21), "referencia")
                '****************************************
                If DataDSDatosCliente.Tables(0).Rows(0)(22) Is System.DBNull.Value Then 'REFERENCIA FONO      TIPO         
                    Me.RBL_ReferenciaTipoTelefono.SelectedValue = 0
                Else
                    Me.RBL_ReferenciaTipoTelefono.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(22)).Selected = True
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(23) Is System.DBNull.Value Then 'n telefono referencia
                    Me.TXT_ReferenciaTelefono.Text = ""
                Else
                    Me.TXT_ReferenciaTelefono.Text = DataDSDatosCliente.Tables(0).Rows(0)(23)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(24) Is System.DBNull.Value Then 'nombre empleador
                    Me.TXT_EmpleadorNombre.Text = ""
                Else
                    Me.TXT_EmpleadorNombre.Text = DataDSDatosCliente.Tables(0).Rows(0)(24)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(25) Is System.DBNull.Value Then 'direccion empleador
                    Me.TXT_EmpleadorDireccion.Text = ""
                Else
                    Me.TXT_EmpleadorDireccion.Text = DataDSDatosCliente.Tables(0).Rows(0)(25)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(26) Is System.DBNull.Value Then 'numero direccion empleador
                    Me.TXT_EmpleadorNumero.Text = ""
                Else
                    Me.TXT_EmpleadorNumero.Text = DataDSDatosCliente.Tables(0).Rows(0)(26)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(27) Is System.DBNull.Value Then 'oficina/depto empleador
                    Me.TXT_EmpleadorOficina.Text = ""
                Else
                    Me.TXT_EmpleadorOficina.Text = DataDSDatosCliente.Tables(0).Rows(0)(27)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(28) Is System.DBNull.Value Then 'REGION EMPLEADOR
                    Me.DDL_EmpleadorRegion.SelectedValue = 0
                Else
                    Me.DDL_EmpleadorRegion.SelectedValue = DDL_EmpleadorRegion.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(28)).Value
                End If
                '*************************LLENA REGION/COMUNA EMPLEADOR
                LlenaDDLComuna(DataDSDatosCliente.Tables(0).Rows(0)(28), DataDSDatosCliente.Tables(0).Rows(0)(29), "empleador")
                '****************************************
                If DataDSDatosCliente.Tables(0).Rows(0)(30) Is System.DBNull.Value Then 'fono empleador
                    Me.TXT_EmpleadorTelefono.Text = ""
                Else
                    Me.TXT_EmpleadorTelefono.Text = DataDSDatosCliente.Tables(0).Rows(0)(30)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(31) Is System.DBNull.Value Then 'anexo empleador
                    Me.TXT_EmpleadorAnexo.Text = ""
                Else
                    Me.TXT_EmpleadorAnexo.Text = DataDSDatosCliente.Tables(0).Rows(0)(31)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(32) Is System.DBNull.Value Then 'cargo empleador
                    Me.TXT_EmpleadorCargo.Text = ""
                Else
                    Me.TXT_EmpleadorCargo.Text = DataDSDatosCliente.Tables(0).Rows(0)(32)
                End If

                'If DataDSDatosCliente.Tables(0).Rows(0)(33) Is System.DBNull.Value Then    'DIA DE PAGO
                ' Me.DDL_DiaPago.SelectedValue = 0                                          'en listado hay 10-20-30 , pero en base hay con 5, 15 , tira error al no encontrar dia
                ' Else
                ' Me.DDL_DiaPago.SelectedValue = DDL_DiaPago.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(33)).Value
                ' End If
                If DataDSDatosCliente.Tables(0).Rows(0)(34) Is System.DBNull.Value Then 'cargo empleador
                    Me.TXT_LugarEnvioEC.Text = ""
                Else
                    Me.TXT_LugarEnvioEC.Text = DataDSDatosCliente.Tables(0).Rows(0)(34)
                End If
                If DataDSDatosCliente.Tables(0).Rows(0)(35) Is System.DBNull.Value Then 'cargo empleador
                    Me.TXT_CorreoElectronico.Text = ""
                Else
                    Me.TXT_CorreoElectronico.Text = DataDSDatosCliente.Tables(0).Rows(0)(35)
                End If
            End If
        Catch EX As Exception
            MsgBox(EX)
            'Response.Write("<script>window.alert('Error al Obtener Datos DatosClientees');</script>")
        End Try
    End Sub
    Protected Sub DDL_RegionCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_RegionCliente.SelectedIndexChanged
        LlenaDDLComuna(Me.DDL_RegionCliente.SelectedValue, "0", "cliente")
    End Sub
    Protected Sub DDL_ReferenciaRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_ReferenciaRegion.SelectedIndexChanged
        LlenaDDLComuna(Me.DDL_ReferenciaRegion.SelectedValue, "0", "referencia")
    End Sub
    Protected Sub DDL_EmpleadorRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_EmpleadorRegion.SelectedIndexChanged
        LlenaDDLComuna(Me.DDL_EmpleadorRegion.SelectedValue, "0", "empleador")
    End Sub
    Protected Sub BTN_Cerrar_Click(sender As Object, e As EventArgs) Handles BTN_Cerrar.Click

    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click

    End Sub
End Class
