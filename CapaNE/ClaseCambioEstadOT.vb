Public Class ClaseCambioEstadOT
    Private _IdCAmbioEstOT As Integer
    Private _idOT As Integer
    Private _idEstadoOT As Integer
    Private _Observaciones As String
    Private _fechaCmbioEstOT As Date
    Public Property IdCAmbioEstOT As Integer
        Get
            Return _IdCAmbioEstOT
        End Get
        Set(ByVal value As Integer)
            _IdCAmbioEstOT = CStr(value)
        End Set
    End Property
    Public Property idOT As Integer
        Get
            Return _idOT
        End Get
        Set(ByVal value As Integer)
            _idOT = CStr(value)
        End Set
    End Property
    Public Property idEstadoOT As Integer
        Get
            Return _idEstadoOT
        End Get
        Set(ByVal value As Integer)
            _idEstadoOT = value
        End Set
    End Property
    Public Property Observaciones As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal value As String)
            _Observaciones = CStr(value)
        End Set
    End Property
    Public Property fechaCmbioEstOT As Date
        Get
            Return _fechaCmbioEstOT
        End Get
        Set(ByVal value As Date)
            _fechaCmbioEstOT = CStr(value)
        End Set
    End Property

  
End Class
