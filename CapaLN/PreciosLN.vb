Imports CapaNE
Imports capaDA
Public Class PreciosLN
    Private objPrec As MetodosPreciosDA

    Public Sub New()
        objPrec = New MetodosPreciosDA
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objPrec.CargarGrilla()
    End Function
    Public Function InsertarPrecio(ByVal objPrecNE As ClasePrecios) As Integer
        Dim id As Integer
        id = objPrec.InsertarPrecio(objPrecNE)
        Return id
    End Function
    Public Sub modificarPrecio(ByVal objPrecNE As ClasePrecios)
        objPrec.modificarPrecio(objPrecNE)
    End Sub
    Public Function cargarGrillaProvees(ByVal producto As String) As DataSet
        Return objPrec.CargarGrillaProducto(producto)
    End Function
    Public Function cargarGrillaProveesPR(ByVal producto As String) As DataSet
        Return objPrec.CargarGrillaProductoPR(producto)
    End Function
    Public Function buscarFechasGrilla(ByVal fech As Date, ByVal fecha As Date) As DataSet
        Return objPrec.BuscarFEchasGrilla(fech, fecha)
    End Function
    Public Function buscarIdPrecio(ByVal idPRecio As String) As DataSet
        Return objPrec.BuscarIdPrecios(idPRecio)
    End Function
    Public Function buscarIdStock(ByVal idStock As String) As DataSet
        Return objPrec.BuscarIdStock(idStock)
    End Function
End Class
