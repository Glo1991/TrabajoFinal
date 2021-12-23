Public Class ClaseDocumento
    Private _IDDoc As Integer
    Private _TipoDocu As String
    Private _NumDoc As Integer
    Private _IDUsuario As String
    Private _IDCliente As Integer

    Public Property IDDoc As Integer
        Get
            Return _IDDoc
        End Get
        Set(ByVal value As Integer)
            _IDDoc = CStr(value)
        End Set
    End Property
    Public Property TipoDoc As String
        Get
            Return _TipoDocu
        End Get
        Set(ByVal value As String)
            _TipoDocu = value
        End Set
    End Property
    Public Property NumDoc As Integer
        Get
            Return _NumDoc
        End Get
        Set(ByVal value As Integer)
            _NumDoc = CStr(value)
        End Set
    End Property
    Public Property IdUSuario As String
        Get
            Return _IDUsuario
        End Get
        Set(ByVal value As String)
            _IDUsuario = CStr(value)
        End Set
    End Property
    Public Property IDCliente As Integer
        Get
            Return _IDCliente
        End Get
        Set(ByVal value As Integer)
            _IDCliente = CStr(value)
        End Set
    End Property
End Class