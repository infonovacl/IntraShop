Partial Class Consultas_GestionCobranza
    Inherits System.Web.UI.Page
    Dim connSTR As String = "dsn=DesaWeb;uid=desaweb;pwd=Dsa.web"
    Dim conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)

    Protected Sub Tab_GestionCobranza_ActiveTabChanged(sender As Object, e As EventArgs) Handles Tab_GestionCobranza.ActiveTabChanged
        MsgBox(Me.Tab_GestionCobranza.ActiveTabIndex.ToString)
        Select Case Me.Tab_GestionCobranza.ActiveTabIndex.ToString
            Case 0
                Dim DataDSCobranzaTelefonica As New Data.DataSet
                Dim RutCliente As Integer
                RutCliente = Session("rut")
                Try
                    DataDSCobranzaTelefonica.Clear()
                    Dim STRCobranzaTelefonica As String = "execute procedure procw_cons_gestel ('" & RutCliente & "' )"
                    Dim DATACobranzaTelefonica As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRCobranzaTelefonica, conn)
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
                Catch EX As Exception
                    MsgBox(EX)
                End Try
        End Select
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Tab_GestionCobranza.ActiveTabIndex = 5

        End If
    End Sub
End Class
