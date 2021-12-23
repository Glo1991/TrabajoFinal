Imports CapaNE
Imports capaDA
Public Class VentasLN
    Private objVentas As MetodosVentasDA
    Private objPuntoV As New MetodosPuntoVentaDA
    Public Sub New()
        objVentas = New MetodosVentasDA
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objVentas.CargarGrilla()
    End Function
    Public Function buscarPrecioVta(ByVal idStock As Integer, ByVal idProv As Integer) As DataSet
        Return objVentas.BuscarPrecVta(idStock, idProv)
    End Function
    Public Function buscarPRoveedos(ByVal idStock As Integer) As DataSet
        Return objVentas.BuscarProveedor(idStock)
    End Function
    Public Function InsertarVentas(ByVal objVta As ClaseVentas) As Integer
        Dim id As Integer
        id = objVentas.InsertarVenta(objVta)
        Return id
    End Function
    Public Function InsertarItemVenta(ByVal objItemVta As ClaseItemVenta) As Integer
        Dim id As Integer
        id = objVentas.InsertarItemVenta(objItemVta)
        Return id
    End Function
    Public Function BuscarCostoArticulo(ByVal idart As String) As DataSet
        Return objVentas.BuscarCostoArticulo(idart)
    End Function
    Public Function BuscarNumFacVta() As DataSet
        Return objVentas.BuscarNumFacVenta()
    End Function
    Public Function buscaridVenta(ByVal tipocom As String, ByVal numcom As String) As DataSet
        Return objVentas.BuscarIdVenta(tipocom, numcom)
    End Function
    Public Function buscarNumComprob(ByVal tipocomprobante As String, ByVal numcomprobante As String) As DataSet
        Return objVentas.BuscarNumComprob(tipocomprobante, numcomprobante)
    End Function
    Public Function buscarFechasGrillaVta(ByVal fech As String, ByVal fecha As String, ByVal tipocomprobante As String, ByVal cliente As String, ByVal anulada As Integer) As DataSet
        Return objVentas.BuscarFEchasGrillaVta(fech, fecha, tipocomprobante, cliente, anulada)
    End Function
    Public Function buscarNomClienGrilla(ByVal cli As String) As DataSet
        Return objVentas.BuscarNomClienteGrilla(cli)
    End Function
    Public Function buscarPresupuesto(ByVal idcliente As String) As DataSet
        Return objVentas.buscarPresupuesto(idcliente)
    End Function
    Public Function buscarcabecerapresupuesto(ByVal idp As String) As DataSet
        Return objVentas.buscarcabecerapresupuesto(idp)
    End Function
    Public Function buscarItemPresupuesto(ByVal idPR As String) As DataTable
        Return objVentas.buscarItemPresupuesto(idPR)
    End Function
    Public Function buscarCOSTOItemPresupuesto(ByVal idPR As String) As DataSet
        Return objVentas.buscarCOSTOItemPresupuesto(idPR)
    End Function
    Public Sub modificarPRFacturado(ByVal idPR As Integer)
        objVentas.modificarPRFacturado(idPR)
    End Sub
    Public Function buscarCobroFactura(ByVal tipocomprobante As String, ByVal numcomprobante As String) As DataSet
        Return objVentas.buscarCobroFactura(tipocomprobante, numcomprobante)
    End Function
    Public Sub modificarFacturaAnulada(ByVal tipocomprobante As String, ByVal numcomprobante As String)
        objVentas.modificarFacturaAnulada(tipocomprobante, numcomprobante)
    End Sub
    Public Function buscarItemAnulCS(ByVal tipocomprobante As String, ByVal numcomprobante As String) As DataSet
        Return objVentas.buscarItemAnulCS(tipocomprobante, numcomprobante)
    End Function
    Public Function buscarVinculosPRModif(ByVal tipocomprobante As String, ByVal numcomprobante As String) As DataSet
        Return objVentas.buscarVinculosPRModif(tipocomprobante, numcomprobante)
    End Function
    Public Sub modificarvinculoPRactiv(ByVal tipocomprobante As String, ByVal numcomprobante As String)
        objVentas.modificarvinculoPRactiv(tipocomprobante, numcomprobante)
    End Sub
    Public Sub modificarPRFacturadoAnulado(ByVal idPR As Integer)
        objVentas.modificarPRFacturadoAnulado(idPR)
    End Sub
    Public Function CargarGrillaPtoVenta() As DataSet
        Return objPuntoV.CargarGrilla()
    End Function
    Public Sub modificarPtoVenta(ByVal idPv As ClasePutoVenta)
        objPuntoV.modificarPtoVenta(idPv)
    End Sub
    Public Function InsertarPuntoVenta(ByVal idPv As ClasePutoVenta) As Integer
        Dim id As Integer
        id = objPuntoV.InsertarPuntoVenta(idPv)
        Return id
    End Function
    Public Function seleccionarPtoVenta(ByVal pto As Integer) As DataSet
        Return objPuntoV.seleccionarPtoVenta(pto)
    End Function
    Public Function buscarPtoVenta(ByVal pto As Integer) As DataSet
        Return objPuntoV.buscarPtoVenta(pto)
    End Function
    Public Function puntoporDefecto() As DataSet
        Return objPuntoV.puntoporDefecto()
    End Function
    Public Function MAXnumFactptoxdef() As DataSet
        Return objPuntoV.MAXnumFactptoxdef()
    End Function
    Public Function MAXnumFactpto() As DataSet
        Return objPuntoV.MAXnumFactpto()
    End Function
    Public Function buscarfactura(ByVal tipo As String, ByVal fac As String) As DataSet
        Return objVentas.buscarfactura(tipo, fac)
    End Function
    Public Function PuntoVentaValido() As DataSet
        Return objPuntoV.PuntoVentaValido()
    End Function
End Class
