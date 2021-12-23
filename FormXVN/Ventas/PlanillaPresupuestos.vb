Imports CapaLN
Imports CapaNE
Public Class PlanillaPresupuestos
    Private Sub PlanillaPresupuestos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim objPrLN As New PresupuestosLN
        ds = objPrLN.cargaGrilla()
        dgvCompra.DataSource = ds.Tables(0)
        dgvCompra.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompra.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompra.Columns(5).Visible = False
        For Each dgv As DataGridViewRow In dgvCompra.Rows
            If dgv.Cells(5).Value = 1 Then
                dgv.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NuevoPresupuestos.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim numPR As Integer
        Dim objPr As New PresupuestosLN
        Dim objIPR As New PresupuestosLN
        numPR = dgvCompra.CurrentRow.Cells(1).Value
        ds = objPr.detallePresupuesto(numPR)
        ds2 = objIPR.detalleItemPresupuesto(numPR)
        DetallePresupuesto.txtNombre.Text = ds.Tables(0).Rows(0).Item(0).ToString
        DetallePresupuesto.TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString
        DetallePresupuesto.dtpFecIng.Value = ds.Tables(0).Rows(0).Item(2).ToString
        DetallePresupuesto.TextBox5.Text = ds.Tables(0).Rows(0).Item(3).ToString
        DetallePresupuesto.Label8.Text = ds.Tables(0).Rows(0).Item(4).ToString
        If ds.Tables(0).Rows(0).Item(5) = 1 Then
            DetallePresupuesto.Label6.Visible = True
            DetallePresupuesto.Button7.Visible = False
        Else
            DetallePresupuesto.Label6.Visible = False
            DetallePresupuesto.Button7.Visible = True
        End If
        DetallePresupuesto.DataGridView1.DataSource = ds2.Tables(0)


        DetallePresupuesto.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet
        Dim objPRLN As New PresupuestosLN
        Dim fechadesde As String
        Dim fechahasta As String
        Dim anulado As Integer = 0
        If CheckBox2.Checked = True Then
            anulado = 1
        Else
            anulado = 0
        End If

        If CheckBox1.Checked = True Then

            fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
                fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
            ds = objPRLN.cargaGrillafechas(fechadesde, fechahasta, TxtBuscar.Text, TextBox1.Text, anulado)
            dgvCompra.DataSource = ds.Tables(0)
                dgvCompra.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCompra.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCompra.Columns(5).Visible = False
            For Each dgv As DataGridViewRow In dgvCompra.Rows
                If dgv.Cells(5).Value = 1 Then
                    dgv.DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        Else
                fechadesde = ""
            fechahasta = ""
            ds = objPRLN.cargaGrillafechas(fechadesde, fechahasta, TxtBuscar.Text, TextBox1.Text, anulado)
            dgvCompra.DataSource = ds.Tables(0)
            dgvCompra.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCompra.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCompra.Columns(5).Visible = False
            For Each dgv As DataGridViewRow In dgvCompra.Rows
                If dgv.Cells(5).Value = 1 Then
                    dgv.DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        End If


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ds As New DataSet
        Dim objPrLN As New PresupuestosLN
        ds = objPrLN.cargaGrilla()
        dgvCompra.DataSource = ds.Tables(0)
        dgvCompra.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompra.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        dgvCompra.Columns(5).Visible = False
        For Each dgv As DataGridViewRow In dgvCompra.Rows
            If dgv.Cells(5).Value = 1 Then
                dgv.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True

        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            DateTimePicker1.Value = Now
            DateTimePicker2.Value = Now
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ds As New DataSet
        Dim dsVOT As New DataSet
        Dim objPR As New PresupuestosLN
        ds = objPR.vinculosPR(dgvCompra.CurrentRow.Cells(1).Value)
        If ds.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("No es posible anular el Presupuesto ya que tiene comprobantes asociados")
        Else
            Dim dsanulado As New DataSet
            dsanulado = objPR.buscarPRanulado(dgvCompra.CurrentRow.Cells(1).Value)
            If dsanulado.Tables(0).Rows(0).Item(0) = 1 Then
                MessageBox.Show("El presupuesto ya se encuentra anulado")
            Else
                Dim resp As Integer
            resp = MessageBox.Show(" Confirma la anulación del presupuesto?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = vbYes Then

                objPR.modificarPRAnulado(dgvCompra.CurrentRow.Cells(1).Value)
                    dsVOT = objPR.vinculosPROT(dgvCompra.CurrentRow.Cells(1).Value)
                    If dsVOT.Tables(0).Rows.Count > 0 Then
                        objPR.ModificarvinculosPRInactivoOT(dgvCompra.CurrentRow.Cells(1).Value)
                        MessageBox.Show("El presupuesto fue anulado y se liberó la Orden de trabajo " & dsVOT.Tables(0).Rows(0).Item(3) & "")
                    Else
                        MessageBox.Show("El presupuesto fue anulado ")
                    End If
                End If

            End If

        End If

    End Sub
End Class