Imports CapaNE
Imports CapaLN
Public Class Usuarios
    Dim objUsuarioLN As New UsuariosLN
    Dim objUsuarioNe As New ClaseUsuariosNE
    Private Sub Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objUsuarioLN.cargaGrilla()
        dgvUsuarios.DataSource = ds.Tables(0)
        dgvUsuarios.Columns(5).Visible = False
        dgvUsuarios.Columns(7).Visible = False
        dgvUsuarios.Columns(0).Width = 80
        dgvUsuarios.Columns(1).Width = 80
        dgvUsuarios.Columns(2).Width = 120
        dgvUsuarios.Columns(3).Width = 70
        dgvUsuarios.Columns(4).Width = 120
        dgvUsuarios.Columns(6).Width = 100
        ComboBoxBuscar.Text = "Seleccione"
        cboTipoDoc.Enabled = False
        txtNumDoc.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim metUsuar As New UsuariosLN
        Dim objUsuarioNE As New ClaseUsuariosNE
        If ComboBoxBuscar.Text <> "Seleccione" Then
            If LblBusqueda.Text <> "" Then
                If ComboBoxBuscar.SelectedItem = "Nombre de Usuario" Then
                    ds = metUsuar.cargarGrillaUsuario(LblBusqueda.Text)
                    dgvUsuarios.DataSource = ds.Tables(0)
                    dgvUsuarios.Columns(5).Visible = False
                    dgvUsuarios.Columns(7).Visible = False
                Else
                    MsgBox("No se encontró la busqueda")
                End If
            End If
            If txtNumDoc.Text <> "" Then
                If ComboBoxBuscar.SelectedItem = "N° de Documento" Then
                    ds = metUsuar.cargarGrillaDoc(txtNumDoc.Text, cboTipoDoc.Text)
                    dgvUsuarios.DataSource = ds.Tables(0)
                    dgvUsuarios.Columns(5).Visible = False
                    dgvUsuarios.Columns(7).Visible = False
                End If
            End If
        End If


    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim resp As Integer
        resp = MessageBox.Show("Desea agregar un Usuario?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            RegistrarUsuario.Show()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBoxBuscar.Text = "Seleccione"
        LblBusqueda.Clear()
        Dim ds As New DataSet
        ds = objUsuarioLN.cargaGrilla()
        dgvUsuarios.DataSource = ds.Tables(0)
        dgvUsuarios.Columns(5).Visible = False
        dgvUsuarios.Columns(7).Visible = False
        cboTipoDoc.Text = Nothing
        txtNumDoc.Clear()
        cboTipoDoc.Enabled = False
        txtNumDoc.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea modificar datos del Usuario?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objUsuarioNE As New ClaseUsuariosNE
            Dim objUsuarioLN As New UsuariosLN
            Dim formModUsuar As New ModificarUsuario
            Dim idUsuar As Integer
            Dim ds As New DataSet
            If dgvUsuarios.CurrentRow.Selected = True Then
                idUsuar = Me.dgvUsuarios.CurrentRow.Cells(5).Value
                ds = objUsuarioLN.buscarUsuario(idUsuar)
                ModificarUsuario.txtusuar.Text = ds.Tables(0).Rows(0).Item(1).ToString
                ModificarUsuario.txtcontras.Text = ds.Tables(0).Rows(0).Item(2).ToString
                ModificarUsuario.cbotipoUsuario.Text = ds.Tables(0).Rows(0).Item(3).ToString
                ModificarUsuario.txtNom.Text = ds.Tables(0).Rows(0).Item(4).ToString
                ModificarUsuario.txtApellido.Text = ds.Tables(0).Rows(0).Item(5).ToString
                'ModificarUsuario.Label3.Text = ds.Tables(0).Rows(0).Item(0).ToString
                Dim dsDocumento As New DataSet
                dsDocumento = objUsuarioLN.buscarDocum(ModificarUsuario.txtusuar.Text)
                ModificarUsuario.ComboTipoDoc.Text = dsDocumento.Tables(0).Rows(0).Item(2)
                ModificarUsuario.txtNumDoc.Text = dsDocumento.Tables(0).Rows(0).Item(0)
            End If
            ModificarUsuario.idUsuarioo = idUsuar
            ModificarUsuario.Show()
        End If
    End Sub

    Private Sub ComboBoxBuscar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxBuscar.SelectedIndexChanged
        If ComboBoxBuscar.Text = "N° de Documento" Then
            cboTipoDoc.Enabled = True
            txtNumDoc.Enabled = True
            LblBusqueda.Enabled = False
            LblBusqueda.Clear()
        Else
            cboTipoDoc.Enabled = False
            txtNumDoc.Enabled = False
            LblBusqueda.Enabled = True
            cboTipoDoc.Text = Nothing
            txtNumDoc.Clear()

        End If
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress

        'Condicional que evalua que la tecla pulsada sea un número 
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
            MessageBox.Show("Introduzca sólo valores númericos")
        End If
    End Sub

    Private Sub txtNumDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoc.TextChanged
        txtNumDoc.MaxLength = 8
    End Sub

    Private Sub btnInactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactivar.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea modificar datos del Usuario?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objUsuarioNE As New ClaseUsuariosNE
            Dim objUsuarioLN As New UsuariosLN
            Dim formModUsuar As New Habilitar_o_Deshabilitar_Usuario
            Dim idUsuar As Integer
            Dim idEstado As Integer
            Dim ds As New DataSet
            If dgvUsuarios.CurrentRow.Selected = True Then
                idUsuar = Me.dgvUsuarios.CurrentRow.Cells(5).Value
                ds = objUsuarioLN.buscarUsuario(idUsuar)
                Habilitar_o_Deshabilitar_Usuario.txtusuar.Text = ds.Tables(0).Rows(0).Item(1).ToString
                Habilitar_o_Deshabilitar_Usuario.txtTipoUsuar.Text = ds.Tables(0).Rows(0).Item(3).ToString
                Habilitar_o_Deshabilitar_Usuario.txtNom.Text = ds.Tables(0).Rows(0).Item(4).ToString
                Habilitar_o_Deshabilitar_Usuario.txtApellido.Text = ds.Tables(0).Rows(0).Item(5).ToString
                Habilitar_o_Deshabilitar_Usuario.Label3.Text = ds.Tables(0).Rows(0).Item(6).ToString
                'ModificarUsuario.Label3.Text = ds.Tables(0).Rows(0).Item(0).ToString
                Dim dsEstado As New DataSet
                idEstado = Me.dgvUsuarios.CurrentRow.Cells(7).Value
                dsEstado = objUsuarioLN.BuscarEstado(idEstado)
                Habilitar_o_Deshabilitar_Usuario.TextBox1.Text = dsEstado.Tables(0).Rows(0).Item(1)
                Dim dsDocumento As New DataSet
                dsDocumento = objUsuarioLN.buscarDocum(Habilitar_o_Deshabilitar_Usuario.txtusuar.Text)
                Habilitar_o_Deshabilitar_Usuario.txtTipoDoc.Text = dsDocumento.Tables(0).Rows(0).Item(0)
                Habilitar_o_Deshabilitar_Usuario.txtNumDoc.Text = dsDocumento.Tables(0).Rows(0).Item(1)
            End If
            Habilitar_o_Deshabilitar_Usuario.idUsuarioo = idUsuar
            Habilitar_o_Deshabilitar_Usuario.Show()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class