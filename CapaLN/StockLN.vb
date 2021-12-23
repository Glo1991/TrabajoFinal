Imports CapaNE
Imports capaDA
Public Class StockLN
    Private objStock As MetodosStockDA

    Public Sub New()
        objStock = New MetodosStockDA
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objStock.CargarGrilla()
    End Function
    Public Function InsertarStock(ByVal objStoock As ClaseStock) As Integer
        Dim id As Integer
        id = objStock.InsertarStock(objStoock)
        Return id
    End Function
    Public Function cargarComboCategoria(ByVal objStoock As ClaseStock) As DataSet
        Return objStock.cargarComboCategoria()
    End Function
    Public Function cargarComboProducto(ByVal objStoock As ClaseStock, ByVal idStock As String) As DataSet
        Return objStock.cargarComboProducto(idStock)
    End Function
    Public Function cargarComboProveedores(ByVal objStoock As ClaseStock) As DataSet
        Return objStock.cargarComboProveedor()
    End Function
    Public Function buscarIdStock(ByVal objStoock As String) As DataSet
        Return objStock.BuscarIDStock(objStoock)
    End Function
    Public Sub modificarStock(ByVal objStoock As ClaseStock)
        objStock.modificarStock(objStoock)
    End Sub
    Public Function cargarGrillaCategoria(ByVal categoria As String, ByVal producto As String) As DataSet
        Return objStock.CargarGrillaCategoria(categoria, producto)
    End Function
    Public Function cargarGrillaProveedor(ByVal Proveedor As String) As DataSet
        Return objStock.CargarGrillaProveedor(Proveedor)
    End Function
    Public Function cargarGrillaCategoriaSolo(ByVal categoria As Integer, ByVal descripcion As String) As DataSet
        Return objStock.CargarGrillaCatSolo(categoria, descripcion)
    End Function
    Public Function cargarGrillaDescSolo(ByVal descripcion As String) As DataSet
        Return objStock.CargarGrillaDescSolo(descripcion)
    End Function
    Public Function cargaGrillaMinStock() As DataSet
        Return objStock.CargarGrillaMinStock()
    End Function
    Public Function cargarGrillaCategoriaMnStock(ByVal categoria As String) As DataSet
        Return objStock.BuscarMinStock(categoria)
    End Function
    Public Function InsertarCorreccionStock(ByVal CStock As ClaseCorreccionStock) As Integer
        Dim id As Integer
        id = objStock.InsertarCorreccionStock(CStock)
        Return id
    End Function
    Public Function buscarCS(ByVal bCStock As String) As DataSet
        Return objStock.BuscarCorreccionStock(bCStock)
    End Function
    Public Function bDesArticulo(ByVal bArticulo As String) As DataSet
        Return objStock.BuscarDescrArticulo(bArticulo)
    End Function
    Public Function bStockArticulo(ByVal bsArticulo As String) As DataSet
        Return objStock.BuscarStockArticulo(bsArticulo)
    End Function
    Public Function seleccionArticulo(ByVal selArt As String) As DataSet
        Return objStock.seleccionarticulo(selArt)
    End Function
    Public Function ReporteStock(ByVal categoria As Integer, ByVal descripcion As String) As DataTable
        Return objStock.ReporteStock(categoria, descripcion)
    End Function
End Class
