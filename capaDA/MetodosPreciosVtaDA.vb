Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosPreciosVtaDA
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
        Dim da As New SqlDataAdapter(" select cs.NomCategoria as 'Categoría', m.Descripcion as 'Marca',
 ar.descripcion as Articulo,ar.idArticulo as Codigo, ar.precioVenta as Precio
from articulos ar
inner join CategoriaStock cs on cs.idCategoria=ar.idCategoria
inner join marcas m on m.idMarca=ar.idMarca
order by cs.NomCategoria,  m.Descripcion, ar.descripcion", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarPrecioVta(ByVal prec As ClasePreciosVta) As Integer
        Dim sel As String

        sel = "insert into PreciosVta (precioVta, idProv, Fecha, idStock )values ( @precioVta, @idProv, @Fecha, @idStock ) SELECT SCOPE_IDENTITY()"

        com.Parameters.AddWithValue("@precioVta", prec.Precio)
        com.Parameters.AddWithValue("@idProv", prec.idProv)
        com.Parameters.AddWithValue("@Fecha", prec.Fecha)
        com.Parameters.AddWithValue("@idStock", prec.idStock)
        com.Parameters.AddWithValue("@idPrecio", prec.idPrecio)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Function CargarActual() As DataSet
        Dim da As New SqlDataAdapter("select porcActual from ActualizPrec", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarPrecio(ByVal precio As ClasePreciosVta, ByVal actual As Integer)
        Dim sel As String

        Try
            sel = "set dateformat dmy update PreciosVta set precioVta = precioVta + (precioVta * '" & actual & "'/ 100)," & _
                "Fecha = '" & precio.Fecha & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarPrecioProveedor(ByVal precio As ClasePreciosVta, ByVal actual As Integer, ByVal idProv As Integer)
        Dim sel As String

        Try
            sel = "set dateformat dmy update PreciosVta set precioVta = precioVta + (precioVta * '" & actual & "'/ 100)," & _
                "Fecha = '" & precio.Fecha & "' where idProv =  '" & idProv & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarPrecioCateg(ByVal precio As ClasePreciosVta, ByVal actual As Integer, ByVal idCat As Integer)
        Dim sel As String

        Try
            sel = "set dateformat dmy update PreciosVta set precioVta = precioVta + (precioVta * '" & actual & "'/ 100)," & _
                "Fecha = '" & precio.Fecha & "'" & _
            " from PreciosVta  p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join CategoriaStock c" & _
" on s.idCategoria  =c.idCategoria " & _
" where c.idCategoria='" & idCat & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarPrecioProduct(ByVal precio As ClasePreciosVta, ByVal actual As Integer, ByVal idCat As Integer, ByVal Prod As String)
        Dim sel As String

        Try
            sel = "set dateformat dmy update PreciosVta set precioVta = precioVta + (precioVta * '" & actual & "'/ 100)," & _
                "Fecha = '" & precio.Fecha & "'" & _
            " from PreciosVta  p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join CategoriaStock c" & _
" on s.idCategoria  =c.idCategoria " & _
" where c.idCategoria='" & idCat & "'" & _
" and s.Producto = '" & Prod & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarPrecioCatYPr(ByVal precio As ClasePreciosVta, ByVal actual As Integer, ByVal idCat As Integer, ByVal idProv As Integer)
        Dim sel As String

        Try
            sel = "set dateformat dmy update PreciosVta set precioVta = precioVta + (precioVta * '" & actual & "'/ 100)," & _
                "Fecha = '" & precio.Fecha & "'" & _
            " from PreciosVta  p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join CategoriaStock c" & _
" on s.idCategoria  =c.idCategoria " & _
" where c.idCategoria='" & idCat & "'" & _
" and p.idProv = '" & idProv & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarPrecioCatProvYProd(ByVal precio As ClasePreciosVta, ByVal actual As Integer, ByVal idCat As Integer, ByVal idProv As Integer, ByVal prod As String)
        Dim sel As String

        Try
            sel = "set dateformat dmy update PreciosVta set precioVta = precioVta + (precioVta * '" & actual & "'/ 100)," & _
                "Fecha = '" & precio.Fecha & "'" & _
            " from PreciosVta  p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join CategoriaStock c" & _
" on s.idCategoria  =c.idCategoria " & _
" where c.idCategoria='" & idCat & "'" & _
" and p.idProv = '" & idProv & "'" & _
            " and s.Producto = '" & prod & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function BuscarIdPreciosVta(ByVal idPrecio) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precioVta  as 'Precio', p.Fecha  as 'Fecha',s.idStock as 'Código', idPrecVta, p.idProv, r.NomRaz  from PreciosVta  p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
" where idPrecVta = '" & idPrecio & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaProductoVta(ByVal producto As String) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precioVta  as 'Precio', p.Fecha  as 'Fecha',s.idStock as 'Código', idPrecVta, p.idProv, r.NomRaz  from PreciosVta  p" & _
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
    Public Function CargarGrillaProductoPRov(ByVal prov As String) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precioVta  as 'Precio', p.Fecha  as 'Fecha',s.idStock as 'Código', idPrecVta, p.idProv, r.NomRaz  from PreciosVta  p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
        " where r.NomRaz like '%" & prov & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarFEchasGrilla(ByVal categoria As String, ByVal marca As String, ByVal descripcion As String) As DataSet
        Dim sql As String = "select cs.NomCategoria as 'Categoría', m.Descripcion as 'Marca',
 ar.descripcion as Articulo,ar.idArticulo as Codigo, ar.precioVenta as Precio
from articulos ar
inner join CategoriaStock cs on cs.idCategoria=ar.idCategoria
inner join marcas m on m.idMarca=ar.idMarca  where ar.descripcion<>''"
        If categoria <> 0 Then
            sql = sql & "and cs.idCategoria= " & categoria & ""
        End If
        If marca <> 0 Then
            sql = sql & "and m.idMarca= " & marca & ""
        End If
        If descripcion <> "" Then
            sql = sql & "and ar.descripcion like '%" & descripcion & "%'"
        End If
        sql = sql & "order by cs.NomCategoria,  m.Descripcion, ar.descripcion"

        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
End Class
