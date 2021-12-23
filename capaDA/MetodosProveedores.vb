Imports System.Data.SqlClient
Imports CapaNE
Public Class MetodosProveedores
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
        Dim da As New SqlDataAdapter("select p.IdCuit  as 'CUIT', p.NomRaz 'Nombre/Razón Social', d.Pais, d.Provincia, p.Celular as 'Contacto', p.idProv" & _
" from Proveedores  p" & _
" inner join Direccion d on" & _
" p.idProv = d.idProv" & _
" order by p.NomRaz", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function InsertarProveedor(ByVal prov As ClaseProveedor) As Integer
        Dim sel As String

        sel = "insert into Proveedores (IdCuit, NomRaz ,TelFijo , Celular , Email ) values (@IdCuit, @NomRaz, @TelFijo, @Celular, @Email) SELECT SCOPE_IDENTITY()"

        com.Parameters.AddWithValue("@IdCuit", prov.IdCuit)
        com.Parameters.AddWithValue("@NomRaz", prov.NomRaz)
        com.Parameters.AddWithValue("@TelFijo", prov.TelFijo)
        com.Parameters.AddWithValue("@Celular", prov.telCelular)
        com.Parameters.AddWithValue("@Email", prov.Email)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Sub InsertarDireccion(ByVal dire As ClaseDireccion)
        Dim sel As String
        Try
            sel = "insert into Direccion (idProv , Pais , Provincia , Ciudad , Barrio , Calle , NumCalle ,Piso , Dpto ) values ('" & dire.IdProv & "','" & dire.Pais & "','" & dire.Provincia & "','" & dire.Ciudad & "','" & dire.Barrio & "','" & dire.Calle & "','" & dire.NumCalle & "', '" & dire.Piso & "','" & dire.Dpto & "')"

            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function BuscarIDProveedor(ByVal idProv) As DataSet

        Dim da As New SqlDataAdapter("select * from Proveedores where idProv= " & "'" & idProv & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIDDire(ByVal idProv) As DataSet

        Dim da As New SqlDataAdapter("select * from Direccion where idProv= " & "'" & idProv & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarProv(ByVal Prov As ClaseProveedor)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Proveedores set NomRaz = '" & Prov.NomRaz & "'," & _
                "IdCuit = '" & Prov.IdCuit & "'," & _
                "TelFijo = '" & Prov.TelFijo & "'," & _
                "Celular = '" & Prov.telCelular & "'," & _
                "Email = '" & Prov.Email & "'" & _
                "where idProv = '" & Prov.idProv & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarDireProv(ByVal Dire As ClaseDireccion)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Direccion set Pais = '" & Dire.Pais & "'," & _
                "Provincia = '" & Dire.Provincia & "'," & _
                "Ciudad = '" & Dire.Ciudad & "'," & _
                "Barrio = '" & Dire.Barrio & "'," & _
                "Calle = '" & Dire.Calle & "'," & _
                "NumCalle = '" & Dire.NumCalle & "'," & _
                "Piso = '" & Dire.Piso & "'," & _
                "Dpto = '" & Dire.Dpto & "'" & _
                "where idProv = '" & Dire.IdProv & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function CargarGrillaIdCuit(ByVal idCuit As String) As DataSet

        Dim da As New SqlDataAdapter("select p.IdCuit  as 'CUIT', p.NomRaz 'Nombre/Razón Social', d.Pais, d.Provincia, p.Celular as 'Contacto', p.idProv" & _
" from Proveedores  p" & _
" inner join Direccion d on" & _
" p.idProv = d.idProv" & _
" where p.IdCuit = " & " '" & idCuit & "'" & _
" order by p.NomRaz", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarGrillaNomRaz(ByVal NomRaz As String) As DataSet

        Dim da As New SqlDataAdapter("select p.IdCuit  as 'CUIT', p.NomRaz 'Nombre/Razón Social', d.Pais, d.Provincia, p.Celular as 'Contacto', p.idProv" &
" from Proveedores  p" &
" inner join Direccion d on" &
" p.idProv = d.idProv" &
" where p.NomRaz LIKE " & " '" & NomRaz & "%'" &
" order by p.NomRaz", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarCUIT(ByVal idcuit) As DataSet

        Dim da As New SqlDataAdapter("select * from Proveedores where idCuit= " & "'" & idcuit & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
End Class
