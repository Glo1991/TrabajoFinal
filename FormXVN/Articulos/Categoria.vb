Imports CapaLN
Imports CapaNE
Public Class Categoria

    Dim objCatg As New ArticulosLN
    Private Sub Marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objCatg.cargaGrillCategoria()
        dgvMarcas.DataSource = ds.Tables(0)
        dgvMarcas.Columns(0).Width = 70
        dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If XVN.Label3.Text = "Limitada" Then
            Button4.Enabled = False
            Button3.Enabled = False
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NuevaCategoria.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea ver o modificar la Categería?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objCatNE As New ClaseCategoria
            Dim objcatLN As New ArticulosLN
            Dim formModCat As New ModificarCategoria
            Dim idCategoria As Integer
            Dim ds As New DataSet
            If dgvMarcas.CurrentRow.Selected = True Then
                idCategoria = Me.dgvMarcas.CurrentRow.Cells(0).Value
                ds = objcatLN.buscaridCate(idCategoria)
                ModificarCategoria.TextBox1.Text = ds.Tables(0).Rows(0).Item(0).ToString
                ModificarCategoria.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
            End If
            ModificarCategoria.idCategoria = idCategoria
            ModificarCategoria.TextBox1.Enabled = False
            ModificarCategoria.Show()
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        Dim ds As New DataSet
        ds = objCatg.cargaGrillCategoria()
        dgvMarcas.DataSource = ds.Tables(0)
        dgvMarcas.Columns(0).Width = 70
        dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text <> "" Then
            Dim ds As New DataSet
            ds = objCatg.busquedaCategorCOD(TextBox2.Text, TextBox1.Text)
            dgvMarcas.DataSource = ds.Tables(0)
            dgvMarcas.Columns(0).Width = 70
            dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If TextBox1.Text <> "" And TextBox2.Text = "" Then
            Dim ds As New DataSet
            ds = objCatg.busquedaCategorDEscr(TextBox1.Text)
            dgvMarcas.DataSource = ds.Tables(0)
            dgvMarcas.Columns(0).Width = 70
            dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If TextBox2.Text = "" And TextBox1.Text = "" Then
            Dim ds As New DataSet
            ds = objCatg.cargaGrillCategoria()
            dgvMarcas.DataSource = ds.Tables(0)
            dgvMarcas.Columns(0).Width = 70
            dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub
End Class