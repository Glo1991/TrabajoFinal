Public Class ClasePrecios
    Private _IdPrecio As Integer
    Private _idItem As Integer
    Private _idStock As Integer
    Private _Precio As Double
    Private _Fecha As Date
    Private _idProv As Integer
    Public Property IdPrecio As Integer
        Get
            Return _IdPrecio
        End Get
        Set(ByVal value As Integer)
            _IdPrecio = CStr(value)
        End Set
    End Property
    Public Property idStock As Integer
        Get
            Return _idStock
        End Get
        Set(ByVal value As Integer)
            _idStock = CStr(value)
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
    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = CStr(value)
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
End Class
