Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosVentasDA
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
        Dim da As New SqlDataAdapter("select cl.Apellido+' '+cl.Nombre as Cliente, v.tipoFactura as 'Tipo', 
substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13) as 'N° de comprobante',
v.total as 'Total', v.Fecha as 'Fecha Comprobante', v.anulada
from ventas v
inner join Documento d on d.NumDoc=v.idCliente
inner join Cliente cl on cl.IdCliente=d.idCliente where v.anulada=0 order by fecha, Cliente ", con)

        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarPrecVta(ByVal stock As Integer, ByVal prov As Integer) As DataSet

        Dim da As New SqlDataAdapter("select precioVta  from PreciosVta where idStock ='" & stock & "' and idProv ='" & prov & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarProveedor(ByVal stock As Integer) As DataSet

        Dim da As New SqlDataAdapter("select idProv  from PreciosVta where idStock ='" & stock & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarVenta(ByVal venta As ClaseVentas) As Integer
        Dim sel As String

        sel = "insert into Ventas (Fecha, numFactura, total, idCliente, tipoFactura, pagado, anulada ) values (@Fecha, @numFactura, @total, @idCliente, @tipofactura, @pagado,@anulada)"

        com.Parameters.AddWithValue("@Fecha", venta.Fecha)
        com.Parameters.AddWithValue("@numFactura", venta.numFactura)
        com.Parameters.AddWithValue("@total", venta.total)
        com.Parameters.AddWithValue("@idCliente", venta.idCliente)
        com.Parameters.AddWithValue("@tipoFactura", venta.tipofactura)
        com.Parameters.AddWithValue("@pagado", venta.pagado)
        com.Parameters.AddWithValue("@anulada", venta.anulada)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Function BuscarCostoArticulo(ByVal idarticulo As Integer) As DataSet

        Dim da As New SqlDataAdapter("select costo  from articulos where idarticulo ='" & idarticulo & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarItemVenta(ByVal Item As ClaseItemVenta) As Integer
        Dim sel As String

        sel = "insert into ItemVenta(idarticulo, cantidad, precio, total, numFactura, tipofactura,esarticulo, costoarticulo) values (@idarticulo, @cantidad, @precio, @total, @numFactura, @tipofactura,@esarticulo, @costoarticulo) SELECT SCOPE_IDENTITY()"
        com.Parameters.Clear()
        com.Parameters.AddWithValue("@idarticulo", Item.idArticulo)
        com.Parameters.AddWithValue("@cantidad", Item.cantidad)
        com.Parameters.AddWithValue("@precio", Item.Precio)
        com.Parameters.AddWithValue("@total", Item.Total)
        com.Parameters.AddWithValue("@numFactura", Item.numFactura)
        com.Parameters.AddWithValue("@tipofactura", Item.tipofactura)
        com.Parameters.AddWithValue("@esarticulo", Item.esarticulo)
        com.Parameters.AddWithValue("@costoarticulo", Item.costo)
        com.CommandText = sel

        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function

    Public Function BuscarNumFacVenta() As DataSet

        Dim da As New SqlDataAdapter("select max(idVenta + 1 )  from Ventas ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIdVenta(ByVal tipocomprobante As String, ByVal numcomprobante As String) As DataSet

        Dim da As New SqlDataAdapter("select cl.Apellido+' '+cl.Nombre as Cliente,v.idCliente,  v.tipoFactura as 'Tipo', 
substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13) as 'N° de comprobante',
v.total as 'Total', v.Fecha as 'Fecha Comprobante', v.anulada
from ventas v
inner join Documento d on d.NumDoc=v.idCliente
inner join Cliente cl on cl.IdCliente=d.idCliente 
where v.tipoFactura='" & tipocomprobante & "' 
and substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13)= '" & numcomprobante & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarNumComprob(ByVal tipocomprobante As String, ByVal numcomprobante As String) As DataSet

        Dim da As New SqlDataAdapter("select  (case when iv.esarticulo=0 then ar.descripcion else ls.DescripcionServicio end) as 'Detalle', iv.cantidad as 'Cantidad', iv.precio as 'Precio Unitario',
iv.total as 'Importe', ar.idArticulo as 'Código', (case when iv.esarticulo= 1 then 'Servicio' else 'Artículo' end) as 'Tipo'
from ItemVenta iv 
left join Articulos ar on ar.idArticulo=iv.idArticulo
left join ListaServicios ls on ls.idServicio= iv.idArticulo
where iv.tipofactura='" & tipocomprobante & "'
and substring( (right(replicate ('0',13)+(cast (iv.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (iv.numFactura as varchar)), 13)), 6,13)= '" & numcomprobante & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarFEchasGrillaVta(ByVal fech As String, ByVal fecha As String, ByVal tipocomprobante As String, ByVal cliente As String, ByVal anulada As Integer) As DataSet
        Dim sql As String = "select cl.Apellido+' '+cl.Nombre as Cliente, v.tipoFactura as 'Tipo', 
substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13) as 'N° de comprobante',
v.total as 'Total', v.Fecha as 'Fecha Comprobante', v.anulada
from ventas v
inner join Documento d on d.NumDoc=v.idCliente
inner join Cliente cl on cl.IdCliente=d.idCliente where v.fecha>'1899/01/01' "
        If fech <> "" And fecha <> "" Then
            sql = sql & " and v.Fecha between '" & fech & "' and '" & fecha & "' "
        End If
        If tipocomprobante <> "" Then
            sql = sql & " and v.tipoFactura= '" & tipocomprobante & "'"
        End If
        If cliente <> "" Then
            sql = sql + "and (cl.Apellido+' '+cl.Nombre) like '%" & cliente & "%'"
        End If
        If anulada = 1 Then
            sql = sql & "and (v.anulada = 0 or v.anulada=1 ) "
        Else
            sql = sql & "and v.anulada = 0  "
        End If

        sql = sql & "order by fecha, Cliente "

        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarNomClienteGrilla(ByVal client) As DataSet

        Dim da As New SqlDataAdapter("select (c.Apellido +' '+ c.Nombre) as 'Cliente', v.total as 'Total', v.numFactura as 'N° de Comprobante',v.Fecha, v.idVenta, c.idCliente " & _
" from Ventas v" & _
" inner join Cliente c" & _
" on v.idCliente = c.IdCliente " & _
" where (c.Apellido +' '+ c.Nombre) like '%" & client & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    '    Public Function BuscarNumdeComprob(ByVal compr) As DataSet

    '        Dim da As New SqlDataAdapter("select (c.Apellido +' '+ c.Nombre) as 'Cliente', v.total as 'Total', v.numFactura as 'N° de Comprobante',v.Fecha, v.idVenta, c.idCliente " &
    '" from Ventas v" &
    '" inner join Cliente c" &
    '" on v.idCliente = c.IdCliente " &
    '" where v.numFactura like '%" & compr & "%'", con)
    '        Dim ds As New DataSet
    '        Try
    '            da.Fill(ds)

    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '        End Try
    '        Return ds

    '    End Function
    Public Function buscarPresupuesto(ByVal idcliente) As DataSet

        Dim da As New SqlDataAdapter("select idPresupuesto, tipoComprobante, codigocliente, fechaIngreso 
from Presupuestos
where facturado= 0 and anulado=0
and codigocliente=" & idcliente & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function buscarcabecerapresupuesto(ByVal idPRe1) As DataSet

        Dim da As New SqlDataAdapter("select idPresupuesto as 'Nro Presupuesto',  cl.Apellido+' '+cl.Nombre as Cliente, total as 'Total',  pr.fechaIngreso as Fecha, pr.anulado
from Presupuestos pr 
inner join Documento d on d.NumDoc=pr.codigocliente
inner join Cliente cl on cl.IdCliente=d.IdCliente
where pr.facturado=0 and anulado=0
and pr.codigocliente=" & idPRe1 & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function buscarCOSTOItemPresupuesto(ByVal idPRe) As DataSet

        Dim da As New SqlDataAdapter("   select idarticulo from itemPR i 
   left join Articulos ar on ar.idArticulo=i.CodigoArticuloServicio
  where ar.Costo>i.precio and i.idPresupuesto=" & idPRe & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function buscarItemPresupuesto(ByVal idPRe) As DataTable

        Dim da As New SqlDataAdapter("select  (case when esArticulo=0 then ar.descripcion else ls.DescripcionServicio end) as 'Descripcion',  i.cantidad, i.precio,
 i.total , i.CodigoArticuloServicio, cast ((case when esArticulo=0 then 'Artículo' else 'Servicio' end) as varchar)as 'Tipo', idPresupuesto
from itemPR i 
left join Articulos ar on ar.idArticulo=i.CodigoArticuloServicio and i.esArticulo=0
left join ListaServicios ls on ls.idServicio=i.CodigoArticuloServicio and i.esArticulo=1
where  (i.precio>=(case when esArticulo=0 then ar.Costo else 0 end)
or   i.precio>=(case when esArticulo=1 then  0 end)) and i.idPresupuesto=" & idPRe & "", con)
        Dim ds As New DataTable
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

    Public Sub modificarPRFacturado(ByVal numPR As Integer)
        Dim sel As String
        Try
            sel = "update Presupuestos set facturado = 1
                where idPresupuesto = " & numPR & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function buscarCobroFactura(ByVal tipoFactura As String, ByVal numerofactura As String) As DataSet

        Dim da As New SqlDataAdapter("	select * from Cobros c where c.esAnulacion=0
	and c.anulado=0 and c.tipoComprobante='" & tipoFactura & "' and c.numcomprobante=" & numerofactura & " ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function buscarItemAnulCS(ByVal tipoFactura As String, ByVal numerofactura As String) As DataSet

        Dim da As New SqlDataAdapter("select i.tipofactura, i.numFactura, i.cantidad, i.idArticulo, (cl.Apellido +' '+ cl.Nombre ) from ItemVenta i
inner join Ventas v on v.tipoFactura=i.tipofactura and v.numFactura=i.numFactura
inner join Documento d on d.NumDoc=v.idCliente
inner join cliente cl on cl.IdCliente=d.IdCliente
where  i.esarticulo=0 and v.tipofactura='" & tipoFactura & "' and v.numFactura=" & numerofactura & " ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarFacturaAnulada(ByVal tipoFactura As String, ByVal numerofactura As String)
        Dim sel As String
        Try
            sel = "update ventas set anulada = 1
                where tipofactura = '" & tipoFactura & "'
                and numfactura=" & numerofactura & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function buscarVinculosPRModif(ByVal tipoFactura As String, ByVal numerofactura As String) As DataSet

        Dim da As New SqlDataAdapter("select * from Vinculos v where v.activo=1 and v.TipoComprobante='" & tipoFactura & "' and v.numerocomprobante=" & numerofactura & " ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarvinculoPRactiv(ByVal tipoFactura As String, ByVal numerofactura As String)
        Dim sel As String
        Try
            sel = "update Vinculos set activo=0 where activo=1 and TipoComprobante = '" & tipoFactura & "'
                and numerocomprobante=" & numerofactura & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarPRFacturadoAnulado(ByVal numPR As Integer)
        Dim sel As String
        Try
            sel = "update Presupuestos set facturado = 0
                where idPresupuesto = " & numPR & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function buscarfactura(ByVal tipoFactura As String, ByVal numerofactura As String) As DataSet

        Dim da As New SqlDataAdapter("select * from ventas v where v.anulada=0 and v.tipoFactura='" & tipoFactura & "' and v.numFactura=" & numerofactura & " ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
End Class
