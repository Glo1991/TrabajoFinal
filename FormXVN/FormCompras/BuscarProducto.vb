Imports CapaNE
Imports CapaLN
Public Class BuscarProducto
    Dim objartLN As New ArticulosLN
    Dim objartkNe As New ClaseArticulo
    Public numPR As Integer
    Public numFactura As Integer
    Private Sub BuscarProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objartLN.cargaGrillaArt()
        dgvStock.DataSource = ds.Tables(0)
        dgvStock.Columns(0).DefaultCellStyle.Alignment = HorizontalAlignment.Right
        dgvStock.Columns(0).Width = 70
        TextBox1.Enabled = False
        numPR = 0
        If XVN.Label3.Text = "Limitada" Then

            Button3.Enabled = False
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
            'ds = objStockLN.cargarGrillaProveedor(ComboBox1.Text)
            'dgvStock.DataSource = ds.Tables(0)
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        NuevoArticulo.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea seleccionar Producto?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            If numPR <> 0 Then
                Dim objartLN As New ArticulosLN
                Dim objartkNe As New ClaseArticulo
                'Dim formModStock As New ModificarStock
                Dim idStock As Integer
                Dim ds As New DataSet
                If dgvStock.CurrentRow.Selected = True Then
                    idStock = Me.dgvStock.CurrentRow.Cells(0).Value
                    ds = objartLN.buscaridArticulo(idStock)
                    NuevoPresupuestos.TextBox6.Text = ds.Tables(0).Rows(0).Item(1).ToString
                    NuevoPresupuestos.TextBox7.Text = ds.Tables(0).Rows(0).Item(0).ToString
                    NuevoPresupuestos.TextBox8.Text = ds.Tables(0).Rows(0).Item(6).ToString

                    Me.Close()

                End If
            Else

                If numFactura <> 0 Then
                    Dim objartLN As New ArticulosLN
                    Dim objartkNe As New ClaseArticulo
                    'Dim formModStock As New ModificarStock
                    Dim idStock As Integer
                    Dim ds As New DataSet
                    If dgvStock.CurrentRow.Selected = True Then
                        idStock = Me.dgvStock.CurrentRow.Cells(0).Value
                        ds = objartLN.buscaridArticulo(idStock)
                        RegistrarVenta.TextBox2.Text = ds.Tables(0).Rows(0).Item(1).ToString
                        RegistrarVenta.TextBox8.Text = ds.Tables(0).Rows(0).Item(0).ToString
                        RegistrarVenta.TextBox3.Text = ds.Tables(0).Rows(0).Item(6).ToString

                        Me.Close()

                    End If
                Else
                    Dim objartLN As New ArticulosLN
                    Dim objartkNe As New ClaseArticulo
                    'Dim formModStock As New ModificarStock
                    Dim idStock As Integer
                    Dim ds As New DataSet
                    If dgvStock.CurrentRow.Selected = True Then
                        idStock = Me.dgvStock.CurrentRow.Cells(0).Value
                        ds = objartLN.buscaridArticulo(idStock)
                        RegistrarCompra.TextBox2.Text = ds.Tables(0).Rows(0).Item(1).ToString

                        Me.Close()

                    End If

                    RegistrarCompra.idStoock = idStock
                End If
            End If

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class