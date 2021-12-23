Imports CapaLN
Imports CapaNE
Public Class AgregarPtoVenta
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim ds As New DataSet
        Dim objPuntoVentaNE As New ClasePutoVenta
        Dim objPuntoventaLN As New VentasLN
        Dim activo As Integer
        Dim pordefecto As Integer
        If TextBox1.Text = "" Then
            MessageBox.Show("Debe ingresar un punto de Venta válido")
        Else
            ds = objPuntoventaLN.buscarPtoVenta(TextBox1.Text)

        If ds.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("El punto de venta ya se encuentra registrado")
        Else

            objPuntoVentaNE.puntoVenta = TextBox1.Text
                objPuntoventaLN.InsertarPuntoVenta(objPuntoVentaNE)
                MessageBox.Show("Se agregó el punto de venta")
                Me.Close()
                PuntoVenta.inicio()
            End If
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.MaxLength = 5
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class