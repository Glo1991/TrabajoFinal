Imports CapaLN
Imports CapaNE
Public Class PuntoVenta
    Dim objPtoVenta As New VentasLN
    Private Sub PuntoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicio()
    End Sub
    Public Sub inicio()
        Dim ds As New DataSet
        Dim objPtoVenta As New VentasLN
        ds = objPtoVenta.CargarGrillaPtoVenta()
        dgvMarcas.DataSource = ds.Tables(0)
        dgvMarcas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If XVN.Label3.Text = "Limitada" Then
            Button4.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AgregarPtoVenta.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ds As New DataSet
        Dim activo As String
        Dim prodefecto As String
        ds = objPtoVenta.seleccionarPtoVenta(dgvMarcas.CurrentRow.Cells(0).Value)

        If ds.Tables(0).Rows.Count > 0 Then
            ModificarPuntoVenta.TextBox1.Text = dgvMarcas.CurrentRow.Cells(0).Value
            If dgvMarcas.CurrentRow.Cells(1).Value = "SI" Then
                ModificarPuntoVenta.CheckBox1.Checked = True
            Else
                ModificarPuntoVenta.CheckBox1.Checked = False
            End If
            If dgvMarcas.CurrentRow.Cells(2).Value = "SI" Then
                ModificarPuntoVenta.CheckBox2.Checked = True
            Else
                ModificarPuntoVenta.CheckBox2.Checked = False
            End If
        End If
        ModificarPuntoVenta.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class