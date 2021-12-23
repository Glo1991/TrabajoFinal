Imports CapaNE
Imports CapaLN
Public Class HistorialPrecios
    Dim objPrecHisLN As New PreciosHistLN
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub HistorialPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objPrecHisLN.cargaGrilla()
        dgvPrecios.DataSource = ds.Tables(0)
        dgvPrecios.Columns(0).Width = 220
        dgvPrecios.Columns(4).Visible = False
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        If CboCampo.SelectedItem = "Producto" Then
            If ComboBox1.SelectedItem = "Nombre/Razón Social" Or ComboBox1.Text = "Seleccione" Then
                ds = objPrecHisLN.cargarGrillaProvProdFecha(TextBox1.Text, TxtBuscar.Text, DateTimePicker1.Value, DateTimePicker2.Value)
                dgvPrecios.DataSource = ds.Tables(0)
                dgvPrecios.Columns(4).Visible = False
            End If
        End If
        If CboCampo.SelectedItem = "Nombre/Razón Social" Then
            If ComboBox1.SelectedItem = "Producto" Or ComboBox1.Text = "Seleccione" Then
                ds = objPrecHisLN.cargarGrillaProvProdFecha(TxtBuscar.Text, TextBox1.Text, DateTimePicker1.Value, DateTimePicker2.Value)
                dgvPrecios.DataSource = ds.Tables(0)
                dgvPrecios.Columns(4).Visible = False
            End If
        End If
        If CboCampo.SelectedItem = "Fecha" Then
            ds = objPrecHisLN.cargarGrillaFecha(DateTimePicker1.Value, DateTimePicker2.Value)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(4).Visible = False
        End If
    End Sub
    Private Sub CboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectedIndexChanged
        If CboCampo.SelectedItem = "Nombre/Razón Social" Then
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("Seleccione")
            ComboBox1.Items.Add("Producto")
            ComboBox1.Enabled = True
            TextBox1.Enabled = True
            TxtBuscar.Enabled = True

        End If
        If CboCampo.SelectedItem = "Producto" Then
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("Seleccione")
            ComboBox1.Items.Add("Nombre/Razón Social")
            ComboBox1.Enabled = True
            TextBox1.Enabled = True
            TxtBuscar.Enabled = True

        End If
        If CboCampo.SelectedItem = "Fecha" Then
            ComboBox1.Enabled = False
            TextBox1.Clear()
            TxtBuscar.Clear()
            TextBox1.Enabled = False
            TxtBuscar.Enabled = False
        End If
    
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Dim ds As DataSet
        If CboCampo.SelectedItem = "Producto" Then
            ds = objPrecHisLN.cargarGrillaProd(TxtBuscar.Text)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(4).Visible = False

        End If
        If CboCampo.SelectedItem = "Nombre/Razón Social" Then
            ds = objPrecHisLN.cargarGrillaProv(TxtBuscar.Text)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(4).Visible = False

        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim ds As DataSet
        If CboCampo.SelectedItem = "Producto" And ComboBox1.SelectedItem = "Nombre/Razón Social" Then
            ds = objPrecHisLN.cargarGrillaProvProd(TextBox1.Text, TxtBuscar.Text)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(4).Visible = False

        End If
        If CboCampo.SelectedItem = "Nombre/Razón Social" And ComboBox1.SelectedItem = "Producto" Then
            ds = objPrecHisLN.cargarGrillaProvProd(TxtBuscar.Text, TextBox1.Text)
            dgvPrecios.DataSource = ds.Tables(0)
            dgvPrecios.Columns(4).Visible = False

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Seleccione" Then
            TextBox1.Clear()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ds As New DataSet
        ds = objPrecHisLN.cargaGrilla()
        dgvPrecios.DataSource = ds.Tables(0)
        dgvPrecios.Columns(0).Width = 220
        dgvPrecios.Columns(4).Visible = False
        CboCampo.Text = "Seleccione"
        ComboBox1.SelectedItem = "Seleccione"
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        TextBox1.Clear()
        TxtBuscar.Clear()
    End Sub
End Class