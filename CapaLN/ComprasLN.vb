Imports CapaNE
Imports capaDA
Public Class ComprasLN
    Private objCompras As MetodosComprasDA
    Public Sub New()
        objCompras = New MetodosComprasDA
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objCompras.CargarGrilla()
    End Function
    Public Function InsertarCompras(ByVal objCompNE As ClaseCompras) As Integer
        Dim id As Integer
        id = objCompras.InsertarCompra(objCompNE)
        Return id
    End Function
    Public Function InsertarItem(ByVal objCompNE As ClaseItem) As Integer
        Dim id As Integer
        id = objCompras.InsertarItem(objCompNE)
        Return id
    End Function
    Public Function buscaridItem(ByVal item As String, ByVal item2 As String, ByVal item3 As String) As DataSet
        Return objCompras.BuscarIdItem(item, item2, item3)
    End Function
    Public Function buscarNumFact(ByVal NumFac As String) As DataSet
        Return objCompras.BuscarNumFact(NumFac)
    End Function
    Public Function buscaridCompra(ByVal compra As String) As DataSet
        Return objCompras.BuscarIdCompra(compra)
    End Function
    Public Sub borrarItem(ByVal item As ClaseItem)
        objCompras.borrarItem(item)
    End Sub
    Public Function buscarNumFactGrilla(ByVal NumFac As String) As DataSet
        Return objCompras.BuscarNumdeFactura(NumFac)
    End Function
    Public Function buscarNomdeProvGrilla(ByVal prov As String) As DataSet
        Return objCompras.BuscarNomdeProvGrilla(prov)
    End Function
    Public Function buscarNumdeCuitGrilla(ByVal cuit As String) As DataSet
        Return objCompras.BuscarNumdeCuitGrilla(cuit)
    End Function
    Public Function buscarFechasGrilla(ByVal fech As String, ByVal fecha As String) As DataSet
        Return objCompras.BuscarFEchasGrilla(fech, fecha)
    End Function
    Public Sub modificarStock(ByVal objStoock As Integer, ByVal sNuevo As Double)
        objCompras.modificarStockK(objStoock, sNuevo)
    End Sub
    Public Function buscaridStock(ByVal stock As String) As DataSet
        Return objCompras.BuscarIDStock(stock)
    End Function
    Public Sub modificarAnulado(ByVal objStoock As ClaseCompras)
        objCompras.modificarANulado(objStoock)
    End Sub
    Public Function buscarAnulado(ByVal stock As String) As DataSet
        Return objCompras.buscarAnulado(stock)
    End Function
    Public Function ValidarNumComprobante(ByVal tipo As String, ByVal num As String, ByVal cuit As String) As DataSet
        Return objCompras.ValidarNumComprobante(tipo, num, cuit)
    End Function
End Class
