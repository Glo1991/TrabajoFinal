Imports CapaLN
Imports CapaNE
Public Class PreciosVentas
    Dim PrecVtaLN As New PreciosVtaLN
    Dim PrecVtaNE As New ClasePreciosVta
    Private Sub PreciosVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ActualizacionPrecios.Show()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea Modificar los datos?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim PrecVtaLN As New PreciosVtaLN
            Dim PrecVtaNE As New ClasePreciosVta

            Dim idPrecio As Integer
            Dim idProv As Integer
            Dim ds As New DataSet
            If dgvPrecios.CurrentRow.Selected = True Then
                idPrecio = Me.dgvPrecios.CurrentRow.Cells(4).Value
                idProv = Me.dgvPrecios.CurrentRow.Cells(5).Value
                ds = PrecVtaLN.buscarIdPrecioVta(idPrecio)
                ModificarPrecVta.TextBox2.Text = ds.Tables(0).Rows(0).Item(0).ToString
                ModificarPrecVta.TextBox3.Text = ds.Tables(0).Rows(0).Item(6).ToString
                ModificarPrecVta.TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString

            End If
            ModificarPrecVta.idPrecio = idPrecio
            ModificarPrecVta.idAProv = idProv
            ModificarPrecVta.Show()

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       Dim ds As DataSet

        'If CboCampo.SelectedItem = "Fecha" Then
        '    ds = PrecVtaLN.buscarFechasGrilla(DateTimePicker1.Value, DateTimePicker2.Value)
        '    dgvPrecios.DataSource = ds.Tables(0)
        '    dgvPrecios.Columns(0).Width = 200
        '    dgvPrecios.Columns(3).Visible = False
        '    dgvPrecios.Columns(4).Visible = False
        '    dgvPrecios.Columns(5).Visible = False
        'End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Dim ds As DataSet
        If CboCampo.SelectedItem = "Producto" Then

            ds = PrecVtaLN.cargarGrillaProduct(TxtBuscar.Text)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(0).Width = 200
            dgvPrecios.Columns(3).Visible = False
            dgvPrecios.Columns(4).Visible = False
            dgvPrecios.Columns(5).Visible = False

        End If
        If CboCampo.SelectedItem = "Nombre/Razón Social" Then
            ds = PrecVtaLN.cargarGrillaProveesPRov(TxtBuscar.Text)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(0).Width = 200
            dgvPrecios.Columns(3).Visible = False
            dgvPrecios.Columns(4).Visible = False
            dgvPrecios.Columns(5).Visible = False
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Inicio()
        TxtBuscar.Clear()
        CboCampo.Text = "Seleccione"
        Button1.Enabled = False
    End Sub
    Private Sub Inicio()
        Dim ds As New DataSet
        ds = PrecVtaLN.cargaGrilla()
        dgvPrecios.DataSource = ds.Tables(0)
        dgvPrecios.Columns(0).Width = 200
        dgvPrecios.Columns(3).Visible = False
        dgvPrecios.Columns(4).Visible = False
        dgvPrecios.Columns(5).Visible = False
        Button1.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
    End Sub
End Class