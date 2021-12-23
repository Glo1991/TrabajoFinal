Imports System.Data
Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosPresupuestos

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
    Public Function CargarGrilla() As DataSet
        Dim da As New SqlDataAdapter("  select (cl.Apellido +' '+ cl.Nombre) as Cliente, p.idpresupuesto as 'NUMERO PRESUPUESTO', d.NumDoc AS DNI,
  p.total as TOTAL, fechaIngreso as Fecha, p.Anulado
   from presupuestos p  
   inner join  itemPR i on i.idpresupuesto=p.idpresupuesto 
   inner join Documento d  on d.NumDoc= p.codigocliente 
   inner join cliente cl on cl.IdCliente=d.IdCliente 
   left join Articulos ar on ar.idArticulo=i.CodigoArticuloServicio
   left join ListaServicios ls on ls.idServicio=i.CodigoArticuloServicio
where p.anulado=0
   GROUP BY cl.Apellido, cl.Nombre,  p.idpresupuesto , p.total, d.NumDoc,fechaIngreso, p.Anulado order by fechaingreso, cl.Apellido", con)

        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function
    Public Function InsertarPresupuesto(ByVal PR As ClasePresupuestos) As Integer
        Dim insert As String
        insert = "insert into Presupuestos ( tipoComprobante, codigocliente, fechaIngreso, total, Anulado, facturado)" &
        " values ( @tipoComprobante, @codigocliente, @fechaIngreso, @total,@Anulado, @facturado) SELECT SCOPE_IDENTITY()"
        'com.Parameters.AddWithValue("@idPresupuesto", PR.idPresupuesto)
        com.Parameters.AddWithValue("@tipoComprobante", PR.tipocomprobante)
        com.Parameters.AddWithValue("@codigocliente", PR.Codgigocliente)
        com.Parameters.AddWithValue("@fechaIngreso", PR.FechaIngreso)
        com.Parameters.AddWithValue("@total", PR.Total)
        com.Parameters.AddWithValue("@Anulado", PR.Anulado)
        com.Parameters.AddWithValue("@facturado", PR.facturado)
        com.CommandText = insert
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Artículo")
        End Try
        Return t
    End Function
    Public Function InsertarItemPR(ByVal ItPR As ClaseItemPR) As Integer
        Dim insert As String = ""
        insert = "insert into itemPR ( CodigoArticuloServicio, esArticulo, cantidad, precio, total,tipoComprobante,idPresupuesto)" &
        " values ( @CodigoArticuloServicio, @esArticulo, @cantidad, @precio,@total1,@tipoComprobante1, @idPresupuesto) SELECT SCOPE_IDENTITY()"
        'com.Parameters.AddWithValue("@idItemPR", ItPR.idItemPR)
        com.Parameters.Clear()
        com.Parameters.AddWithValue("@CodigoArticuloServicio", ItPR.Codigo)
        com.Parameters.AddWithValue("@esArticulo", ItPR.esArticulo)
        com.Parameters.AddWithValue("@cantidad", ItPR.cantidad)
        com.Parameters.AddWithValue("@precio", ItPR.Precio)
        com.Parameters.AddWithValue("@tipoComprobante1", ItPR.tipocomprobante)
        com.Parameters.AddWithValue("@total1", ItPR.Total)
        com.Parameters.AddWithValue("@idPresupuesto", ItPR.idPresupuesto)
        com.CommandText = insert
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Artículo")
        End Try
        Return t
    End Function
    Public Function nuevoPresupuesto() As DataSet
        Dim da As New SqlDataAdapter("select IDENT_CURRENT('Presupuestos')+1  as identcurrent ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function CargarGrillaFechas(ByVal fechadesde As String, ByVal fechahasta As String, ByVal dni As String, ByVal numPresup As String, ByVal anulado As Integer) As DataSet
        Dim sql As String
        sql = "select (cl.Apellido +' '+ cl.Nombre) as Cliente, p.idpresupuesto as 'NUMERO PRESUPUESTO', d.NumDoc AS DNI, " &
        "p.total as TOTAL, fechaIngreso as Fecha , p.Anulado  " &
        " from presupuestos p  " &
        " inner join  itemPR i on i.idpresupuesto=p.idpresupuesto " &
        " inner join Documento d  on d.NumDoc= p.codigocliente " &
        " inner join cliente cl on cl.IdCliente=d.IdCliente " &
        " left join Articulos ar on ar.idArticulo=i.CodigoArticuloServicio " &
        " left join ListaServicios ls on ls.idServicio=i.CodigoArticuloServicio where p.idpresupuesto<>0"
        If fechadesde <> "" And fechahasta <> "" Then
            sql = sql & " and fechaingreso between '" & fechadesde & "' and '" & fechahasta & "'"
        End If

        If numPresup <> "" Then
            sql = sql & " and p.idpresupuesto =" & numPresup & ""
        End If

        If dni <> "" Then
            sql = sql & " and d.Numdoc= " & dni & ""

        End If
        If anulado = 1 Then
            sql = sql & " and (p.anulado= 0 or  p.anulado=1)"
        Else
            sql = sql & " and p.anulado= 0"
        End If

        sql = sql & " GROUP BY cl.Apellido, cl.Nombre,  p.idpresupuesto , p.total, d.NumDoc,fechaIngreso, p.Anulado order by fechaingreso, cl.Apellido"
        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return ds
    End Function
    Public Function EsArticulo(ByVal idarticulo As Integer) As Integer
        Dim da As New SqlDataAdapter("select idarticulo from articulos where idarticulo=" & idarticulo & " ", con)
        Dim esArt As Integer
        If da.ToString <> "" Then
            esArt = 0
        Else
            esArt = 1
        End If
        Return esArt
    End Function
    Public Function detallePresupuesto(ByVal idpresupuesto As Integer) As DataSet
        Dim da As New SqlDataAdapter(" select cl.Apellido+' '+cl.Nombre, d.NumDoc, p.fechaIngreso, p.total, idPresupuesto, p.anulado  
from presupuestos p inner join Documento d on d.NumDoc= p.codigocliente
  inner join cliente cl on cl.IdCliente=d.IdCliente where idpresupuesto=" & idpresupuesto & " ", con)
        Dim ds As New DataSet

        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function detalleItemPresupuesto(ByVal idpresupuesto As Integer) As DataSet
        Dim da As New SqlDataAdapter("  select  (case when i.esArticulo=0 then ar.descripcion else ls.DescripcionServicio end) as Detalle, i.cantidad as Cantidad, i.precio as Precio, (i.cantidad * i.precio) as Total,
  (case when i.esArticulo=0 then ar.idArticulo else ls.idServicio end) as Codigo, (case when i.esArticulo=0 then 'Articulo' else 'Servicio'end) as Tipo, idarticulo
  from itemPR i
   left join Articulos ar on ar.idArticulo=i.CodigoArticuloServicio
  left join ListaServicios ls on ls.idServicio=i.CodigoArticuloServicio where idpresupuesto=" & idpresupuesto & " ", con)

        Dim ds As New DataSet

        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function VinculosFacturaPresupuestp(ByVal idpresupuesto As Integer) As DataSet
        Dim da As New SqlDataAdapter("    select (v.TipoComprobante +' '+ substring( (right(replicate ('0',13)+(cast (v.numerocomprobante as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numerocomprobante as varchar)), 13)), 6,13)) as comprobante
 from Vinculos v where v.TipoComAsociado='PR' and v.activo=1
 and v.numeroComAsociado=" & idpresupuesto & "
 union
 select ((case when v.TipoComAsociado='OT' then 'ORDEN DE TRABAJO' else v.TipoComAsociado end)  +' '+ cast (v.numeroComAsociado as varchar)) as comprobante
 from Vinculos v where v.TipoComprobante='PR'and v.activo=1
 and v.numerocomprobante=" & idpresupuesto & " ", con)

        Dim ds As New DataSet

        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function VinculosPRFactura(ByVal numFactura As Long, ByVal tipofac As String) As DataSet
        Dim da As New SqlDataAdapter("   select ((case when v.TipoComAsociado='PR' then 'Presupuesto' else v.TipoComAsociado end) +' '+ cast (v.numeroComAsociado as varchar)) as comprobante
 from Vinculos v where v.activo=1 and v.TipoComprobante='" & tipofac & " '
 and v.numerocomprobante='" & numFactura & " '", con)

        Dim ds As New DataSet

        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function vinculosPR(ByVal idPR As Integer) As DataSet
        Dim da As New SqlDataAdapter(" 	select * from Vinculos v where
	v.TipoComAsociado='PR' and v.activo=1
	and  v.numeroComAsociado=" & idPR & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function
    Public Sub modificarPRAnulado(ByVal numPR As Integer)
        Dim sel As String

        Try
            sel = "update Presupuestos set anulado = 1
                where idPresupuesto = " & numPR & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function vinculosPROT(ByVal idPR As Integer) As DataSet
        Dim da As New SqlDataAdapter(" 	select * from Vinculos v where
	v.Tipocomprobante='PR' and v.activo=1
	and  v.numerocomprobante=" & idPR & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error ")
        End Try
        Return ds
    End Function
    Public Sub ModificarvinculosPRInactivoOT(ByVal idPR As Integer)
        Dim sel As String

        Try
            sel = " Update Vinculos  set activo=0 where
	Tipocomprobante='PR' and activo=1
	and  numerocomprobante=" & idPR & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function buscarPRanulado(ByVal idPR As Integer) As DataSet
        Dim da As New SqlDataAdapter(" select anulado from Presupuestos where idPresupuesto=" & idPR & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error ")
        End Try
        Return ds
    End Function
End Class
