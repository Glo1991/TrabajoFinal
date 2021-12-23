Imports CapaLN
Imports CapaNE
Public Class ModificarServicio
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim objServicioLN As New ServiciosLN
        Dim objServicioNe As New ClaseServicios
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar una descripción")
        Else
            If TextBox1.Text = "" Then
                MessageBox.Show("Debe ingresar un precio")
            Else
                objServicioNe.idServicio = txtCodigo.Text
                objServicioNe.DescripcionServicio = txtNombre.Text
                objServicioNe.CostoServicio = TextBox1.Text
                objServicioLN.modificarServicio(objServicioNe)
                Me.Close()
                Dim ds As New DataSet
                ds = objServicioLN.crgarGrillaServi()
                ListaServicios.dgvPrecios.DataSource = ds.Tables(0)
                ListaServicios.inicio()
            End If
        End If


    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If

        End If

    End Sub
End Class