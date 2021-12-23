Imports System.Data
Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosServicios
    Private da As SqlDataAdapter
    Private ds As DataSet
    Private dt As DataTable
    Private con As New SqlConnection
    Private com As New SqlCommand
    Public Sub New()
        Dim objcon As New Conexion
        con = objcon.abrir
        com.Connection = con
    End Sub
    Public Function CargarGrillaServi() As DataSet
        Dim da As New SqlDataAdapter("select DescripcionServicio as Servicio, idServicio as Codigo, costoservicio as Precio from listaservicios", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function
    Public Function buscarServicio(ByVal descripcion As String) As DataSet
        Dim da As New SqlDataAdapter("select DescripcionServicio as Servicio, idServicio as Codigo, " &
" costoservicio as Precio from listaservicios where descripcionServicio like '%" & descripcion & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function
    Public Function buscarIDServicio(ByVal id As String) As DataSet
        Dim da As New SqlDataAdapter("select * from listaservicios where idServicio= " & id & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function
    Public Function nuevoCodServicio() As DataSet
        Dim da As New SqlDataAdapter("select IDENT_CURRENT('ListaServicios') +1  as identcurrent ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function InsertarArticulo(ByVal servicio As ClaseServicios) As Integer
        Dim insert As String
        insert = "insert into ListaServicios ( DescripcionServicio, costoServicio)" &
        " values (@DescripcionServicio,@costoServicio  ) SELECT SCOPE_IDENTITY()"
        com.Parameters.AddWithValue("@DescripcionServicio", servicio.DescripcionServicio)
        com.Parameters.AddWithValue("@costoServicio", servicio.CostoServicio)

        com.CommandText = insert
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Artículo")
        End Try
        Return t
    End Function
    Public Sub modificarServicio(ByVal servi As ClaseServicios)
        Dim sel As String

        Try
            sel = "update ListaServicios set DescripcionServicio = '" & servi.DescripcionServicio & "'," &
                "costoServicio =" & servi.CostoServicio & "" &
                "where idServicio = '" & servi.idServicio & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class
