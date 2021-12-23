Public Class ClasePreciosVta
    Private _IdPrecVta As Integer
    Private _idPrecio As Integer
    Private _idStock As Integer
    Private _Precio As Double
    Private _Fecha As Date
    Private _idProv As Integer
    Public Property IdPrecVta As Integer
        Get
            Return _IdPrecVta
        End Get
        Set(ByVal value As Integer)
            _IdPrecVta = CStr(value)
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
    Public Property idPrecio As Integer
        Get
            Return _idPrecio
        End Get
        Set(ByVal value As Integer)
            _idPrecio = CStr(value)
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
