Public Class GraficoRentabilidad
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub GraficoRentabilidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = Rentabilidad.DateTimePicker1.Value.ToShortDateString
        Label2.Text = Rentabilidad.DateTimePicker2.Value.ToShortDateString

        For Each dgv As DataGridViewRow In Rentabilidad.DataGridView1.Rows
            Chart1.Series("Venta").Points.AddXY(dgv.Cells(1).Value + " " + Mid((dgv.Cells(2).Value), 7, 8), dgv.Cells(4).Value)
            Chart1.Series("Costo").Points.AddXY(dgv.Cells(1).Value + " " + Mid((dgv.Cells(2).Value), 7, 8), dgv.Cells(5).Value)
        Next
    End Sub
End Class