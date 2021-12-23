Imports CapaLN
Imports CapaNE
Imports System
Public Class ModificarUsuario
    Public idUsuarioo As Integer
    Dim objUsuarioLN As New UsuariosLN
    Public cambic As Integer
    Private Sub ModificarUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboTipoDoc.Enabled = False
        txtNumDoc.Enabled = False
        txtusuar.Enabled = False
        txtApellido.Enabled = False
        txtNom.Enabled = False
        If cambic = 1 Then
            cbotipoUsuario.Enabled = False
            Dim ds As New DataSet
            ds = objUsuarioLN.buscarTipoUsuario(XVN.Label1.Text)
            If ds.Tables.Count > 0 Then
                idUsuarioo = ds.Tables(0).Rows(0).Item(0).ToString
                txtusuar.Text = ds.Tables(0).Rows(0).Item(1).ToString
                txtcontras.Text = ds.Tables(0).Rows(0).Item(2).ToString
                cbotipoUsuario.Text = ds.Tables(0).Rows(0).Item(3).ToString
                txtNom.Text = ds.Tables(0).Rows(0).Item(4).ToString
                txtApellido.Text = ds.Tables(0).Rows(0).Item(5).ToString
                'ModificarUsuario.Label3.Text = ds.Tables(0).Rows(0).Item(0).ToString
                Dim dsDocumento As New DataSet
                dsDocumento = objUsuarioLN.buscarDocum(txtusuar.Text)
                ComboTipoDoc.Text = dsDocumento.Tables(0).Rows(0).Item(2)
                txtNumDoc.Text = dsDocumento.Tables(0).Rows(0).Item(0)
            End If
        End If
    End Sub

    Private Sub BtnGuardUs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardUs.Click
        If cbotipoUsuario.Text = "" Then
            MessageBox.Show("Debe seleccionar un Tipo de Usuario")
        Else
            If txtcontras.Text = "" Then
                MessageBox.Show("Debe ingresar una contraseña")
            Else


                Dim objUsuarLN As New UsuariosLN
                Dim objUsuaNe As New ClaseUsuariosNE
                Dim doc As New ClaseDocumento
                objUsuaNe.Nombre = txtNom.Text
                objUsuaNe.Apellido = txtApellido.Text
                objUsuaNe.NomUsuario = txtusuar.Text
                objUsuaNe.PAss = txtcontras.Text
                objUsuaNe.TipoUsuario = cbotipoUsuario.Text
                'objUsuaNe.IdUsuario = Label3.Text
                doc.TipoDoc = ComboTipoDoc.Text
                doc.NumDoc = txtNumDoc.Text
                doc.IdUSuario = txtusuar.Text

                objUsuaNe.IdUsuario = idUsuarioo
                objUsuarLN.modificarUsuar(objUsuaNe)
                'doc.IdUSuario = idUsuarioo
                objUsuarLN.modificarDocum(doc)
                Me.Close()
                Dim ds As DataSet

                Dim form As New Usuarios
                ds = objusuarioLN.cargaGrilla
                Usuarios.dgvUsuarios.DataSource = ds.Tables(0)
                Usuarios.dgvUsuarios.Columns(5).Visible = False
                Me.Close()
            End If
        End If
    End Sub


    Private Sub txtNom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNom.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class