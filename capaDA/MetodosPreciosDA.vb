Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosPreciosDA
    Private con As New SqlConnection
    Private com As New SqlCommand
    Private da As SqlDataAdapter
    Private ds As DataSet
    Private dt As DataTable
    Public Sub New()
        Dim objcon As New Conexion
        con = objcon.abrir
        com.Connection = con
    End Sub
    Public Function CargarGrilla() As DataSet
        Dim da As New SqlDataAdapter("select s.Producto, p.precio, r.NomRaz , p.fecha, idPrecio, s.idStock, p.idProv  from Precios p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
" order by s.Producto", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarPrecio(ByVal prec As ClasePrecios) As Integer
        Dim sel As String

        sel = "insert into Precios (precio, idProv, Fecha, idStock ) values ( @precio, @idProv, @Fecha, @idStock ) SELECT SCOPE_IDENTITY()"
        com.Parameters.Clear()
        com.Parameters.AddWithValue("@precio", prec.precio)
        com.Parameters.AddWithValue("@idProv", prec.idProv)
        com.Parameters.AddWithValue("@Fecha", prec.Fecha)
        com.Parameters.AddWithValue("@idStock", prec.idStock)
        'com.Parameters.AddWithValue("@idItem", prec.idItem)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Sub modificarPrecio(ByVal precio As ClasePrecios)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Precios set precio = '" & precio.Precio & "'," & _
                "fecha = '" & precio.Fecha & "'" & _
                "where idPrecio = '" & precio.IdPrecio & "'" & _
                "and idProv = '" & precio.idProv & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function CargarGrillaProducto(ByVal producto As String) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precio, r.NomRaz , p.fecha, idPrecio, s.idStock, p.idProv  from Precios p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
        " where s.Producto like '%" & producto & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaProductoPR(ByVal producto As String) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precio, r.NomRaz , p.fecha, idPrecio, s.idStock, p.idProv  from Precios p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
        " where r.NomRaz like '%" & producto & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarFEchasGrilla(ByVal fech As Date, ByVal fecha As Date) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precio, r.NomRaz , p.fecha, idPrecio, s.idStock, p.idProv  from Precios p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
" where p.fecha between '" & fech & "'" & _
" and '" & fecha & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIdPrecios(ByVal idPrecio) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precio, r.NomRaz , p.fecha, idPrecio  from Precios p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
" where idPrecio= " & "'" & idPrecio & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIdStock(ByVal idStock As Integer) As DataSet

        Dim da As New SqlDataAdapter("select p.precio, p.fecha, idPrecio, p.idStock ,p.idProv from Precios p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
" where p.idStock= " & "'" & idStock & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
End Class
