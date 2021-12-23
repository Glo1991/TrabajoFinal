Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosStockDA
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
        Dim da As New SqlDataAdapter("     select    cs.NomCategoria as Categoria,  m.Descripcion as Marca, ar.descripcion as 'Descripción',
  ar.idArticulo as Codigo, st.cantidad as Cantidad, ar.StockMin as 'Stock Mínimo'
   from Stock st inner join Articulos ar
   on ar.idArticulo=st.idArticulo
   inner join CategoriaStock cs on ar.idCategoria=cs.idCategoria
   inner join Marcas m on m.idMarca=ar.idMarca order by cs.NomCategoria, ar.idArticulo", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarStock(ByVal stock As ClaseStock) As Integer
        Dim sel As String

        sel = "insert into Stock (idArticulo,idCategoria, Producto , cantidad) values (@idArticulo, @idCategoria, @Producto, @Cantidad) SELECT SCOPE_IDENTITY()"
        com.Parameters.AddWithValue("@idArticulo", stock.idArticulo)
        com.Parameters.AddWithValue("@idCategoria", stock.idCategoris)
        com.Parameters.AddWithValue("@Producto", stock.Producto)
        com.Parameters.AddWithValue("@Cantidad", stock.cantidad)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Function cargarComboCategoria() As DataSet 'DataTable
        da = New SqlDataAdapter("select idCategoria, upper (NomCategoria) as NomCategoria from CategoriaStock ", con)
        ds = New DataSet
        dt = New DataTable
        Try
            da.Fill(ds, "tabCat")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function cargarComboProducto(ByVal Cat As String) As DataSet 'DataTable
        'da = New SqlDataAdapter("select idStock,  upper (Producto) as Producto   from Stock where idCategoria = " & "'" & idCat & "'", con)
        da = New SqlDataAdapter("select idStock,  upper (Producto) as Producto   from Stock s inner join CategoriaStock c on s.idCategoria = c.idCategoria  where c.NomCategoria = " & "'" & Cat & "'", con)
        ds = New DataSet
        dt = New DataTable
        Try
            da.Fill(ds, "tabCat")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function cargarComboProveedor() As DataSet 'DataTable
        da = New SqlDataAdapter("select idProv,NomRaz  from Proveedores ", con)
        ds = New DataSet
        dt = New DataTable
        Try
            da.Fill(ds, "tabProv")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function BuscarIDStock(ByVal idStock) As DataSet

        Dim da As New SqlDataAdapter("select * from Stock where idArticulo= " & "'" & idStock & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarStock(ByVal stock As ClaseStock)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Stock set cantidad = '" & stock.cantidad & "'" &
                "where idArticulo = '" & stock.idArticulo & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function CargarGrillaCategoria(ByVal categoria As String, ByVal producto As String) As DataSet

        Dim da As New SqlDataAdapter("select ar.idArticulo as Codigo, ar.descripcion, m.Descripcion as Marca," &
  " cs.NomCategoria as Categoria, st.cantidad as Cantidad, ar.StockMin as StockMinimo" &
  " from Stock st inner join Articulos ar" &
  " on ar.idArticulo=st.idArticulo" &
  " inner join CategoriaStock cs on ar.idCategoria=cs.idCategoria" &
  " inner join Marcas m on m.idMarca=ar.idMarca order by ar.idArticulo" &
        " where ar.idCategoria= " & " '" & categoria & "'" &
        " and ar.descripcion like '%" & producto & "%'" &
        "order by  ar.idArticulo ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaProveedor(ByVal Proveedor As String) As DataSet

        Dim da As New SqlDataAdapter("select c.NomCategoria as 'Categoría', s.Producto,  p.NomRaz as 'Proveedor', s.cantidad, s.idStock " & _
" from Stock s " & _
" inner join CategoriaStock c on" & _
" c.idCategoria = s.idCategoria" & _
" inner join Proveedores  p on" & _
" p.idProv = s.idProv" & _
        " where p.NomRaz = " & " '" & Proveedor & "'" & _
        " order by c.idCategoria ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaCatSolo(ByVal idcategoria As Integer, ByVal descripcion As String) As DataSet

        Dim da As New SqlDataAdapter("    select    cs.NomCategoria as Categoria,  m.Descripcion as Marca, ar.descripcion as 'Descripción',
  ar.idArticulo as Codigo, st.cantidad as Cantidad, ar.StockMin as 'Stock Mínimo'
   from Stock st inner join Articulos ar
   on ar.idArticulo=st.idArticulo
   inner join CategoriaStock cs on ar.idCategoria=cs.idCategoria
   inner join Marcas m on m.idMarca=ar.idMarca" &
  " where ar.idCategoria = " & " '" & idcategoria & "'" &
  " and ar.descripcion like " & " '%" & descripcion & "%'" &
  "  order by cs.NomCategoria, ar.idArticulo", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaDescSolo(ByVal descripcion As String) As DataSet

        Dim da As New SqlDataAdapter("    select    cs.NomCategoria as Categoria,  m.Descripcion as Marca, ar.descripcion as 'Descripción',
  ar.idArticulo as Codigo, st.cantidad as Cantidad, ar.StockMin as 'Stock Mínimo'
   from Stock st inner join Articulos ar
   on ar.idArticulo=st.idArticulo
   inner join CategoriaStock cs on ar.idCategoria=cs.idCategoria
   inner join Marcas m on m.idMarca=ar.idMarca" &
  " where ar.descripcion like " & " '%" & descripcion & "%'" &
  "  order by cs.NomCategoria, ar.idArticulo", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaMinStock() As DataSet
        Dim da As New SqlDataAdapter(" select    cs.NomCategoria as Categoria,  m.Descripcion as Marca, ar.descripcion as 'Descripción',
  ar.idArticulo as Codigo, st.cantidad as Cantidad, ar.StockMin as 'Stock Mínimo'
   from Stock st inner join Articulos ar
   on ar.idArticulo=st.idArticulo
   inner join CategoriaStock cs on ar.idCategoria=cs.idCategoria
   inner join Marcas m on m.idMarca=ar.idMarca" &
  " where st.cantidad<ar.StockMin order by cs.NomCategoria, st.idArticulo", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarMinStock(ByVal stock As String) As DataSet

        Dim da As New SqlDataAdapter("    select    cs.NomCategoria as Categoria,  m.Descripcion as Marca, ar.descripcion as 'Descripción',
  ar.idArticulo as Codigo, st.cantidad as Cantidad, ar.StockMin as 'Stock Mínimo'
   from Stock st inner join Articulos ar
   on ar.idArticulo=st.idArticulo
   inner join CategoriaStock cs on ar.idCategoria=cs.idCategoria
   inner join Marcas m on m.idMarca=ar.idMarca" &
  " where st.cantidad<ar.StockMin" &
        " and ar.idCategoria= " & " '" & stock & "'" &
        "order by  cs.NomCategoria, st.idArticulo ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarCorreccionStock(ByVal Cstock As ClaseCorreccionStock) As Integer
        Dim sel As String

        sel = "insert into correccionesstock (idArticulo,Descripcion,ingreso,egreso,fechamodificacion) values(@idArticulo1, @Descripcion, @ingreso, @egreso, @fechamodificacion) SELECT SCOPE_IDENTITY()"
        com.Parameters.Clear()
        com.Parameters.AddWithValue("@idArticulo1", Cstock.idarticulo)
        com.Parameters.AddWithValue("@Descripcion", Cstock.Descripcion)
        com.Parameters.AddWithValue("@ingreso", Cstock.Ingeso)
        com.Parameters.AddWithValue("@egreso", Cstock.Egreso)
        com.Parameters.AddWithValue("@fechamodificacion", Cstock.fechamodificacion)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Function BuscarCorreccionStock(ByVal bcstock As String) As DataSet

        Dim da As New SqlDataAdapter("  select cs.Descripcion as Motivo," &
  " cs.ingreso as Ingreso, cs.egreso as Egreso, cast (cs.fechamodificacion as date)as 'Fecha'" &
  " from correccionesStock cs inner join articulos ar on ar.idArticulo=cs.idarticulo" &
 " where ar.idarticulo= " & " '" & bcstock & "'" &
        "order by cs.fechamodificacion ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

    Public Function BuscarDescrArticulo(ByVal bdArt As String) As DataSet

        Dim da As New SqlDataAdapter(" select ar.descripcion from articulos ar where ar.idarticulo= " & "'" & bdArt & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

    Public Function BuscarStockArticulo(ByVal bsArt As String) As DataSet

        Dim da As New SqlDataAdapter(" select s.cantidad from stock s where s.idArticulo= " & "'" & bsArt & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function seleccionarticulo(ByVal selArt As String) As DataSet

        Dim da As New SqlDataAdapter(" select  ar.descripcion as Descripcion, ar.idarticulo as Codigo from articulos ar where ar.descripcion like " & "'" & selArt & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function ReporteStock(ByVal idcategoria As Integer, ByVal descripcion As String) As DataTable

        Dim sql As String = "select    cs.NomCategoria as Categoria,  m.Descripcion as Marca, ar.descripcion as 'Descripcion',
  ar.idArticulo as Codigo, st.cantidad as Cantidad, ar.StockMin as 'StockMnimo'
   from Stock st inner join Articulos ar
   on ar.idArticulo=st.idArticulo
   inner join CategoriaStock cs on ar.idCategoria=cs.idCategoria
   inner join Marcas m on m.idMarca=ar.idMarca where ar.idarticulo<>0 "

        If idcategoria <> 0 Then
            sql = sql & " and ar.idCategoria = " & idcategoria & ""
        End If
        If descripcion <> "" Then
            sql = sql & " and ar.descripcion like " & " '%" & descripcion & "%'"
        End If

        sql = sql & "order by cs.NomCategoria, ar.idArticulo"

        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataTable
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function


End Class
