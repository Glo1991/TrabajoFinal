Imports CapaLN
Imports CapaNE
Public Class ModificarPrecVta
    Dim objPrecVtaLN As New PreciosVtaLN
    Dim objPrecVtaNe As New ClasePreciosVta
    Public idPrecio As Integer
    Public idAProv As Integer
    Private Sub ModificarPrecVta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        DateTimePicker1.Enabled = False

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click

    End Sub
End Class