Public Class ClaseItem
    Private _idItem As Integer
    Private _Articulo As Integer
    Private _cantidad As Integer
    Private _Precio As Double
    Private _Importe As Double
    Private _numFactura As Long
    Private _tipocomprobante As String
    Public Property Articulo As Integer
        Get
            Return _Articulo
        End Get
        Set(ByVal value As Integer)
            _Articulo = CStr(value)
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
    Public Property Importe As Double
        Get
            Return _Importe
        End Get
        Set(ByVal value As Double)
            _Importe = CStr(value)
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
    Public Property tipocomprobante As String
        Get
            Return _tipocomprobante
        End Get
        Set(ByVal value As String)
            _tipocomprobante = CStr(value)
        End Set
    End Property
End Class
