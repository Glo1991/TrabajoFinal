Imports CapaNE
Imports CapaLN
Public Class Proveedores
    Dim objProvLN As New ProveedoresLN
    Dim objProvNe As New ClaseProveedor
    Private Sub Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objProvLN.cargaGrilla()
        dgvProv.DataSource = ds.Tables(0)
        dgvProv.Columns(5).Visible = False
        txtNumDoc.Enabled = False
        If XVN.Label3.Text = "Limitada" Then
            Button4.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        RegistrarProveedor.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea ver o modificar datos del Proveedor?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objProvLN As New ProveedoresLN
            Dim objProvNe As New ClaseProveedor
            Dim formModProv As New ModificarProveedor
            Dim idProv As Integer
            Dim ds As New DataSet
            If dgvProv.CurrentRow.Selected = True Then
                idProv = Me.dgvProv.CurrentRow.Cells(5).Value
                ds = objProvLN.buscarIdProv(idProv)
                ModificarProveedor.txtNombre.Text = ds.Tables(0).Rows(0).Item(2).ToString
                ModificarProveedor.txtNumCuit.Text = ds.Tables(0).Rows(0).Item(1).ToString
                ModificarProveedor.txtTelFij.Text = ds.Tables(0).Rows(0).Item(3).ToString
                ModificarProveedor.txtCel.Text = ds.Tables(0).Rows(0).Item(4).ToString
                ModificarProveedor.txtemail.Text = ds.Tables(0).Rows(0).Item(5).ToString
                Dim dsDirec As New DataSet
                dsDirec = objProvLN.buscarIdDomic(idProv)
                ModificarProveedor.cmbPais.Text = dsDirec.Tables(0).Rows(0).Item(2).ToString
                ModificarProveedor.txtProvincia.Text = dsDirec.Tables(0).Rows(0).Item(3).ToString
                ModificarProveedor.txtCiudad.Text = dsDirec.Tables(0).Rows(0).Item(4).ToString
                ModificarProveedor.txtBarrio.Text = dsDirec.Tables(0).Rows(0).Item(5).ToString
                ModificarProveedor.txtCalle.Text = dsDirec.Tables(0).Rows(0).Item(6).ToString
                ModificarProveedor.txtNro.Text = dsDirec.Tables(0).Rows(0).Item(7).ToString
                ModificarProveedor.cmbPiso.Text = dsDirec.Tables(0).Rows(0).Item(8).ToString
                ModificarProveedor.txtDepto.Text = dsDirec.Tables(0).Rows(0).Item(9).ToString
            End If
            ModificarProveedor.idAProv = idProv
            ModificarProveedor.txtNombre.Enabled = False
            ModificarProveedor.txtNumCuit.Enabled = False
            ModificarProveedor.txtTelFij.Enabled = True
            ModificarProveedor.txtCel.Enabled = True
            ModificarProveedor.txtemail.Enabled = True
            ModificarProveedor.cmbPais.Enabled = True
            ModificarProveedor.txtProvincia.Enabled = True
            ModificarProveedor.txtCiudad.Enabled = True
            ModificarProveedor.txtBarrio.Enabled = True
            ModificarProveedor.txtCalle.Enabled = True
            ModificarProveedor.txtNro.Enabled = True
            ModificarProveedor.cmbPiso.Enabled = True
            ModificarProveedor.txtDepto.Enabled = True
            ModificarProveedor.Show()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub CboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectedIndexChanged
        If CboCampo.Text = "CUIT" Then
            txtNumDoc.Enabled = True
            TxtBuscar.Enabled = False
            TxtBuscar.Clear()
        Else
            txtNumDoc.Enabled = False
            TxtBuscar.Enabled = True
            txtNumDoc.Clear()

        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim objProvLN As New ProveedoresLN
        Dim objProvNE As New ClaseProveedor
        If CboCampo.Text <> "Seleccione" Then
            If TxtBuscar.Text <> "" Then
                If CboCampo.SelectedItem = "Nombre/Razón Social" Then
                    ds = objProvLN.cargarGrillaNomRaz(TxtBuscar.Text)
                    dgvProv.DataSource = ds.Tables(0)
                    dgvProv.Columns(5).Visible = False
                Else
                    MsgBox("No se encontró la busqueda")
                End If
            End If
            If txtNumDoc.Text <> "" Then
                If CboCampo.SelectedItem = "CUIT" Then
                    ds = objProvLN.cargarGrillaIdCuit(txtNumDoc.Text)
                    dgvProv.DataSource = ds.Tables(0)
                    dgvProv.Columns(5).Visible = False
                End If
            End If
        Else
            If TxtBuscar.Text = "" And CboCampo.SelectedItem <> "" Then
                ds = objProvLN.cargaGrilla()
                dgvProv.DataSource = ds.Tables(0)
                dgvProv.Columns(5).Visible = False
            End If
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CboCampo.Text = "Seleccione"
        TxtBuscar.Clear()
        Dim ds As New DataSet
        ds = objProvLN.cargaGrilla()
        dgvProv.DataSource = ds.Tables(0)
        dgvProv.Columns(5).Visible = False
        txtNumDoc.Clear()
        txtNumDoc.Enabled = False
    End Sub

    Private Sub dgvProv_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvProv.DoubleClick
        Dim objProvLN As New ProveedoresLN
        Dim objProvNe As New ClaseProveedor
        Dim formModProv As New ModificarProveedor
        Dim idProv As Integer
        Dim ds As New DataSet
        If dgvProv.CurrentRow.Selected = True Then
            idProv = Me.dgvProv.CurrentRow.Cells(5).Value
            ds = objProvLN.buscarIdProv(idProv)
            ModificarProveedor.txtNombre.Text = ds.Tables(0).Rows(0).Item(2).ToString
            ModificarProveedor.txtNumCuit.Text = ds.Tables(0).Rows(0).Item(1).ToString
            ModificarProveedor.txtTelFij.Text = ds.Tables(0).Rows(0).Item(3).ToString
            ModificarProveedor.txtCel.Text = ds.Tables(0).Rows(0).Item(4).ToString
            ModificarProveedor.txtemail.Text = ds.Tables(0).Rows(0).Item(5).ToString
            Dim dsDirec As New DataSet
            dsDirec = objProvLN.buscarIdDomic(idProv)
            ModificarProveedor.cmbPais.Text = dsDirec.Tables(0).Rows(0).Item(2).ToString
            ModificarProveedor.txtProvincia.Text = dsDirec.Tables(0).Rows(0).Item(3).ToString
            ModificarProveedor.txtCiudad.Text = dsDirec.Tables(0).Rows(0).Item(4).ToString
            ModificarProveedor.txtBarrio.Text = dsDirec.Tables(0).Rows(0).Item(5).ToString
            ModificarProveedor.txtCalle.Text = dsDirec.Tables(0).Rows(0).Item(6).ToString
            ModificarProveedor.txtNro.Text = dsDirec.Tables(0).Rows(0).Item(7).ToString
            ModificarProveedor.cmbPiso.Text = dsDirec.Tables(0).Rows(0).Item(8).ToString
            ModificarProveedor.txtDepto.Text = dsDirec.Tables(0).Rows(0).Item(9).ToString
        End If
        ModificarProveedor.idAProv = idProv
        ModificarProveedor.txtNombre.Enabled = False
        ModificarProveedor.txtNumCuit.Enabled = False
        ModificarProveedor.txtTelFij.Enabled = False
        ModificarProveedor.txtCel.Enabled = False
        ModificarProveedor.txtemail.Enabled = False
        ModificarProveedor.cmbPais.Enabled = False
        ModificarProveedor.txtProvincia.Enabled = False
        ModificarProveedor.txtCiudad.Enabled = False
        ModificarProveedor.txtBarrio.Enabled = False
        ModificarProveedor.txtCalle.Enabled = False
        ModificarProveedor.txtNro.Enabled = False
        ModificarProveedor.cmbPiso.Enabled = False
        ModificarProveedor.txtDepto.Enabled = False
        ModificarProveedor.Show()
    End Sub
End Class