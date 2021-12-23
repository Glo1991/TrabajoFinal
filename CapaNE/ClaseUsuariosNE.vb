Public Class ClaseUsuariosNE
    Private _IdUsuar As Integer
    Private _NomUsuario As String
    Private _usuarioPAss As String
    Private _Nombre As String
    Private _Apellido As String
    Private _TipoUsuario As String
    Private _idEstado As Integer
    Public Property IdUsuario As Integer
        Get
            Return _IdUsuar
        End Get
        Set(ByVal value As Integer)
            _IdUsuar = CStr(value)
        End Set
    End Property
    Public Property NomUsuario As String
        Get
            Return _NomUsuario
        End Get
        Set(ByVal value As String)
            _NomUsuario = CStr(value)
        End Set
    End Property
    Public Property PAss As String
        Get
            Return _usuarioPAss
        End Get
        Set(ByVal value As String)
            _usuarioPAss = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = CStr(value)
        End Set
    End Property

    Public Property TipoUsuario As String
        Get
            Return _TipoUsuario
        End Get
        Set(ByVal value As String)
            _TipoUsuario = CStr(value)
        End Set
    End Property
    Public Property Apellido As String
        Get
            Return _Apellido
        End Get
        Set(ByVal value As String)
            _Apellido = CStr(value)
        End Set
    End Property
    Public Property idEstado As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = CStr(value)
        End Set
    End Property
End Class
