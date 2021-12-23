Public Class ClaseCorreccionStock
    Private _idCorreccionStock As Integer
    Private _Descripcion As String
    Private _Ingeso As Double
    Private _Egreso As Double
    Private _fechamodificacion As DateTime
    Private _idarticulo As Integer
    Public Property idCorreccionStock As Integer
        Get
            Return _idCorreccionStock
        End Get
        Set(ByVal value As Integer)
            _idCorreccionStock = CStr(value)
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
    Public Property Ingeso As Double
        Get
            Return _Ingeso
        End Get
        Set(ByVal value As Double)
            _Ingeso = CStr(value)
        End Set
    End Property
    Public Property Egreso As Double
        Get
            Return _Egreso
        End Get
        Set(ByVal value As Double)
            _Egreso = CStr(value)
        End Set
    End Property
    Public Property fechamodificacion As DateTime
        Get
            Return _fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            _fechamodificacion = CStr(value)
        End Set
    End Property
    Public Property idarticulo As Integer
        Get
            Return _idarticulo
        End Get
        Set(ByVal value As Integer)
            _idarticulo = CStr(value)
        End Set
    End Property

End Class
