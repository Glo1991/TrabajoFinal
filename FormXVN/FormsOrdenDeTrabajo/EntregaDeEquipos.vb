Imports CapaNE
Imports CapaLN
Public Class EntregaDeEquipos
    Dim objORdTLN As New OrdenDeTrabajoLN
    Dim objORdTNE As New ClaseOrdenDeTRabajo
    Dim fechadesde As String
    Dim fechahasta As String
    Private Sub EntregaDeEquipos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objORdTLN.cargaGrillaEspCli()
        dgvAlumnas.DataSource = ds.Tables(0)
        CambioColorGRilla()
        CheckBox1.Checked = False
        If CheckBox1.Checked = False Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim metOT As New OrdenDeTrabajoLN
        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        If CboCampo.SelectedItem = "Apellido" And TxtBuscar.Text <> "" And CheckBox1.Checked = False Then
            ds = metOT.cargarGrillaApellidoEsperand(TxtBuscar.Text)
            dgvAlumnas.DataSource = ds.Tables(0)
            CambioColorGRilla()
        End If
        If CboCampo.SelectedItem = "Apellido" And TxtBuscar.Text <> "" And CheckBox1.Checked = True Then
            ds = metOT.cargarGrillaApellidoFechaEsperando(TxtBuscar.Text, fechadesde, fechahasta)
            dgvAlumnas.DataSource = ds.Tables(0)
            CambioColorGRilla()

        End If

        If CboCampo.SelectedItem = "N° de Orden de Trabajo" And TxtBuscar.Text <> "" And CheckBox1.Checked = False Then
            ds = metOT.cargarGrillaNumOTEsperand(TxtBuscar.Text)
            dgvAlumnas.DataSource = ds.Tables(0)
            CambioColorGRilla()
        End If

        If CboCampo.SelectedItem = "N° de Orden de Trabajo" And TxtBuscar.Text <> "" And CheckBox1.Checked = True Then
            ds = metOT.cargarGrillaNroOrdenFechaEsperand(TxtBuscar.Text, fechadesde, fechahasta)
            dgvAlumnas.DataSource = ds.Tables(0)
            CambioColorGRilla()
        End If


        If CheckBox1.Checked = True And TxtBuscar.Text = "" Then
            ds = metOT.cargarGrillaFechaEsperand(fechadesde, fechahasta)
            dgvAlumnas.DataSource = ds.Tables(0)
            CambioColorGRilla()
        End If
        If TxtBuscar.Text = "" And CheckBox1.Checked = False Then
            ds = objORdTLN.cargaGrillaEspCli()
            dgvAlumnas.DataSource = ds.Tables(0)
            CambioColorGRilla()
        End If
    End Sub
    Public Sub CambioColorGRilla()
        For Each fila As DataGridViewRow In dgvAlumnas.Rows
            If fila.Cells(5).Value = "Esperando al Cliente" Then
                fila.DefaultCellStyle.BackColor = Color.LightBlue
            End If

        Next
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim objEnEquipLN As New OrdenDeTrabajoLN
        Dim objEnEquipNE As New ClaseOrdenDeTRabajo
        Dim idOrdTr As Integer
        Dim ds As New DataSet
        If dgvAlumnas.CurrentRow.Selected = True Then
            idOrdTr = Me.dgvAlumnas.CurrentRow.Cells(0).Value
            ds = objEnEquipLN.buscarMail(idOrdTr)
            EnviarMail.TextBox1.Text = ds.Tables(0).Rows(0).Item(0).ToString
            
        End If
        EnviarMail.idOrdTrab = idOrdTr
        EnviarMail.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ds As New DataSet
        ds = objORdTLN.cargaGrillaEspCli()
        dgvAlumnas.DataSource = ds.Tables(0)
        CambioColorGRilla()
        CheckBox1.Checked = False
        If CheckBox1.Checked = False Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub
End Class