Imports CapaNE
Imports CapaLN
Public Class Sotck
    Dim objStockLN As New StockLN
    Dim objStockNe As New ClaseStock
    Private Sub Sotck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ds As New DataSet
        ds = objStockLN.cargaGrilla()
        dgvStock.DataSource = ds.Tables(0)
        dgvStock.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvStock.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvStock.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvStock.Columns(3).Width = 70
        dgvStock.Columns(4).Width = 70
        dgvStock.Columns(5).Width = 80
        TextBox1.Enabled = False

        cargarComboCategoria()


        SumaStock()
        If XVN.Label3.Text = "Limitada" Then
            Button4.Enabled = False

        End If
    End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ds As New DataSet
        ds = objStockLN.cargaGrilla()
        dgvStock.DataSource = ds.Tables(0)
        cargarComboCategoria()
        TextBox1.Clear()
        CboCampo.Text = "Seleccione"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea Modificar el Stock?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objStockLN As New StockLN
            Dim objStockNe As New ClaseStock
            Dim formModStock As New ModificarStock
            Dim idStock As Integer
            'Dim cantidad As Double
            Dim ds As New DataSet
            If dgvStock.CurrentRow.Selected = True Then
                idStock = Me.dgvStock.CurrentRow.Cells(3).Value
                ds = objStockLN.buscarIdStock(idStock)
                ModificarStock.txtCodigo.Text = Me.dgvStock.CurrentRow.Cells(3).Value
                ModificarStock.txtProducto.Text = Me.dgvStock.CurrentRow.Cells(2).Value
                ModificarStock.NumericUpDown1.Text = Me.dgvStock.CurrentRow.Cells(4).Value
                ModificarStock.Cantidad = Me.dgvStock.CurrentRow.Cells(4).Value




            End If
            ModificarStock.idStoock = idStock
            ModificarStock.Show()
            ModificarStock.txtProducto.Enabled = False
            ModificarStock.txtCodigo.Enabled = False
        End If
    End Sub
    Private Sub ComboBoxBuscarOpc_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectionChangeCommitted
        If CboCampo.SelectedItem = "Categoría" Then
            cargarComboCategoria()

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
            ds = objStockLN.cargarGrillaCategoriaSolo(ComboBox1.SelectedValue, TextBox1.Text)
            dgvStock.DataSource = ds.Tables(0)


        End If
    End Sub

    Private Sub ComboBox1_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles ComboBox1.PreviewKeyDown
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock
        ds = objStockLN.cargarGrillaCategoriaSolo(ComboBox1.SelectedValue, TextBox1.Text)
        dgvStock.DataSource = ds.Tables(0)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock
        If CboCampo.SelectedItem = "Categoría" And TextBox1.Text <> "" Then
            ds = objStockLN.cargarGrillaCategoriaSolo(ComboBox1.SelectedValue, TextBox1.Text)
            dgvStock.DataSource = ds.Tables(0)


        End If
        If CboCampo.Text = "Seleccione" And TextBox1.Text <> "" Then
            ds = objStockLN.cargarGrillaDescSolo(TextBox1.Text)
            dgvStock.DataSource = ds.Tables(0)


        End If
    End Sub
    Sub SumaStock()
        Dim stockIn As String
        Dim totEq As Integer
        For Each dgv As DataGridViewRow In dgvStock.Rows
            stockIn = dgv.Cells(4).Value
            If stockIn < dgv.Cells(5).Value Then
                totEq = totEq + 1
            End If
        Next
        lblStock.Text = totEq.ToString

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        VerMinStock.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ReporteSTOCK1.Show()
    End Sub
End Class