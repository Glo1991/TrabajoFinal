Public Class ClaseReparacionStock
    Private _idItemRepar As Integer
    Private _idStock As Integer
    Private _cantidad As Integer
    Private _idORdDeTRab As Integer
    Public Property idStock As Integer
        Get
            Return _idStock
        End Get
        Set(ByVal value As Integer)
            _idStock = CStr(value)
        End Set
    End Property
    Public Property idORdDeTRab As Integer
        Get
            Return _idORdDeTRab
        End Get
        Set(ByVal value As Integer)
            _idORdDeTRab = CStr(value)
        End Set
    End Property
    Public Property idItemRepar As Integer
        Get
            Return _idItemRepar
        End Get
        Set(ByVal value As Integer)
            _idItemRepar = CStr(value)
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
End Class
