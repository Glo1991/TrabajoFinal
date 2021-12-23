Imports CapaLN
Imports CapaNE
Public Class ModificarPuntoVenta
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim objPuntoVentaNE As New ClasePutoVenta
        Dim objPuntoventaLN As New VentasLN
        Dim activo As Integer
        Dim pordefecto As Integer
        If CheckBox1.Checked = True Then
            activo = 1
        Else
            activo = 0
        End If

        If CheckBox2.Checked = True Then
            pordefecto = 1
        Else
            pordefecto = 0
        End If



        If CheckBox2.Checked = True And CheckBox1.Checked = False Then
            MessageBox.Show("No se puede desactivar porque el punto de venta está por defecto")
            CheckBox1.Checked = True
        Else
            If pordefecto = 1 Then
                Dim ds1 As New DataSet
                ds1 = objPuntoventaLN.puntoporDefecto()
                If ds1.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show("Ya existe un punto de venta por defecto")
                Else

                    objPuntoVentaNE.activo = activo
                    objPuntoVentaNE.Pordefecto = pordefecto
                    objPuntoVentaNE.puntoVenta = TextBox1.Text
                    objPuntoventaLN.modificarPtoVenta(objPuntoVentaNE)


                    MessageBox.Show("Se modificó el punto de venta")
                    Me.Close()
                    PuntoVenta.inicio()
                End If
            Else

                objPuntoVentaNE.activo = activo
                objPuntoVentaNE.Pordefecto = pordefecto
                objPuntoVentaNE.puntoVenta = TextBox1.Text
                objPuntoventaLN.modificarPtoVenta(objPuntoVentaNE)


                MessageBox.Show("Se modificó el punto de venta")
                Me.Close()
                PuntoVenta.inicio()

            End If
            End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = True
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = True
        End If
    End Sub
End Class