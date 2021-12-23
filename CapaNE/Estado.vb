Public Class Estado
    Private _idEstado As String
    Private _Estado As String
    Public Property idEstado As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = CStr(value)
        End Set
    End Property
    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = CStr(value)
        End Set
    End Property
End Class
