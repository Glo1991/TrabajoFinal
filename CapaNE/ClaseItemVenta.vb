Public Class ClaseItemVenta
    Private _idItem As Integer
    Private _idArticulo As Integer
    Private _cantidad As Integer
    Private _Precio As Double
    Private _Total As Double
    Private _numFactura As Long
    Private _tipofactura As String
    Private _esarticulo As Integer
    Private _costo As Double
    Public Property idArticulo As Integer
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As Integer)
            _idArticulo = CStr(value)
        End Set
    End Property
    Public Property idItem As Integer
        Get
            Return _idItem
        End Get
        Set(ByVal value As Integer)
            _idItem = CStr(value)
        End Set
    End Property
    Public Property Precio As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property
    Public Property Total As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = CStr(value)
        End Set
    End Property

    Public Property cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = CStr(value)
        End Set
    End Property
    Public Property numFactura As Long
        Get
            Return _numFactura
        End Get
        Set(ByVal value As Long)
            _numFactura = CStr(value)
        End Set
    End Property
    Public Property tipofactura As String
        Get
            Return _tipofactura
        End Get
        Set(ByVal value As String)
            _tipofactura = CStr(value)
        End Set
    End Property
    Public Property esarticulo As Integer
        Get
            Return _esarticulo
        End Get
        Set(ByVal value As Integer)
            _esarticulo = CStr(value)
        End Set
    End Property
    Public Property costo As Double
        Get
            Return _costo
        End Get
        Set(ByVal value As Double)
            _costo = CStr(value)
        End Set
    End Property
End Class
