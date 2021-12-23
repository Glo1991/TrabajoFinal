Imports capaDA
Imports CapaNE
Public Class CobrosLN
    Private objCobro As New MetodosCobrosDA
    Public Function cargargrilla() As DataSet
        Return objCobro.CargarGrilla()
    End Function
    Public Function InsertarCobro(ByVal Cobro As ClaseCobro) As Integer
        Dim id As Integer
        id = objCobro.InsertarCobro(Cobro)
        Return id
    End Function
    Public Sub modificarCobroFactura(ByVal numfactura As Long, ByVal tipofac As String)
        objCobro.modificarCobroFactura(numfactura, tipofac)
    End Sub
    Public Function buscarpagado(ByVal numfactura As String, ByVal tipofac As String) As DataSet
        Return objCobro.buscarpagado(numfactura, tipofac)
    End Function
    Public Function buscarcobro(ByVal idcobro) As DataSet
        Return objCobro.buscarCobro(idcobro)
    End Function
    Public Sub modificarCobroANULFactura(ByVal numfactura As Long, ByVal tipofac As String)
        objCobro.modificarCobroANULFactura(numfactura, tipofac)
    End Sub
    Public Sub modificarCobroANUladoCOBRO(ByVal idcobro As Integer)
        objCobro.modificarCobroANUladoCOBRO(idcobro)
    End Sub
    Public Function buscarfechacobro(ByVal fechadesde As String, ByVal fechahasta As String) As DataSet
        Return objCobro.buscarfechacobro(fechadesde, fechahasta)
    End Function
End Class
