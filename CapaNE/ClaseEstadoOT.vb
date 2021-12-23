Public Class ClaseEstadoOT
    Private _idEstado As String
    Private _EstadoOT As String
    Public Property idEstado As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = CStr(value)
        End Set
    End Property
    Public Property EstadoOT As String
        Get
            Return _EstadoOT
        End Get
        Set(ByVal value As String)
            _EstadoOT = CStr(value)
        End Set
    End Property
End Class
