Public Class ClaseMarca
    Private _idMarca As Integer
    Private _DescripcionMarca As String
    Private _Margen As Double
    Public Property idMarca As Integer
        Get
            Return _idMarca
        End Get
        Set(ByVal value As Integer)
            _idMarca = CStr(value)
        End Set
    End Property
    Public Property DescripcionMarca As String
        Get
            Return _DescripcionMarca
        End Get
        Set(ByVal value As String)
            _DescripcionMarca = CStr(value)
        End Set
    End Property
    Public Property Margen As Double
        Get
            Return _MArgen
        End Get
        Set(ByVal value As Double)
            _MArgen = CStr(value)
        End Set
    End Property
End Class
