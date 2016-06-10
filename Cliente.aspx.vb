Partial Class Cliente
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    <System.Web.Script.Services.ScriptMethod(),
        System.Web.Services.WebMethod()>
    Public Shared Function BuscaClientexNombre(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim conn2 As Data.SqlClient.SqlConnection = New Data.SqlClient.SqlConnection
        conn2.ConnectionString = ConfigurationManager _
         .ConnectionStrings("constr").ConnectionString
        Dim cmd As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand
        cmd.CommandText = "select ContactName from Customers where" &
        " ContactName like @SearchText + '%'"
        cmd.Parameters.AddWithValue("@SearchText", prefixText)
        cmd.Connection = conn2
        conn2.Open()
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As Data.SqlClient.SqlDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("ContactName").ToString)
        End While
        conn2.Close()
        Return customers
    End Function
    Protected Sub BTN_Buscar_Click(sender As Object, e As EventArgs) Handles BTN_Buscar.Click
        'Me.TXT_RutCliente.Text = Master.PropertyMasterTextBox2
        Master.PropertyMasterTextBox2.Text = Me.TXT_RutCliente.Text
        Dim menu As TreeView
        menu = Master.FindControl("TVM_Principal")
        menu.Enabled = True
        menu.Font.Strikeout = False
        Session("rut") = Me.TXT_RutCliente.Text
        'Master.Master.FindControl("TVM_Principal").e

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
                    If DataDSEstados.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_Estados.Visible = False
                        Me.LBL_EstadosError.Visible = True
                        Me.LBL_EstadosError.Text = DataDSEstados.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_Estados.Visible = True
                        Me.LBL_EstadosError.Visible = False
                        Me.Grilla_Estados.DataSource = DataDSEstados.Tables(0).DefaultView
                        Me.Grilla_Estados.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Estdos');</script>")
                End Try
            Case 1
                Dim DataDSLaboral As New Data.DataSet
                Try
                    Dim STRLaboral As String = "execute procedure procw_cons_laboral ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATALaboral As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRLaboral, conn)
                    DATALaboral.Fill(DataDSLaboral, "PRUEBA")
                    If DataDSLaboral.Tables(0).Rows(0)(0) = 1 Then
                        Me.TBL_Laboral.Visible = False
                        Me.LBL_LaboralError.Visible = True
                        Me.LBL_LaboralError.Text = DataDSLaboral.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.TBL_Laboral.Visible = True
                        Me.LBL_LaboralError.Visible = False
                        If DataDSLaboral.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                            Me.TXT_LaboralEmpleador.Text = ""
                        Else
                            Me.TXT_LaboralEmpleador.Text = DataDSLaboral.Tables(0).Rows(0)(2)
                        End If
                        If DataDSLaboral.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                            Me.TXT_LaboralDireccion.Text = ""
                        Else
                            Me.TXT_LaboralDireccion.Text = DataDSLaboral.Tables(0).Rows(0)(3)
                        End If
                        If DataDSLaboral.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                            Me.TXT_LaboralRegion.Text = ""
                        Else
                            Me.TXT_LaboralRegion.Text = DataDSLaboral.Tables(0).Rows(0)(4)
                        End If
                        If DataDSLaboral.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                            Me.TXT_LaboralComuna.Text = ""
                        Else
                            Me.TXT_LaboralComuna.Text = DataDSLaboral.Tables(0).Rows(0)(5)
                        End If
                        If DataDSLaboral.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                            Me.TXT_LaboralTelefono.Text = ""
                        Else
                            Me.TXT_LaboralTelefono.Text = DataDSLaboral.Tables(0).Rows(0)(6)
                        End If
                        If DataDSLaboral.Tables(0).Rows(0)(7) Is System.DBNull.Value Then
                            Me.TXT_LaboralAnexo.Text = ""
                        Else
                            Me.TXT_LaboralAnexo.Text = DataDSLaboral.Tables(0).Rows(0)(7)
                        End If
                        If DataDSLaboral.Tables(0).Rows(0)(8) Is System.DBNull.Value Then
                            Me.TXT_LaboralAntiguedad.Text = "0"
                        Else
                            Me.TXT_LaboralAntiguedad.Text = Format(CType(DataDSLaboral.Tables(0).Rows(0)(8), Integer), "#,##0")
                        End If
                        If DataDSLaboral.Tables(0).Rows(0)(9) Is System.DBNull.Value Then
                            Me.TXT_LaboralIngresos.Text = "0"
                        Else
                            Me.TXT_LaboralIngresos.Text = Format(CType(DataDSLaboral.Tables(0).Rows(0)(9), Integer), "###,###,##0")
                        End If
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Datos Laborales');</script>")
                End Try
            Case 2
                Dim DataDSContratos As New Data.DataSet
                Try
                    DataDSContratos.Clear()
                    Dim STRContratos As String = "execute procedure procw_cons_contrato ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAContratos As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRContratos, conn)
                    DATAContratos.Fill(DataDSContratos, "PRUEBA")
                    If DataDSContratos.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_Contratos.Visible = False
                        Me.LBL_ContratosError.Visible = True
                        Me.LBL_ContratosError.Text = DataDSContratos.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_Contratos.Visible = True
                        Me.LBL_ContratosError.Visible = False
                        Me.Grilla_Contratos.DataSource = DataDSContratos.Tables(0).DefaultView
                        Me.Grilla_Contratos.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Contratos');</script>")
                End Try
            Case 3  '   QUEDA PENDIENTE REVISION ALEJA
                Dim DataDSModificaciones As New Data.DataSet
                Try
                    DataDSModificaciones.Clear()
                    Dim STRModificaciones As String = "execute procedure procw_cons_modif ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAModificaciones As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRModificaciones, conn)
                    DATAModificaciones.Fill(DataDSModificaciones, "PRUEBA")
                    Me.Grilla_Modificaciones.DataSource = DataDSModificaciones.Tables(0).DefaultView
                    Me.Grilla_Modificaciones.DataBind()
                Catch EX As Exception
                    ' Response.Write("<script>window.alert('Error al Obtener Modificaciones');</script>")
                End Try
            Case 4
                Dim DataDSDescuentos As New Data.DataSet
                Try
                    DataDSDescuentos.Clear()
                    Dim STRDescuentos As String = "execute procedure procw_cons_descto ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATADescuentos As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDescuentos, conn)
                    DATADescuentos.Fill(DataDSDescuentos, "PRUEBA")
                    If DataDSDescuentos.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_Descuentos.Visible = False
                        Me.LBL_DescuentosError.Visible = True
                        Me.Panel_DescuentosDetalle.Visible = False
                        Me.LBL_DescuentosError.Text = DataDSDescuentos.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_Descuentos.Visible = True
                        Me.LBL_DescuentosError.Visible = False
                        Me.Panel_DescuentosDetalle.Visible = False
                        Me.Grilla_Descuentos.DataSource = DataDSDescuentos.Tables(0).DefaultView
                        Me.Grilla_Descuentos.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Descuentos');</script>")
                End Try
            Case 5
                'consultas db
            Case 6
                Dim DataDSSolicitudes As New Data.DataSet
                Try
                    DataDSSolicitudes.Clear()
                    Dim STRSolicitudes As String = "execute procedure procw_cons_solic ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATASolicitudes As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSolicitudes, conn)
                    DATASolicitudes.Fill(DataDSSolicitudes, "PRUEBA")
                    If DataDSSolicitudes.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_Solicitudes.Visible = False
                        Me.LBL_SolicitudesError.Visible = True
                        Me.LBL_SolicitudesError.Text = DataDSSolicitudes.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_Solicitudes.Visible = True
                        Me.LBL_SolicitudesError.Visible = False
                        Me.Grilla_Solicitudes.DataSource = DataDSSolicitudes.Tables(0).DefaultView
                        Me.Grilla_Solicitudes.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Solicitudes');</script>")
                End Try
            Case 7
                Dim DataDSUltimosAbonos As New Data.DataSet
                Try
                    DataDSUltimosAbonos.Clear()
                    Dim STRUltimosAbonos As String = "execute procedure procw_cons_resumen1 ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAUltimosAbonos As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRUltimosAbonos, conn)
                    DATAUltimosAbonos.Fill(DataDSUltimosAbonos, "PRUEBA")
                    If DataDSUltimosAbonos.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_ResumenUltimosAbonos.Visible = False
                        Me.LBL_ResumenUltAbonosError.Visible = True
                        Me.LBL_ResumenUltAbonosError.Text = DataDSUltimosAbonos.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_ResumenUltimosAbonos.Visible = True
                        Me.LBL_ResumenUltAbonosError.Visible = False
                        Me.Grilla_ResumenUltimosAbonos.DataSource = DataDSUltimosAbonos.Tables(0).DefaultView
                        Me.Grilla_ResumenUltimosAbonos.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Solicitudes');</script>")
                End Try
                Dim DataDSResumenClasificaciones As New Data.DataSet
                Try
                    DataDSResumenClasificaciones.Clear()
                    Dim STRResumenClasificaciones As String = "execute procedure procw_cons_resumen2 ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAResumenClasificaciones As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRResumenClasificaciones, conn)
                    DATAResumenClasificaciones.Fill(DataDSResumenClasificaciones, "PRUEBA")
                    If DataDSResumenClasificaciones.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_ResumenUltimasClasificaciones.Visible = False
                        Me.LBL_ResumenClasifError.Visible = True
                        Me.LBL_ResumenClasifError.Text = DataDSResumenClasificaciones.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_ResumenUltimasClasificaciones.Visible = True
                        Me.LBL_ResumenClasifError.Visible = False
                        Me.Grilla_ResumenUltimasClasificaciones.DataSource = DataDSResumenClasificaciones.Tables(0).DefaultView
                        Me.Grilla_ResumenUltimasClasificaciones.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Solicitudes');</script>")
                End Try
                Dim DataDSResumenOtros As New Data.DataSet
                TXT_ResumenComprasTotales.Text = "0"
                TXT_ResumenFecAprobacion.Text = ""
                TXT_ResumenFecRechazo.Text = ""
                TXT_ResumenFecSolicitud.Text = ""
                TXT_ResumenFecVerifLaboral.Text = ""
                TXT_ResumenFecVerifParticular.Text = ""
                TXT_ResumenPagosTotales.Text = "0"
                TXT_ResumenTotalCuentaAl.Text = ""
                Try
                    DataDSResumenOtros.Clear()
                    Dim STRResumenOtros As String = "execute procedure procw_cons_resumen3 ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAResumenOtros As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRResumenOtros, conn)
                    DATAResumenOtros.Fill(DataDSResumenOtros, "PRUEBA")
                    If DataDSResumenOtros.Tables(0).Rows(0)(0) = 1 Then
                        'Me.LBL_ResumenClasifError.Visible = True
                        'Me.LBL_ResumenClasifError.Text = DataDSResumenOtros.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        If DataDSResumenOtros.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                            Me.TXT_ResumenFecSolicitud.Text = ""
                        Else
                            Me.TXT_ResumenFecSolicitud.Text = DataDSResumenOtros.Tables(0).Rows(0)(2)
                        End If
                        If DataDSResumenOtros.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                            Me.TXT_ResumenFecAprobacion.Text = ""
                        Else
                            Me.TXT_ResumenFecAprobacion.Text = DataDSResumenOtros.Tables(0).Rows(0)(3)
                        End If
                        If DataDSResumenOtros.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                            Me.TXT_ResumenFecVerifParticular.Text = ""
                        Else
                            Me.TXT_ResumenFecVerifParticular.Text = DataDSResumenOtros.Tables(0).Rows(0)(4)
                        End If
                        If DataDSResumenOtros.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                            Me.TXT_ResumenFecVerifLaboral.Text = ""
                        Else
                            Me.TXT_ResumenFecVerifLaboral.Text = DataDSResumenOtros.Tables(0).Rows(0)(5)
                        End If
                        If DataDSResumenOtros.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                            Me.TXT_ResumenFecRechazo.Text = ""
                        Else
                            Me.TXT_ResumenFecRechazo.Text = DataDSResumenOtros.Tables(0).Rows(0)(6)
                        End If
                        If DataDSResumenOtros.Tables(0).Rows(0)(7) Is System.DBNull.Value Then
                            Me.TXT_ResumenTotalCuentaAl.Text = ""
                        Else
                            Me.TXT_ResumenTotalCuentaAl.Text = DataDSResumenOtros.Tables(0).Rows(0)(7)
                        End If
                        If DataDSResumenOtros.Tables(0).Rows(0)(8) Is System.DBNull.Value Then
                            Me.TXT_ResumenComprasTotales.Text = ""
                        Else
                            Me.TXT_ResumenComprasTotales.Text = Format(DataDSResumenOtros.Tables(0).Rows(0)(8), "###,###,##0")
                        End If
                        If DataDSResumenOtros.Tables(0).Rows(0)(9) Is System.DBNull.Value Then
                            Me.TXT_ResumenPagosTotales.Text = ""
                        Else
                            Me.TXT_ResumenPagosTotales.Text = Format(DataDSResumenOtros.Tables(0).Rows(0)(9), "###,###,##0")
                        End If
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Solicitudes');</script>")
                End Try
            Case 8
                Dim DataDSComentarios As New Data.DataSet
                Try
                    DataDSComentarios.Clear()
                    Dim STRComentarios As String = "execute procedure procw_cons_comenta ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAComentarios As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRComentarios, conn)
                    DATAComentarios.Fill(DataDSComentarios, "PRUEBA")
                    If DataDSComentarios.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_Comentarios.Visible = False
                        Me.LBL_ComentariosError.Visible = True
                        Me.LBL_ComentariosError.Text = DataDSComentarios.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_Comentarios.Visible = True
                        Me.LBL_ComentariosError.Visible = False
                        Me.Grilla_Comentarios.DataSource = DataDSComentarios.Tables(0).DefaultView
                        Me.Grilla_Comentarios.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Comentarios');</script>")
                End Try
            Case 9
                Dim DataDSPagos As New Data.DataSet
                Try
                    DataDSPagos.Clear()
                    Dim STRPagos As String = "execute procedure procw_cons_pagos ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAPagos As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRPagos, conn)
                    DATAPagos.Fill(DataDSPagos, "PRUEBA")
                    If DataDSPagos.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_Pagos.Visible = False
                        Me.LBL_PagosError.Visible = True
                        Me.LBL_PagosError.Text = DataDSPagos.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_Pagos.Visible = True
                        Me.LBL_PagosError.Visible = False
                        Me.Grilla_Pagos.DataSource = DataDSPagos.Tables(0).DefaultView
                        Me.Grilla_Pagos.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Comentarios');</script>")
                End Try
            Case 10
                Dim DataDSVentas As New Data.DataSet
                Try
                    DataDSVentas.Clear()
                    Dim STRVentas As String = "execute procedure procw_cons_ventas ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATAVentas As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRVentas, conn)
                    DATAVentas.Fill(DataDSVentas, "PRUEBA")
                    If DataDSVentas.Tables(0).Rows(0)(0) = 1 Then
                        Me.Panel_Ventas.Visible = False
                        Me.LBL_VentasError.Visible = True
                        Me.LBL_VentasError.Text = DataDSVentas.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_Ventas.Visible = True
                        Me.LBL_VentasError.Visible = False
                        Me.Panel_VentasDetalle.Visible = False
                        Me.BTN_VentasDetalle.Visible = False
                        Me.Grilla_Ventas.DataSource = DataDSVentas.Tables(0).DefaultView
                        Me.Grilla_Ventas.DataBind()
                        Me.Grilla_Ventas.Columns(13).Visible = False
                        Me.Grilla_Ventas.Columns(14).Visible = False
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Comentarios');</script>")
                End Try
            Case 11
                Dim DataDSRepacta As New Data.DataSet
                Try
                    DataDSRepacta.Clear()
                    Dim STRRepacta As String = "execute procedure procw_cons_repacta ('" & Me.TXT_RutCliente.Text & "')"
                    Dim DATARepacta As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRRepacta, conn)
                    DATARepacta.Fill(DataDSRepacta, "PRUEBA")
                    If DataDSRepacta.Tables(0).Rows(0)(0) = 1 Then
                        Me.LBL_RepactacionesError.Text = DataDSRepacta.Tables(0).Rows(0)(1)  ' mensaje de error
                        Me.Panel_Repactaciones.Visible = False
                        Me.LBL_RepactacionesError.Visible = True
                    Else
                        Me.Panel_Repactaciones.Visible = True
                        Me.LBL_RepactacionesError.Visible = False
                        Me.Grilla_Repactaciones.DataSource = DataDSRepacta.Tables(0).DefaultView
                        Me.Grilla_Repactaciones.DataBind()
                    End If
                Catch EX As Exception
                    ' MsgBox(EX)
                    'Response.Write("<script>window.alert('Error al Obtener Comentarios');</script>")
                End Try
            Case 12
                Dim DataDSDeuda As New Data.DataSet
                Try
                    Dim STRDeuda As String = "execute procedure procw_cons_deuda ('" & Me.TXT_RutCliente.Text & "' )"
                    Dim DATADeuda As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDeuda, conn)
                    DATADeuda.Fill(DataDSDeuda, "PRUEBA")
                    If DataDSDeuda.Tables(0).Rows(0)(0) = 1 Then
                        Me.TBL_Deuda.Visible = False
                        Me.LBL_DeudaError.Visible = True
                        Me.LBL_DeudaError.Text = DataDSDeuda.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.TBL_Deuda.Visible = True
                        Me.LBL_DeudaError.Visible = False
                        If DataDSDeuda.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                            Me.TXT_DeudaMontoCapital.Text = "0"
                        Else
                            Me.TXT_DeudaMontoCapital.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(2), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                            Me.TXT_DeudaMontoInteres.Text = ""
                        Else
                            Me.TXT_DeudaMontoInteres.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(3), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                            Me.TXT_DeudaMontoHonorario.Text = ""
                        Else
                            Me.TXT_DeudaMontoHonorario.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(4), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                            Me.TXT_DeudaCobroProducto.Text = ""
                        Else
                            Me.TXT_DeudaCobroProducto.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(5), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                            Me.TXT_DeudaComisionAvance.Text = ""
                        Else
                            Me.TXT_DeudaComisionAvance.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(6), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(7) Is System.DBNull.Value Then
                            Me.TXT_DeudaAdministracion.Text = ""
                        Else
                            Me.TXT_DeudaAdministracion.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(7), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(8) Is System.DBNull.Value Then
                            Me.TXT_DeudaSeguros.Text = "0"
                        Else
                            Me.TXT_DeudaSeguros.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(8), Integer), "###,###,##0")
                        End If
                        '************************************************************************************************
                        If DataDSDeuda.Tables(0).Rows(0)(9) Is System.DBNull.Value Then
                            Me.TXT_DeudaInteresMora.Text = "0"
                        Else
                            Me.TXT_DeudaInteresMora.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(9), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(10) Is System.DBNull.Value Then
                            Me.TXT_DeudaGastosCobranza.Text = ""
                        Else
                            Me.TXT_DeudaGastosCobranza.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(10), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(11) Is System.DBNull.Value Then
                            Me.TXT_DeudaImpuestos.Text = "0"
                        Else
                            Me.TXT_DeudaImpuestos.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(11), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(12) Is System.DBNull.Value Then
                            Me.TXT_DeudaCostasJudiciales.Text = ""
                        Else
                            Me.TXT_DeudaCostasJudiciales.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(12), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(13) Is System.DBNull.Value Then
                            Me.TXT_DeudaInteresPeriodo.Text = "0"
                        Else
                            Me.TXT_DeudaInteresPeriodo.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(13), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(14) Is System.DBNull.Value Then
                            Me.TXT_DeudaOtrosCobros.Text = "0"
                        Else
                            Me.TXT_DeudaOtrosCobros.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(14), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(15) Is System.DBNull.Value Then
                            Me.TXT_DeudaSaldoFavor.Text = "0"
                        Else
                            Me.TXT_DeudaSaldoFavor.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(15), Integer), "###,###,##0")
                        End If
                        If DataDSDeuda.Tables(0).Rows(0)(16) Is System.DBNull.Value Then
                            Me.TXT_DeudaTotal.Text = "0"
                        Else
                            Me.TXT_DeudaTotal.Text = Format(CType(DataDSDeuda.Tables(0).Rows(0)(16), Integer), "###,###,##0")
                        End If
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Datos Laborales');</script>")
                End Try
            Case 13
                Dim DataDSXPagar As New Data.DataSet
                Try
                    DataDSXPagar.Clear()
                    Dim STRXPagar As String = "execute procedure procw_cons_porpagar ('" & Me.TXT_RutCliente.Text & "')"
                    Dim DATAXPagar As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRXPagar, conn)
                    DATAXPagar.Fill(DataDSXPagar, "PRUEBA")
                    If DataDSXPagar.Tables(0).Rows(0)(0) = 1 Then
                        Me.LBL_XPagarError.Text = DataDSXPagar.Tables(0).Rows(0)(1)  ' mensaje de error
                        Me.Panel_XPagar.Visible = False
                        Me.LBL_XPagarError.Visible = True
                    Else
                        Me.Panel_XPagar.Visible = True
                        Me.LBL_XPagarError.Visible = False
                        Me.Grilla_XPagar.DataSource = DataDSXPagar.Tables(0).DefaultView
                        Me.Grilla_XPagar.DataBind()

                        Dim X, sumatotalcuota, sumatotalpendiente As Long
                        For X = 0 To Me.Grilla_XPagar.Rows.Count - 1
                            sumatotalcuota = sumatotalcuota + CType(Me.Grilla_XPagar.Rows(X).Cells(8).Text, Long)
                            sumatotalpendiente = sumatotalpendiente + CType(Me.Grilla_XPagar.Rows(X).Cells(9).Text, Long)
                            'sumaventaactual = sumaventaactual + CType(Me.GrillaAnioActual.Rows(X).Cells(3).Text, Long)
                        Next
                        Me.Grilla_XPagar.FooterRow.Cells(0).Text = "SUB-TOTAL"
                        Me.Grilla_XPagar.FooterRow.Cells(8).Text = Format(sumatotalcuota, "###,###,##0")
                        Me.Grilla_XPagar.FooterRow.Cells(9).Text = Format(sumatotalpendiente, "###,###,##0")
                        ' Me.GrillaAnioActual.FooterRow.Cells(3).Text = Format(sumaventaactual, "###,###,##0")
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Datos Laborales');</script>")
                End Try
            Case 14
                Dim DataDSSeguros As New Data.DataSet
                Try
                    DataDSSeguros.Clear()
                    Dim STRSeguros As String = "execute procedure procw_cons_seguro ('" & Me.TXT_RutCliente.Text & "')"
                    Dim DATASeguros As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSeguros, conn)
                    DATASeguros.Fill(DataDSSeguros, "PRUEBA")
                    If DataDSSeguros.Tables(0).Rows(0)(0) = 1 Then
                        Me.LBL_SegurosError.Text = DataDSSeguros.Tables(0).Rows(0)(1)  ' mensaje de error
                        Me.Panel_Seguros.Visible = False
                        Me.LBL_SegurosError.Visible = True
                    Else
                        Me.Panel_Seguros.Visible = True
                        Me.LBL_SegurosError.Visible = False
                        Me.Grilla_Seguros.DataSource = DataDSSeguros.Tables(0).DefaultView
                        Me.Grilla_Seguros.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Datos Laborales');</script>")
                End Try
            Case 15
                Dim DataDSSBIF As New Data.DataSet
                Try
                    DataDSSBIF.Clear()
                    Dim STRSBIF As String = "execute procedure procw_cons_sbif ('" & Me.TXT_RutCliente.Text & "')"
                    Dim DATASBIF As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSBIF, conn)
                    DATASBIF.Fill(DataDSSBIF, "PRUEBA")
                    If DataDSSBIF.Tables(0).Rows(0)(0) = 1 Then
                        Me.LBL_SBIFError.Text = DataDSSBIF.Tables(0).Rows(0)(1)  ' mensaje de error
                        Me.Panel_SBIF.Visible = False
                        Me.LBL_SBIFError.Visible = True
                    Else
                        Me.Panel_SBIF.Visible = True
                        Me.LBL_SBIFError.Visible = False
                        Me.Grilla_SBIF.DataSource = DataDSSBIF.Tables(0).DefaultView
                        Me.Grilla_SBIF.DataBind()
                    End If
                Catch EX As Exception
                    'Response.Write("<script>window.alert('Error al Obtener Datos Laborales');</script>")
                End Try
        End Select
    End Sub
    Protected Sub Grilla_Estados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grilla_Estados.SelectedIndexChanged
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
            If DataDSSubEstados.Tables(0).Rows(0)(0) = 1 Then ' algun error en consulta 
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
    End Sub
    Protected Sub BTN_EstadosSubEstados_Click(sender As Object, e As EventArgs) Handles BTN_EstadosSubEstados.Click
        Me.TXT_EstadoDescripcionSubEstado.Text = ""
        Me.Panel_EstadosDetalle.Visible = False
        Me.Panel_Estados.Visible = True
    End Sub
    Protected Sub Grilla_Descuentos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grilla_Descuentos.SelectedIndexChanged
        Dim DataDSDetDescuentos As New Data.DataSet
        Dim IndiceGrillaDetDescuentos As Integer = 0
        Dim CodigoSucursal As Integer
        Dim Caja As Integer
        Dim FechaDescuento As String
        Dim NumeroComprobante As Integer
        Try
            DataDSDetDescuentos.Clear()
            IndiceGrillaDetDescuentos = Me.Grilla_Descuentos.SelectedIndex.ToString()
            CodigoSucursal = Me.Grilla_Descuentos.Rows(IndiceGrillaDetDescuentos).Cells(7).Text
            Caja = Me.Grilla_Descuentos.Rows(IndiceGrillaDetDescuentos).Cells(2).Text
            FechaDescuento = Me.Grilla_Descuentos.Rows(IndiceGrillaDetDescuentos).Cells(4).Text
            NumeroComprobante = Me.Grilla_Descuentos.Rows(IndiceGrillaDetDescuentos).Cells(3).Text

            Dim STRDetDescuentos As String = "execute procedure procw_cons_pago_det  ('" & Me.TXT_RutCliente.Text & "'," & CodigoSucursal & "," & Caja & ",'" & FechaDescuento & "'," & NumeroComprobante & ",'DES')"
            Dim DATADetDescuentos As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDetDescuentos, conn)
            DATADetDescuentos.Fill(DataDSDetDescuentos, "PRUEBA")
            If DataDSDetDescuentos.Tables(0).Rows(0)(0) = 1 Then ' algun error en consulta 
                Me.LBL_DescuentosDetalleError.Visible = True
                Me.LBL_DescuentosDetalleError.Text = DataDSDetDescuentos.Tables(0).Rows(0)(1)
            Else
                Me.LBL_DescuentosDetalleError.Text = ""
                Me.LBL_DescuentosDetalleError.Visible = False
                If DataDSDetDescuentos.Tables(0).Rows(0)(2) Is System.DBNull.Value Then
                    Me.TXT_DescuentosMontoCapital.Text = "0"
                Else
                    Me.TXT_DescuentosMontoCapital.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(2), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(3) Is System.DBNull.Value Then
                    Me.TXT_DescuentosMontoInteres.Text = "0"
                Else
                    Me.TXT_DescuentosMontoInteres.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(3), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(4) Is System.DBNull.Value Then
                    Me.TXT_DescuentosMontoHonorarios.Text = "0"
                Else
                    Me.TXT_DescuentosMontoHonorarios.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(4), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(5) Is System.DBNull.Value Then
                    Me.TXT_DescuentosCobroProducto.Text = "0"
                Else
                    Me.TXT_DescuentosCobroProducto.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(5), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(6) Is System.DBNull.Value Then
                    Me.TXT_DescuentosComisionAvance.Text = "0"
                Else
                    Me.TXT_DescuentosComisionAvance.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(6), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(7) Is System.DBNull.Value Then
                    Me.TXT_DescuentosAdministracion.Text = "0"
                Else
                    Me.TXT_DescuentosAdministracion.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(7), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(8) Is System.DBNull.Value Then
                    Me.TXT_DescuentosSeguros.Text = "0"
                Else
                    Me.TXT_DescuentosSeguros.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(8), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(9) Is System.DBNull.Value Then
                    Me.TXT_DescuentosInteresMora.Text = "0"
                Else
                    Me.TXT_DescuentosInteresMora.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(9), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(10) Is System.DBNull.Value Then
                    Me.TXT_DescuentosGastosCobranza.Text = "0"
                Else
                    Me.TXT_DescuentosGastosCobranza.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(10), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(11) Is System.DBNull.Value Then
                    Me.TXT_DescuentosImpuesto.Text = "0"
                Else
                    Me.TXT_DescuentosImpuesto.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(11), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(12) Is System.DBNull.Value Then
                    Me.TXT_DescuentosCobrosGrales.Text = "0"
                Else
                    Me.TXT_DescuentosCobrosGrales.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(12), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(13) Is System.DBNull.Value Then
                    Me.TXT_DescuentosCostasJudiciales.Text = "0"
                Else
                    Me.TXT_DescuentosCostasJudiciales.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(13), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(14) Is System.DBNull.Value Then
                    Me.TXT_DescuentosInteresPeriodo.Text = "0"
                Else
                    Me.TXT_DescuentosInteresPeriodo.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(14), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(15) Is System.DBNull.Value Then
                    Me.TXT_DescuentosCargosPagados.Text = "0"
                Else
                    Me.TXT_DescuentosCargosPagados.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(15), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(16) Is System.DBNull.Value Then
                    Me.TXT_DescuentosSaldoFavorInicial.Text = "0"
                Else
                    Me.TXT_DescuentosSaldoFavorInicial.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(16), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(17) Is System.DBNull.Value Then
                    Me.TXT_DescuentosMontoAbono.Text = "0"
                Else
                    Me.TXT_DescuentosMontoAbono.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(17), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(18) Is System.DBNull.Value Then
                    Me.TXT_DescuentosSaldoFavorFinal.Text = "0"
                Else
                    Me.TXT_DescuentosSaldoFavorFinal.Text = Format(DataDSDetDescuentos.Tables(0).Rows(0)(18), " #,##0")
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(19) Is System.DBNull.Value Then
                    Me.TXT_DescuentosFechaProceso.Text = "0"
                Else
                    Me.TXT_DescuentosFechaProceso.Text = DataDSDetDescuentos.Tables(0).Rows(0)(19)
                End If
                If DataDSDetDescuentos.Tables(0).Rows(0)(20) Is System.DBNull.Value Then
                    Me.TXT_DescuentosEstadoAbono.Text = "0"
                Else
                    Me.TXT_DescuentosEstadoAbono.Text = Trim(DataDSDetDescuentos.Tables(0).Rows(0)(20))
                End If
            End If
            Me.LBL_DescuentosError.Visible = False
            Me.Panel_Descuentos.Visible = False
            Me.Panel_DescuentosDetalle.Visible = True
        Catch EX As Exception
            'Response.Write("<script>window.alert('Error al Obtener SubEstados');</script>")
        End Try
    End Sub
    Protected Sub BTN_DescuentosDetalle_Click(sender As Object, e As EventArgs) Handles BTN_DescuentosDetalle.Click
        TXT_DescuentosAdministracion.Text = "0"
        TXT_DescuentosCargosPagados.Text = "0"
        TXT_DescuentosCobroProducto.Text = "0"
        TXT_DescuentosCobrosGrales.Text = "0"
        TXT_DescuentosComisionAvance.Text = "0"
        TXT_DescuentosCostasJudiciales.Text = "0"
        TXT_DescuentosEstadoAbono.Text = "0"
        TXT_DescuentosFechaProceso.Text = "0"
        TXT_DescuentosGastosCobranza.Text = "0"
        TXT_DescuentosImpuesto.Text = "0"
        TXT_DescuentosInteresMora.Text = "0"
        TXT_DescuentosInteresPeriodo.Text = "0"
        TXT_DescuentosMontoAbono.Text = "0"
        TXT_DescuentosMontoCapital.Text = "0"
        TXT_DescuentosMontoHonorarios.Text = "0"
        TXT_DescuentosMontoInteres.Text = "0"
        TXT_DescuentosSaldoFavorFinal.Text = "0"
        TXT_DescuentosSaldoFavorInicial.Text = "0"
        TXT_DescuentosSeguros.Text = "0"
        Me.Panel_DescuentosDetalle.Visible = False
        Me.Panel_Descuentos.Visible = True
    End Sub
    Protected Sub Grilla_Ventas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grilla_Ventas.SelectedIndexChanged
        Dim DataDSDetVenta As New Data.DataSet
        Dim IndiceGrillaVentas As Integer = 0
        Dim CodigoSucursal, CodigoNegocio As Integer
        Dim NCaja As Integer
        Dim FechaVenta As String
        Dim NBoleta As Integer
        Try
            DataDSDetVenta.Clear()
            IndiceGrillaVentas = Me.Grilla_Ventas.SelectedIndex.ToString()
            Me.Grilla_Ventas.Columns(13).Visible = True
            Me.Grilla_Ventas.Columns(14).Visible = True
            CodigoSucursal = Me.Grilla_Ventas.Rows(IndiceGrillaVentas).Cells(13).Text
            CodigoNegocio = Me.Grilla_Ventas.Rows(IndiceGrillaVentas).Cells(14).Text
            Me.Grilla_Ventas.Columns(13).Visible = False
            Me.Grilla_Ventas.Columns(14).Visible = False
            NCaja = Me.Grilla_Ventas.Rows(IndiceGrillaVentas).Cells(5).Text
            FechaVenta = Me.Grilla_Ventas.Rows(IndiceGrillaVentas).Cells(3).Text
            NBoleta = Me.Grilla_Ventas.Rows(IndiceGrillaVentas).Cells(6).Text
            Dim STRDetVenta As String = "execute procedure procw_cons_ventas_det (" & Me.TXT_RutCliente.Text & "," & CodigoSucursal & "," & CodigoNegocio & "," & NCaja & ",'" & FechaVenta & "'," & NBoleta & ")"
            Dim DATADetVenta As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDetVenta, conn)
            DATADetVenta.Fill(DataDSDetVenta, "PRUEBA")
            If DataDSDetVenta.Tables(0).Rows(0)(0) = 1 Then ' algun error en consulta 
                Me.LBL_VentasDetalleError.Visible = True
                Me.Panel_VentasDetalle.Visible = False
                Me.Panel_Ventas.Visible = False
                Me.LBL_VentasDetalleError.Text = DataDSDetVenta.Tables(0).Rows(0)(1)
                Me.BTN_VentasDetalle.Visible = True
            Else
                Me.Panel_Ventas.Visible = False
                Me.LBL_VentasDetalleError.Visible = False
                Me.BTN_VentasDetalle.Visible = True
                Me.Grilla_VentasDetalle.DataSource = DataDSDetVenta.Tables(0).DefaultView
                Me.Grilla_VentasDetalle.DataBind()
                Me.Panel_VentasDetalle.Visible = True
            End If
        Catch EX As Exception

        End Try
    End Sub
    Protected Sub BTN_VentasDetalle_Click(sender As Object, e As EventArgs) Handles BTN_VentasDetalle.Click
        Me.LBL_VentasDetalleError.Text = ""
        Me.Panel_VentasDetalle.Visible = False
        Me.Panel_Ventas.Visible = True
        Me.BTN_VentasDetalle.Visible = False
    End Sub
End Class
