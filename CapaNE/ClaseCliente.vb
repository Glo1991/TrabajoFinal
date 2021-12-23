Public Class ClaseCliente
    Private _IdCliente As Integer
    Private _NomAlum As String
    Private _ApellAlum As String
    Private _FechaNac As Date
    Private _FechaIngreso As Date
    Private _TelFijo As String
    Private _telCelular As String
    Private _Email As String
    Private _EdadAlum As Integer
    Public Property IdCliente As Integer
        Get
            Return _IdCliente
        End Get
        Set(ByVal value As Integer)
            _IdCliente = CStr(value)
        End Set
    End Property
    Public Property NomAlum As String
        Get
            Return _NomAlum
        End Get
        Set(ByVal value As String)
            _NomAlum = CStr(value)
        End Set
    End Property
    Public Property ApellAlum As String
        Get
            Return _ApellAlum
        End Get
        Set(ByVal value As String)
            _ApellAlum = value
        End Set
    End Property
    Public Property FechaNac As Date
        Get
            Return _FechaNac
        End Get
        Set(ByVal value As Date)
            _FechaNac = CStr(value)
        End Set
    End Property

    Public Property FechaIngreso As Date
        Get
            Return _FechaIngreso
        End Get
        Set(ByVal value As Date)
            _FechaIngreso = CStr(value)
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
    Public Property EdadAlum As Integer
        Get
            Return _EdadAlum
        End Get
        Set(ByVal value As Integer)
            _EdadAlum = CStr(value)
        End Set
    End Property
End Class
