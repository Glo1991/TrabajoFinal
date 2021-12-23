Public Class ClaseOrdenDeTRabajo
    Private _idOrdenTRab As Integer
    Private _NumDocCL As Integer
    Private _cantidad As Integer
    Private _Fecha As Date
    Private _MotivoCon As String
    Private _DispositARep As String
    Private _Cargador As String
    Private _Bateria As String
    Private _Funda As String
    Private _Maletin As String
    Private _Cables As String
    Private _IdEstadoOT As String
    Private _AlertEntrEquip As Date
    Private _activa As Integer
    Public Property activa As Integer
        Get
            Return _activa
        End Get
        Set(ByVal value As Integer)
            _activa = CStr(value)
        End Set
    End Property
    Public Property idOrdenTRab As Integer
        Get
            Return _idOrdenTRab
        End Get
        Set(ByVal value As Integer)
            _idOrdenTRab = CStr(value)
        End Set
    End Property
    Public Property NumDocCL As Integer
        Get
            Return _NumDocCL
        End Get
        Set(ByVal value As Integer)
            _NumDocCL = CStr(value)
        End Set
    End Property
    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property
    Public Property MotivoCon As String
        Get
            Return _MotivoCon
        End Get
        Set(ByVal value As String)
            _MotivoCon = CStr(value)
        End Set
    End Property

    Public Property DispositARep As String
        Get
            Return _DispositARep
        End Get
        Set(ByVal value As String)
            _DispositARep = CStr(value)
        End Set
    End Property

    Public Property Cargador As String
        Get
            Return _Cargador
        End Get
        Set(ByVal value As String)
            _Cargador = CStr(value)
        End Set
    End Property

    Public Property Bateria As String
        Get
            Return _Bateria
        End Get
        Set(ByVal value As String)
            _Bateria = CStr(value)
        End Set
    End Property

    Public Property Funda As String
        Get
            Return _Funda
        End Get
        Set(ByVal value As String)
            _Funda = CStr(value)
        End Set
    End Property

    Public Property Maletin As String
        Get
            Return _Maletin
        End Get
        Set(ByVal value As String)
            _Maletin = CStr(value)
        End Set
    End Property

    Public Property Cables As String
        Get
            Return _Cables
        End Get
        Set(ByVal value As String)
            _Cables = CStr(value)
        End Set
    End Property

    Public Property IdEstadoOT As String
        Get
            Return _IdEstadoOT
        End Get
        Set(ByVal value As String)
            _IdEstadoOT = CStr(value)
        End Set
    End Property
    Public Property AlertEntrEquip As Date
        Get
            Return _AlertEntrEquip
        End Get
        Set(ByVal value As Date)
            _AlertEntrEquip = CStr(value)
        End Set
    End Property
End Class
