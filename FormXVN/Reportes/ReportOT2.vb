Public Class ReportOT2
    Private Sub ReportOT2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DataSet1.cabezaOT' Puede moverla o quitarla según sea necesario.
        Me.cabezaOTTableAdapter.Fill(Me.DataSet1.cabezaOT, VerOrdenTRab.TextBox1.Text)
        'TODO: esta línea de código carga datos en la tabla 'DataSet1.cuerpoOT' Puede moverla o quitarla según sea necesario.
        Me.cuerpoOTTableAdapter.Fill(Me.DataSet1.cuerpoOT, VerOrdenTRab.TextBox1.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class