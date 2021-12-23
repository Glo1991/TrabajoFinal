Public Class ClasePutoVenta
    Private _puntoVenta As Integer
    Private _Pordefecto As Integer
    Private _activo As Integer
    Public Property puntoVenta As Integer
        Get
            Return _puntoVenta
        End Get
        Set(ByVal value As Integer)
            _puntoVenta = CStr(value)
        End Set
    End Property
    Public Property Pordefecto As Integer
        Get
            Return _Pordefecto
        End Get
        Set(ByVal value As Integer)
            _Pordefecto = CStr(value)
        End Set
    End Property
    Public Property activo As Integer
        Get
            Return _activo
        End Get
        Set(ByVal value As Integer)
            _activo = CStr(value)
        End Set
    End Property
End Class
