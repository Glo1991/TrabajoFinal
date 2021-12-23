Imports System.Data
Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosPuntoVentaDA
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
        Dim da As New SqlDataAdapter("select right(replicate ('0',5)+(cast (PuntodeVenta as varchar)), 5)  as 'NUMERO DE PUNTO DE VENTA', 
 (case when activo=1 then 'SI' else 'NO' end) as 'ACTIVO', (case when porDefecto=1 then 'SI' else 'NO' end) as 'POR DEFECTO'
 from PuntoVenta", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Sub modificarPtoVenta(ByVal ptoventa As ClasePutoVenta)
        Dim sel As String

        Try
            sel = "update PuntoVenta set activo = " & ptoventa.activo & ",
                pordefecto= " & ptoventa.Pordefecto & "
                where PuntodeVenta = " & ptoventa.puntoVenta & ""
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function InsertarPuntoVenta(ByVal ptoventa As ClasePutoVenta) As Integer
        Dim insert As String
        insert = "insert into PuntoVenta ( PuntodeVenta,pordefecto, activo)" &
        " values (@PuntodeVenta, @pordefecto, 1 ) SELECT SCOPE_IDENTITY()"
        com.Parameters.AddWithValue("@PuntodeVenta", ptoventa.puntoVenta)
        com.Parameters.AddWithValue("@pordefecto", ptoventa.Pordefecto)
        'com.Parameters.AddWithValue("@activo", ptoventa.activo)


        com.CommandText = insert
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Artículo")
        End Try
        Return t
    End Function
    Public Function seleccionarPtoVenta(ByVal pto As String) As DataSet
        Dim da As New SqlDataAdapter("select right(replicate ('0',5)+(cast (PuntodeVenta as varchar)), 5)  as 'Numero de punto de Venta', 
(case when porDefecto=1 then 'SI' else 'NO' end) as 'Por Defecto', (case when activo=1 then 'SI' else 'NO' end) as 'ACTIVO'
 from PuntoVenta where PuntodeVenta=" & pto & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function buscarPtoVenta(ByVal pto As String) As DataSet
        Dim da As New SqlDataAdapter("select *
 from PuntoVenta where PuntodeVenta=" & pto & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function puntoporDefecto() As DataSet
        Dim da As New SqlDataAdapter("select right(replicate ('0',5)+(cast (PuntodeVenta as varchar)), 5)  as 'Numero de punto de Venta', 
(case when porDefecto=1 then 'SI' else 'NO' end) as 'Por Defecto', (case when activo=1 then 'SI' else 'NO' end) as 'ACTIVO'
 from PuntoVenta where porDefecto=1", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function puntoActivo() As DataSet
        Dim da As New SqlDataAdapter("select right(replicate ('0',5)+(cast (PuntodeVenta as varchar)), 5)  as 'Numero de punto de Venta', 
(case when porDefecto=1 then 'SI' else 'NO' end) as 'Por Defecto', (case when activo=1 then 'SI' else 'NO' end) as 'ACTIVO'
 from PuntoVenta where activo=1", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function MAXnumFactptoxdef() As DataSet
        Dim da As New SqlDataAdapter("select right(replicate ('0',13)+ cast(((case when max(v.numFactura) is null then ((cast((select p.PuntodeVenta from PuntoVenta p where p.porDefecto=1) as varchar))+ replicate ('0',8) +1)
else (max(v.numFactura)+1)end)) as varchar), 13) as 'numfactura' 
from ventas v where
v.anulada=0 
and numFactura between (cast((select p.PuntodeVenta from PuntoVenta p where p.porDefecto=1) as varchar))+ replicate ('0',8) 
and (cast((select p.PuntodeVenta from PuntoVenta p where p.porDefecto=1) as varchar))+ replicate ('9',8)", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function MAXnumFactpto() As DataSet
        Dim da As New SqlDataAdapter("
select right(replicate ('0',13)+ cast(((case when max(v.numFactura) is null then ((cast((select top 1 PuntodeVenta from PuntoVenta where activo=1) as varchar))+ replicate ('0',8) +1)
else (max(v.numFactura)+1)end)) as varchar), 13) as 'numfactura' 
from ventas v where
v.anulada=0 
and numFactura between (cast((select p.PuntodeVenta from PuntoVenta p where p.porDefecto=1) as varchar))+ replicate ('0',8) 
and (cast((select p.PuntodeVenta from PuntoVenta p where p.porDefecto=1) as varchar))+ replicate ('9',8)", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function PuntoVentaValido() As DataSet
        Dim da As New SqlDataAdapter("select  left((cast (PuntodeVenta as varchar)+replicate ('0',8)), 13) as'DESDE', 
left((cast (PuntodeVenta as varchar)+replicate ('9',8)), 13) as 'Hasta'
from PuntoVenta where activo=1", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function

End Class
