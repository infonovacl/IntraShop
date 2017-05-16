Imports Microsoft.VisualBasic
Public Class Globales
    'Public Shared connSTR As String = "dsn=dbdesa;uid=informix;pwd=informixdesa"
    Public Shared connSTR As String = "dsn=dbdesaweb;uid=desaweb;pwd=Dsa.web"
    Public Shared conn As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(connSTR)
End Class
