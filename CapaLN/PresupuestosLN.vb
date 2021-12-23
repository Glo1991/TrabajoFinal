Imports capaDA
Imports CapaNE
Public Class PresupuestosLN
    Private objPR As New MetodosPresupuestos
    Dim objVinOT As New MetodosOTDA
    Public Function cargaGrilla() As DataSet
        Return objPR.CargarGrilla()
    End Function
    Public Function InsertPresupuestos(ByVal objbtPR As ClasePresupuestos) As Integer
        Dim id As Integer
        id = objPR.InsertarPresupuesto(objbtPR)
        Return id
    End Function
    Public Function InsertItemPR(ByVal objItPR As ClaseItemPR) As Integer
        Dim id As Integer
        id = objPR.InsertarItemPR(objItPR)
        Return id
    End Function
    Public Function NuevoPresupuesto() As DataSet
        Return objPR.nuevoPresupuesto()
    End Function
    Public Function InsertVinculoOT(ByVal VinOT As ClaseVinculo) As Integer
        Dim id As Integer
        id = objVinOT.InsertaVinculoOT(VinOT)
        Return id
    End Function
    Public Function CargarPresupuestoVinculoOT(ByVal idOt) As DataSet
        Return objVinOT.CargarPresupuestoVinculoOT(idOt)
    End Function
    Public Function CargarItemVinculoOT(ByVal idOt) As DataSet
        Return objVinOT.CargarItemVinculoOT(idOt)
    End Function
    Public Function cargaGrillafechas(ByVal fechadesde As String, ByVal fechahasta As String, ByVal dni As String, ByVal numpr As String, ByVal anulado As Integer) As DataSet
        Return objPR.CargarGrillaFechas(fechadesde, fechahasta, dni, numpr, anulado)
    End Function
    Public Function esarticulo(ByVal idarticulo As Integer) As Integer
        Return objPR.EsArticulo(idarticulo)
    End Function
    Public Function detallePresupuesto(ByVal idpresupuesto As Integer) As DataSet
        Return objPR.detallePresupuesto(idpresupuesto)
    End Function
    Public Function detalleItemPresupuesto(ByVal idpresupuesto As Integer) As DataSet
        Return objPR.detalleItemPresupuesto(idpresupuesto)
    End Function
    Public Function VinculosFacturaPresupuestp(ByVal idpresupuesto As Integer) As DataSet
        Return objPR.VinculosFacturaPresupuestp(idpresupuesto)
    End Function
    Public Function VinculosPRFactura(ByVal numFactura As Long, ByVal tipofac As String) As DataSet
        Return objPR.VinculosPRFactura(numFactura, tipofac)
    End Function
    Public Function vinculosPR(ByVal idPR As Integer) As DataSet
        Return objPR.vinculosPR(idPR)
    End Function
    Public Sub modificarPRAnulado(ByVal idPR As Integer)
        objPR.modificarPRAnulado(idPR)
    End Sub
    Public Function vinculosPROT(ByVal idPR As Integer) As DataSet
        Return objPR.vinculosPROT(idPR)
    End Function
    Public Sub ModificarvinculosPRInactivoOT(ByVal idPR As Integer)
        objPR.ModificarvinculosPRInactivoOT(idPR)
    End Sub
    Public Function buscarPRanulado(ByVal idPR As Integer) As DataSet
        Return objPR.buscarPRanulado(idPR)
    End Function
End Class
