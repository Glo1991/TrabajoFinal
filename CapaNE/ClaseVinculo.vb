Public Class ClaseVinculo
    Private _TipoComprobante As String
    Private _numerocomprobante As Long
    Private _TipoComAsociado As String
    Private _numeroComAsociado As Long
    Private _Fecha As Date
    Private _activo As Integer
    Public Property activo As Integer
        Get
            Return _activo
        End Get
        Set(ByVal value As Integer)
            _activo = CStr(value)
        End Set
    End Property
    Public Property TipoComprobante As String
        Get
            Return _TipoComprobante
        End Get
        Set(ByVal value As String)
            _TipoComprobante = CStr(value)
        End Set
    End Property
    Public Property numerocomprobante As Long
        Get
            Return _numerocomprobante
        End Get
        Set(ByVal value As Long)
            _numerocomprobante = CStr(value)
        End Set
    End Property
    Public Property TipoComAsociado As String
        Get
            Return _TipoComAsociado
        End Get
        Set(ByVal value As String)
            _TipoComAsociado = CStr(value)
        End Set
    End Property
    Public Property numeroComAsociado As Long
        Get
            Return _numeroComAsociado
        End Get
        Set(ByVal value As Long)
            _numeroComAsociado = CStr(value)
        End Set
    End Property
    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = CStr(value)
        End Set
    End Property
End Class