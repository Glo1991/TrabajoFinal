Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosEstadisticas
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

    Public Function CargarGrilla(ByVal idcategoria As String, ByVal idmarca As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataSet

        Dim sql As String
        sql = " select  ct.NomCategoria as 'Categoría', m.Descripcion as'Marca', ar.descripcion as 'Descripción', ar.idArticulo as 'Código', 
 sum(iv.cantidad) as 'cantidad'
 from articulos ar
 inner join CategoriaStock ct on ct.idCategoria=ar.idCategoria
 inner join marcas m on m.idMarca= ar.idMarca
 inner join ItemVenta iv on iv.idArticulo=ar.idArticulo
 inner join Ventas v on iv.numFactura=v.numFactura and iv.tipofactura=v.tipoFactura
 where iv.esarticulo=0 and v.anulada=0
  and v.fecha between '" & fechadesde & "' and '" & fechahasta & "'"
        If idcategoria <> "" Then
            sql = sql & "and ar.idCategoria=" & idcategoria & ""
        End If
        If idmarca <> "" Then
            sql = sql & "and ar.idMarca =" & idmarca & ""
        End If
        'If fechahasta <> "" And fechadesde <> "" Then
        '    sql = sql & "and v.fecha between" & fechadesde & " and " & fechahasta & ""
        'End If
        sql = sql & " group by  ar.idArticulo,ar.descripcion, ct.NomCategoria , m.Descripcion  order by 1,2,3 "
        Dim da As New SqlDataAdapter(sql, con)
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
    Public Function CargarGrillaCompras(ByVal idcategoria As String, ByVal idmarca As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataSet

        Dim sql As String
        sql = " select ct.NomCategoria as 'Categoría', m.Descripcion as'Marca',ar.descripcion as'Descripción',  ar.idArticulo as 'Código',
 sum(iv.cantidad) as 'Cantidad'
 from articulos ar
 inner join CategoriaStock ct on ct.idCategoria=ar.idCategoria
 inner join marcas m on m.idMarca= ar.idMarca
 inner join Item iv on iv.idArticulo=ar.idArticulo
 inner join compras v on iv.numFactura=v.numFactura and iv.tipocomprobante=v.tipoComprobante
 where v.Anulado=0  
 and v.FechaIngreso between '" & fechadesde & "' and '" & fechahasta & "'"
        If idcategoria <> "" Then
            sql = sql & "and ar.idCategoria=" & idcategoria & ""
        End If
        If idmarca <> "" Then
            sql = sql & "and ar.idMarca =" & idmarca & ""
        End If

        sql = sql & " group by  ar.idArticulo,ar.descripcion, ct.NomCategoria , m.Descripcion  order by 1,2,3 "
        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

    Public Function rentabilidad(ByVal fechadesde As String, ByVal fechahasta As String) As DataSet

        Dim sql As String
        sql = " select v.Fecha as 'Fecha Comprobante', cl.Apellido+' '+cl.Nombre as Cliente, v.tipoFactura as 'Tipo', 
substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13) as 'N° de comprobante',
sum(iv.total) as 'Venta', sum(iv.cantidad * iv.costoArticulo) as 'Costo Venta'
from ventas v
inner join Documento d on d.NumDoc=v.idCliente
inner join Cliente cl on cl.IdCliente=d.idCliente 
inner join ItemVenta iv on iv.numFactura= v.numFactura and iv.tipofactura=v.tipoFactura
where iv.esarticulo=0 and iv.tipofactura like'F_' and  v.anulada=0
 and v.Fecha between '" & fechadesde & "' and '" & fechahasta & "'"
        'If idcategoria <> "" Then
        '    sql = sql & "and ar.idCategoria=" & idcategoria & ""
        'End If
        'If idmarca <> "" Then
        '    sql = sql & "and ar.idMarca =" & idmarca & ""
        'End If

        sql = sql & " group by v.Fecha ,  cl.Apellido, cl.Nombre  ,v.tipoFactura,v.numFactura order by Fecha,Cliente  "
        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

    Public Function ReporteVentasxart(ByVal idcategoria As String, ByVal idmarca As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataTable

        Dim sql As String
        sql = " select  ct.NomCategoria as 'Categoría', m.Descripcion as'Marca', ar.descripcion as 'Descripción', ar.idArticulo as 'Código', 
 sum(iv.cantidad) as 'cantidad'
 from articulos ar
 inner join CategoriaStock ct on ct.idCategoria=ar.idCategoria
 inner join marcas m on m.idMarca= ar.idMarca
 inner join ItemVenta iv on iv.idArticulo=ar.idArticulo
 inner join Ventas v on iv.numFactura=v.numFactura and iv.tipofactura=v.tipoFactura
 where iv.esarticulo=0 and v.anulada=0
  and v.fecha between '" & fechadesde & "' and '" & fechahasta & "'"
        If idcategoria <> "" Then
            sql = sql & "and ar.idCategoria=" & idcategoria & ""
        End If
        If idmarca <> "" Then
            sql = sql & "and ar.idMarca =" & idmarca & ""
        End If
        'If fechahasta <> "" And fechadesde <> "" Then
        '    sql = sql & "and v.fecha between" & fechadesde & " and " & fechahasta & ""
        'End If
        sql = sql & " group by  ar.idArticulo,ar.descripcion, ct.NomCategoria , m.Descripcion  order by 1,2,3 "
        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataTable
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function Reporterentabilidad(ByVal fechadesde As String, ByVal fechahasta As String) As DataTable

        Dim sql As String
        sql = "   select cast(v.Fecha as date) as 'Fecha' , cl.Apellido+' '+cl.Nombre as Cliente, v.tipoFactura as 'Tipo', 
(substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13)) as 'Ndecomprobante',
sum(iv.total) as 'Venta', (sum(iv.cantidad * iv.costoArticulo)) as 'CostoVenta', (sum(iv.total)- (sum(iv.cantidad * iv.costoArticulo))) as 'Resultado',
(case when (sum(iv.cantidad * iv.costoArticulo))<>0 then (((sum(iv.total)- (sum(iv.cantidad * iv.costoArticulo)))*100/ (sum(iv.cantidad * iv.costoArticulo)))) else 100  end)as 'Porcentaje'
from ventas v
inner join Documento d on d.NumDoc=v.idCliente
inner join Cliente cl on cl.IdCliente=d.idCliente 
inner join ItemVenta iv on iv.numFactura= v.numFactura and iv.tipofactura=v.tipoFactura
where iv.esarticulo=0 and iv.tipofactura like'F_' and  v.anulada=0
 and v.Fecha between '" & fechadesde & "' and '" & fechahasta & "'"
        'If idcategoria <> "" Then
        '    sql = sql & "and ar.idCategoria=" & idcategoria & ""
        'End If
        'If idmarca <> "" Then
        '    sql = sql & "and ar.idMarca =" & idmarca & ""
        'End If

        sql = sql & " group by v.Fecha ,  cl.Apellido, cl.Nombre  ,v.tipoFactura,v.numFactura order by Fecha,Cliente  "
        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataTable
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function ReporteComrpasxart(ByVal idcategoria As String, ByVal idmarca As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataTable

        Dim sql As String
        sql = " select ct.NomCategoria as 'Categoría', m.Descripcion as'Marca',ar.descripcion as'Descripción',  ar.idArticulo as 'Código',
 sum(iv.cantidad) as 'Cantidad'
 from articulos ar
 inner join CategoriaStock ct on ct.idCategoria=ar.idCategoria
 inner join marcas m on m.idMarca= ar.idMarca
 inner join Item iv on iv.idArticulo=ar.idArticulo
 inner join compras v on iv.numFactura=v.numFactura and iv.tipocomprobante=v.tipoComprobante
 where v.Anulado=0  
 and v.FechaIngreso between '" & fechadesde & "' and '" & fechahasta & "'"
        If idcategoria <> "" Then
            sql = sql & "and ar.idCategoria=" & idcategoria & ""
        End If
        If idmarca <> "" Then
            sql = sql & "and ar.idMarca =" & idmarca & ""
        End If

        sql = sql & " group by  ar.idArticulo,ar.descripcion, ct.NomCategoria , m.Descripcion  order by 1,2,3 "
        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataTable
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function ReportePR(ByVal numpr As Double) As DataTable

        Dim sql As String
        sql = "  select (cl.Apellido+' '+cl.Nombre)as'Cliente',d.NumDoc as 'DNI', pr.idPresupuesto as'NumPR', pr.fechaingreso as 'Fecha',
 (case when i.esArticulo=0 then ar.descripcion else ls.DescripcionServicio end) as Detalle, i.cantidad as Cantidad, i.precio as Precio, (i.cantidad * i.precio) as Total,
  (case when i.esArticulo=0 then ar.idArticulo else ls.idServicio end) as Codigo, 
  (case when i.esArticulo=0 then 'Articulo' else 'Servicio'end) as Tipo, idarticulo
  from Presupuestos pr
 inner join itemPR i on i.idPresupuesto=pr.idPresupuesto
 inner join Documento d on d.NumDoc=pr.codigocliente
 inner join Cliente cl on cl.IdCliente=d.IdCliente
 left join Articulos ar on ar.idArticulo=i.CodigoArticuloServicio
 left join ListaServicios ls on ls.idServicio=i.CodigoArticuloServicio
 where pr.idPresupuesto=" & numpr & " "
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
