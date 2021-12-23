Public Class ClasePreciosHist
    Private _IdPrecioHist As Integer
    Private _idArticulo As Integer
    Private _PrecioHist As Double
    Private _FechaPrecHist As Date
    Private _idProv As Integer
    Public Property IdPrecioHist As Integer
        Get
            Return _IdPrecioHist
        End Get
        Set(ByVal value As Integer)
            _IdPrecioHist = CStr(value)
        End Set
    End Property
    Public Property idArticulo As Integer
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As Integer)
            _idArticulo = CStr(value)
        End Set
    End Property
    Public Property PrecioHist As Double
        Get
            Return _PrecioHist
        End Get
        Set(ByVal value As Double)
            _PrecioHist = value
        End Set
    End Property
    Public Property FechaPrecHist As Date
        Get
            Return _FechaPrecHist
        End Get
        Set(ByVal value As Date)
            _FechaPrecHist = CStr(value)
        End Set
    End Property
    Public Property idProv As Integer
        Get
            Return _idProv
        End Get
        Set(ByVal value As Integer)
            _idProv = CStr(value)
        End Set
    End Property
End Class
