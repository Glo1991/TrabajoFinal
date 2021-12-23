Imports CapaLN
Imports Microsoft.Reporting.WinForms
Imports FormXVN
Public Class ReporteSTOCK1
    Dim obj As New StockLN
    Public NombreReporte As String = "FormXVN.ReportSTOCK.rdlc"
    Public FormaReporte As String = "Normal"
    Private Sub ReporteSTOCK1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable

        Try
            'AgendaForm.Adaptador.Fill(dt)
            Dim rds As ReportDataSource = New ReportDataSource
            rds.Name = "DataSet1"
            Dim idcategoria As Integer
            Dim descripcion As String
            descripcion = Sotck.TextBox1.Text
            If Sotck.ComboBox1.Text = "Seleccione" Then
                idcategoria = 0
            Else
                idcategoria = Sotck.ComboBox1.SelectedValue
            End If
            dt = obj.ReporteStock(idcategoria, descripcion)
            rds.Value = dt

            ReportViewer1.Reset()
            ReportViewer1.LocalReport.ReportEmbeddedResource = NombreReporte
            ReportViewer1.LocalReport.EnableExternalImages = True
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)


            Dim newPageSettings As New System.Drawing.Printing.PageSettings
            newPageSettings.Margins = New System.Drawing.Printing.Margins(20, 20, 20, 20)

            'If FormaReporte = "Acostado" Then
            '    newPageSettings.Landscape = True
            'End If
            ReportViewer1.SetPageSettings(newPageSettings)
            Me.ReportViewer1.RefreshReport()


        Catch ex As Exception
            Console.WriteLine(Err.Description)
        End Try
    End Sub
End Class