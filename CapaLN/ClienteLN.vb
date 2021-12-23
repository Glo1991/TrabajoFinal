Imports CapaNE
Imports capaDA
Public Class ClienteLN
    Private objAlumna As MetodosClientesDA

    Public Sub New()
        objAlumna = New MetodosClientesDA
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objAlumna.CargarGrilla()
    End Function
    Public Function InsertarAlumna(ByVal objAlumNE As ClaseCliente) As Integer
        Dim id As Integer
        id = objAlumna.InsertarCliente(objAlumNE)
        Return id
    End Function
    Public Sub insertarDocumAlum(ByVal objAlumNE As ClaseDocumento)
        objAlumna.InsertarDocumCliente(objAlumNE)
    End Sub
    Public Sub insertarDireAlum(ByVal objAlumNE As ClaseDireccion)
        objAlumna.InsertarDireccion(objAlumNE)
    End Sub
    Public Function buscarAlumna(ByVal objAlumNE As String) As DataSet
        Return objAlumna.BuscarIDCliente(objAlumNE)
    End Function
    Public Function buscaridDoc(ByVal doc As String) As DataSet
        Return objAlumna.BuscarIDDoc(doc)
    End Function
    Public Function buscarIdDomic(ByVal dire As String) As DataSet
        Return objAlumna.BuscarIDDire(dire)
    End Function
    Public Function cargarGrillaDoc(ByVal documento As String, ByVal tipoDoc As String) As DataSet
        Return objAlumna.CargarGrillaDoc(documento, tipoDoc)
    End Function
    Public Function cargarGrillaApellido(ByVal apellido As String) As DataSet
        Return objAlumna.CargarGrillaApellido(apellido)
    End Function
    Public Sub modificarAlum(ByVal objAlumNE As ClaseCliente)
        objAlumna.modificarCliente(objAlumNE)
    End Sub
    Public Sub modificarDocum(ByVal objDocNE As ClaseDocumento)
        objAlumna.modificarDocCliennte(objDocNE)
    End Sub
    Public Sub modificarDireAlu(ByVal DireNe As ClaseDireccion)
        objAlumna.modificarDireCliente(DireNe)
    End Sub
    Public Function BuscarDoc(ByVal doc) As DataSet
        Return objAlumna.BuscarDoc(doc)
    End Function
End Class
