Public Class ActualizacionPrec
    Private _IdActualizacion As Integer
    Private _porcActual As Integer
    Public Property IdActualizacion As Integer
        Get
            Return _IdActualizacion
        End Get
        Set(ByVal value As Integer)
            _IdActualizacion = CStr(value)
        End Set
    End Property
    Public Property porcActual As Integer
        Get
            Return _porcActual
        End Get
        Set(ByVal value As Integer)
            _porcActual = CStr(value)
        End Set
    End Property
End Class
