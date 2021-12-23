Public Class ClaseCategoria
    Private _idCategoria As Integer
    Private _DescripcionCategoria As String
    Public Property idCategoria As Integer
        Get
            Return _idCategoria
        End Get
        Set(ByVal value As Integer)
            _idCategoria = CStr(value)
        End Set
    End Property
    Public Property DescripcionCategoria As String
        Get
            Return _DescripcionCategoria
        End Get
        Set(ByVal value As String)
            _DescripcionCategoria = CStr(value)
        End Set
    End Property
End Class
