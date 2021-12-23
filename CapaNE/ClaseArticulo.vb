Public Class ClaseArticulo
    Private _idArticulo As Integer
    Private _CodArticulo As String
    Private _Descripcion As String
    Private _idMarca As Integer
    Private _idCategoria As Integer
    Private _StockMin As Double
    Private _costo As Double
    Private _PrecioVenta As Double
    Private _TipoPrecio As Integer
    Public Property idArticulo As Integer
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As Integer)
            _idArticulo = CStr(value)
        End Set
    End Property
    Public Property CodArticulo As String
        Get
            Return _CodArticulo
        End Get
        Set(ByVal value As String)
            _CodArticulo = CStr(value)
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = CStr(value)
        End Set
    End Property
    Public Property idMarca As Integer
        Get
            Return _idMarca
        End Get
        Set(ByVal value As Integer)
            _idMarca = CStr(value)
        End Set
    End Property
    Public Property StockMin As Double
        Get
            Return _StockMin
        End Get
        Set(ByVal value As Double)
            _StockMin = CStr(value)
        End Set
    End Property
    Public Property idCategoria As Integer
        Get
            Return _idCategoria
        End Get
        Set(ByVal value As Integer)
            _idCategoria = CStr(value)
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
    Public Property PrecioVenta As Double
        Get
            Return _PrecioVenta
        End Get
        Set(ByVal value As Double)
            _PrecioVenta = CStr(value)
        End Set
    End Property
    Public Property TipoPrecio As Integer
        Get
            Return _TipoPrecio
        End Get
        Set(ByVal value As Integer)
            _TipoPrecio = CStr(value)
        End Set
    End Property

End Class
