Imports System.Data.SqlClient
Imports CapaNe
Public Class MEtodosUsuariosDA
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

    Public Function InsertarUsuario(ByVal usuar As ClaseUsuariosNE) As Integer
        Dim sel As String

        sel = "insert into Usuarios (IdUsuario ,Pass , Nombre, Apellido, TipoUsuario, idEstado)values (@id, @Pass, @Nombre, @apellido, @tipousuar, @idEstado)  SELECT SCOPE_IDENTITY()"

        com.Parameters.AddWithValue("@id", usuar.NomUsuario)
        com.Parameters.AddWithValue("@Pass", usuar.PAss)
        com.Parameters.AddWithValue("@Nombre", usuar.Nombre)
        com.Parameters.AddWithValue("@apellido", usuar.Apellido)
        com.Parameters.AddWithValue("@tipousuar", usuar.TipoUsuario)
        com.Parameters.AddWithValue("@idEstado", usuar.IdUsuario)
        com.CommandText = sel
        Dim t As Integer
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return t
    End Function
    Public Sub InsertarDocumUsuario(ByVal doc As ClaseDocumento)
        Dim sel As String
        Try
            sel = "set dateformat dmy insert into Documento (IdUsuario , TipoDoc , NumDoc ) values ('" & doc.IdUSuario & "','" & doc.TipoDoc & "','" & doc.NumDoc & "')"

            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function CargarGrilla() As DataSet
        Dim da As New SqlDataAdapter("select u.IdUsuario as Usuario,u.TipoUsuario as 'Tipo de Usuario', u.Apellido + ' '+ u.Nombre as 'Apellido y Nombre'," & _
      " d.TipoDoc as 'Tipo de Documento'," & _
      " d.NumDoc as 'Numero de Documento',ID, e.Estado, e.idEstado " & _
      " from Usuarios u " & _
      " inner join Documento d " & _
      "on u.IdUsuario = d.IdUsuario inner join estado e on e.idEstado = u.idEstado order by u.IdUsuario ", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub BorrarUsuarios(ByVal usuar As ClaseUsuariosNE)

        Dim sel As String
        Try
            sel = "delete from Usuarios where Id= @id"
            com.CommandText = sel

            com.Parameters.AddWithValue("@id", usuar.IdUsuario)
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        con.Close()

    End Sub
    'corregido
    Public Function CargarGrillaDoc(ByVal documento As String, ByVal tipoDoc As String) As DataSet

        Dim da As New SqlDataAdapter("select u.IdUsuario as Usuario, u.TipoUsuario as 'Tipo de Usuario',  u.Apellido + ' '+ u.Nombre as 'Apellido y Nombre', " & _
    " d.TipoDoc as 'Tipo de Documento'," & _
    " d.NumDoc as 'Numero de Documento', u.ID, e.Estado, e.idEstado " & _
    " from Usuarios u " & _
    " inner join Documento d on " & _
       " u.IdUsuario = d.IdUsuario inner join estado e on e.idEstado = u.idEstado " & _
        " where d.NumDoc = " & " '" & documento & "'" & _
        " and d.TipoDoc = " & "'" & tipoDoc & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    'corregido
    Public Function CargarGrillaUsuario(ByVal usuario As String) As DataSet

        Dim da As New SqlDataAdapter("select u.IdUsuario as Usuario, u.TipoUsuario as 'Tipo de Usuario',  u.Apellido + ' '+ u.Nombre as 'Apellido y Nombre', " & _
    " d.TipoDoc as 'Tipo de Documento'," & _
    " d.NumDoc as 'Numero de Documento', u.ID, e.Estado, e.idEstado " & _
    " from Usuarios u " & _
    " inner join Documento d on " & _
       " u.IdUsuario = d.IdUsuario inner join estado e on e.idEstado = u.idEstado " & _
        " where u.IdUsuario = " & " '" & usuario & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIDUsuar(ByVal idusuar) As DataSet

        Dim da As New SqlDataAdapter("select * from Usuarios where id= " & "'" & idusuar & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIDDoc(ByVal idusuario) As DataSet

        Dim da As New SqlDataAdapter("select * from Documento where IdUsuario= " & "'" & idusuario & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function BuscarIDEsado(ByVal idEstado) As DataSet

        Dim da As New SqlDataAdapter("select * from Estado where idEstado= " & "'" & idEstado & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Sub modificarUsuario(ByVal usuar As ClaseUsuariosNE)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Usuarios set IdUsuario = '" & usuar.NomUsuario & "'," & _
                "Apellido = '" & usuar.Apellido & "'," & _
                "Nombre = '" & usuar.Nombre & "'," & _
                "TipoUsuario = '" & usuar.TipoUsuario & "'," & _
                "Pass = '" & usuar.PAss & "'" & _
                "where ID = '" & usuar.IdUsuario & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub modificarDocUsuar(ByVal doc As ClaseDocumento)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Documento set TipoDoc = '" & doc.TipoDoc & "'," & _
                "NumDoc = '" & doc.NumDoc & "'" & _
                "where IdUsuario = '" & doc.IdUSuario & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Function Validarusuar(ByVal usuar As ClaseUsuariosNE)
        Dim da As New SqlDataAdapter("select * from usuarios where IdUsuario='" & usuar.NomUsuario & "' and pass='" & usuar.PAss & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Finally
        End Try
        'Return ds

        'Dim cmd As New SqlCommand
        'Try
        '    Dim dr As SqlDataReader
        '    'dr = Nothing
        '    cmd = New SqlCommand("select * from usuarios where IdUsuario='" & usuar.IdUsuario & "' and pass='" & usuar.PAss & "'")
        '    'cmd.CommandType = CommandType.StoredProcedure
        '    cmd.Connection = con
        '    'cmd.Parameters.AddWithValue("@ID", usuar.NomUsuario)
        '    'cmd.Parameters.AddWithValue("@Pass", usuar.PAss)
        '    Dim ds As New DataTable

        '    dr = cmd.ExecuteReader
        '    If dr.HasRows = True Then
        '        Return True
        '    Else
        '        Return False
        '    End If
        '    'con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Return False
        'Finally

        'End Try
    End Function
    Public Function BuscarTipoUsuar(ByVal idusuar) As DataSet

        Dim da As New SqlDataAdapter("select * from Usuarios where IdUsuario= " & "'" & idusuar & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function Existe(ByVal usuar As ClaseUsuariosNE) As Boolean
        Dim sel As String

        sel = "select COUNT (*) from  Usuarios where IdUsuario =@IdUsuario"

        com.Parameters.AddWithValue("@IdUsuario", usuar.NomUsuario)

        com.CommandText = sel
        Dim t As Boolean
        Try
            t = CInt(com.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        If t = 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Public Sub modificarEstado(ByVal usuar As ClaseUsuariosNE)
        Dim sel As String

        Try
            sel = "set dateformat dmy update Usuarios set idEstado = '" & usuar.idEstado & "'" &
                "where ID = '" & usuar.IdUsuario & "'"
            com.CommandText = sel
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Public Function BuscarIDUsuar2(ByVal idusuar2) As DataSet

        Dim da As New SqlDataAdapter("select * from Usuarios where IdUsuario= " & "'" & idusuar2 & "'", con)
        Dim ds As New DataSet
        Try
            da.Fill(ds)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ds

    End Function
    Public Function CargarConexiones() As DataSet

        'Dim da As New SqlDataAdapter("select * from Usuarios where IdUsuario= " & "'" & idusuar2 & "'", con)
        'Dim ds As New DataSet
        'Try
        '    da.Fill(ds)

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
        'Return ds

    End Function
End Class
