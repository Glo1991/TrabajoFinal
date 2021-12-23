Public Class ClaseCobro
    Private _idcobro As Integer
    Private _Tipocomproabnte As String
    Private _NumComrpobante As Long
    Private _Total As Double
    Private _Fecha As Date
    Private _anulado As Integer
    Private _esanulacion As Integer
    Public Property idcobro As Integer
        Get
            Return _idcobro
        End Get
        Set(ByVal value As Integer)
            _idcobro = CStr(value)
        End Set
    End Property
    Public Property Tipocomproabnte As String
        Get
            Return _Tipocomproabnte
        End Get
        Set(ByVal value As String)
            _Tipocomproabnte = CStr(value)
        End Set
    End Property
    Public Property NumComrpobante As Long
        Get
            Return _NumComrpobante
        End Get
        Set(ByVal value As Long)
            _NumComrpobante = CStr(value)
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
    Public Property Total As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = CStr(value)
        End Set
    End Property
    Public Property esanulacion As Integer
        Get
            Return _esanulacion
        End Get
        Set(ByVal value As Integer)
            _esanulacion = CStr(value)
        End Set
    End Property
    Public Property anulado As Integer
        Get
            Return _anulado
        End Get
        Set(ByVal value As Integer)
            _anulado = CStr(value)
        End Set
    End Property

End Class
