Public Class ClaseServicios
    Private _idServicio As Integer
    Private _DescripcionServicio As String
    Private _CostoServicio As Double
    Public Property idServicio As Integer
        Get
            Return _idServicio
        End Get
        Set(ByVal value As Integer)
            _idServicio = CStr(value)
        End Set
    End Property
    Public Property DescripcionServicio As String
        Get
            Return _DescripcionServicio
        End Get
        Set(ByVal value As String)
            _DescripcionServicio = CStr(value)
        End Set
    End Property
    Public Property CostoServicio As Double
        Get
            Return _CostoServicio
        End Get
        Set(ByVal value As Double)
            _CostoServicio = CStr(value)
        End Set
    End Property
End Class
