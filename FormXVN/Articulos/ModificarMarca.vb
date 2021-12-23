Imports CapaLN
Imports CapaNE
Public Class ModificarMarca
    Public idMarca As Integer
    Private Sub ModificarMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim objMarcaLN As New ArticulosLN
        Dim objMarcaNe As New ClaseMarca
        objMarcaNe.DescripcionMarca = txtNombre.Text
        objMarcaNe.idMarca = idMarca
        objMarcaNe.Margen = TextBox2.Text
        objMarcaLN.modificarMarca(objMarcaNe)
        Me.Close()
        Dim ds As DataSet

        Dim form As New Marcas
        ds = objMarcaLN.cargaGrillaMArca
        Marcas.dgvMarcas.DataSource = ds.Tables(0)
        Marcas.dgvMarcas.Columns(0).Width = 70
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
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