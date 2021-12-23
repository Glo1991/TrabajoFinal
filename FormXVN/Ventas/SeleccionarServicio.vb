Imports CapaLN
Imports CapaNE
Public Class SeleccionarServicio
    Public esfactura As Integer
    Private Sub SeleccionarServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim objServicio As New ServiciosLN
        ds = objServicio.crgarGrillaServi()
        dgvPrecios.DataSource = ds.Tables(0)
        inicio()
        If XVN.Label3.Text = "Limitada" Then
            Button4.Enabled = False
            Button3.Enabled = False
        End If
    End Sub
    Sub inicio()

        dgvPrecios.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPrecios.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPrecios.Columns(1).Width = 70
        dgvPrecios.Columns(2).Width = 90
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AgregarServicio.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea modificar el Servicio?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim ds As New DataSet
        Dim objServicio As New ServiciosLN
        Dim idServicio As Integer
        If resp = vbYes Then
            If dgvPrecios.CurrentRow.Selected = True Then
                idServicio = Me.dgvPrecios.CurrentRow.Cells(1).Value
                ds = objServicio.buscarIDServicio(idServicio)
                ModificarServicio.txtCodigo.Text = ds.Tables(0).Rows(0).Item(0).ToString
                ModificarServicio.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
                ModificarServicio.TextBox1.Text = ds.Tables(0).Rows(0).Item(2).ToString
            End If
            ModificarServicio.txtCodigo.Enabled = False
            ModificarServicio.Show()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim objServicioLN As New ServiciosLN
        Dim ds As New DataSet
        If esfactura = 1 Then

            ds = objServicioLN.buscarIDServicio(dgvPrecios.CurrentRow.Cells(1).Value)
            RegistrarVenta.TextBox7.Text = ds.Tables(0).Rows(0).Item(1).ToString
            RegistrarVenta.TextBox4.Text = ds.Tables(0).Rows(0).Item(0).ToString
            RegistrarVenta.TextBox6.Text = ds.Tables(0).Rows(0).Item(2).ToString
            Me.Close()
        Else

            ds = objServicioLN.buscarIDServicio(dgvPrecios.CurrentRow.Cells(1).Value)
            NuevoPresupuestos.TextBox4.Text = ds.Tables(0).Rows(0).Item(0).ToString
            NuevoPresupuestos.TextBox2.Text = ds.Tables(0).Rows(0).Item(1).ToString
            NuevoPresupuestos.TextBox3.Text = ds.Tables(0).Rows(0).Item(2).ToString
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class