Public Class ClaseItemPR
    Private _idItemPR As Integer
    Private _Codigo As Integer
    Private _cantidad As Integer
    Private _Precio As Double
    Private _Total As Double
    Private _esArticulo As Integer
    Private _tipocomprobante As String
    Private _idPresupuesto As Integer
    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = CStr(value)
        End Set
    End Property
    Public Property idItemPR As Integer
        Get
            Return _idItemPR
        End Get
        Set(ByVal value As Integer)
            _idItemPR = CStr(value)
        End Set
    End Property
    Public Property Precio As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
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

    Public Property cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = CStr(value)
        End Set
    End Property
    Public Property esArticulo As Integer
        Get
            Return _esArticulo
        End Get
        Set(ByVal value As Integer)
            _esArticulo = CStr(value)
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
    Public Property idPresupuesto As Integer
        Get
            Return _idPresupuesto
        End Get
        Set(ByVal value As Integer)
            _idPresupuesto = CStr(value)
        End Set
    End Property
End Class
