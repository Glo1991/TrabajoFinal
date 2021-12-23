Imports CapaNE
Imports CapaLN
Public Class VerMinStock
    Dim objStockLN As New StockLN
    Dim objStockNe As New ClaseStock
    Private Sub VerMinStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objStockLN.cargaGrillaMinStock()
        dgvStock.DataSource = ds.Tables(0)
        dgvStock.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvStock.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvStock.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvStock.Columns(3).Width = 70
        dgvStock.Columns(4).Width = 70
        dgvStock.Columns(5).Width = 80

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock

        If CboCampo.SelectedItem = "Categoría" Then
            ds = objStockLN.cargarGrillaCategoriaMnStock(ComboBox1.SelectedValue)
            dgvStock.DataSource = ds.Tables(0)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ds As New DataSet
        ds = objStockLN.cargaGrillaMinStock()
        dgvStock.DataSource = ds.Tables(0)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Sub cargarComboCategoria()
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock

        ds = New DataSet
        ds = objStockLN.cargarComboCategoria(objStockNe)
        ComboBox1.DataSource = ds.Tables("tabCat")
        ComboBox1.DisplayMember = "NomCategoria"
        ComboBox1.ValueMember = "idCategoria"
        ComboBox1.Text = "Seleccione"
    End Sub
    Private Sub ComboBoxBuscarOpc_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectionChangeCommitted
        If CboCampo.SelectedItem = "Categoría" Then
            cargarComboCategoria()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ImprimirMinStock.Show()
    End Sub
End Class