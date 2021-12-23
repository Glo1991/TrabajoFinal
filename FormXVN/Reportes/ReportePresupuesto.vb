Public Class ReportePresupuesto
    Private Sub ReportePresupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DataSet1.DataTable3' Puede moverla o quitarla según sea necesario.
        Me.DataTable3TableAdapter.Fill(Me.DataSet1.DataTable3, DetallePresupuesto.Label8.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class