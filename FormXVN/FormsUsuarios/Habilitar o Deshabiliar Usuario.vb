Imports CapaLN
Imports CapaNE
Imports System
Public Class Habilitar_o_Deshabilitar_Usuario
    Public idUsuarioo As Integer
    Dim objUsuarioLN As New UsuariosLN
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Habilitar_o_Deshabilitar_Usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtApellido.Enabled = False
        txtNom.Enabled = False
        txtTipoDoc.Enabled = False
        txtTipoUsuar.Enabled = False
        txtusuar.Enabled = False
        txtNumDoc.Enabled = False
        'TextBox1.ForeColor = Color.Black
        If TextBox1.Text = "Activo" Then
            TextBox1.BackColor = Color.Green
        Else
            TextBox1.BackColor = Color.Red
        End If
    End Sub

    Private Sub btnInactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactivar.Click
        Dim objUsuarLN As New UsuariosLN
        Dim objUsuaNe As New ClaseUsuariosNE
        objUsuaNe.IdUsuario = idUsuarioo

        If Label3.Text = "1" Then
            Label3.Text = "2"
            objUsuaNe.idEstado = Label3.Text
            objUsuarLN.modificarEstado(objUsuaNe)
        ElseIf Label3.Text = "2" Then
            Label3.Text = "1"
            objUsuaNe.idEstado = Label3.Text
            objUsuarLN.modificarEstado(objUsuaNe)
        End If

        Dim ds As DataSet

        Dim form As New Usuarios
        ds = objUsuarioLN.cargaGrilla
        Usuarios.dgvUsuarios.DataSource = ds.Tables(0)
        Usuarios.dgvUsuarios.Columns(5).Visible = False
        Me.Close()
    End Sub

End Class