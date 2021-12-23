Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosPrecioHistDA
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
        Dim da As New SqlDataAdapter("select s.Producto, p.precioHist as 'Precio' , r.NomRaz as 'Proveedor' , p.fechaPrecHisto as 'Fecha', idPrecHist   from PreciosHist p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv " & _
" order by s.Producto ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarPrecioHist(ByVal prec As ClasePreciosHist) As Integer
        Dim sel As String

        sel = "insert into PreciosHist (precioHist, idProv, fechaPrecHisto, idArticulo ) values ( @precioHist, @idProv, @fechaPrecHisto, @idArticulo ) SELECT SCOPE_IDENTITY()"
        com.Parameters.Clear()
        com.Parameters.AddWithValue("@precioHist", prec.PrecioHist)
        com.Parameters.AddWithValue("@idProv", prec.idProv)
        com.Parameters.AddWithValue("@fechaPrecHisto", prec.FechaPrecHist)
        com.Parameters.AddWithValue("@idArticulo", prec.idArticulo)
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
    Public Function CargarGrillaProducto(ByVal producto As String) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precioHist as 'Precio' , r.NomRaz as 'Proveedor' , p.fechaPrecHisto as 'Fecha', idPrecHist   from PreciosHist p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv " & _
        " where s.Producto like '%" & producto & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaProv(ByVal prov As String) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precioHist as 'Precio' , r.NomRaz as 'Proveedor' , p.fechaPrecHisto as 'Fecha', idPrecHist   from PreciosHist p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv " & _
        " where  r.NomRaz like '%" & prov & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaProvProc(ByVal prov As String, ByVal prod As String) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precioHist as 'Precio' , r.NomRaz as 'Proveedor' , p.fechaPrecHisto as 'Fecha', idPrecHist   from PreciosHist p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv " & _
        " where  r.NomRaz like '%" & prov & "%'" & _
        " and s.Producto  like '%" & prod & "%'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaProvProdFech(ByVal prov As String, ByVal prod As String, ByVal fecha As Date, ByVal fech As Date) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precioHist as 'Precio' , r.NomRaz as 'Proveedor' , p.fechaPrecHisto as 'Fecha', idPrecHist   from PreciosHist p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv " & _
        " where  r.NomRaz like '%" & prov & "%'" & _
        " and s.Producto  like '%" & prod & "%'" & _
        " and p.fechaPrecHisto between '" & fecha & "'" & _
        " and '" & fech & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaFecha(ByVal fecha As Date, ByVal fech As Date) As DataSet

        Dim da As New SqlDataAdapter("select s.Producto, p.precioHist as 'Precio' , r.NomRaz as 'Proveedor' , p.fechaPrecHisto as 'Fecha', idPrecHist   from PreciosHist p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock " & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv " & _
        " where  p.fechaPrecHisto between '" & fecha & "'" & _
        " and '" & fech & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIdStockIdProv(ByVal idStock As Integer, ByVal idProv As Integer) As DataSet

        Dim da As New SqlDataAdapter("select p.precio, p.fecha, idPrecio, p.idStock ,p.idProv from Precios p" & _
" inner join Stock s" & _
" on s.idStock = p.idStock" & _
" inner join Proveedores r" & _
" on r.idProv = p.idProv" & _
" where p.idStock= " & "'" & idStock & "'" & _
" and p.idProv= " & "'" & idProv & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
End Class
