Imports CapaNE
Imports capaDA
Public Class ServiciosLN
    Private objServicio As New MetodosServicios

    Public Sub New()

    End Sub
    Public Function crgarGrillaServi() As DataSet
        Return objServicio.CargarGrillaServi()
    End Function
    Public Function buscarServicio(ByVal servicio As String) As DataSet
        Return objServicio.buscarServicio(servicio)
    End Function
    Public Function buscarIDServicio(ByVal id As String) As DataSet
        Return objServicio.buscarIDServicio(id)
    End Function
    Public Function nuevoCodServicio() As DataSet
        Return objServicio.nuevoCodServicio()
    End Function
    Public Function InsertarServicio(ByVal objServ As ClaseServicios) As Integer
        Dim id As Integer
        id = objServicio.InsertarArticulo(objServ)
        Return id
    End Function
    Public Sub modificarServicio(ByVal serv As ClaseServicios)
        objServicio.modificarServicio(serv)
    End Sub
End Class
