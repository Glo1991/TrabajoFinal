Imports CapaNE
Imports CapaLN
Public Class NuevaCategoria
    Dim objCatLN As New ArticulosLN
    Dim objCatNe As New ClaseCategoria
    Private Sub NuevaCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objCatLN.cargarIdCategoria()
        TextBox1.Text = ds.Tables(0).Rows(0).Item(0).ToString

    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim idCategoria As Integer
        Dim resp As Integer
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar una descripción")
        Else
            resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = vbYes Then
                If txtNombre.Text = "" Then
                    MsgBox("Debe ingresar una Descripción")
                Else
                    Dim objCatNe As ClaseCategoria
                    objCatNe = New ClaseCategoria
                    objCatNe.DescripcionCategoria = txtNombre.Text

                    idCategoria = objCatLN.InsertCategoria(objCatNe)
                    MsgBox("Los datos ingresados se guardaron Correctamente")
                    Dim ds As New DataSet
                    ds = objCatLN.cargaGrillCategoria()
                    Categoria.dgvMarcas.DataSource = ds.Tables(0)
                    Categoria.dgvMarcas.Columns(0).Width = 70
                    Me.Close()

                End If
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class