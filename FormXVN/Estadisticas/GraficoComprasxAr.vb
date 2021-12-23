Public Class GraficoComprasxAr
    Private Sub GraficoComprasxAr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = ComprasxArticulo.DateTimePicker1.Value.ToShortDateString
        Label2.Text = ComprasxArticulo.DateTimePicker2.Value.ToShortDateString

        For Each dgv As DataGridViewRow In ComprasxArticulo.DataGridView1.Rows
            Chart1.Series(0).Points.AddXY(dgv.Cells(2).Value, dgv.Cells(4).Value)

        Next
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class