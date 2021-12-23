Imports CapaLN
Imports CapaNE
Public Class BuscarPresupuestos
    Public idcliente As Integer
    Public BFACTURA As Integer
    Private Sub BuscarPresupuestos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim objVenta As New VentasLN
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        DateTimePicker1.Value = DateTimePicker1.Value.AddDays(-30)
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(0).DefaultCellStyle.Alignment = ContentAlignment.MiddleRight
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = ContentAlignment.MiddleRight
        DataGridView1.ClearSelection()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim numPR As Integer
        Dim objPr As New PresupuestosLN
        Dim objIPR As New PresupuestosLN
        numPR = DataGridView1.CurrentRow.Cells(0).Value
        ds = objPr.detallePresupuesto(numPR)
        ds2 = objIPR.detalleItemPresupuesto(numPR)
        DetallePresupuesto.txtNombre.Text = ds.Tables(0).Rows(0).Item(0).ToString
        DetallePresupuesto.TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString
        DetallePresupuesto.dtpFecIng.Value = ds.Tables(0).Rows(0).Item(2).ToString
        DetallePresupuesto.TextBox5.Text = ds.Tables(0).Rows(0).Item(3).ToString
        DetallePresupuesto.Label8.Text = ds.Tables(0).Rows(0).Item(4).ToString
        If ds.Tables(0).Rows(0).Item(5) = 0 Then
            DetallePresupuesto.Label6.Visible = False
        Else
            DetallePresupuesto.Label6.Visible = True
        End If
        DetallePresupuesto.DataGridView1.DataSource = ds2.Tables(0)
        DetallePresupuesto.Show()
        For Each n As Int32 In filas_sel
            DataGridView1.Rows(n).Selected = True

        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ds As New DataSet
        Dim objV As New VentasLN
        Dim numpr As Integer
        Dim dt As New DataTable

        Dim objvta As New VentasLN
        If filas_sel.Count = 0 Then
            MessageBox.Show("No ha seleccionado ningún presupuesto")
        Else
            For Each n As Int32 In filas_sel
                Dim dscosto As New DataSet
                numpr = DataGridView1.Rows(n).Cells(0).Value
                dscosto = objvta.buscarCOSTOItemPresupuesto(numpr)
                If dscosto.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show("Este presupuesto contiene artículos con precios menor al costo. Sólo se va a seleccionar los artículos con precios correctos")
                End If
            Next
            For Each n As Int32 In filas_sel

                numpr = DataGridView1.Rows(n).Cells(0).Value
                'dt = objV.buscarItemPresupuesto(numpr)
                ds.Tables.Add(objV.buscarItemPresupuesto(numpr))

                'Me.Close()
            Next
            For i As Integer = 0 To filas_sel.Count - 1
                ds.Tables(0).Merge(ds.Tables(i))
            Next
            RegistrarVenta.DataGridView1.Rows.Clear()
            RegistrarVenta.TextBox5.Clear()
            For dv As Integer = 0 To ds.Tables(0).Rows.Count - 1

                RegistrarVenta.DataGridView1.Rows.Add(ds.Tables(0).Rows(dv).Item(0), ds.Tables(0).Rows(dv).Item(1), ds.Tables(0).Rows(dv).Item(2), ds.Tables(0).Rows(dv).Item(3), ds.Tables(0).Rows(dv).Item(4), ds.Tables(0).Rows(dv).Item(5))
                RegistrarVenta.listaPR.Add(ds.Tables(0).Rows(dv).Item(6))
            Next

            'RegistrarVenta.DataGridView1.DataSource = ds.Tables(0)
            RegistrarVenta.Totalsuma()
            Me.Close()
        End If

    End Sub
    Dim filas_sel As New List(Of Integer)
    Private Sub SeleccionarDeseleccionarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarDeseleccionarToolStripMenuItem.Click
        Dim i As Integer = DataGridView1.CurrentRow.Index
        DataGridView1.Rows(i).Selected = False
        If filas_sel.Contains(i) Then
            filas_sel.Remove(i)
        Else
            filas_sel.Add(i)
        End If
        For Each n As Int32 In filas_sel
            DataGridView1.Rows(n).Selected = True
        Next
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        For Each n As Int32 In filas_sel
            DataGridView1.Rows(n).Selected = True

        Next
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        For Each n As Int32 In filas_sel
            DataGridView1.Rows(n).Selected = True

        Next
    End Sub
End Class