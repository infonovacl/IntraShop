Imports Microsoft.VisualBasic
Public Class Globales
    'Public Shared connSTR As String = "dsn=dbdesa;uid=informix;pwd=informixdesa"
    'Public Shared connSTR As String = "dsn=desaweb;uid=desaweb;pwd=Dsa.web"
    Public Shared connSTR As String = ConfigurationManager.ConnectionStrings("ConnectionString_FamilyShop").ConnectionString
    Public Shared conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
    Private Const ConSignos As String = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ"
    Private Const SinSignos As String = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUcC"
    Public Shared Function SacaCaracteresEspeciales(ByRef Texto As String) As String
        Dim i As Integer
        If Len(Texto) <> 0 Then
            For i = 1 To Len(ConSignos)
                Texto = Replace(Texto, Mid(ConSignos, i, 1), Mid(SinSignos, i, 1))
            Next
        End If
        Return Texto
    End Function
    Public Shared Function VerificaCorreo(ByRef Mail As String) As String
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(Mail, pattern)
        Dim EmailAddressCheck As String
        If emailAddressMatch.Success Then
            EmailAddressCheck = Mail
        Else
            EmailAddressCheck = ""
        End If
        Return EmailAddressCheck
    End Function
End Class
