Imports CapaNE
Imports CapaLN
Public Class BuscarProductoVenta
    Dim objStockLN As New StockLN
    Dim objStockNe As New ClaseStock
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea seleccionar Producto?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objStockLN As New StockLN
            Dim objStockNe As New ClaseStock
            Dim objventaLN As New VentasLN
            Dim idStock As Integer
            Dim idPRov As Integer
            Dim ds As New DataSet
            Dim dsPrecVta As New DataSet
            Dim dsProveed As New DataSet
            If dgvStock.CurrentRow.Selected = True Then
                idStock = Me.dgvStock.CurrentRow.Cells(3).Value
                ds = objStockLN.buscarIdStock(idStock)
                RegistrarVenta.TextBox2.Text = ds.Tables(0).Rows(0).Item(2).ToString
                dsProveed = objventaLN.buscarPRoveedos(idStock)
                idPRov = dsProveed.Tables(0).Rows(0).Item(0).ToString
                dsPrecVta = objventaLN.buscarPrecioVta(idStock, idPRov)
                RegistrarVenta.TextBox3.Text = dsPrecVta.Tables(0).Rows(0).Item(0).ToString
                Me.Close()

            End If
            RegistrarVenta.idStoock = idStock

        End If
    End Sub
    Private Sub ComboBoxBuscarOpc_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectionChangeCommitted
        If CboCampo.SelectedItem = "Categoría" Then
            cargarComboCategoria()
        ElseIf CboCampo.SelectedItem = "Proveedor" Then
            cargarComboProveedores()
        End If
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
    Sub cargarComboProveedores()
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock

        ds = New DataSet
        ds = objStockLN.cargarComboProveedores(objStockNe)
        ComboBox1.DataSource = ds.Tables("tabProv")
        ComboBox1.DisplayMember = "NomRaz"
        ComboBox1.ValueMember = "idProv"
        ComboBox1.Text = "Seleccione"
    End Sub

    Private Sub CboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectedIndexChanged
        If CboCampo.Text = "Categoría" Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock

        If CboCampo.SelectedItem = "Categoría" And TextBox1.Text = "" Then
            'ds = objStockLN.cargarGrillaCategoriaSolo(ComboBox1.Text)
            'dgvStock.DataSource = ds.Tables(0)

        End If

        If CboCampo.SelectedItem = "Proveedor" Then
            ds = objStockLN.cargarGrillaProveedor(ComboBox1.Text)
            dgvStock.DataSource = ds.Tables(0)
        End If

    End Sub

    Private Sub ComboBox1_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles ComboBox1.PreviewKeyDown
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock
        ds = objStockLN.cargarGrillaCategoria(ComboBox1.Text, TextBox1.Text)
        dgvStock.DataSource = ds.Tables(0)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock
        If CboCampo.SelectedItem = "Categoría" And TextBox1.Text <> "" Then
            ds = objStockLN.cargarGrillaCategoria(ComboBox1.Text, TextBox1.Text)
            dgvStock.DataSource = ds.Tables(0)

        End If
    End Sub

    Private Sub BuscarProductoVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objStockLN.cargaGrilla()
        dgvStock.DataSource = ds.Tables(0)
        dgvStock.Columns(0).Width = 150
        dgvStock.Columns(1).Width = 200
        dgvStock.Columns(2).Width = 120
        dgvStock.Columns(3).Width = 80
        TextBox1.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class