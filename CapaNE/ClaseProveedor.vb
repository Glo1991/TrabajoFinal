Public Class ClaseProveedor
    Private _idProv As Integer
    Private _IdCuit As Long
    Private _NomRaz As String
    Private _TelFijo As String
    Private _telCelular As String
    Private _Email As String
    Public Property idProv As Integer
        Get
            Return _idProv
        End Get
        Set(ByVal value As Integer)
            _idProv = CStr(value)
        End Set
    End Property
    Public Property IdCuit As Long
        Get
            Return _IdCuit
        End Get
        Set(ByVal value As Long)
            _IdCuit = CStr(value)
        End Set
    End Property
    Public Property NomRaz As String
        Get
            Return _NomRaz
        End Get
        Set(ByVal value As String)
            _NomRaz = CStr(value)
        End Set
    End Property
    Public Property TelFijo As String
        Get
            Return _TelFijo
        End Get
        Set(ByVal value As String)
            _TelFijo = CStr(value)
        End Set
    End Property
    Public Property telCelular As String
        Get
            Return _telCelular
        End Get
        Set(ByVal value As String)
            _telCelular = CStr(value)
        End Set
    End Property
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = CStr(value)
        End Set
    End Property
End Class
