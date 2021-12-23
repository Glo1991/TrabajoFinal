Imports CapaNE
Imports CapaLN
Public Class BuscarOrdTrab
    Dim objORdTLN As New OrdenDeTrabajoLN
    Dim objORdTNE As New ClaseOrdenDeTRabajo
    Dim fechadesde As String
    Dim fechahasta As String
    Private Sub BuscarOrdTrab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objORdTLN.cargaGrilla()
        dgvAlumnas.DataSource = ds.Tables(0)
        dgvAlumnas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        CheckBox1.Checked = False
        CambioColorGRilla()
        SumaEquipos()
        MostrarAlerta()
        CheckBox1.Checked = False
        'If CheckBox1.Checked = False Then
        '    MaskedTextBox1.Enabled = False
        '    MaskedTextBox1.Enabled = False
        'End If
        'If XVN.Label3.Text = "Limitada" Then
        '    Button6.Enabled = False
        'End If
        cargarComboEstadoOT()

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OrdenDeTRabajo.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim metOT As New OrdenDeTrabajoLN
        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        If CheckBox1.Checked = False Then
            fechadesde = ""
            fechahasta = ""
        End If
        If ComboBox1.Text = "Seleccione" Then
            ComboBox1.SelectedValue = 0
        End If
        ds = metOT.cargarGrillaApellido(fechadesde, fechahasta, TextBox1.Text, ComboBox1.SelectedValue, TxtBuscar.Text)
        dgvAlumnas.DataSource = ds.Tables(0)
        dgvAlumnas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        CambioColorGRilla()
        SumaEquipos()
        MostrarAlerta()

    End Sub
    Sub cargarComboEstadoOT()
        Dim ds As DataSet
        Dim objEstadoOTkLN As New OrdenDeTrabajoLN
        Dim objEstadoOTkNE As New ClaseEstadoOT

        ds = New DataSet
        ds = objEstadoOTkLN.cargarComboEstadoOT(objEstadoOTkNE)
        ComboBox1.DataSource = ds.Tables("tabCat")
        ComboBox1.DisplayMember = "EstadoOT"
        ComboBox1.ValueMember = "idEstadoOT"
        ComboBox1.Text = "Seleccione"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea modificar estado de la Orden de Trabajo?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objAlumnaNE As New ClaseCliente
            Dim objAlumLN As New ClienteLN
            Dim formModAlum As New ModificarCliente
            Dim objORdTLN As New OrdenDeTrabajoLN
            Dim objORdTNE As New ClaseOrdenDeTRabajo
            Dim idAlumna As Integer
            Dim ds As New DataSet
            If dgvAlumnas.CurrentRow.Selected = True Then
                idAlumna = Me.dgvAlumnas.CurrentRow.Cells(3).Value
                ds = objORdTLN.buscarIdCliene(idAlumna)
                Modificar_Estado_OT.TextBox7.Text = ds.Tables(0).Rows(0).Item(1).ToString & " " & ds.Tables(0).Rows(0).Item(2).ToString
               
                Dim dsIdOT As New DataSet
                Dim dsIdESOT As New DataSet
                'Dim dsIdOT As New DataSet
                Dim idOrdT As Integer
                Dim cargador As String
                Dim bateria As String
                Dim funda As String
                Dim idEstOT As String
                idOrdT = Me.dgvAlumnas.CurrentRow.Cells(0).Value
                dsIdOT = objORdTLN.buscaridOT(idOrdT)
                Modificar_Estado_OT.TextBox1.Text = idOrdT
                Modificar_Estado_OT.DateTimePicker1.Value = dsIdOT.Tables(0).Rows(0).Item(2)
                Modificar_Estado_OT.TextBox2.Text = dsIdOT.Tables(0).Rows(0).Item(3)
                Modificar_Estado_OT.TextBox6.Text = dsIdOT.Tables(0).Rows(0).Item(4)

                idEstOT = dsIdOT.Tables(0).Rows(0).Item(10)
                dsIdESOT = objORdTLN.buscaridEStadoOT(idEstOT)
                Modificar_Estado_OT.ComboBox1.Text = dsIdESOT.Tables(0).Rows(0).Item(1)
                cargador = dsIdOT.Tables(0).Rows(0).Item(5)
                bateria = dsIdOT.Tables(0).Rows(0).Item(6)
                funda = dsIdOT.Tables(0).Rows(0).Item(7)


                If cargador = "SI" Then
                    Modificar_Estado_OT.CheckBox1.Checked = True
                Else
                    Modificar_Estado_OT.CheckBox1.Checked = False
                End If
                If bateria = "SI" Then
                    Modificar_Estado_OT.CheckBox2.Checked = True
                Else
                    VerOrdenTRab.CheckBox2.Checked = False
                End If
                If funda = "SI" Then
                    Modificar_Estado_OT.CheckBox5.Checked = True
                Else
                    Modificar_Estado_OT.CheckBox5.Checked = False
                End If
                If dsIdOT.Tables(0).Rows(0).Item(8) = "SI" Then
                    Modificar_Estado_OT.CheckBox4.Checked = True
                Else
                    Modificar_Estado_OT.CheckBox4.Checked = False
                End If
                If dsIdOT.Tables(0).Rows(0).Item(9) = "SI" Then
                    Modificar_Estado_OT.CheckBox3.Checked = True
                Else
                    Modificar_Estado_OT.CheckBox3.Checked = False
                End If
            End If
            Modificar_Estado_OT.idAlumnaaa = idAlumna
            Modificar_Estado_OT.TextBox2.Enabled = False
            Modificar_Estado_OT.DateTimePicker1.Enabled = False
            Modificar_Estado_OT.TextBox6.Enabled = False
            Modificar_Estado_OT.TextBox7.Enabled = False
            Modificar_Estado_OT.CheckBox1.Enabled = False
            Modificar_Estado_OT.CheckBox2.Enabled = False
            Modificar_Estado_OT.CheckBox3.Enabled = False
            Modificar_Estado_OT.CheckBox4.Enabled = False
            Modificar_Estado_OT.CheckBox5.Enabled = False
            Modificar_Estado_OT.TextBox1.Enabled = False
            Modificar_Estado_OT.Show()
        End If

    End Sub
    Public Sub CambioColorGRilla()
        For Each fila As DataGridViewRow In dgvAlumnas.Rows
            If fila.Cells(5).Value = "En Proceso" Then
                fila.DefaultCellStyle.BackColor = Color.Yellow
            End If
            If fila.Cells(5).Value = "Listo" Then
                fila.DefaultCellStyle.BackColor = Color.LawnGreen
            End If
            If fila.Cells(5).Value = "Esperando al Cliente" Then
                fila.DefaultCellStyle.BackColor = Color.LightBlue
            End If
            If fila.Cells(5).Value = "Sin Arreglo" Then
                fila.DefaultCellStyle.BackColor = Color.Red
            End If
            If fila.Cells(5).Value = "Entregado" Then
                fila.DefaultCellStyle.BackColor = Color.Violet
            End If
        Next
        txtAmarillo.Enabled = False
        txtCeleste.Enabled = False
        txtRojo.Enabled = False
        txtVerde.Enabled = False
        txtVioleta.Enabled = False
        dgvAlumnas.Columns(0).Width = 90
        dgvAlumnas.Columns(1).Width = 140
        dgvAlumnas.Columns(2).Width = 80
        dgvAlumnas.Columns(3).Width = 80
        dgvAlumnas.Columns(4).Width = 150
        dgvAlumnas.Columns(5).Width = 100

    End Sub
    Public Sub SumaEquipos()
        'Dim EspAlCl As String
        'Dim totEq As Integer
        Dim ds As DataSet
        ds = objORdTLN.estadoEntregar()
        If ds.Tables(0).Rows.Count > 0 Then
            lblCantEq.Text = ds.Tables(0).Rows(0).Item(0).ToString
        End If
        'For Each dgv As DataGridViewRow In dgvAlumnas.Rows
        '    EspAlCl = dgv.Cells(5).Value
        '    If EspAlCl = "Esperando al Cliente" Then
        '        totEq = totEq + 1
        '    End If
        'Next
        'lblCantEq.Text = totEq.ToString
    End Sub
    Public Sub MostrarAlerta()
        If lblCantEq.Text = 0 Then
            Label7.Visible = False
            Label9.Visible = False
            Button7.Visible = False
            lblCantEq.Visible = False
            Label10.Visible = True
            PictureBox1.Visible = False
        Else
            Label10.Visible = False
            Label7.Visible = True
            Label9.Visible = True
            Button7.Visible = True
            lblCantEq.Visible = True
            PictureBox1.Visible = True
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        EntregaDeEquipos.Show()
    End Sub

   
    Private Sub dgvAlumnas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvAlumnas.DoubleClick
            Dim objAlumnaNE As New ClaseCliente
            Dim objAlumLN As New ClienteLN
            Dim formModAlum As New ModificarCliente
            Dim objORdTLN As New OrdenDeTrabajoLN
            Dim objORdTNE As New ClaseOrdenDeTRabajo
            Dim idAlumna As Integer
            Dim idOrdT As Integer
            Dim ds As New DataSet
            If dgvAlumnas.CurrentRow.Selected = True Then
            idAlumna = Me.dgvAlumnas.CurrentRow.Cells(3).Value
            ds = objORdTLN.buscarIdCliene(idAlumna)

                VerOrdenTRab.TextBox7.Text = ds.Tables(0).Rows(0).Item(1).ToString & " " & ds.Tables(0).Rows(0).Item(2).ToString
                VerOrdenTRab.TextBox4.Text = ds.Tables(0).Rows(0).Item(5).ToString
                VerOrdenTRab.TextBox3.Text = ds.Tables(0).Rows(0).Item(6).ToString
                VerOrdenTRab.TextBox5.Text = ds.Tables(0).Rows(0).Item(7).ToString

                Dim dsIdOT As New DataSet


                Dim cargador As String
                Dim bateria As String
                Dim funda As String
                idOrdT = Me.dgvAlumnas.CurrentRow.Cells(0).Value
                dsIdOT = objORdTLN.buscaridOT(idOrdT)
                VerOrdenTRab.TextBox1.Text = idOrdT
                VerOrdenTRab.DateTimePicker1.Value = dsIdOT.Tables(0).Rows(0).Item(2)
                VerOrdenTRab.TextBox2.Text = dsIdOT.Tables(0).Rows(0).Item(3)
                VerOrdenTRab.TextBox6.Text = dsIdOT.Tables(0).Rows(0).Item(4)
                cargador = dsIdOT.Tables(0).Rows(0).Item(5)
                bateria = dsIdOT.Tables(0).Rows(0).Item(6)
                funda = dsIdOT.Tables(0).Rows(0).Item(7)


                If cargador = "SI" Then
                    VerOrdenTRab.CheckBox1.Checked = True
                Else
                    VerOrdenTRab.CheckBox1.Checked = False
                End If
                If bateria = "SI" Then
                    VerOrdenTRab.CheckBox2.Checked = True
                Else
                    VerOrdenTRab.CheckBox2.Checked = False
                End If
                If funda = "SI" Then
                    VerOrdenTRab.CheckBox5.Checked = True
                Else
                    VerOrdenTRab.CheckBox5.Checked = False
                End If
                If dsIdOT.Tables(0).Rows(0).Item(8) = "SI" Then
                    VerOrdenTRab.CheckBox4.Checked = True
                Else
                    VerOrdenTRab.CheckBox4.Checked = False
                End If
                If dsIdOT.Tables(0).Rows(0).Item(9) = "SI" Then
                    VerOrdenTRab.CheckBox3.Checked = True
                Else
                    VerOrdenTRab.CheckBox3.Checked = False
                End If
            End If
            VerOrdenTRab.idAlumnaaa = idAlumna
            VerOrdenTRab.idOrdTrabajoo = idOrdT
            VerOrdenTRab.TextBox1.Enabled = False
            VerOrdenTRab.TextBox2.Enabled = False
            VerOrdenTRab.DateTimePicker1.Enabled = False
            VerOrdenTRab.TextBox3.Enabled = False
            VerOrdenTRab.TextBox4.Enabled = False
            VerOrdenTRab.TextBox5.Enabled = False
            VerOrdenTRab.TextBox6.Enabled = False
            VerOrdenTRab.TextBox7.Enabled = False
            VerOrdenTRab.CheckBox1.Enabled = False
            VerOrdenTRab.CheckBox2.Enabled = False
            VerOrdenTRab.CheckBox3.Enabled = False
            VerOrdenTRab.CheckBox4.Enabled = False
            VerOrdenTRab.CheckBox5.Enabled = False
            VerOrdenTRab.Show()
    End Sub

    Private Sub dgvAlumnas_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAlumnas.ColumnHeaderMouseClick
        CambioColorGRilla()
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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            'If Asc(e.KeyChar) = 46 Then
            '    e.Handled = False   ' <<< Para que admita el punto.
            'End If

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ds As New DataSet
        TxtBuscar.Clear()
        TextBox1.Clear()
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        ds = objORdTLN.cargaGrilla()
        dgvAlumnas.DataSource = ds.Tables(0)
        dgvAlumnas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        CheckBox1.Checked = False
        CambioColorGRilla()
        SumaEquipos()
        MostrarAlerta()
        CheckBox1.Checked = False

        'If XVN.Label3.Text = "Limitada" Then
        '    Button6.Enabled = False
        'End If
        cargarComboEstadoOT()
    End Sub
End Class