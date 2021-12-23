Imports CapaNE
Imports CapaDA
Public Class UsuariosLN
    Private objUsuario As MEtodosUsuariosDA


    Public Sub New()
        objUsuario = New MetodosUsuariosDA
    End Sub

    Public Function VAlidarUsuar(ByVal usuar As ClaseUsuariosNE)
        Return objUsuario.Validarusuar(usuar)
    End Function
    Public Function buscarTipoUsuario(ByVal usuarioid As String) As DataSet
        Return objUsuario.BuscarTipoUsuar(usuarioid)
    End Function
    Public Function InsertarDatosUSuario(ByVal objUsuarioNE As ClaseUsuariosNE) As Integer
        Dim id As Integer
        id = objUsuario.InsertarUsuario(objUsuarioNE)
        Return id
    End Function
    Public Sub insertarDocu(ByVal objUsuarioNE As ClaseDocumento)
        objUsuario.InsertarDocumUsuario(objUsuarioNE)
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objUsuario.CargarGrilla()
    End Function
    Public Sub BorrarUsuar(ByVal id As ClaseUsuariosNE)
        objUsuario.BorrarUsuarios(id)
    End Sub
    Public Function cargarGrillaDoc(ByVal documento As String, ByVal tipoDoc As String) As DataSet
        Return objUsuario.CargarGrillaDoc(documento, tipoDoc)
    End Function
    Public Function cargarGrillaUsuario(ByVal usuario As String) As DataSet
        Return objUsuario.CargarGrillaUsuario(usuario)
    End Function
    Public Function buscarUsuario(ByVal usuarioid As String) As DataSet
        Return objUsuario.BuscarIDUsuar(usuarioid)
    End Function
    Public Function buscarDocum(ByVal doc As String) As DataSet
        Return objUsuario.BuscarIDDoc(doc)
    End Function
    Public Function BuscarEstado(ByVal estado As String) As DataSet
        Return objUsuario.BuscarIDEsado(estado)
    End Function
    Public Sub modificarUsuar(ByVal objUsuarNe As ClaseUsuariosNE)
        objUsuario.modificarUsuario(objUsuarNe)
    End Sub
    Public Sub modificarDocum(ByVal objDocNE As ClaseDocumento)
        objUsuario.modificarDocUsuar(objDocNE)
    End Sub
    Function ExisteUsuar(ByVal usuar As ClaseUsuariosNE)
        Return objUsuario.Existe(usuar)
    End Function
    Public Sub modificarEstado(ByVal objUsuarNe As ClaseUsuariosNE)
        objUsuario.modificarEstado(objUsuarNe)
    End Sub
    Public Function buscarUsuario2(ByVal usuarioid2 As String) As DataSet
        Return objUsuario.BuscarIDUsuar2(usuarioid2)
    End Function
End Class
