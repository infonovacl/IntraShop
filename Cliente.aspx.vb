Partial Class MenuPrincipal
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=ODBCifx64;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Sub BTN_Buscar_Click(sender As Object, e As EventArgs) Handles BTN_Buscar.Click
        'Me.TXT_RutCliente.Text = Master.PropertyMasterTextBox2
        Master.PropertyMasterTextBox2.Text = Me.TXT_RutCliente.Text
        Session("rut") = Me.TXT_RutCliente.Text
    End Sub
    Protected Sub ProcesaTab(sender As Object, e As EventArgs) Handles BTN_ProcesaTab.Click
        '  MsgBox(Session("TabIndexo"))
        ' MsgBox(Me.LBL_TabIndice.Text)
        ' MsgBox("Hola CTM")
    End Sub
    Protected Sub Tab_Consultas_ActiveTabChanged(sender As Object, e As EventArgs) Handles Tab_Consultas.ActiveTabChanged
        Select Case Me.Tab_Consultas.ActiveTabIndex.ToString
            Case 0
                Dim DataDSEstados As New Data.DataSet
                Try
                    DataDSEstados.Clear()
                    Dim STREstados As String = "execute procedure procw_cons_estados ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAEstados As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STREstados, conn)
                    DATAEstados.Fill(DataDSEstados, "PRUEBA")
                    Me.Grilla_Estados.DataSource = DataDSEstados.Tables(0).DefaultView
                    Me.Grilla_Estados.DataBind()
                Catch EX As Exception
                    Response.Write("<script>window.alert('Error al Obtener Estdos');</script>")
                End Try
            Case 2
                Dim DataDSLaboral As New Data.DataSet
                Try
                    Dim STRLaboral As String = "execute procedure procw_cons_laboral ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATALaboral As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLaboral, conn)
                    DATALaboral.Fill(DataDSLaboral, "PRUEBA")
                    If DataDSLaboral.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                        Me.LBL_Empleador_Laboral.Text = ""
                    Else
                        Me.LBL_Empleador_Laboral.Text = DataDSLaboral.Tables(0).Rows(0)(2)
                    End If
                    If DataDSLaboral.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                        Me.LBL_Direccion_Laboral.Text = ""
                    Else
                        Me.LBL_Direccion_Laboral.Text = DataDSLaboral.Tables(0).Rows(0)(3)
                    End If
                    If DataDSLaboral.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                        Me.LBL_Region_Laboral.Text = ""
                    Else
                        Me.LBL_Region_Laboral.Text = DataDSLaboral.Tables(0).Rows(0)(4)
                    End If
                    If DataDSLaboral.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                        Me.LBL_Comuna_Laboral.Text = ""
                    Else
                        Me.LBL_Comuna_Laboral.Text = DataDSLaboral.Tables(0).Rows(0)(5)
                    End If
                    If DataDSLaboral.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                        Me.LBL_Telefono_Laboral.Text = ""
                    Else
                        Me.LBL_Telefono_Laboral.Text = DataDSLaboral.Tables(0).Rows(0)(6)
                    End If
                    If DataDSLaboral.Tables(0).Rows(0)(7) Is System.DBNull.Value Then
                        Me.LBL_Anexo_Laboral.Text = ""
                    Else
                        Me.LBL_Anexo_Laboral.Text = DataDSLaboral.Tables(0).Rows(0)(7)
                    End If
                    If DataDSLaboral.Tables(0).Rows(0)(8) Is System.DBNull.Value Then
                        Me.LBL_Antiguedad_Laboral.Text = "0"
                    Else
                        Me.LBL_Antiguedad_Laboral.Text = Format(CType(DataDSLaboral.Tables(0).Rows(0)(8), Integer), "#,##0")
                    End If
                    If DataDSLaboral.Tables(0).Rows(0)(9) Is System.DBNull.Value Then
                        Me.LBL_TotalIngresos_Laboral.Text = "0"
                    Else
                        Me.LBL_TotalIngresos_Laboral.Text = Format(CType(DataDSLaboral.Tables(0).Rows(0)(9), Integer), "###,###,##0")
                    End If
                Catch EX As Exception
                    Response.Write("<script>window.alert('Error al Obtener Datos Laborales');</script>")
                End Try
            Case 3
                Dim DataDSContratos As New Data.DataSet
                Try
                    DataDSContratos.Clear()
                    Dim STRContratos As String = "execute procedure procw_cons_contrato ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAContratos As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRContratos, conn)
                    DATAContratos.Fill(DataDSContratos, "PRUEBA")
                    Me.Grilla_Contratos.DataSource = DataDSContratos.Tables(0).DefaultView
                    Me.Grilla_Contratos.DataBind()
                Catch EX As Exception
                    Response.Write("<script>window.alert('Error al Obtener Contratos');</script>")
                End Try
            Case 4
                Dim DataDSModificaciones As New Data.DataSet
                Try
                    DataDSModificaciones.Clear()
                    Dim STRModificaciones As String = "execute procedure procw_cons_modif ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAModificaciones As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRModificaciones, conn)
                    DATAModificaciones.Fill(DataDSModificaciones, "PRUEBA")
                    Me.Grilla_Modificaciones.DataSource = DataDSModificaciones.Tables(0).DefaultView
                    Me.Grilla_Modificaciones.DataBind()
                Catch EX As Exception
                    Response.Write("<script>window.alert('Error al Obtener Modificaciones');</script>")
                End Try
            Case 5
                Dim DataDSDescuentos As New Data.DataSet
                Try
                    DataDSDescuentos.Clear()
                    Dim STRDescuentos As String = "execute procedure procw_cons_descto ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATADescuentos As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDescuentos, conn)
                    DATADescuentos.Fill(DataDSDescuentos, "PRUEBA")
                    Me.Grilla_Descuentos.DataSource = DataDSDescuentos.Tables(0).DefaultView
                    Me.Grilla_Descuentos.DataBind()
                Catch EX As Exception
                    Response.Write("<script>window.alert('Error al Obtener Descuentos');</script>")
                End Try
            Case 6
                Dim DataDSDescuentos As New Data.DataSet
                Try
                    DataDSDescuentos.Clear()
                    Dim STRDescuentos As String = "execute procedure procw_cons_descto ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATADescuentos As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDescuentos, conn)
                    DATADescuentos.Fill(DataDSDescuentos, "PRUEBA")
                    Me.Grilla_Descuentos.DataSource = DataDSDescuentos.Tables(0).DefaultView
                    Me.Grilla_Descuentos.DataBind()
                Catch EX As Exception
                    Response.Write("<script>window.alert('Error al Obtener Descuentos');</script>")
                End Try
            Case 7
                Dim DataDSSolicitudes As New Data.DataSet
                Try
                    DataDSSolicitudes.Clear()
                    Dim STRSolicitudes As String = "execute procedure procw_cons_solic ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATASolicitudes As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSolicitudes, conn)
                    DATASolicitudes.Fill(DataDSSolicitudes, "PRUEBA")
                    'Me.Grilla_Solicitudes.DataSource = DataDSSolicitudes.Tables(0).DefaultView
                    ' Me.Grilla_Solicitudes.DataBind()
                Catch EX As Exception
                    Response.Write("<script>window.alert('Error al Obtener Solicitudes');</script>")
                End Try
        End Select
    End Sub
    Protected Sub Grilla_Estados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grilla_Estados.SelectedIndexChanged
        'MsgBox(Me.Grilla_Estados.SelectedIndex.ToString())
        Dim DataDSSubEstados As New Data.DataSet
        Dim IndiceGrillaEstados As Integer = 0
        Dim FechaEstado As String
        Dim CodigoEstadoNuevo As Integer
        Try
            DataDSSubEstados.Clear()
            IndiceGrillaEstados = Me.Grilla_Estados.SelectedIndex.ToString()
            FechaEstado = Me.Grilla_Estados.Rows(IndiceGrillaEstados).Cells(1).Text
            CodigoEstadoNuevo = Me.Grilla_Estados.Rows(IndiceGrillaEstados).Cells(3).Text
            Dim STRSubEstados As String = "execute procedure procw_cons_estados_det ('" & Me.TXT_RutCliente.Text & "','" & FechaEstado & "'," & CodigoEstadoNuevo & " )"
            Dim DATASubEstados As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSubEstados, conn)
            DATASubEstados.Fill(DataDSSubEstados, "PRUEBA")
            If DataDSSubEstados.Tables(0).Rows(0)(0) = 1 Then
                Me.TXT_EstadoDescripcionSubEstado.Text = DataDSSubEstados.Tables(0).Rows(0)(1)
            Else
                If DataDSSubEstados.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                    Me.TXT_EstadoDescripcionSubEstado.Text = ""
                Else
                    Me.TXT_EstadoDescripcionSubEstado.Text = DataDSSubEstados.Tables(0).Rows(0)(2)
                End If
            End If
            Me.Panel_Estados.Visible = False
            Me.Panel_EstadosDetalle.Visible = True
        Catch EX As Exception
            Response.Write("<script>window.alert('Error al Obtener SubEstados');</script>")
        End Try
        'Response.Write("<script>window.open(""clasificacion.aspx?rut=" & rut_cliente & "&cta=" & cta_cte & """, ""CLASIFICACIONES"" , ""width=270,height=350, top=230, left=750, scrollbars=NO"");</script>")
    End Sub
    Protected Sub BTN_EstadosSubEstados_Click(sender As Object, e As EventArgs) Handles BTN_EstadosSubEstados.Click
        Me.TXT_EstadoDescripcionSubEstado.Text = ""
        Me.Panel_EstadosDetalle.Visible = False
        Me.Panel_Estados.Visible = True
    End Sub
End Class
