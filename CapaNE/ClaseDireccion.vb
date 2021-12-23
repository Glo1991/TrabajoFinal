Public Class ClaseDireccion
    Private _IdDireccion As Integer
    Private _IdCliente As Integer
    Private _IdProv As Integer
    Private _Pais As String
    Private _Provincia As String
    Private _Ciudad As String
    Private _Barrio As String
    Private _Calle As String
    Private _NumCalle As String
    Private _Piso As String
    Private _Dpto As String
    Private _Lote As String
    Private _Manzana As String
    Public Property IdDireccion As Integer
        Get
            Return _IdDireccion
        End Get
        Set(ByVal value As Integer)
            _IdDireccion = CStr(value)
        End Set
    End Property
    Public Property IdCliente As Integer
        Get
            Return _IdCliente
        End Get
        Set(ByVal value As Integer)
            _IdCliente = CStr(value)
        End Set
    End Property
    Public Property IdProv As Integer
        Get
            Return _IdProv
        End Get
        Set(ByVal value As Integer)
            _IdProv = CStr(value)
        End Set
    End Property
    Public Property Pais As String
        Get
            Return _Pais
        End Get
        Set(ByVal value As String)
            _Pais = value
        End Set
    End Property
    Public Property Provincia As String
        Get
            Return _Provincia
        End Get
        Set(ByVal value As String)
            _Provincia = CStr(value)
        End Set
    End Property

    Public Property Ciudad As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            _Ciudad = CStr(value)
        End Set
    End Property
    Public Property Barrio As String
        Get
            Return _Barrio
        End Get
        Set(ByVal value As String)
            _Barrio = CStr(value)
        End Set
    End Property
    Public Property Calle As String
        Get
            Return _Calle
        End Get
        Set(ByVal value As String)
            _Calle = CStr(value)
        End Set
    End Property
    Public Property NumCalle As String
        Get
            Return _NumCalle
        End Get
        Set(ByVal value As String)
            _NumCalle = CStr(value)
        End Set
    End Property
    Public Property Piso As String
        Get
            Return _Piso
        End Get
        Set(ByVal value As String)
            _Piso = CStr(value)
        End Set
    End Property
    Public Property Dpto As String
        Get
            Return _Dpto
        End Get
        Set(ByVal value As String)
            _Dpto = CStr(value)
        End Set
    End Property
    Public Property Lote As String
        Get
            Return _Lote
        End Get
        Set(ByVal value As String)
            _Lote = CStr(value)
        End Set
    End Property
    Public Property Manzana As String
        Get
            Return _Manzana
        End Get
        Set(ByVal value As String)
            _Manzana = CStr(value)
        End Set
    End Property

End Class
