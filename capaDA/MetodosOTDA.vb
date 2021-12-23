Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosOTDA
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
    Public Function InsertaOT(ByVal Ot As ClaseOrdenDeTRabajo) As Integer
        Dim sel As String

        sel = "insert into OrdenDeTRabajo (NumDocCl, fecha, MotivoConsulta, DispositivoRep, Cargador, Bateria, Funda, Maletin, Cables, IdEstadoOT, activa) values (@NumDocCl, @fecha, @MotivoConsulta, @DispositivoRep, @Cargador, @Bateria, @Funda, @Maletin, @Cables, @IdEstadoOT, @activa) SELECT SCOPE_IDENTITY()"

        com.Parameters.AddWithValue("@NumDocCl", Ot.NumDocCL)
        com.Parameters.AddWithValue("@fecha", Ot.Fecha)
        com.Parameters.AddWithValue("@MotivoConsulta", Ot.MotivoCon)
        com.Parameters.AddWithValue("@DispositivoRep", Ot.DispositARep)
        com.Parameters.AddWithValue("@Cargador", Ot.Cargador)
        com.Parameters.AddWithValue("@Bateria", Ot.Bateria)
        com.Parameters.AddWithValue("@Funda", Ot.Funda)
        com.Parameters.AddWithValue("@Maletin", Ot.Maletin)
        com.Parameters.AddWithValue("@Cables", Ot.Cables)
        com.Parameters.AddWithValue("@IdEstadoOT", Ot.IdEstadoOT)
        com.Parameters.AddWithValue("@activa", Ot.activa)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Sub InsertarEstadoOT(ByVal EstadoOt As ClaseEstadoOT)
        Dim sel As String
        Try
            sel = "insert into EstadoOT (EstadoOT )values ('" & EstadoOt.EstadoOT & "')"

            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function BuscarIDCliente(ByVal idCliente) As DataSet

        Dim da As New SqlDataAdapter("select c.FecIng as 'Fecha de Ingreso', c.Apellido, c.Nombre, o.TipoDoc as 'Tipo de Dni', o.NumDoc as 'Numero Doc', c.TelFij, c.Celular, c.Email " &
        " from Cliente c " &
        " inner join Direccion d on" &
        " c.IdCliente = d.idCliente" &
        " inner join Documento o on" &
        " o.IdCliente = c.IdCliente" &
        " where o.NumDoc = '" & idCliente & "'", con)

        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrilla() As DataSet
        Dim da As New SqlDataAdapter("select o.idOrdenTrab as 'N° de Orden de Trabajo', o.fecha as 'Fecha Ingreso', c.Apellido + ' '+ c.Nombre  as 'Cliente', 
d.NumDoc as 'N° de Documento', o.DispositivoRep as 'Dispositivo', e.EstadoOT 
 from OrdenDeTRabajo o inner join EstadoOT e on o.IdEstadoOT = e.idEstadoOT inner join Documento  d
 on d.NumDoc  = o.NumDocCl inner join Cliente c
 on c.IdCliente = d.IdCliente 
 where o.idOrdenTrab<>0
 order by o.fecha, Cliente ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIDordT(ByVal OT) As DataSet

        Dim da As New SqlDataAdapter("select * from OrdenDeTRabajo where idOrdenTrab = " & "'" & OT & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaApellido(ByVal fechadesde As String, ByVal fechahasta As String, ByVal numOT As String, ByVal idestadoOT As String, ByVal cliente As String) As DataSet

        Dim sql As String = "select o.idOrdenTrab as 'N° de Orden de Trabajo', o.fecha as 'Fecha Ingreso', c.Apellido + ' '+ c.Nombre  as 'Cliente', 
d.NumDoc as 'N° de Documento', o.DispositivoRep as 'Dispositivo', e.EstadoOT 
 from OrdenDeTRabajo o inner join EstadoOT e on o.IdEstadoOT = e.idEstadoOT inner join Documento  d
 on d.NumDoc  = o.NumDocCl inner join Cliente c
 on c.IdCliente = d.IdCliente 
 where o.idOrdenTrab<>0 "
        If fechadesde <> "" And fechahasta <> "" Then
            sql = sql & " and o.fecha between '" & fechadesde & "' and '" & fechahasta & "' "
        End If

        If numOT <> "" Then
            sql = sql & "and  o.idOrdenTrab=" & numOT & ""
        End If
        If idestadoOT <> "" Then
            sql = sql & "and  o.IdEstadoOT = " & idestadoOT & ""
        End If
        If cliente <> "0" Then
            sql = sql & " and (c.Apellido + ' '+ c.Nombre) like '%" & cliente & "%'"
        End If
        sql = sql & "order by o.fecha, Cliente"

        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaApellidoEsperand(ByVal Apellido As String) As DataSet

        Dim da As New SqlDataAdapter(" select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', 
   o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT, o.AlertEntrEquip
from OrdenDeTRabajo o
inner join EstadoOT e
on o.IdEstadoOT = e.idEstadoOT 
inner join Documento  d
on d.NumDoc  = o.NumDocCl 
inner join Cliente c
on c.IdCliente = d.IdCliente" &
" where c.Apellido like " & " '" & Apellido & "%'" &
" and e.EstadoOT = 'Esperando al Cliente' " &
        " order by o.fecha ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaNumOT(ByVal NumOT As String) As DataSet

        Dim da As New SqlDataAdapter("select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT " &
" from OrdenDeTRabajo o" &
" inner join EstadoOT e" &
" on o.IdEstadoOT = e.idEstadoOT " &
" inner join Documento  d" &
" on d.NumDoc  = o.NumDocCl " &
" inner join Cliente c" &
" on c.IdCliente = d.IdCliente" &
" where idOrdenTrab = " & " '" & NumOT & "'" &
        " order by idOrdenTrab ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaNumOTEsperand(ByVal NumOT As String) As DataSet

        Dim da As New SqlDataAdapter("select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', 
   o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT, o.AlertEntrEquip
from OrdenDeTRabajo o
inner join EstadoOT e
on o.IdEstadoOT = e.idEstadoOT 
inner join Documento  d
on d.NumDoc  = o.NumDocCl 
inner join Cliente c
on c.IdCliente = d.IdCliente" &
" where idOrdenTrab = " & " '" & NumOT & "'" &
" and e.EstadoOT = 'Esperando al Cliente' " &
        " order by o.fecha ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaFecha(ByVal fecha1 As Date, ByVal fecha2 As Date) As DataSet

        Dim da As New SqlDataAdapter("select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT" &
" from OrdenDeTRabajo o" &
" inner join EstadoOT e" &
" on o.IdEstadoOT = e.idEstadoOT" &
" inner join Documento  d" &
" on d.NumDoc  = o.NumDocCl " &
" inner join Cliente c" &
" on c.IdCliente = d.IdCliente" &
" WHERE o.fecha BETWEEN '" & fecha1 & "' AND '" & fecha2 & "' ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaFechaEsperand(ByVal fecha1 As String, ByVal fecha2 As String) As DataSet

        Dim da As New SqlDataAdapter("select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', 
   o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT, o.AlertEntrEquip
from OrdenDeTRabajo o
inner join EstadoOT e
on o.IdEstadoOT = e.idEstadoOT 
inner join Documento  d
on d.NumDoc  = o.NumDocCl 
inner join Cliente c
on c.IdCliente = d.IdCliente" &
" and e.EstadoOT = 'Esperando al Cliente' " &
" WHERE fecha BETWEEN '" & fecha1 & "' AND '" & fecha2 & "' ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIDEstadoOT(ByVal EsOT) As DataSet

        Dim da As New SqlDataAdapter("select * from EstadoOT where idEstadoOT = " & "'" & EsOT & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function cargarComboEstadoOt() As DataSet 'DataTable
        da = New SqlDataAdapter("select * from EstadoOT ", con)
        ds = New DataSet
        dt = New DataTable
        Try
            da.Fill(ds, "tabCat")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Sub modificarEstadoOT(ByVal EstOT As ClaseOrdenDeTRabajo)
        Dim sel As String

        Try
            sel = "set dateformat dmy update OrdenDeTRabajo set IdEstadoOT = '" & EstOT.IdEstadoOT & "'" & _
                "where idOrdenTrab = '" & EstOT.idOrdenTRab & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function InsertaCAmbioEstOT(ByVal CbiEstOt As ClaseCambioEstadOT) As Integer
        Dim sel As String

        sel = "insert into CambioEstOT (idOT, idEstadoOT, Observaciones, fechaCbioEstOT) values (@idOT, @idEstadoOT, @Observaciones, @fechaCbioEstOT) SELECT SCOPE_IDENTITY()"

        com.Parameters.AddWithValue("@idOT", CbiEstOt.idOT)
        com.Parameters.AddWithValue("@idEstadoOT", CbiEstOt.idEstadoOT)
        com.Parameters.AddWithValue("@Observaciones", CbiEstOt.Observaciones)
        com.Parameters.AddWithValue("@fechaCbioEstOT", CbiEstOt.fechaCmbioEstOT)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Function CargarGrillaCbioEstOT(ByVal NumOT As String) As DataSet
        Dim da As New SqlDataAdapter("select fechaCbioEstOT as 'Fecha', e.EstadoOT as 'Estado' , c.Observaciones   " & _
"from CambioEstOT  c " & _
"inner join OrdenDeTRabajo o " & _
"on o.idOrdenTrab = c.idOT  " & _
"inner join EstadoOT e " & _
"on e.idEstadoOT = c.idEstadoOT " & _
"where o.idOrdenTrab = " & " '" & NumOT & "'" & _
"order by c.fechaCbioEstOT", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaEsperCliente() As DataSet
        Dim da As New SqlDataAdapter("   select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', 
   o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT, o.AlertEntrEquip
from OrdenDeTRabajo o
inner join EstadoOT e
on o.IdEstadoOT = e.idEstadoOT 
inner join Documento  d
on d.NumDoc  = o.NumDocCl 
inner join Cliente c
on c.IdCliente = d.IdCliente
where e.idEstadoOT = 4 ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarEmail(ByVal idORd) As DataSet

        Dim da As New SqlDataAdapter("select c.Email  from OrdenDeTRabajo o" & _
" inner join Documento  d" & _
" on d.NumDoc  = o.NumDocCl " & _
" inner join Cliente c" & _
" on c.IdCliente = d.IdCliente" & _
" where o.idOrdenTrab = " & "'" & idORd & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarAlerta(ByVal Alerta As ClaseOrdenDeTRabajo)
        Dim sel As String
        Try
            sel = "set dateformat dmy update OrdenDeTRabajo set AlertEntrEquip = '" & Alerta.AlertEntrEquip & "'" & _
                "where idOrdenTrab = '" & Alerta.idOrdenTRab & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function CargarGrillaApellidoFecha(ByVal Apellido As String, ByVal fecha1 As Date, ByVal fecha2 As Date) As DataSet

        Dim da As New SqlDataAdapter("select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT " & _
" from OrdenDeTRabajo o" & _
" inner join EstadoOT e" & _
" on o.IdEstadoOT = e.idEstadoOT " & _
" inner join Documento  d" & _
" on d.NumDoc  = o.NumDocCl " & _
" inner join Cliente c" & _
" on c.IdCliente = d.IdCliente" & _
" where c.Apellido like " & " '" & Apellido & "%'" & _
" and fecha BETWEEN '" & fecha1 & "' AND '" & fecha2 & "'" & _
        " order by o.fecha ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaNroOrdenFecha(ByVal NroOrden As Integer, ByVal fecha1 As Date, ByVal fecha2 As Date) As DataSet

        Dim da As New SqlDataAdapter("select o.idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT " & _
" from OrdenDeTRabajo o" & _
" inner join EstadoOT e" & _
" on o.IdEstadoOT = e.idEstadoOT " & _
" inner join Documento  d" & _
" on d.NumDoc  = o.NumDocCl " & _
" inner join Cliente c" & _
" on c.IdCliente = d.IdCliente" & _
" where o.idOrdenTrab like " & " '" & NroOrden & "%'" & _
" and fecha BETWEEN '" & fecha1 & "' AND '" & fecha2 & "'" & _
        " order by o.fecha ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaNroOrdenFechaEsperand(ByVal NroOrden As Integer, ByVal fecha1 As String, ByVal fecha2 As String) As DataSet

        Dim da As New SqlDataAdapter("select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', 
   o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT, o.AlertEntrEquip
from OrdenDeTRabajo o
inner join EstadoOT e
on o.IdEstadoOT = e.idEstadoOT 
inner join Documento  d
on d.NumDoc  = o.NumDocCl 
inner join Cliente c
on c.IdCliente = d.IdCliente" &
" where o.idOrdenTrab like " & " '" & NroOrden & "%'" &
" and fecha BETWEEN '" & fecha1 & "' AND '" & fecha2 & "'" &
" and e.EstadoOT = 'Esperando al Cliente' " &
        " order by o.fecha ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaApellidoFechaEsperand(ByVal Apellido As String, ByVal fecha1 As String, ByVal fecha2 As String) As DataSet

        Dim da As New SqlDataAdapter(" select idOrdenTrab as 'N° de Orden de Trabajo', c.Apellido + ' '+ c.Nombre  as 'Cliente', d.NumDoc as 'N° de Documento', 
   o.fecha as 'Fecha Ingreso', o.DispositivoRep as 'Dispositivo', e.EstadoOT, o.AlertEntrEquip
from OrdenDeTRabajo o
inner join EstadoOT e
on o.IdEstadoOT = e.idEstadoOT 
inner join Documento  d
on d.NumDoc  = o.NumDocCl 
inner join Cliente c
on c.IdCliente = d.IdCliente" &
" where c.Apellido like " & " '" & Apellido & "%'" &
" and o.fecha BETWEEN '" & fecha1 & "' AND '" & fecha2 & "'" &
" and e.idEstadoOT = 4 " &
        " order by o.fecha ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarModifConfigEMAIL(ByVal email As ClaseEmail)
        Dim cmd As New SqlCommand
        Try

            cmd = New SqlCommand("ConfiguracionMAilproced", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@mail", email.mail)
            cmd.Parameters.AddWithValue("@contrasena", email.contrasena)
            cmd.Parameters.AddWithValue("@smtp", email.smtp)
            cmd.Parameters.AddWithValue("@Puerto", email.puerto)
            'Dim ds As New DataSet
            'Dim dr As SqlDataReader
            cmd.ExecuteNonQuery()
            'If dr.HasRows = True Then
            '    Return True
            'Else
            '    Return False
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally

        End Try
        'Return ds
    End Function
    Public Function cargarconfiguraciones() As DataSet 'DataTable
        da = New SqlDataAdapter("select * from configuracionmail ", con)
        ds = New DataSet
        'dt = New DataTable
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function InsertaVinculoOT(ByVal vinculo As ClaseVinculo) As Integer
        Dim sel As String

        sel = "insert into Vinculos (TipoComprobante, numerocomprobante, TipoComAsociado, numeroComAsociado, activo) values (@TipoComprobante, @numerocomprobante, @TipoComAsociado, @numeroComAsociado, @activo) "

        com.Parameters.AddWithValue("@TipoComprobante", vinculo.TipoComprobante)
        com.Parameters.AddWithValue("@numerocomprobante", vinculo.numerocomprobante)
        com.Parameters.AddWithValue("@TipoComAsociado", vinculo.TipoComAsociado)
        com.Parameters.AddWithValue("@numeroComAsociado", vinculo.numeroComAsociado)
        com.Parameters.AddWithValue("@activo", vinculo.activo)
        'om.Parameters.AddWithValue("@fecha", vinculo.fecha)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Function BuscarPresupuesto(ByVal idPresupuesto) As DataSet

        Dim da As New SqlDataAdapter("select c.Email  from OrdenDeTRabajo o" &
" inner join Documento  d" &
" on d.NumDoc  = o.NumDocCl " &
" inner join Cliente c" &
" on c.IdCliente = d.IdCliente" &
" where o.idOrdenTrab = " & "'" & idPresupuesto & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarPresupuestoVinculoOT(ByVal idOt As Integer) As DataSet
        Dim da As New SqlDataAdapter("    select cl.Apellido, cl.Nombre, pr.idPresupuesto, pr.total,d.NumDoc, pr.fechaingreso, pr.anulado from vinculos v
  inner join presupuestos pr on pr.idPresupuesto=v.numerocomprobante 
  and pr.tipoComprobante=v.tipocomprobante
  inner join Documento d on d.NumDoc=pr.codigocliente
  inner join Cliente cl on cl.IdCliente=d.IdCliente where v.TipoComAsociado='OT' and  v.activo=1
    and v.NumeroComAsociado=" & idOt & "
    group by cl.Apellido, cl.Nombre, pr.idPresupuesto, pr.total,d.NumDoc, pr.fechaingreso, pr.anulado ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function
    Public Function CargarItemVinculoOT(ByVal idPR As Integer) As DataSet
        Dim da As New SqlDataAdapter(" select  (case when i.esArticulo=0 then ar.descripcion else ls.DescripcionServicio end) as Detalle, i.cantidad as Cantidad, i.precio as Precio, (i.cantidad * i.precio) as Total,
  (case when i.esArticulo=0 then ar.idArticulo else ls.idServicio end) as Codigo, (case when i.esArticulo=0 then 'Articulo' else 'Servicio'end) as Tipo, idarticulo, i.CodigoArticuloServicio
  from itemPR i
   left join Articulos ar on ar.idArticulo=i.CodigoArticuloServicio
  left join ListaServicios ls on ls.idServicio=i.CodigoArticuloServicio
  where i.idPresupuesto=" & idPR & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function
    Public Function vinculoPROT(ByVal idOT As Integer) As DataSet
        Dim da As New SqlDataAdapter("  select ((case when v.TipoComprobante='PR' then 'Presupuesto' else v.TipoComprobante end)  +' '+ cast (v.numerocomprobante as varchar)) as comprobante
 from Vinculos v where v.TipoComAsociado='OT' 	and v.activo=1
 and v.numeroComAsociado=" & idOT & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar artículo")
        End Try
        Return ds
    End Function

    Public Function estadoEntregar() As DataSet
        Dim da As New SqlDataAdapter("  Select count(*) from OrdenDeTRabajo where IdEstadoOT=4", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function


End Class
