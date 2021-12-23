Public Class ClaseCompras
    Private _idCompra As Integer
    Private _FechaIngreso As Date
    Private _idProv As Integer
    Private _numFactura As Long
    Private _total As Double
    Private _tipoCom As String
    Private _Anulado As Integer
    Public Property tipoCom As String
        Get
            Return _tipoCom
        End Get
        Set(ByVal value As String)
            _tipoCom = CStr(value)
        End Set
    End Property
    Public Property idCompra As Integer
        Get
            Return _idCompra
        End Get
        Set(ByVal value As Integer)
            _idCompra = CStr(value)
        End Set
    End Property
    Public Property FechaIngreso As Date
        Get
            Return _FechaIngreso
        End Get
        Set(ByVal value As Date)
            _FechaIngreso = value
        End Set
    End Property
    Public Property idProv As Integer
        Get
            Return _idProv
        End Get
        Set(ByVal value As Integer)
            _idProv = CStr(value)
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
    Public Property Anulado As Integer
        Get
            Return _Anulado
        End Get
        Set(ByVal value As Integer)
            _Anulado = CStr(value)
        End Set
    End Property
End Class
