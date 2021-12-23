Public Class ClaseStock
    Private _idStock As Integer
    Private _idCategoris As Integer
    Private _Producto As String
    Private _idProv As Integer
    Private _cantidad As Integer
    Private _idArticulo As Integer
    Public Property idStock As Integer
        Get
            Return _idStock
        End Get
        Set(ByVal value As Integer)
            _idStock = CStr(value)
        End Set
    End Property
    Public Property idCategoris As Integer
        Get
            Return _idCategoris
        End Get
        Set(ByVal value As Integer)
            _idCategoris = CStr(value)
        End Set
    End Property
    Public Property Producto As String
        Get
            Return _Producto
        End Get
        Set(ByVal value As String)
            _Producto = value
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

    Public Property cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = CStr(value)
        End Set
    End Property
    Public Property idArticulo As Integer
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As Integer)
            _idArticulo = CStr(value)
        End Set
    End Property
End Class
