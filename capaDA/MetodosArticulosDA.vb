Imports System.Data
Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosArticulosDA

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
    Public Function CargarGrillaArt() As DataSet
        Dim da As New SqlDataAdapter("select ar.IDARTICULO as Codigo, ar.descripcion as Articulo, m.descripcion as Marca, cs.NomCategoria as Categoria" &
" from articulos ar inner join CategoriaStock cs on ar.idCategoria= cs.idCategoria" &
" inner join marcas m on m.idMarca=ar.idMarca", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function
    Public Sub modificarArticulo(ByVal articulo As ClaseArticulo)
        Dim sel As String

        Try
            sel = "update Articulos set descripcion = '" & articulo.Descripcion & "'," &
                "idMarca= " & articulo.idMarca & "," &
                "idCategoria= " & articulo.idCategoria & "," &
                 "StockMin= " & articulo.StockMin & "," &
                  "PrecioVenta= " & articulo.PrecioVenta & "," &
                   "TipoPrecio= " & articulo.TipoPrecio & "," &
                 "Costo= " & articulo.costo & "" &
                "where idArticulo = " & articulo.idArticulo & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function nuevoCodArticulo() As DataSet
        Dim da As New SqlDataAdapter("select IDENT_CURRENT('Articulos') +1  as identcurrent ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function BuscarIDArticulo(ByVal idArticulo) As DataSet

        Dim da As New SqlDataAdapter(" select idArticulo, descripcion, idMarca, idCategoria, StockMin, costo, precioVenta, tipoPrecio from articulos  where idArticulo= " & "'" & idArticulo & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function cargarComboCategoria() As DataSet 'DataTable
        da = New SqlDataAdapter("select idCategoria, upper (NomCategoria) as NomCategoria from CategoriaStock ", con)
        ds = New DataSet
        dt = New DataTable
        Try
            da.Fill(ds, "tabCate")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function cargarComboMarca() As DataSet 'DataTable
        da = New SqlDataAdapter("select idMarca, upper (Descripcion) as Marca from Marcas ", con)
        ds = New DataSet
        dt = New DataTable
        Try
            da.Fill(ds, "tabMarc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function InsertarArticulo(ByVal Articulo As ClaseArticulo) As Integer
        Dim insert As String
        insert = "insert into Articulos ( descripcion,idMarca, idCategoria, StockMin, costo, precioVenta, TipoPrecio)" &
        " values (@descripcion, @idMarca, @idCategoria, @StockMin, @costo,@precioVenta,@TipoPrecio  ) SELECT SCOPE_IDENTITY()"
        com.Parameters.AddWithValue("@descripcion", Articulo.Descripcion)
        com.Parameters.AddWithValue("@idMarca", Articulo.idMarca)
        com.Parameters.AddWithValue("@idCategoria", Articulo.idCategoria)
        com.Parameters.AddWithValue("@StockMin", Articulo.StockMin)
        com.Parameters.AddWithValue("@costo", Articulo.costo)
        com.Parameters.AddWithValue("@precioVenta", Articulo.PrecioVenta)
        com.Parameters.AddWithValue("@TipoPrecio", Articulo.TipoPrecio)
        com.CommandText = insert
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Artículo")
        End Try
        Return t
    End Function
    Public Function CargarMarcas() As DataSet
        Dim da As New SqlDataAdapter("select idMarca as Codigo, descripcion as Marca, margen as Margen from Marcas", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function nuevaMarca() As DataSet
        Dim da As New SqlDataAdapter("select IDENT_CURRENT('Marcas') +1  as identcurrent ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function BuscarIDMarca(ByVal idMarcas) As DataSet

        Dim da As New SqlDataAdapter("select * from Marcas where idMarca= " & "'" & idMarcas & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarMarca(ByVal MArcas As ClaseMarca)
        Dim sel As String

        Try
            sel = "update Marcas set Descripcion = '" & MArcas.DescripcionMarca & "'," &
                "margen =" & MArcas.Margen & "" &
                "where idMarca = '" & MArcas.idMarca & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function InsertarMARCA(ByVal Marca As ClaseMarca) As Integer
        Dim insert As String
        insert = "insert into Marcas ( descripcion, margen)" &
        " values (@descripcion, @margen ) SELECT SCOPE_IDENTITY()"
        com.Parameters.AddWithValue("@descripcion", Marca.DescripcionMarca)
        com.Parameters.AddWithValue("@margen", Marca.Margen)
        com.CommandText = insert
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Marca")
        End Try
        Return t
    End Function
    Public Function idCategoria() As DataSet
        Dim da As New SqlDataAdapter("select IDENT_CURRENT('CategoriaStock') +1  as identcurrent ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function InsertarCATEGORIA(ByVal categoria As ClaseCategoria) As Integer
        Dim insert As String
        insert = "insert into CategoriaStock ( NomCategoria)" &
        " values (@NomCategoria ) SELECT SCOPE_IDENTITY()"
        com.Parameters.AddWithValue("@NomCategoria", categoria.DescripcionCategoria)
        com.CommandText = insert
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Marca")
        End Try
        Return t
    End Function
    Public Function CargarCategoria() As DataSet
        Dim da As New SqlDataAdapter("select idCategoria as Codigo, NomCategoria as Categoria from CategoriaStock", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function BuscarIDCategoria(ByVal idCategoria) As DataSet

        Dim da As New SqlDataAdapter("select * from CategoriaStock where IdCategoria= " & "'" & idCategoria & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarCategoria(ByVal Categoria As ClaseCategoria)
        Dim sel As String

        Try
            sel = "update CategoriaStock set NomCategoria = '" & Categoria.DescripcionCategoria & "'" &
                "where idCategoria = '" & Categoria.idCategoria & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarCostoArt(ByVal costoArt As ClaseArticulo)
        Dim sel As String

        Try
            sel = "update Articulos set costo= " & costoArt.costo & "" &
                "where idArticulo= '" & costoArt.idArticulo & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ModificarCostoPRECIOArt(ByVal costoPR As ClaseArticulo)
        Dim sel As String

        Try
            sel = "update Articulos set PrecioVenta= (costo *(select margen from marcas m, articulos ar where m.idMarca=ar.idMarca and ar.idArticulo= " & costoPR.idArticulo & ")/100)+ costo
where TipoPrecio=1
and idArticulo= " & costoPR.idArticulo & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function BusquedaCategoria(ByVal idCategoria, descripcion) As DataSet

        Dim da As New SqlDataAdapter("select ar.IDARTICULO as Codigo, ar.descripcion as Articulo, m.descripcion as Marca, cs.NomCategoria as Categoria" &
" from articulos ar inner join CategoriaStock cs on ar.idCategoria= cs.idCategoria" &
" inner join marcas m on m.idMarca=ar.idMarca" &
" where ar.idCategoria='" & idCategoria & "'" &
" and ar.descripcion like '%" & descripcion & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BusquedaMarca(ByVal idMArca, descripcion) As DataSet

        Dim da As New SqlDataAdapter("select ar.IDARTICULO as Codigo, ar.descripcion as Articulo, m.descripcion as Marca, cs.NomCategoria as Categoria" &
" from articulos ar inner join CategoriaStock cs on ar.idCategoria= cs.idCategoria" &
" inner join marcas m on m.idMarca=ar.idMarca" &
" where ar.idMArca='" & idMArca & "'" &
" and ar.descripcion like '%" & descripcion & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BusquedaDescripcion(ByVal descripcion) As DataSet

        Dim da As New SqlDataAdapter("select ar.IDARTICULO as Codigo, ar.descripcion as Articulo, m.descripcion as Marca, cs.NomCategoria as Categoria" &
" from articulos ar inner join CategoriaStock cs on ar.idCategoria= cs.idCategoria" &
" inner join marcas m on m.idMarca=ar.idMarca" &
" where  ar.descripcion like '%" & descripcion & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BusquedaCodCategoria(ByVal idCategoria, descripcion) As DataSet

        Dim da As New SqlDataAdapter("select * from CategoriaStock where IdCategoria= " & "'" & idCategoria & "'" &
                                     " and NomCategoria like '%" & descripcion & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BusquedaDESCCategoria(ByVal descripcion) As DataSet

        Dim da As New SqlDataAdapter("select * from CategoriaStock where nomCategoria like " & "'%" & descripcion & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BusquedaCodMARCA(ByVal idMArca, descripcion) As DataSet

        Dim da As New SqlDataAdapter("select * from MArcas where idMarca= " & "'" & idMArca & "'" &
                                     " and descripcion like '%" & descripcion & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BusquedaDESCMArca(ByVal descripcion) As DataSet

        Dim da As New SqlDataAdapter("select * from MArcas where descripcion like " & "'%" & descripcion & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    ''para articulo
    Public Function BuscarMargen(ByVal idmarca) As DataSet

        Dim da As New SqlDataAdapter("select margen from marcas where idMarca= " & idmarca & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaArtMM() As DataSet
        Dim da As New SqlDataAdapter("select cs.NomCategoria as Categoria, m.descripcion as Marca, ar.descripcion as Articulo, ar.IDARTICULO as Codigo, ar.precioVenta as Precio, (case when ar.TipoPrecio=0 then 'Manual' else 'Por Marca'end) as 'Tipo de Precio'" &
" from articulos ar inner join CategoriaStock cs on ar.idCategoria= cs.idCategoria" &
" inner join marcas m on m.idMarca=ar.idMarca order by cs.NomCategoria", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function

    Public Sub modificarPrecioProcentaje(ByVal ar As ClaseArticulo, ByVal porcentaje As Double)
        Dim sel As String

        Try
            sel = "update Articulos set precioVenta = precioVenta + ((precioVenta * " & porcentaje & ")/100)" &
                 "where idArticulo = " & ar.idArticulo & "" &
                 "and tipoPrecio=0"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub modificarTipoPrecioMANUAL(ByVal arP As ClaseArticulo)
        Dim sel As String

        Try
            sel = "update Articulos set tipoPrecio = 0" &
                 "where idArticulo = " & arP.idArticulo & "" &
                 "and tipoPrecio=1"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarTipoPrecioMARCA(ByVal arPM As ClaseArticulo)
        Dim sel As String

        Try
            sel = " update articulos  set TipoPrecio=1 ," &
  " PrecioVenta= Costo +(costo * m.Margen/100)" &
  " from articulos a , (select m.Margen, ar.idArticulo as ID from Marcas m, articulos ar where m.idMarca=ar.idMarca) m" &
  " where a.idArticulo=m.ID" &
  " and a.idarticulo=" & arPM.idArticulo & " and tipoprecio=0"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarMAsivCategoria(ByVal arC As ClaseArticulo, ByVal idCat As ClaseCategoria)
        Dim sel As String

        Try
            sel = "update Articulos set idCategoria =" & idCat.idCategoria & "" &
                 "where idArticulo = " & arC.idArticulo & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function CargarGrillaArtMMCategoria(ByVal idCateg As Integer, ByVal descripcion As String) As DataSet
        Dim da As New SqlDataAdapter("select cs.NomCategoria as Categoria, m.descripcion as Marca, ar.descripcion as Articulo, ar.IDARTICULO as Codigo,
ar.precioVenta as Precio, (case when ar.TipoPrecio=0 then 'Manual' else 'Por Marca'end) as 'Tipo de Precio'
 from articulos ar inner join CategoriaStock cs on ar.idCategoria= cs.idCategoria
 inner join marcas m on m.idMarca=ar.idMarca " &
" where ar.idCategoria=" & idCateg & "" &
" and ar.descripcion like '%" & descripcion & "%'" &
" order by cs.NomCategoria", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function
    Public Function BusquedaDescripcionMM(ByVal descripcion) As DataSet

        Dim da As New SqlDataAdapter("select cs.NomCategoria as Categoria, m.descripcion as Marca, ar.descripcion as Articulo, ar.IDARTICULO as Codigo,
ar.precioVenta as Precio, (case when ar.TipoPrecio=0 then 'Manual' else 'Por Marca'end) as 'Tipo de Precio'
 from articulos ar inner join CategoriaStock cs on ar.idCategoria= cs.idCategoria
 inner join marcas m on m.idMarca=ar.idMarca" &
" where  ar.descripcion Like '%" & descripcion & "%'" &
" order by cs.NomCategoria", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

End Class

