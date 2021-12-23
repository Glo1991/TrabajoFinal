Public Class ClasePresupuestos
    Private _idPresupuesto As Integer
    Private _Codgigocliente As Integer
    Private _FechaIngreso As Date
    Private _Total As Double
    Private _Anulado As Integer
    Private _Aprobado As Integer
    Private _tipocomprobante As String
    Private _CodigoUsuario As String
    Private _facturado As Integer
    Public Property facturado As Integer
        Get
            Return _facturado
        End Get
        Set(ByVal value As Integer)
            _facturado = CStr(value)
        End Set
    End Property
    Public Property idPresupuesto As Integer
        Get
            Return _idPresupuesto
        End Get
        Set(ByVal value As Integer)
            _idPresupuesto = CStr(value)
        End Set
    End Property
    Public Property Codgigocliente As Integer
        Get
            Return _Codgigocliente
        End Get
        Set(ByVal value As Integer)
            _Codgigocliente = CStr(value)
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
    Public Property Total As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = CStr(value)
        End Set
    End Property

    Public Property Anulado As Integer
        Get
            Return _Anulado
        End Get
        Set(ByVal value As Integer)
            _Anulado = CStr(value)
        End Set
    End Property
    Public Property Aprobado As Integer
        Get
            Return _Aprobado
        End Get
        Set(ByVal value As Integer)
            _Aprobado = CStr(value)
        End Set
    End Property
    Public Property tipocomprobante As String
        Get
            Return _tipocomprobante
        End Get
        Set(ByVal value As String)
            _tipocomprobante = CStr(value)
        End Set
    End Property
    Public Property CodigoUsuario As String
        Get
            Return _CodigoUsuario
        End Get
        Set(ByVal value As String)
            _CodigoUsuario = CStr(value)
        End Set
    End Property
End Class
