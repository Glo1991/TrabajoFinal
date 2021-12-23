Imports CapaNE
Imports CapaLN
Public Class NuevaMarca
    Dim objMarcaLN As New ArticulosLN
    Dim objMarcaNe As New ClaseArticulo
    Private Sub NuevaMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objMarcaLN.cargarIdmarca()
        TextBox1.Text = ds.Tables(0).Rows(0).Item(0).ToString
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim idMarca As Integer
        Dim resp As Integer
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar una descripción")
        Else
            If TextBox2.Text = "" Then
                MessageBox.Show("Debe ingresar un margen")
            Else
                resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = vbYes Then
                    If txtNombre.Text = "" Then
                        MsgBox("Debe ingresar una Descripción")
                    Else
                        Dim objMarcaNe As ClaseMarca
                        objMarcaNe = New ClaseMarca
                        objMarcaNe.DescripcionMarca = txtNombre.Text
                        objMarcaNe.Margen = TextBox2.Text
                        idMarca = objMarcaLN.InsertMarca(objMarcaNe)
                        MsgBox("Los datos ingresados se guardaron Correctamente")
                        Dim ds As New DataSet
                        ds = objMarcaLN.cargaGrillaMArca()
                        Marcas.dgvMarcas.DataSource = ds.Tables(0)
                        Marcas.dgvMarcas.Columns(0).Width = 70
                        Me.Close()
                    End If
                End If
            End If
        End If

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