Public Class GraficoVentasxAr
    Private Sub GraficoVentasxAr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Chart1.Legends.Add("Artículos")

        Label3.Text = Reporteventasxarticulo.DateTimePicker1.Value.ToShortDateString
        Label2.Text = Reporteventasxarticulo.DateTimePicker2.Value.ToShortDateString

        For Each dgv As DataGridViewRow In Reporteventasxarticulo.DataGridView1.Rows
            Chart1.Series(0).Points.AddXY(dgv.Cells(2).Value, dgv.Cells(4).Value)
        Next
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


End Class