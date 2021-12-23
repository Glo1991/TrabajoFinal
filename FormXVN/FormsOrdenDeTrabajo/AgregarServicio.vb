Imports CapaLN
Imports CapaNE
Public Class AgregarServicio
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub AgregarServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim objServicioLN As New ServiciosLN
        ds = objServicioLN.nuevoCodServicio()
        txtCodigo.Text = ds.Tables(0).Rows(0).Item(0).ToString
        txtCodigo.Enabled = False

    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim objServicioLN As New ServiciosLN
        Dim objServicioNE As New ClaseServicios
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar una descripción")
        Else
            If TextBox1.Text = "" Then
                MessageBox.Show("Debe ingresar un precio")
            Else
                objServicioNE.DescripcionServicio = txtNombre.Text
                objServicioNE.CostoServicio = TextBox1.Text
                objServicioLN.InsertarServicio(objServicioNE)
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