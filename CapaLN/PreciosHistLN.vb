Imports CapaNE
Imports capaDA
Public Class PreciosHistLN
    Private objPrecHist As MetodosPrecioHistDA

    Public Sub New()
        objPrecHist = New MetodosPrecioHistDA
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objPrecHist.CargarGrilla()
    End Function
    Public Function InsertarPrecioHist(ByVal objPrecHistNE As ClasePreciosHist) As Integer
        Dim id As Integer
        id = objPrecHist.InsertarPrecioHist(objPrecHistNE)
        Return id
    End Function
    Public Function cargarGrillaProd(ByVal producto As String) As DataSet
        Return objPrecHist.CargarGrillaProducto(producto)
    End Function
    Public Function cargarGrillaProv(ByVal prov As String) As DataSet
        Return objPrecHist.CargarGrillaProv(prov)
    End Function
    Public Function cargarGrillaProvProd(ByVal prov As String, ByVal prod As String) As DataSet
        Return objPrecHist.CargarGrillaProvProc(prov, prod)
    End Function
    Public Function cargarGrillaProvProdFecha(ByVal prov As String, ByVal prod As String, ByVal fecha As Date, ByVal fech As Date) As DataSet
        Return objPrecHist.CargarGrillaProvProdFech(prov, prod, fecha, fech)
    End Function
    Public Function cargarGrillaFecha(ByVal fecha As Date, ByVal fech As Date) As DataSet
        Return objPrecHist.CargarGrillaFecha(fecha, fech)
    End Function
    Public Function buscarIdStock(ByVal idStock As Integer, ByVal idProv As Integer) As DataSet
        Return objPrecHist.BuscarIdStockIdProv(idStock, idProv)
    End Function
End Class
