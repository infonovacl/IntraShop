﻿Partial Class Solicitudes_AnulaVentaSeguros
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LBL_SegurosXContratarError.Visible = False
        If Not IsPostBack Then
            LlenaSegurosXContratar()
            LlenaSegurosPosiblesAnular()
        End If
    End Sub
    Private Sub LlenaSegurosXContratar()
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            Dim DATADSSegurosXContratarPopUp As New Data.DataSet
            DATADSSegurosXContratarPopUp.Clear()
            Dim STRSegurosXContratar As String = "execute procedure procw_vende_seguros ('" & RutCliente & "')"
            Dim DATASegurosXContratar As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSegurosXContratar, Globales.conn)
            DATASegurosXContratar.Fill(DATADSSegurosXContratarPopUp, "PRUEBA")
            If DATADSSegurosXContratarPopUp.Tables(0).Rows(0)(0) = 1 Or DATADSSegurosXContratarPopUp.Tables(0).Rows.Count = 0 Then
                Me.LBL_SegurosXContratarError.Visible = True
                Me.LBL_SegurosXContratarError.Text = DATADSSegurosXContratarPopUp.Tables(0).Rows(0)(1) ' mensaje de error              
            Else
                Me.Panel_SegurosXAnular.Visible = True
                Me.LBL_SegurosXAnular.Visible = False
                Me.Grilla_SeguroXContratar.DataSource = DATADSSegurosXContratarPopUp.Tables(0).DefaultView
                Me.Grilla_SeguroXContratar.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LlenaSegurosPosiblesAnular()
        Dim RutCliente As Integer
        RutCliente = Session("rut")
        Try
            Dim DATADSSegurosXAnularPopUp As New Data.DataSet
            DATADSSegurosXAnularPopUp.Clear()
            Dim STRSegurosXAnular As String = "execute procedure procw_anula_seguros ('" & RutCliente & "')"
            Dim DATASegurosXAnular As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRSegurosXAnular, Globales.conn)
            DATASegurosXAnular.Fill(DATADSSegurosXAnularPopUp, "PRUEBA")
            If DATADSSegurosXAnularPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.LBL_SegurosXAnular.Visible = True
                Me.LBL_SegurosXAnular.Text = DATADSSegurosXAnularPopUp.Tables(0).Rows(0)(1) ' mensaje de error              
            Else
                Me.Panel_SegurosXAnular.Visible = True
                Me.LBL_SegurosXAnular.Visible = False
                Me.Grilla_SeguroXContratar.DataSource = DATADSSegurosXAnularPopUp.Tables(0).DefaultView
                Me.Grilla_SeguroXContratar.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click

    End Sub
End Class
