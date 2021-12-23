Public Class ClaseEmail
    Private _mail As String
    Private _contrasena As String
    Private _smtp As String
    Private _puerto As Integer
    Public Property mail As String
        Get
            Return _mail
        End Get
        Set(ByVal value As String)
            _mail = CStr(value)
        End Set
    End Property
    Public Property contrasena As String
        Get
            Return _contrasena
        End Get
        Set(ByVal value As String)
            _contrasena = CStr(value)
        End Set
    End Property
    Public Property smtp As String
        Get
            Return _smtp
        End Get
        Set(ByVal value As String)
            _smtp = CStr(value)
        End Set
    End Property
    Public Property puerto As String
        Get
            Return _puerto
        End Get
        Set(ByVal value As String)
            _puerto = CStr(value)
        End Set
    End Property
End Class
