Imports CapaLN
Imports CapaNE
Public Class ModificarCategoria
    Public idCategoria As Integer
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim objCatLN As New ArticulosLN
        Dim objCatNe As New ClaseCategoria
        objCatNe.DescripcionCategoria = txtNombre.Text
        objCatNe.idCategoria = idCategoria
        objCatLN.modificarCateg(objCatNe)
        Me.Close()
        Dim ds As DataSet

        Dim form As New Categoria
        ds = objCatLN.cargaGrillCategoria
        Categoria.dgvMarcas.DataSource = ds.Tables(0)
        Categoria.dgvMarcas.Columns(0).Width = 70
    End Sub

    Private Sub ModificarCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class