Imports CapaNE
Imports CapaLN
Public Class Clientes

    Dim objUsuarioLN As New ClienteLN
    Dim objUsuarioNe As New ClaseCliente
    Private Sub FormCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objUsuarioLN.cargaGrilla()
        dgvAlumnos.DataSource = ds.Tables(0)
        dgvAlumnos.Columns(7).Visible = False
        cbotipoDoc.Enabled = False
        txtNumDoc.Enabled = False

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        RegistrarCliente.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea ver o modificar datos del Cliente?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objAlumnaNE As New ClaseCliente
            Dim objAlumLN As New ClienteLN
            Dim formModAlum As New ModificarCliente
            Dim idAlumna As Integer
            Dim ds As New DataSet
            If dgvAlumnos.CurrentRow.Selected = True Then
                idAlumna = Me.dgvAlumnos.CurrentRow.Cells(7).Value
                ds = objAlumLN.buscarAlumna(idAlumna)
                ModificarCliente.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
                ModificarCliente.txtApellido.Text = ds.Tables(0).Rows(0).Item(2).ToString
                ModificarCliente.dtpFecNac.Text = ds.Tables(0).Rows(0).Item(3).ToString
                ModificarCliente.dtpFecIng.Text = ds.Tables(0).Rows(0).Item(4).ToString
                ModificarCliente.txtTelFij.Text = ds.Tables(0).Rows(0).Item(5).ToString
                ModificarCliente.txtCel.Text = ds.Tables(0).Rows(0).Item(6).ToString
                ModificarCliente.txtemail.Text = ds.Tables(0).Rows(0).Item(7).ToString
                ModificarCliente.txtEdad.Text = ds.Tables(0).Rows(0).Item(8).ToString
                Dim dsDocumento As New DataSet
                dsDocumento = objAlumLN.buscaridDoc(idAlumna)
                ModificarCliente.cmbTipoDni.Text = dsDocumento.Tables(0).Rows(0).Item(2)
                ModificarCliente.txtNumDoc.Text = dsDocumento.Tables(0).Rows(0).Item(0)
                Dim dsDirec As New DataSet
                dsDirec = objAlumLN.buscarIdDomic(idAlumna)
                ModificarCliente.cmbPais.Text = dsDirec.Tables(0).Rows(0).Item(2).ToString
                ModificarCliente.txtProvincia.Text = dsDirec.Tables(0).Rows(0).Item(3).ToString
                ModificarCliente.txtCiudad.Text = dsDirec.Tables(0).Rows(0).Item(4).ToString
                ModificarCliente.txtBarrio.Text = dsDirec.Tables(0).Rows(0).Item(5).ToString
                ModificarCliente.txtCalle.Text = dsDirec.Tables(0).Rows(0).Item(6).ToString
                ModificarCliente.txtNro.Text = dsDirec.Tables(0).Rows(0).Item(7).ToString
                ModificarCliente.cmbPiso.Text = dsDirec.Tables(0).Rows(0).Item(8).ToString
                ModificarCliente.txtDepto.Text = dsDirec.Tables(0).Rows(0).Item(9).ToString
                ModificarCliente.txtLote.Text = dsDirec.Tables(0).Rows(0).Item(10).ToString
                ModificarCliente.txtmanzana.Text = dsDirec.Tables(0).Rows(0).Item(11).ToString
            End If
            ModificarCliente.idAlumnaaa = idAlumna
            ModificarCliente.txtNombre.Enabled = False
            ModificarCliente.txtApellido.Enabled = False
            ModificarCliente.cmbTipoDni.Enabled = False
            ModificarCliente.txtNumDoc.Enabled = False
            ModificarCliente.dtpFecNac.Enabled = False
            ModificarCliente.dtpFecIng.Enabled = False
            ModificarCliente.txtEdad.Enabled = False
            'ModificarCliente.txtTelFij.Enabled = False
            'ModificarCliente.txtCel.Enabled = False
            'ModificarCliente.txtemail.Enabled = False
            'ModificarCliente.cmbPais.Enabled = False
            'ModificarCliente.txtProvincia.Enabled = False
            'ModificarCliente.txtCiudad.Enabled = False
            'ModificarCliente.txtBarrio.Enabled = False
            'ModificarCliente.txtCalle.Enabled = False
            'ModificarCliente.txtNro.Enabled = False
            'ModificarCliente.cmbPiso.Enabled = False
            'ModificarCliente.txtDepto.Enabled = False
            'ModificarCliente.txtLote.Enabled = False
            'ModificarCliente.txtmanzana.Enabled = False
            ModificarCliente.Show()
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim metAlumna As New ClienteLN
        Dim objAlumna As New ClaseCliente
        If CboCampo.Text <> "Seleccione" Then
            If CheckBox1.Checked = True Then
                ds = metAlumna.cargarGrillaApellido(TxtBuscar.Text)
                dgvAlumnos.DataSource = ds.Tables(0)
                dgvAlumnos.Columns(7).Visible = False
            Else
            End If

            If CheckBox2.Checked = True Then
                ds = metAlumna.cargarGrillaDoc(txtNumDoc.Text, cbotipoDoc.Text)
                dgvAlumnos.DataSource = ds.Tables(0)
                dgvAlumnos.Columns(7).Visible = False
            End If

        End If
        If TxtBuscar.Text = "" And txtNumDoc.Text = "" Then
            ds = metAlumna.cargaGrilla()
            dgvAlumnos.DataSource = ds.Tables(0)
            dgvAlumnos.Columns(7).Visible = False
            'CboCampo.Text = "Seleccione"
        End If
    End Sub

    Private Sub CboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectedIndexChanged
        If CboCampo.Text = "N° de Documento" Then
            cbotipoDoc.Enabled = True
            txtNumDoc.Enabled = True
            TxtBuscar.Enabled = False
            TxtBuscar.Clear()
        Else
            cbotipoDoc.Enabled = False
            txtNumDoc.Enabled = False
            TxtBuscar.Enabled = True
            cbotipoDoc.Text = Nothing
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
        If txtNumDoc.Text <> "" And CboCampo.SelectedItem = "N° de Documento" Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        If TxtBuscar.Text <> "" And CboCampo.SelectedItem = "Apellido" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub dgvAlumnas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAlumnos.CellDoubleClick
        Dim objAlumnaNE As New ClaseCliente
        Dim objAlumLN As New ClienteLN
        Dim formModAlum As New ModificarCliente
        Dim idAlumna As Integer
        Dim ds As New DataSet
        If dgvAlumnos.CurrentRow.Selected = True Then
            idAlumna = Me.dgvAlumnos.CurrentRow.Cells(7).Value
            ds = objAlumLN.buscarAlumna(idAlumna)
            ConsultarCliente.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
            ConsultarCliente.txtApellido.Text = ds.Tables(0).Rows(0).Item(2).ToString
            ConsultarCliente.dtpFecNac.Text = ds.Tables(0).Rows(0).Item(3).ToString
            ConsultarCliente.dtpFecIng.Text = ds.Tables(0).Rows(0).Item(4).ToString
            ConsultarCliente.txtTelFij.Text = ds.Tables(0).Rows(0).Item(5).ToString
            ConsultarCliente.txtCel.Text = ds.Tables(0).Rows(0).Item(6).ToString
            ConsultarCliente.txtemail.Text = ds.Tables(0).Rows(0).Item(7).ToString
            ConsultarCliente.txtEdad.Text = ds.Tables(0).Rows(0).Item(8).ToString
            Dim dsDocumento As New DataSet
            dsDocumento = objAlumLN.buscaridDoc(idAlumna)
            ConsultarCliente.cmbTipoDni.Text = dsDocumento.Tables(0).Rows(0).Item(2)
            ConsultarCliente.txtNumDoc.Text = dsDocumento.Tables(0).Rows(0).Item(0)
            Dim dsDirec As New DataSet
            dsDirec = objAlumLN.buscarIdDomic(idAlumna)
            ConsultarCliente.cmbPais.Text = dsDirec.Tables(0).Rows(0).Item(2).ToString
            ConsultarCliente.txtProvincia.Text = dsDirec.Tables(0).Rows(0).Item(3).ToString
            ConsultarCliente.txtCiudad.Text = dsDirec.Tables(0).Rows(0).Item(4).ToString
            ConsultarCliente.txtBarrio.Text = dsDirec.Tables(0).Rows(0).Item(5).ToString
            ConsultarCliente.txtCalle.Text = dsDirec.Tables(0).Rows(0).Item(6).ToString
            ConsultarCliente.txtNro.Text = dsDirec.Tables(0).Rows(0).Item(7).ToString
            ConsultarCliente.cmbPiso.Text = dsDirec.Tables(0).Rows(0).Item(8).ToString
            ConsultarCliente.txtDepto.Text = dsDirec.Tables(0).Rows(0).Item(9).ToString
            ConsultarCliente.txtLote.Text = dsDirec.Tables(0).Rows(0).Item(10).ToString
            ConsultarCliente.txtmanzana.Text = dsDirec.Tables(0).Rows(0).Item(11).ToString
        End If
        ConsultarCliente.idAlumnaaa = idAlumna
        ConsultarCliente.txtNombre.Enabled = False
        ConsultarCliente.txtApellido.Enabled = False
        ConsultarCliente.cmbTipoDni.Enabled = False
        ConsultarCliente.txtNumDoc.Enabled = False
        ConsultarCliente.dtpFecNac.Enabled = False
        ConsultarCliente.dtpFecIng.Enabled = False
        ConsultarCliente.txtEdad.Enabled = False
        ConsultarCliente.txtTelFij.Enabled = False
        ConsultarCliente.txtCel.Enabled = False
        ConsultarCliente.txtemail.Enabled = False
        ConsultarCliente.cmbPais.Enabled = False
        ConsultarCliente.txtProvincia.Enabled = False
        ConsultarCliente.txtCiudad.Enabled = False
        ConsultarCliente.txtBarrio.Enabled = False
        ConsultarCliente.txtCalle.Enabled = False
        ConsultarCliente.txtNro.Enabled = False
        ConsultarCliente.cmbPiso.Enabled = False
        ConsultarCliente.txtDepto.Enabled = False
        ConsultarCliente.txtLote.Enabled = False
        ConsultarCliente.txtmanzana.Enabled = False
        ConsultarCliente.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ds As New DataSet
        ds = objUsuarioLN.cargaGrilla()
        dgvAlumnos.DataSource = ds.Tables(0)
        dgvAlumnos.Columns(7).Visible = False
        cbotipoDoc.Enabled = False
        txtNumDoc.Enabled = False
        TxtBuscar.Clear()
        CboCampo.Text = "Seleccione"
    End Sub
End Class