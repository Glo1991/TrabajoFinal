Imports CapaLN
Imports CapaNE
Public Class SeleccionArticulo
    Private Sub SeleccionArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(1).Width = 70
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

        'DataGridView1.CurrentRow.Cells(0).Value.ToString = HistoricoStock.TextBox1.Text
        HistoricoStock.TextBox2.Text = CStr(DataGridView1.CurrentRow.Cells(1).Value)
        HistoricoStock.TextBox1.Text = CStr(DataGridView1.CurrentRow.Cells(0).Value)
        Me.Close()
    End Sub
End Class