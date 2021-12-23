Imports CapaNE
Imports CapaLN
Public Class PreciosProveedor
    Dim objPrecLN As New PreciosLN
    Private Sub PreciosProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        RegistrarPrecios.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Inicio()
        TxtBuscar.Clear()
        CboCampo.Text = "Seleccione"
        Button1.Enabled = False
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim objPrecLN As New PreciosLN
        Dim objPrecNe As New ClasePrecios

        If CboCampo.SelectedItem = "Fecha" Then
            ds = objPrecLN.buscarFechasGrilla(DateTimePicker1.Value, DateTimePicker2.Value)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(4).Visible = False
            dgvPrecios.Columns(5).Visible = False
            dgvPrecios.Columns(6).Visible = False
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Dim ds As DataSet
        If CboCampo.SelectedItem = "Producto" Then
            ds = objPrecLN.cargarGrillaProvees(TxtBuscar.Text)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(4).Visible = False
            dgvPrecios.Columns(5).Visible = False
            dgvPrecios.Columns(6).Visible = False

        End If
        If CboCampo.SelectedItem = "Nombre/Razón Social" Then
            ds = objPrecLN.cargarGrillaProveesPR(TxtBuscar.Text)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(4).Visible = False
            dgvPrecios.Columns(5).Visible = False
            dgvPrecios.Columns(6).Visible = False

        End If
    End Sub

    Private Sub CboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectedIndexChanged
        If CboCampo.SelectedItem = "Fecha" Then
            Button1.Enabled = True
            TxtBuscar.Enabled = False
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        Else
            Button1.Enabled = False
            TxtBuscar.Enabled = True
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            DateTimePicker1.Value = Now
            DateTimePicker2.Value = Now
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea Modificar los datos?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objPrecLN As New PreciosLN
            Dim objPrecNe As New ClasePrecios

            Dim idPrecio As Integer
            Dim idProv As Integer
            Dim ds As New DataSet
            If dgvPrecios.CurrentRow.Selected = True Then
                idPrecio = Me.dgvPrecios.CurrentRow.Cells(4).Value
                idProv = Me.dgvPrecios.CurrentRow.Cells(6).Value
                ds = objPrecLN.buscarIdPrecio(idPrecio)
                ModificarPrecios.TextBox2.Text = ds.Tables(0).Rows(0).Item(0).ToString
                ModificarPrecios.TextBox3.Text = ds.Tables(0).Rows(0).Item(2).ToString
                ModificarPrecios.TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString

            End If
            ModificarPrecios.idPrecio = idPrecio
            ModificarPrecios.idAProv = idProv
            ModificarPrecios.Show()

        End If

    End Sub
    Private Sub Inicio()
        Dim ds As New DataSet
        ds = objPrecLN.cargaGrilla()
        dgvPrecios.DataSource = ds.Tables(0)
        dgvPrecios.Columns(0).Width = 220
        dgvPrecios.Columns(4).Visible = False
        dgvPrecios.Columns(5).Visible = False
        dgvPrecios.Columns(6).Visible = False
        Button1.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
    End Sub

  

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        HistorialPrecios.Show()
    End Sub

End Class