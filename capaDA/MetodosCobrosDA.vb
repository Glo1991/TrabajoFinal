Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosCobrosDA
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
        Dim da As New SqlDataAdapter("   select c.fecha, (case when c.tipoComprobante like 'F_' then ((case when c.esAnulacion=0 then 'Cobro de Comprobante ' else 'Anulacion de Cobro por Comprobante 'end)+v.tipoFactura +' '+ substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13) )else
 ('Devolución por Comprobante '+v.tipoFactura +' '+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13)) end),
 (case when c.total>0 then c.total else 0 end) as 'Ingreso',(case when c.total<0 then c.total else 0 end) as 'Egreso', idCobro 
 from cobros c
 inner join ventas v on v.tipoFactura= c.tipoComprobante and v.numFactura=c.numcomprobante
 order by c.fecha", con)

        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarCobro(ByVal Cobro As ClaseCobro) As Integer
        Dim insert As String
        insert = "insert into Cobros ( tipoComprobante,numcomprobante, total, esAnulacion, fecha, anulado)" &
        " values (@tipoComprobante, @numcomprobante, @total, @esAnulacion, @fecha,@anulado) SELECT SCOPE_IDENTITY()"
        com.Parameters.AddWithValue("@tipoComprobante", Cobro.Tipocomproabnte)
        com.Parameters.AddWithValue("@numcomprobante", Cobro.NumComrpobante)
        com.Parameters.AddWithValue("@total", Cobro.Total)
        com.Parameters.AddWithValue("@esAnulacion", Cobro.esanulacion)
        com.Parameters.AddWithValue("@fecha", Cobro.Fecha)
        com.Parameters.AddWithValue("@anulado", Cobro.anulado)
        com.CommandText = insert
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Artículo")
        End Try
        Return t
    End Function
    Public Sub modificarCobroFactura(ByVal numfactura As Long, ByVal tipofac As String)
        Dim sel As String

        Try
            sel = "update ventas set pagado = 1
                where numfactura=" & numfactura & "
                and tipofactura = '" & tipofac & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarCobroANULFactura(ByVal numfactura As Long, ByVal tipofac As String)
        Dim sel As String

        Try
            sel = "update ventas set pagado =0
                where numfactura=" & numfactura & "
                and tipofactura = '" & tipofac & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function buscarpagado(ByVal numfactura As String, ByVal tipofac As String) As DataSet
        Dim da As New SqlDataAdapter("select pagado from ventas v 
where substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13)= '" & numfactura & "' 
 and tipofactura = '" & tipofac & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function buscarCobro(ByVal idcobro) As DataSet
        Dim da As New SqlDataAdapter("select * from cobros  where esanulacion=0 and anulado=0 and idCobro= " & idcobro & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Sub modificarCobroANUladoCOBRO(ByVal idcobro As Integer)
        Dim sel As String

        Try
            sel = "update cobros set anulado =1
                where idcobro=" & idcobro & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function buscarfechacobro(ByVal fechadesde As String, ByVal fechahasta As String) As DataSet
        Dim da As New SqlDataAdapter("Select c.fecha, (case when c.tipoComprobante Like 'F_' then ((case when c.esAnulacion=0 then 'Cobro de Comprobante ' else 'Anulacion de Cobro por Comprobante 'end)+v.tipoFactura +' '+ substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13) )else
 ('Devolución por Comprobante '+v.tipoFactura +' '+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 0,6)+'-'+substring( (right(replicate ('0',13)+(cast (v.numFactura as varchar)), 13)), 6,13)) end),
 (case when c.total>0 then c.total else 0 end) as 'Ingreso',(case when c.total<0 then c.total else 0 end) as 'Egreso', idCobro 
 From cobros c
 inner Join ventas v on v.tipoFactura= c.tipoComprobante And v.numFactura=c.numcomprobante
where c.fecha between '" & fechadesde & "' and '" & fechahasta & "'
 order by c.fecha", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
End Class
