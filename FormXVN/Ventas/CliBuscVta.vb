Imports CapaNE
Imports CapaLN
Public Class CliBuscVta
    Dim objUsuarioLN As New ClienteLN
    Dim objUsuarioNe As New ClaseCliente
    Private Sub CliBuscVta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objUsuarioLN.cargaGrilla()
        dgvAlumnas.DataSource = ds.Tables(0)
        dgvAlumnas.Columns(7).Visible = False
        cbotipoDoc.Enabled = False
        txtNumDoc.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea seleccionar el Cliente?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objUsuarioLN As New ClienteLN
            Dim objUsuarioNe As New ClaseCliente
            Dim idCliente As Integer
            Dim ds As New DataSet
            Dim dsDNi As New DataSet
            Dim idDNI As New ClaseDocumento

            If dgvAlumnas.CurrentRow.Selected = True Then
                idCliente = Me.dgvAlumnas.CurrentRow.Cells(7).Value
                ds = objUsuarioLN.buscarAlumna(idCliente)
                RegistrarVenta.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString & " " & ds.Tables(0).Rows(0).Item(2).ToString
                Me.Close()
                dsDNi = objUsuarioLN.buscaridDoc(idCliente)
                RegistrarVenta.TextBox1.Text = dsDNi.Tables(0).Rows(0).Item(0).ToString
            End If

            RegistrarVenta.idCliente = idCliente

        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim metAlumna As New ClienteLN
        Dim objAlumna As New ClaseCliente
        If CboCampo.Text <> "Seleccione" Then
            If TxtBuscar.Text <> "" Then
                If CboCampo.SelectedItem = "Apellido" Then
                    ds = metAlumna.cargarGrillaApellido(TxtBuscar.Text)
                    dgvAlumnas.DataSource = ds.Tables(0)
                    dgvAlumnas.Columns(7).Visible = False
                Else
                    MsgBox("No se encontró la busqueda")
                End If
            End If
            If txtNumDoc.Text <> "" Then
                If CboCampo.SelectedItem = "N° de Documento" Then
                    ds = metAlumna.cargarGrillaDoc(txtNumDoc.Text, cbotipoDoc.Text)
                    dgvAlumnas.DataSource = ds.Tables(0)
                    dgvAlumnas.Columns(7).Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CboCampo.Text = "Seleccione"
        TxtBuscar.Clear()
        Dim ds As New DataSet
        ds = objUsuarioLN.cargaGrilla()
        dgvAlumnas.DataSource = ds.Tables(0)
        dgvAlumnas.Columns(7).Visible = False
        cbotipoDoc.Text = Nothing
        txtNumDoc.Clear()
        cbotipoDoc.Enabled = False
        txtNumDoc.Enabled = False
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class