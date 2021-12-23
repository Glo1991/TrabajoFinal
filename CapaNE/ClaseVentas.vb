Public Class ClaseVentas
    Private _pagado As Integer
    Private _Fecha As Date
    Private _idCliente As Integer
    Private _numFactura As Long
    Private _total As Double
    Private _tipofactura As String
    Private _costo As Double
    Private _anulada As Integer
    Public Property anulada As Integer
        Get
            Return _anulada
        End Get
        Set(ByVal value As Integer)
            _anulada = CStr(value)
        End Set
    End Property
    Public Property pagado As Integer
        Get
            Return _pagado
        End Get
        Set(ByVal value As Integer)
            _pagado = CStr(value)
        End Set
    End Property
    Public Property idCliente As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = CStr(value)
        End Set
    End Property
    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
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
    Public Property total As Double
        Get
            Return _total
        End Get
        Set(ByVal value As Double)
            _total = CStr(value)
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

End Class
