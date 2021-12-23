Imports CapaNE
Imports CapaLN
Public Class ModificarStock
    Dim objStockLN As New StockLN
    Dim objStockNe As New ClaseStock
    Public idStoock As Integer
    Public Cantidad As Double

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock
        Dim objCSLN As New StockLN
        Dim objCSNe As New ClaseCorreccionStock
        objStockNe.cantidad = NumericUpDown1.Text
        objStockNe.idArticulo = idStoock
        objStockLN.modificarStock(objStockNe)

        If (NumericUpDown1.Value - Cantidad) < 0 Then
            objCSNe.idarticulo = idStoock
            objCSNe.Descripcion = "Correccion stock manual: " & TextBox1.Text
            objCSNe.Egreso = (NumericUpDown1.Value - Cantidad)
            objCSNe.Ingeso = 0
            objCSNe.fechamodificacion = Now
            objCSLN.InsertarCorreccionStock(objCSNe)
        Else
            objCSNe.idarticulo = idStoock
            objCSNe.Descripcion = "Correccion stock manual: " & TextBox1.Text
            objCSNe.Egreso = 0
            objCSNe.Ingeso = (NumericUpDown1.Value - Cantidad)
            objCSNe.fechamodificacion = Now
            objCSLN.InsertarCorreccionStock(objCSNe)
        End If
        Me.Close()
        Dim ds As New DataSet
        ds = objStockLN.cargaGrilla()
        Sotck.dgvStock.DataSource = ds.Tables(0)
        Sotck.TextBox1.Enabled = False


    End Sub

    Private Sub ModificarStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

End Class