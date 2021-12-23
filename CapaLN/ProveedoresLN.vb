Imports CapaNE
Imports capaDA
Public Class ProveedoresLN
    Private objProv As MetodosProveedores

    Public Sub New()
        objProv = New MetodosProveedores
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objProv.CargarGrilla()
    End Function
    Public Function InsertarProv(ByVal objProvNE As ClaseProveedor) As Integer
        Dim id As Integer
        id = objProv.InsertarProveedor(objProvNE)
        Return id
    End Function
    Public Sub insertarDireProv(ByVal objProvNE As ClaseDireccion)
        objProv.InsertarDireccion(objProvNE)
    End Sub
    Public Function buscarIdProv(ByVal objProvNE As String) As DataSet
        Return objProv.BuscarIDProveedor(objProvNE)
    End Function
    Public Function buscarIdDomic(ByVal dire As String) As DataSet
        Return objProv.BuscarIDDire(dire)
    End Function
    Public Sub modificarProv(ByVal objProvNE As ClaseProveedor)
        objProv.modificarProv(objProvNE)
    End Sub
    Public Sub modificarDireProv(ByVal DireNe As ClaseDireccion)
        objProv.modificarDireProv(DireNe)
    End Sub
    Public Function cargarGrillaIdCuit(ByVal idCuit As String) As DataSet
        Return objProv.CargarGrillaIdCuit(idCuit)
    End Function
    Public Function cargarGrillaNomRaz(ByVal NomRaz As String) As DataSet
        Return objProv.CargarGrillaNomRaz(NomRaz)
    End Function
    Public Function BuscarCUIT(ByVal idcuit As String) As DataSet
        Return objProv.BuscarCUIT(idcuit)
    End Function
End Class
