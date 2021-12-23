
Imports CapaLN
Imports Microsoft.Reporting.WinForms
Imports FormXVN
Public Class reporterentabilidad
    Dim obj As New EstadisticasLN
    Public NombreReporte As String = "FormXVN.Report1RENTAB.rdlc"
    Public FormaReporte As String = "Normal"
    Private Sub reporterentabilidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable

        Try
            'AgendaForm.Adaptador.Fill(dt)
            Dim rds As ReportDataSource = New ReportDataSource
            rds.Name = "DataSet1"
            dt = obj.Reporterentabilidad(Rentabilidad.fechadesde, Rentabilidad.fechahasta)
            rds.Value = dt

            ReportViewer1.Reset()
            ReportViewer1.LocalReport.ReportEmbeddedResource = NombreReporte
            ReportViewer1.LocalReport.EnableExternalImages = True
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)


            Dim newPageSettings As New System.Drawing.Printing.PageSettings
            newPageSettings.Margins = New System.Drawing.Printing.Margins(50, 20, 20, 20)

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