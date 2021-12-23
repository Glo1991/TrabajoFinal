Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosClientesDA
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
    Public Function InsertarCliente(ByVal alum As ClaseCliente) As Integer
        Dim sel As String

        sel = "insert into Cliente (Nombre, Apellido ,FecNac , FecIng , TelFij , Celular , Email, Edad ) values (@Nombre, @Apellido, @FechaNac, @FechaIng, @TelFijo, @TelCelu, @Email, @Edad) SELECT SCOPE_IDENTITY()"

        com.Parameters.AddWithValue("@Nombre", alum.NomAlum)
        com.Parameters.AddWithValue("@Apellido", alum.ApellAlum)
        com.Parameters.AddWithValue("@FechaNac", alum.FechaNac)
        com.Parameters.AddWithValue("@FechaIng", alum.FechaIngreso)
        com.Parameters.AddWithValue("@TelFijo", alum.TelFijo)
        com.Parameters.AddWithValue("@TelCelu", alum.telCelular)
        com.Parameters.AddWithValue("@Email", alum.Email)
        com.Parameters.AddWithValue("@Edad", alum.EdadAlum)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Sub InsertarDocumCliente(ByVal doc As ClaseDocumento)
        Dim sel As String
        Try
            sel = "set dateformat dmy insert into Documento (IdCliente , TipoDoc , NumDoc ) values ('" & doc.IDCliente & "','" & doc.TipoDoc & "','" & doc.NumDoc & "')"

            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub InsertarDireccion(ByVal dire As ClaseDireccion)
        Dim sel As String
        Try
            sel = "insert into Direccion (idCliente , Pais , Provincia , Ciudad , Barrio , Calle , NumCalle ,Piso , Dpto , Lote , Manzana ) values ('" & dire.IdCliente & "','" & dire.Pais & "','" & dire.Provincia & "','" & dire.Ciudad & "','" & dire.Barrio & "','" & dire.Calle & "','" & dire.NumCalle & "', '" & dire.Piso & "','" & dire.Dpto & "','" & dire.Lote & "','" & dire.Manzana & "')"

            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function CargarGrilla() As DataSet
        Dim da As New SqlDataAdapter("select c.FecIng as 'Fecha de Ingreso', c.Apellido, c.Nombre, o.TipoDoc as 'Tipo de Dni', o.NumDoc as 'Numero Doc', d.Pais, c.FecNac as 'Fecha de Nacimiento', c.IdCliente " & _
                                    " from Cliente c " & _
                                    " inner join Direccion d on" & _
                                    " c.IdCliente = d.idCliente" & _
                                    " inner join Documento o on" & _
                                    " o.IdCliente = c.IdCliente" & _
                                    " order by c.Apellido ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIDCliente(ByVal idCliente) As DataSet

        Dim da As New SqlDataAdapter("select * from Cliente where IdCliente= " & "'" & idCliente & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaDoc(ByVal documento As String, ByVal tipoDoc As String) As DataSet

        Dim da As New SqlDataAdapter("select c.FecIng as 'Fecha de Ingreso', c.Apellido, c.Nombre, o.TipoDoc as 'Tipo de Dni', o.NumDoc as 'Numero Doc', d.Pais, c.FecNac as 'Fecha de Nacimiento', c.IdCliente" & _
                                    " from Cliente c " & _
                                    " inner join Direccion d on" & _
                                    " c.IdCliente = d.idCliente" & _
                                    " inner join Documento o on" & _
                                    " o.IdCliente = c.IdCliente" & _
        " where o.NumDoc = " & " '" & documento & "'" & _
        " and o.TipoDoc = " & "'" & tipoDoc & "'" & _
        "order by c.Apellido ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaApellido(ByVal Apellido As String) As DataSet

        Dim da As New SqlDataAdapter("select c.FecIng as 'Fecha de Ingreso', c.Apellido, c.Nombre, o.TipoDoc as 'Tipo de Dni', o.NumDoc as 'Numero Doc', d.Pais, c.FecNac as 'Fecha de Nacimiento', c.IdCliente" & _
                                    " from Cliente c " & _
                                    " inner join Direccion d on" & _
                                    " c.IdCliente = d.idCliente" & _
                                    " inner join Documento o on" & _
                                    " o.IdCliente = c.IdCliente " & _
        " where c.Apellido like " & "'" & Apellido & "%'" & _
        " order by c.Apellido ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function

    Public Function BuscarIDDoc(ByVal idCliente) As DataSet

        Dim da As New SqlDataAdapter("select * from Documento where IdCliente= " & "'" & idCliente & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIDDire(ByVal idCliente) As DataSet

        Dim da As New SqlDataAdapter("select * from Direccion where idCliente= " & "'" & idCliente & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarCliente(ByVal Cliente As ClaseCliente)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Cliente set Nombre = '" & Cliente.NomAlum & "'," & _
                "Apellido = '" & Cliente.ApellAlum & "'," & _
                "FecNac = '" & Cliente.FechaNac & "'," & _
                "FecIng = '" & Cliente.FechaIngreso & "'," & _
                "TelFij = '" & Cliente.TelFijo & "'," & _
                "Celular = '" & Cliente.telCelular & "'," & _
                "Email = '" & Cliente.Email & "'," & _
                "Edad = '" & Cliente.EdadAlum & "'" & _
                "where IdCliente = '" & Cliente.IdCliente & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarDocCliennte(ByVal doc As ClaseDocumento)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Documento set TipoDoc = '" & doc.TipoDoc & "'," & _
                "NumDoc = '" & doc.NumDoc & "'" & _
                "where IdCliente = '" & doc.IDCliente & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub modificarDireCliente(ByVal Dire As ClaseDireccion)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Direccion set Pais = '" & Dire.Pais & "'," &
                "Provincia = '" & Dire.Provincia & "'," &
                "Ciudad = '" & Dire.Ciudad & "'," &
                "Barrio = '" & Dire.Barrio & "'," &
                "Calle = '" & Dire.Calle & "'," &
                "NumCalle = '" & Dire.NumCalle & "'," &
                "Piso = '" & Dire.Piso & "'," &
                "Dpto = '" & Dire.Dpto & "'," &
                "Lote = '" & Dire.Lote & "'," &
                "Manzana = '" & Dire.Manzana & "'" &
                "where IdCliente = '" & Dire.IdCliente & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function BuscarDoc(ByVal doc) As DataSet

        Dim da As New SqlDataAdapter("select * from Documento where NumDoc= " & doc & "", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
End Class
