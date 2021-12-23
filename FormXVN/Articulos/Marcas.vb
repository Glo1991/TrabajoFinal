Imports CapaLN
Imports CapaNE
Public Class Marcas
    Dim objMarca As New ArticulosLN
    Private Sub Marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objMarca.cargaGrillaMArca()
        dgvMarcas.DataSource = ds.Tables(0)
        dgvMarcas.Columns(0).Width = 70
        dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMarcas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If XVN.Label3.Text = "Limitada" Then
            Button4.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NuevaMarca.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea ver o modificar la Marca?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objMarcaNE As New ClaseMarca
            Dim objMarcaLN As New ArticulosLN
            Dim formModMarcas As New ModificarMarca
            Dim idMarca As Integer
            Dim ds As New DataSet
            If dgvMarcas.CurrentRow.Selected = True Then
                idMarca = Me.dgvMarcas.CurrentRow.Cells(0).Value
                ds = objMarcaLN.buscaridMarca(idMarca)
                ModificarMarca.TextBox1.Text = ds.Tables(0).Rows(0).Item(0).ToString
                ModificarMarca.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
            End If
            ModificarMarca.idMarca = idMarca
            ModificarMarca.TextBox1.Enabled = False
            ModificarMarca.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        Dim ds As New DataSet
        ds = objMarca.cargaGrillaMArca()
        dgvMarcas.DataSource = ds.Tables(0)
        dgvMarcas.Columns(0).Width = 70

        dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMarcas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text <> "" Then
            Dim ds As New DataSet
            ds = objMarca.busquedaMArcaCOD(TextBox2.Text, TextBox1.Text)
            dgvMarcas.DataSource = ds.Tables(0)
            dgvMarcas.Columns(0).Width = 70
            dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvMarcas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If TextBox1.Text <> "" And TextBox2.Text = "" Then
            Dim ds As New DataSet
            ds = objMarca.busquedaMArcaDEscr(TextBox1.Text)
            dgvMarcas.DataSource = ds.Tables(0)
            dgvMarcas.Columns(0).Width = 70
            dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvMarcas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If TextBox2.Text = "" And TextBox1.Text = "" Then
            Dim ds As New DataSet
            ds = objMarca.cargaGrillaMArca()
            dgvMarcas.DataSource = ds.Tables(0)
            dgvMarcas.Columns(0).Width = 70
            dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvMarcas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub
End Class