Imports CapaNE
Imports capaDA
Public Class PreciosVtaLN
    Private objPrecVta As MetodosPreciosVtaDA

    Public Sub New()
        objPrecVta = New MetodosPreciosVtaDA
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objPrecVta.CargarGrilla()
    End Function
    Public Function InsertarPrecio(ByVal objPrecVtaNE As ClasePreciosVta) As Integer
        Dim id As Integer
        id = objPrecVta.InsertarPrecioVta(objPrecVtaNE)
        Return id
    End Function
    Public Function cargaActual() As DataSet
        Return objPrecVta.CargarActual()
    End Function
    Public Sub modificarPrecioVta(ByVal objPrecNE As ClasePreciosVta, ByVal actaul As Integer)
        objPrecVta.modificarPrecio(objPrecNE, actaul)
    End Sub
    Public Sub modificarPrecioProvVta(ByVal objPrecNE As ClasePreciosVta, ByVal actaul As Integer, ByVal idProv As Integer)
        objPrecVta.modificarPrecioProveedor(objPrecNE, actaul, idProv)
    End Sub
    Public Sub modificarPrecioCAtVta(ByVal objPrecNE As ClasePreciosVta, ByVal actaul As Integer, ByVal idCAt As Integer)
        objPrecVta.modificarPrecioCateg(objPrecNE, actaul, idCAt)
    End Sub
    Public Sub modificarPrecioProdVta(ByVal objPrecNE As ClasePreciosVta, ByVal actaul As Integer, ByVal idCAt As Integer, ByVal prod As String)
        objPrecVta.modificarPrecioProduct(objPrecNE, actaul, idCAt, prod)
    End Sub
    Public Sub modificarPrecioCatYProv(ByVal objPrecNE As ClasePreciosVta, ByVal actaul As Integer, ByVal idCAt As Integer, ByVal idProv As Integer)
        objPrecVta.modificarPrecioCatYPr(objPrecNE, actaul, idCAt, idProv)
    End Sub
    Public Sub modificarPrecioCatProvProd(ByVal objPrecNE As ClasePreciosVta, ByVal actaul As Integer, ByVal idCAt As Integer, ByVal idProv As Integer, ByVal prod As String)
        objPrecVta.modificarPrecioCatProvYProd(objPrecNE, actaul, idCAt, idProv, prod)
    End Sub
    Public Function buscarIdPrecioVta(ByVal idPRecio As String) As DataSet
        Return objPrecVta.BuscarIdPreciosVta(idPRecio)
    End Function
    Public Function cargarGrillaProduct(ByVal producto As String) As DataSet
        Return objPrecVta.CargarGrillaProductoVta(producto)
    End Function
    Public Function cargarGrillaProveesPRov(ByVal prov As String) As DataSet
        Return objPrecVta.CargarGrillaProductoPRov(prov)
    End Function
    Public Function buscarFechasGrilla(ByVal categoria As String, ByVal marca As String, ByVal descripcion As String) As DataSet
        Return objPrecVta.BuscarFEchasGrilla(categoria, marca, descripcion)
    End Function
End Class
