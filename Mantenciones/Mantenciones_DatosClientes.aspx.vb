Partial Class Mantencion_DatosClientes
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ObtieneDatosCliente()
        Else
            MsgBox("PRIMERA CARGA")
        End If

    End Sub
    Private Sub ObtieneDatosCliente()
        Dim DataDSDatosCliente As New Data.DataSet
        Dim RutCliente As Integer = Session("rut")
        Try
            Dim STRDatosCliente As String = "execute procedure procw_cons_mant ('" & RutCliente & "' )"
            Dim DATADatosCliente As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDatosCliente, conn)
            DATADatosCliente.Fill(DataDSDatosCliente, "PRUEBA")
            If DataDSDatosCliente.Tables(0).Rows(0)(0) = 1 Then
                ' Me.TBL_DatosCliente.Visible = False
                Me.LBL_DatosClienteError.Visible = True
                Me.LBL_DatosClienteError.Text = DataDSDatosCliente.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                '  Me.TBL_DatosCliente.Visible = True
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
                    ' DDL_EstadoCivil.ClearSelection()
                    'Dim estadocivil As String = DataDSDatosCliente.Tables(0).Rows(0)(9)
                    'DDL_EstadoCivil.SelectedValue = DDL_EstadoCivil.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(9)).Value
                    'Me.DDL_EstadoCivil.SelectedIndex = DDL_EstadoCivil.Items.IndexOf(DDL_EstadoCivil.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(9)))
                    ' Me.DDL_EstadoCivil.Items.FindByValue(DataDSDatosCliente.Tables(0).Rows(0)(9)).Selected = True
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
                'REGION COMUNA CLIENTE
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
                'REGION COMUNA REFERENCIA
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

                ' Me.DDL_Tienda.Items.FindByText(Me.GrillaListado.Rows(Me.GrillaListado.SelectedIndex.ToString()).Cells(3).Text).Selected = True
                ' If DataDSDatosCliente.Tables(0).Rows(0)(8) Is System.DBNull.Value Then
                ' Me.TXT_DatosClienteAntiguedad.Text = "0"
                ' Else
                ' Me.TXT_DatosClienteAntiguedad.Text = Format(CType(DataDSDatosCliente.Tables(0).Rows(0)(8), Integer), "#,##0")
                ' End If
                '     If DataDSDatosCliente.Tables(0).Rows(0)(9) Is System.DBNull.Value Then
                '     Me.TXT_DatosClienteIngresos.Text = "0"
                '     Else
                '     Me.TXT_DatosClienteIngresos.Text = Format(CType(DataDSDatosCliente.Tables(0).Rows(0)(9), Integer), "###,###,##0")
                'End If
            End If
        Catch EX As Exception
            'MsgBox(EX)
            'Response.Write("<script>window.alert('Error al Obtener Datos DatosClientees');</script>")
        End Try
    End Sub
End Class
