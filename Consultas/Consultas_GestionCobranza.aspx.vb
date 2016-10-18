Partial Class Consultas_GestionCobranza
    Inherits System.Web.UI.Page
    Protected Sub Tab_GestionCobranza_ActiveTabChanged(sender As Object, e As EventArgs) Handles Tab_GestionCobranza.ActiveTabChanged
        Select Case Me.Tab_GestionCobranza.ActiveTabIndex.ToString
            Case 0
                CargaInicial()
            Case 1               
                Dim DataDSUnidad As New Data.DataSet
                Dim RutCliente As Integer
                RutCliente = Session("rut")
                Try
                    DataDSUnidad.Clear()
                    Dim STRUnidad As String = "execute procedure procw_cons_unidad ('" & RutCliente & "' )"
                    Dim DATAUnidad As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRUnidad, Globales.conn)
                    DATAUnidad.Fill(DataDSUnidad, "PRUEBA")
                    If DataDSUnidad.Tables(0).Rows(0)(0) = 1 Then
                        Me.Grilla_GestionUnidad.Visible = False
                        Me.Panel_CobranzaUnidad.Visible = False
                        Me.LBL_CobranzaUnidadError.Visible = True
                        Me.LBL_CobranzaUnidadError.Text = DataDSUnidad.Tables(0).Rows(0)(1) ' mensaje de error                       
                    Else
                        Me.Panel_CobranzaUnidad.Visible = True
                        Me.LBL_CobranzaUnidadError.Visible = False
                        Me.Grilla_GestionUnidad.DataSource = DataDSUnidad.Tables(0).DefaultView
                        Me.Grilla_GestionUnidad.DataBind()                       
                    End If                    
                Catch EX1 As Exception
                    Me.LBL_CobranzaUnidadError.Visible = True
                    Me.LBL_CobranzaUnidadError.Text = EX1.Message
                End Try
            Case 2               
                Dim DataDSExterna As New Data.DataSet
                Dim RutCliente As Integer
                RutCliente = Session("rut")
                Try
                    DataDSExterna.Clear()
                    Dim STRExterna As String = "execute procedure procw_cons_cobext ('" & RutCliente & "' )"
                    Dim DATAExterna As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRExterna, Globales.conn)
                    DATAExterna.Fill(DataDSExterna, "PRUEBA")
                    If DataDSExterna.Tables(0).Rows(0)(0) = 1 Then
                        Me.Grilla_CobranzaExterna.Visible = False
                        Me.Panel_CobranzaExterna.Visible = False
                        Me.LBL_CobranzaExternaError.Visible = True
                        Me.LBL_CobranzaExternaError.Text = DataDSExterna.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_CobranzaExterna.Visible = True
                        Me.LBL_CobranzaExternaError.Visible = False
                        Me.Grilla_CobranzaExterna.DataSource = DataDSExterna.Tables(0).DefaultView
                        Me.Grilla_CobranzaExterna.DataBind()
                    End If                  
                Catch EX2 As Exception
                    Me.LBL_CobranzaExternaError.Visible = True
                    Me.LBL_CobranzaExternaError.Text = EX2.Message
                End Try
            Case 3
                Dim DataDSDicom As New Data.DataSet
                Dim RutCliente As Integer
                RutCliente = Session("rut")
                Try                  
                    DataDSDicom.Clear()
                    Dim STRDicom As String = "execute procedure procw_cons_dicom ('" & RutCliente & "' )"
                    Dim DATADicom As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRDicom, Globales.conn)
                    DATADicom.Fill(DataDSDicom, "PRUEBA")
                    If DataDSDicom.Tables(0).Rows(0)(0) = 1 Then
                        Me.Grilla_CobranzaDicom.Visible = False
                        Me.Panel_CobranzaDicom.Visible = False
                        Me.LBL_CobranzaDicomError.Visible = True
                        Me.LBL_CobranzaDicomError.Text = DataDSDicom.Tables(0).Rows(0)(1) ' mensaje de error
                    Else
                        Me.Panel_CobranzaDicom.Visible = True
                        Me.LBL_CobranzaDicomError.Visible = False
                        Me.Grilla_CobranzaDicom.DataSource = DataDSDicom.Tables(0).DefaultView
                        Me.Grilla_CobranzaDicom.DataBind()
                    End If                   
                Catch EX3 As Exception
                    Me.LBL_CobranzaDicomError.Visible = True
                    Me.LBL_CobranzaDicomError.Text = EX3.Message
                End Try
        End Select
    End Sub
    Sub CargaInicial()
        Dim DataDSCobranzaTelefonica As New Data.DataSet
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Me.Tab_GestionCobranza.ActiveTabIndex = 0
        Try        
            DataDSCobranzaTelefonica.Clear()
            Dim STRCobranzaTelefonica As String = "execute procedure procw_cons_gestel ('" & RutCliente & "' )"
            Dim DATACobranzaTelefonica As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRCobranzaTelefonica, Globales.conn)
            DATACobranzaTelefonica.Fill(DataDSCobranzaTelefonica, "PRUEBA")
            If DataDSCobranzaTelefonica.Tables(0).Rows(0)(0) = 1 Then
                Me.Grilla_GestionTelefonica.Visible = False
                Me.Panel_CobranzaTelefonica.Visible = False
                Me.LBL_CobranzaTelefonicaError.Visible = True
                Me.LBL_CobranzaTelefonicaError.Text = DataDSCobranzaTelefonica.Tables(0).Rows(0)(1) ' mensaje de error               
            Else              
                Me.Panel_CobranzaTelefonica.Visible = True
                Me.LBL_CobranzaTelefonicaError.Visible = False
                Me.Grilla_GestionTelefonica.DataSource = DataDSCobranzaTelefonica.Tables(0).DefaultView
                Me.Grilla_GestionTelefonica.DataBind()               
            End If           
        Catch EX4 As Exception
            Me.LBL_CobranzaTelefonicaError.Visible = True
            Me.LBL_CobranzaTelefonicaError.Text = EX4.Message
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Tab_GestionCobranza.ActiveTabIndex = 0
            CargaInicial()
        End If
    End Sub
    Protected Sub BTN_Cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_Cerrar.Click
        'Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
    End Sub
End Class
