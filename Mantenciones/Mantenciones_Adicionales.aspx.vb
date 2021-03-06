﻿Partial Class Mantencion_Adicionales
    Inherits System.Web.UI.Page
    Dim RutCliente As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RutCliente = Request.QueryString("rut")
        Me.Panel_Adicionales.Visible = True
        Me.LBL_AdicionalesError.Visible = False
        If Not IsPostBack Then
            ObtieneAdicionales()
        End If
    End Sub
    Protected Sub BTN_Grabar_Click(sender As Object, e As EventArgs) Handles BTN_Grabar.Click
        Try
            Dim DATADSModificaAdicionalesPopUp As New Data.DataSet
            DATADSModificaAdicionalesPopUp.Clear()
            Dim STRModificaAdicionales As String = "execute procedure procw_mod_adicional  ('" & RutCliente & "','" & Me.TXT_AdicionalRut.Text & "','" & DDL_EstadoAdicionales.SelectedValue & "')"
            Dim DATAModificaAdicionales As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRModificaAdicionales, Globales.conn)
            DATAModificaAdicionales.Fill(DATADSModificaAdicionalesPopUp, "PRUEBA")
            If DATADSModificaAdicionalesPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.Panel_Adicionales.Visible = False
                Me.LBL_AdicionalesError.Visible = True
                Me.LBL_AdicionalesError.Text = DATADSModificaAdicionalesPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else

                Me.Panel_Adicionales.Visible = True
                Me.Panel_AdicionalesDetalle.Visible = False
                Me.LBL_AdicionalesError.Visible = False
                ObtieneAdicionales()
            End If
        Catch EX2 As Exception
            Me.LBL_AdicionalesError.Visible = True
            Me.LBL_AdicionalesError.Text = EX2.Message
        End Try
    End Sub
    Private Sub ObtieneAdicionales()
        Try
            Dim DATADSAdicionalesPopUp As New Data.DataSet
            DATADSAdicionalesPopUp.Clear()
            Me.Grilla_Adicionales.DataSource = Nothing
            Me.Grilla_Adicionales.DataBind()
            Dim STRAdicionales As String = "execute procedure procw_cons_adicional ('" & RutCliente & "' )"
            Dim DATAAdicionales As System.Data.Odbc.OdbcDataAdapter = New System.Data.Odbc.OdbcDataAdapter(STRAdicionales, Globales.conn)
            DATAAdicionales.Fill(DATADSAdicionalesPopUp, "PRUEBA")
            If DATADSAdicionalesPopUp.Tables(0).Rows(0)(0) = 1 Then
                Me.BTN_Grabar.Enabled = False
                Me.Panel_Adicionales.Visible = True
                Me.LBL_AdicionalesError.Visible = True
                Me.LBL_AdicionalesError.Text = DATADSAdicionalesPopUp.Tables(0).Rows(0)(1) ' mensaje de error
            Else
                Me.BTN_Grabar.Enabled = True
                Me.Panel_Adicionales.Visible = True
                Me.LBL_AdicionalesError.Visible = False
                Me.Grilla_Adicionales.DataSource = DATADSAdicionalesPopUp.Tables(0).DefaultView
                Me.Grilla_Adicionales.DataBind()
            End If
        Catch EX As Exception
            Me.LBL_AdicionalesError.Visible = True
            Me.LBL_AdicionalesError.Text = EX.Message
        End Try
    End Sub
    Protected Sub Grilla_Adicionales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grilla_Adicionales.SelectedIndexChanged
        Dim IndiceGrillaAdicionales As Integer = 0
        Try
            IndiceGrillaAdicionales = Me.Grilla_Adicionales.SelectedIndex.ToString()
            Me.TXT_AdicionalRut.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(1).Text
            Me.TXT_AdicionalDv.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(2).Text
            Me.TXT_AdicionalNombres.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(3).Text
            Me.TXT_AdicionalAPaterno.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(4).Text
            Me.TXT_AdicionalAMaterno.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(5).Text
            Me.TXT_AdicionalParentesco.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(6).Text
            Me.TXT_AdicionalFechaNacimiento.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(7).Text
            Me.TXT_AdicionalFechaIng.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(10).Text
            Me.TXT_AdicionalSexo.Text = Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(11).Text
            Me.Panel_Adicionales.Visible = False
            Me.Panel_AdicionalesDetalle.Visible = True
            Me.DDL_EstadoAdicionales.ClearSelection()
            Me.DDL_EstadoAdicionales.Items.FindByText(Trim(Me.Grilla_Adicionales.Rows(IndiceGrillaAdicionales).Cells(8).Text)).Selected = True
            Me.BTN_Grabar.Enabled = True
        Catch EX3 As Exception
            Me.LBL_AdicionalesError.Visible = True
            Me.LBL_AdicionalesError.Text = EX3.Message
        End Try
    End Sub
    Protected Sub IBTN_AdicionalesDetalle_Click(sender As Object, e As ImageClickEventArgs) Handles IBTN_AdicionalesDetalle.Click
        Me.TXT_AdicionalRut.Text = ""
        Me.TXT_AdicionalDv.Text = ""
        Me.TXT_AdicionalNombres.Text = ""
        Me.TXT_AdicionalAPaterno.Text = ""
        Me.TXT_AdicionalAMaterno.Text = ""
        Me.TXT_AdicionalParentesco.Text = ""
        Me.TXT_AdicionalFechaNacimiento.Text = ""
        Me.TXT_AdicionalFechaIng.Text = ""
        Me.TXT_AdicionalSexo.Text = ""
        Me.Panel_Adicionales.Visible = True
        Me.Panel_AdicionalesDetalle.Visible = False
        Me.DDL_EstadoAdicionales.SelectedIndex = 0
        Me.BTN_Grabar.Enabled = False
    End Sub
    Protected Sub BTN_Cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_Cerrar.Click
        Response.Write("<script language='JavaScript'>ventana = window.self;ventana.opener = window.self;ventana.close();</script>")
    End Sub
End Class
