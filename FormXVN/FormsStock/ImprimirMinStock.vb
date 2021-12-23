Public Class ImprimirMinStock

    Private Sub ImprimirMinStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'XVNDataSet.Stock' Puede moverla o quitarla según sea necesario.
        Me.StockTableAdapter.FillBy(Me.XVNDataSet.Stock)

        'Me.ReportViewer1.RefreshReport()
    End Sub
End Class