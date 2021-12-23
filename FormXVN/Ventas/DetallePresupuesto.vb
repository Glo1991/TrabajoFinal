Imports CapaLN
Public Class DetallePresupuesto
    Public bfactura As Integer
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub DetallePresupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.ClearSelection()
        'DataGridView1.Columns(6).Visible = False
        For Each dgv As DataGridViewRow In DataGridView1.Rows

            Dim dscosto As New DataSet
            Dim objartln As New VentasLN
            dscosto = objartln.BuscarCostoArticulo(dgv.Cells(6).Value)
            'If dscosto.Tables(0).Rows.Count > 0 Then

            If dgv.Cells(5).Value = "Articulo" Then
                    If dgv.Cells(2).Value < dscosto.Tables(0).Rows(0).Item(0) Then
                        dgv.DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
            'End If
        Next
        dtpFecIng.Enabled = False
        txtNombre.Enabled = False
        TextBox1.Enabled = False
        TextBox5.Enabled = False
        Label2.Visible = False
        DataGridView1.Columns(0).Width = 400
        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(6).Visible = False
        ComboBox1.Visible = False
        Dim ds As New DataSet
        Dim objpr As New PresupuestosLN
        ds = objpr.VinculosFacturaPresupuestp(Label8.Text)
        If ds.Tables(0).Rows.Count > 0 Then
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.DisplayMember = "comprobante"
            ComboBox1.Visible = True
            Label2.Visible = True
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Else
            ComboBox1.Visible = False
            Label2.Visible = False
        End If

        'Me.ReportViewer1.RefreshReport
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ReportePresupuesto.Show()
    End Sub
End Class