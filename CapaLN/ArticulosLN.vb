Imports capaDA
Imports CapaNE
Public Class ArticulosLN
    Private objArticulo As New MetodosArticulosDA
    Public Function cargaGrillaArt() As DataSet
        Return objArticulo.CargarGrillaArt()
    End Function
    Public Function buscaridArticulo(ByVal arti As String) As DataSet
        Return objArticulo.BuscarIDArticulo(arti)
    End Function
    Public Sub modificarArticulo(ByVal articul As ClaseArticulo)
        objArticulo.modificarArticulo(articul)
    End Sub
    Public Function cargaGrillaMArca() As DataSet
        Return objArticulo.CargarMarcas()
    End Function
    Public Function cargarIdmarca() As DataSet
        Return objArticulo.nuevaMarca()
    End Function
    Public Function cargarComboCategoria(ByVal objCombCat As ClaseCategoria) As DataSet
        Return objArticulo.cargarComboCategoria()
    End Function
    Public Function cargarComboMarcas(ByVal objComMArca As ClaseMarca) As DataSet
        Return objArticulo.cargarComboMarca()
    End Function
    Public Function InsertArticulo(ByVal objbtArticulo As ClaseArticulo) As Integer
        Dim id As Integer
        id = objArticulo.InsertarArticulo(objbtArticulo)
        Return id
    End Function
    Public Function NuevoCodArticulo() As DataSet
        Return objArticulo.nuevoCodArticulo()
    End Function
    Public Function InsertMarca(ByVal objbtMarca As ClaseMarca) As Integer
        Dim id As Integer
        id = objArticulo.InsertarMARCA(objbtMarca)
        Return id
    End Function
    Public Function buscaridMarca(ByVal marca As String) As DataSet
        Return objArticulo.BuscarIDMarca(marca)
    End Function
    Public Sub modificarMarca(ByVal Marc As ClaseMarca)
        objArticulo.modificarMarca(Marc)
    End Sub
    Public Function InsertCategoria(ByVal objbtCtaegoria As ClaseCategoria) As Integer
        Dim id As Integer
        id = objArticulo.InsertarCATEGORIA(objbtCtaegoria)
        Return id
    End Function
    Public Function cargarIdCategoria() As DataSet
        Return objArticulo.idCategoria()
    End Function
    Public Function cargaGrillCategoria() As DataSet
        Return objArticulo.CargarCategoria()
    End Function
    Public Function buscaridCate(ByVal cat As String) As DataSet
        Return objArticulo.BuscarIDCategoria(cat)
    End Function
    Public Sub modificarCateg(ByVal Categ As ClaseCategoria)
        objArticulo.modificarCategoria(Categ)
    End Sub
    Public Sub modificarCostoARt(ByVal McostoARt As ClaseArticulo)
        objArticulo.ModificarCostoArt(McostoARt)
    End Sub
    Public Sub ModificarCostoPRECIOArt(ByVal preciocosto As ClaseArticulo)
        objArticulo.ModificarCostoPRECIOArt(preciocosto)
    End Sub
    Public Function busquedaArtCateg(ByVal idcate As Integer, descr As String) As DataSet
        Return objArticulo.BusquedaCategoria(idcate, descr)
    End Function
    Public Function busquedaArtMarca(ByVal idMArca As Integer, descr As String) As DataSet
        Return objArticulo.BusquedaMarca(idMArca, descr)
    End Function
    Public Function busquedaArtDescripcion(ByVal descr As String) As DataSet
        Return objArticulo.BusquedaDescripcion(descr)
    End Function
    Public Function busquedaCategorCOD(ByVal idCateg As Integer, descr As String) As DataSet
        Return objArticulo.BusquedaCodCategoria(idCateg, descr)
    End Function
    Public Function busquedaCategorDEscr(ByVal descr As String) As DataSet
        Return objArticulo.BusquedaDESCCategoria(descr)
    End Function
    Public Function busquedaMArcaCOD(ByVal idMarca As Integer, descr As String) As DataSet
        Return objArticulo.BusquedaCodMARCA(idMarca, descr)
    End Function
    Public Function busquedaMArcaDEscr(ByVal descr As String) As DataSet
        Return objArticulo.BusquedaDESCMArca(descr)
    End Function
    Public Function buscarmargen(ByVal idmarca As String) As DataSet
        Return objArticulo.BuscarMargen(idmarca)
    End Function
    Public Function cargaGrillaArtMM() As DataSet
        Return objArticulo.CargarGrillaArtMM()
    End Function
    Public Sub modificarPrecioProcentaje(ByVal ar As ClaseArticulo, porcentaje As Double)
        objArticulo.modificarPrecioProcentaje(ar, porcentaje)
    End Sub
    Public Sub modificarTipoPrecioMANUAL(ByVal arP As ClaseArticulo)
        objArticulo.modificarTipoPrecioMANUAL(arP)
    End Sub
    Public Sub modificarTipoPrecioMARCA(ByVal arPM As ClaseArticulo)
        objArticulo.modificarTipoPrecioMARCA(arPM)
    End Sub
    Public Sub modificarMAsivCategoria(ByVal arC As ClaseArticulo, ByVal idcategoria As ClaseCategoria)
        objArticulo.modificarMAsivCategoria(arC, idcategoria)
    End Sub
    Public Function cargaGrillaArtMMCategoria(ByVal idCate As Integer, ByVal descrip As String) As DataSet
        Return objArticulo.CargarGrillaArtMMCategoria(idCate, descrip)
    End Function
    Public Function cargaGrillaArtMMDescripcion(ByVal descrip As String) As DataSet
        Return objArticulo.BusquedaDescripcionMM(descrip)
    End Function
End Class
