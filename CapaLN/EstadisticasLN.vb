Imports capaDA
Imports CapaNE
Public Class EstadisticasLN
    Private objEstadistica As New MetodosEstadisticas
    Public Function cargaGrillaArt(ByVal idcategoria As String, ByVal idmarca As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataSet
        Return objEstadistica.CargarGrilla(idcategoria, idmarca, fechadesde, fechahasta)
    End Function
    Public Function cargarComboCategoria(ByVal objCombCat As ClaseCategoria) As DataSet
        Return objEstadistica.cargarComboCategoria()
    End Function
    Public Function cargarComboMarcas(ByVal objComMArca As ClaseMarca) As DataSet
        Return objEstadistica.cargarComboMarca()
    End Function
    Public Function CargarGrillaCompras(ByVal idcategoria As String, ByVal idmarca As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataSet
        Return objEstadistica.CargarGrillaCompras(idcategoria, idmarca, fechadesde, fechahasta)
    End Function
    Public Function rentabilidad(ByVal fechadesde As String, ByVal fechahasta As String) As DataSet
        Return objEstadistica.rentabilidad(fechadesde, fechahasta)
    End Function
    Public Function ReporteVentasxart(ByVal idcategoria As String, ByVal idmarca As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataTable
        Return objEstadistica.ReporteVentasxart(idcategoria, idmarca, fechadesde, fechahasta)
    End Function
    Public Function Reporterentabilidad(ByVal fechadesde As String, ByVal fechahasta As String) As DataTable
        Return objEstadistica.Reporterentabilidad(fechadesde, fechahasta)
    End Function
    Public Function ReporteComrpasxart(ByVal idcategoria As String, ByVal idmarca As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataTable
        Return objEstadistica.ReporteComrpasxart(idcategoria, idmarca, fechadesde, fechahasta)
    End Function
    Public Function ReportePR(ByVal numpr As Double) As DataTable
        Return objEstadistica.ReportePR(numpr)
    End Function
End Class
