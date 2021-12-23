Imports System
Imports System.Data.SqlClient
Imports capaDA.My
Imports System.Configuration
Public Class Conexion
    Public Function abrir() As SqlConnection

        Dim con As String
        Dim scon As New SqlConnection
        'con = "Data Source=" & Global.capaDA.My.Settings.nombreServidor & ";Initial Catalog=" & Global.capaDA.My.Settings.nombreBase & ";Integrated Security=True"
        'con = "Data Source=NB216\SQLEXPRESS;Initial Catalog=XVN;Integrated Security=True"
        con = "Data Source=DESKTOP-9AQCF25;Initial Catalog=XVN;Integrated Security=True"
        scon = New SqlConnection(con)
        'multipleactiveresultsets = True

        scon.Open()
        Return scon

    End Function
End Class
