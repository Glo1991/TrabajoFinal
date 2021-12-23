Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosComprasDA
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
        Dim da As New SqlDataAdapter("select c.FechaIngreso  as 'Fecha de Ingreso',p.NomRaz as 'Proveedor',  p.IdCuit as 'CUIT' , c.tipoComprobante as 'Tipo de Comprobante',
substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 6,13) as 'Número de Comrpobante', total as 'Total', 
 c.idCompra, c.anulado
from Compras  c
 inner join Proveedores  p on  
 p.idProv = c.idProv 
order by c.fechaIngreso  ", con)

        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarCompra(ByVal compra As ClaseCompras) As Integer
        Dim sel As String

        sel = "insert into Compras ( FechaIngreso, numFactura, total, idProv,tipoComprobante, anulado) values (@FechaIngreso, @numFactura, @total, @idProv,@tipoComprobante, @anulado) SELECT SCOPE_IDENTITY()"

        com.Parameters.AddWithValue("@FechaIngreso", compra.FechaIngreso)
        com.Parameters.AddWithValue("@numFactura", compra.numFactura)
        com.Parameters.AddWithValue("@total", compra.total)
        com.Parameters.AddWithValue("@idProv", compra.idProv)
        com.Parameters.AddWithValue("@tipoComprobante", compra.tipoCom)
        com.Parameters.AddWithValue("@anulado", compra.Anulado)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Function InsertarItem(ByVal Item As ClaseItem) As Integer
        Dim sel As String

        sel = "insert into Item (idArticulo, cantidad, precio, importe, numFactura,tipocomprobante) values (@idArticulo, @cantidad, @precio, @importe, @numFactura,@tipocomprobante) SELECT SCOPE_IDENTITY()"
        com.Parameters.Clear()
        com.Parameters.AddWithValue("@idArticulo", Item.Articulo)
        com.Parameters.AddWithValue("@cantidad", Item.cantidad)
        com.Parameters.AddWithValue("@precio", Item.Precio)
        com.Parameters.AddWithValue("@importe", Item.Importe)
        com.Parameters.AddWithValue("@numFactura", Item.numFactura)
        com.Parameters.AddWithValue("@tipocomprobante", Item.tipocomprobante)
        com.CommandText = sel

        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Function BuscarIdItem(ByVal idItem, ByVal item2, ByVal item3) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, i.cantidad, i.precio, i.importe, s.idStock, i.idItem " & _
" from Item i" & _
" inner join Stock s on" & _
        " s.idStock = i.idstock" & _
       " where i.idItem = '" & idItem & "'" & _
       " or i.idItem = '" & item2 & "'" & _
       " or i.idItem = '" & item3 & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarNumFact(ByVal numFact) As DataSet

        Dim da As New SqlDataAdapter("select ar.Descripcion as 'Descripción', i.cantidad as 'Cantidad', i.precio as 'Precio', i.importe as 'Importe', s.idArticulo, i.idItem " &
" from Item i" &
" inner join Stock s on" &
" s.idArticulo = i.idArticulo" &
" inner join Articulos ar on" &
" ar.idArticulo = i.idArticulo" &
" where i.numFactura = '" & numFact & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIdCompra(ByVal idCompra) As DataSet

        Dim da As New SqlDataAdapter("select c.FechaIngreso, p.NomRaz, p.IdCuit, c.numFactura, c.total, c.idCompra, c.tipoComprobante   from Compras c" &
" inner join Proveedores  p on" &
" p.idProv = c.idProv" &
" where c.idCompra = '" & idCompra & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub borrarItem(ByVal item As ClaseItem)

        Dim sel As String
        Try
            sel = "delete  from Item where idItem = @item"
            com.CommandText = sel
            com.Parameters.AddWithValue("@item", item.idItem)
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        con.Close()

    End Sub
    Public Function BuscarNumdeFactura(ByVal fact) As DataSet

        Dim da As New SqlDataAdapter("select c.FechaIngreso  as 'Fecha de Ingreso',p.NomRaz as 'Proveedor',  p.IdCuit as 'CUIT' , c.tipoComprobante as 'Tipo de Comprobante',
substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 6,13) as 'Número de Comrpobante', total as 'Total', 
 c.idCompra, c.anulado
from Compras  c
 inner join Proveedores  p on  
 p.idProv = c.idProv 
 where c.numFactura like '%" & fact & "%' order by c.FechaIngreso ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarNomdeProvGrilla(ByVal prov) As DataSet

        Dim da As New SqlDataAdapter("select c.FechaIngreso  as 'Fecha de Ingreso',p.NomRaz as 'Proveedor',  p.IdCuit as 'CUIT' , c.tipoComprobante as 'Tipo de Comprobante',
substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 6,13) as 'Número de Comrpobante', total as 'Total', 
 c.idCompra, c.anulado
from Compras  c
 inner join Proveedores  p on  
 p.idProv = c.idProv 
 where p.NomRaz like '%" & prov & "%' order by c.fechaIngreso", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarNumdeCuitGrilla(ByVal cuit) As DataSet

        Dim da As New SqlDataAdapter("select c.FechaIngreso  as 'Fecha de Ingreso',p.NomRaz as 'Proveedor',  p.IdCuit as 'CUIT' , c.tipoComprobante as 'Tipo de Comprobante',
substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 6,13) as 'Número de Comrpobante', total as 'Total', 
 c.idCompra, c.anulado
from Compras  c
 inner join Proveedores  p on  
 p.idProv = c.idProv 
 where p.IdCuit like '%" & cuit & "%' order by c.FechaIngreso", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarFEchasGrilla(ByVal fech As String, ByVal fecha As String) As DataSet

        Dim da As New SqlDataAdapter("select c.FechaIngreso  as 'Fecha de Ingreso',p.NomRaz as 'Proveedor',  p.IdCuit as 'CUIT' , c.tipoComprobante as 'Tipo de Comprobante',
substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (c.numFactura as varchar)), 13)), 6,13) as 'Número de Comrpobante', total as 'Total', 
 c.idCompra, c.anulado
from Compras  c
 inner join Proveedores  p on  
 p.idProv = c.idProv 
where c.FechaIngreso between '" & fech & "' and '" & fecha & "' order by  c.FechaIngreso ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

    Public Sub modificarStockK(ByVal stock As Integer, ByVal sNuevo As Double)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Stock set cantidad = cantidad + " & sNuevo & "" &
                "where idArticulo = '" & stock & "'"
            com.Parameters.Clear()
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function BuscarIDStock(ByVal stock) As DataSet

        Dim da As New SqlDataAdapter("select s.cantidad" &
" from Stock s" &
" inner join item i on" &
" s.idStock = i.idstock" &
" where i.idstock ='" & stock & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

    Public Sub modificarANulado(ByVal stock As ClaseCompras)
        Dim sel As String

        Try
            sel = "update compras set anulado=1 where idcompra = '" & stock.idCompra & "'"
            com.Parameters.Clear()
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function buscarAnulado(ByVal stock) As DataSet

        Dim da As New SqlDataAdapter("select anulado from compras i" &
" where i.idcompra ='" & stock & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function ValidarNumComprobante(ByVal tipo As String, ByVal num As String, ByVal cuit As String) As DataSet

        Dim da As New SqlDataAdapter(" select * from Compras c 
 inner join Proveedores pr on pr.idProv=c.idProv
where c.Anulado=0 and c.tipoComprobante='" & tipo & "'
 and c.numFactura=" & num & " and pr.IdCuit= " & cuit & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
End Class
