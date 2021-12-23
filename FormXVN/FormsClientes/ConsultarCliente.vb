Imports CapaNE
Imports CapaLN
Public Class ConsultarCliente
    Public idAlumnaaa As Integer

    Dim objAlumnaLN As New ClienteLN
    Dim objAlumnaNe As New ClaseCliente
    Private Sub ConsultarCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class