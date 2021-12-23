Imports CapaNE
Imports CapaLN
Public Class BuscarProveedor
    Dim objProvLN As New ProveedoresLN
    Dim objProvNe As New ClaseProveedor
    Private Sub BuscarProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objProvLN.cargaGrilla()
        dgvProv.DataSource = ds.Tables(0)
        dgvProv.Columns(5).Visible = False
        txtNumDoc.Enabled = False
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea seleccionar el Proveedor?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objProvLN As New ProveedoresLN
            Dim objProvNe As New ClaseProveedor
            Dim formModProv As New ModificarProveedor
            Dim idProv As Integer
            Dim ds As New DataSet
            If dgvProv.CurrentRow.Selected = True Then
                idProv = Me.dgvProv.CurrentRow.Cells(5).Value
                ds = objProvLN.buscarIdProv(idProv)
                RegistrarCompra.txtNombre.Text = ds.Tables(0).Rows(0).Item(2).ToString
                RegistrarCompra.TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString
                Me.Close()
                RegistrarCompra.idAProv = idProv
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class