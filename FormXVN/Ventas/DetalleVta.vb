Imports CapaNE
Imports CapaLN
Public Class DetalleVta
    Public idVentaa As Integer
    Public idItemVenta As Integer
    Private Sub DetalleVta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim ds As New DataSet
        'Dim objCobro As New CobrosLN
        'If ds.Tables.Count > 0 Then
        '    If ds.Tables(0).Rows(0).Item(0) = 0 Then
        '        BtnNuevo.Visible = False
        '    Else

        '        BtnNuevo.Visible = True
        '    End If
        'End If
        Label6.Visible = False
        ComboBox1.Visible = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox5.Enabled = False
        txtNombre.Enabled = False
        txtNumDoc.Enabled = False
        dtpFecIng.Enabled = False
        DataGridView1.Enabled = False
        DataGridView1.Columns(0).Width = 400
        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim ds As New DataSet
        Dim objPR As New PresupuestosLN
        ds = objPR.VinculosPRFactura(Replace(txtNumDoc.Text, "-", ""), TextBox2.Text)
        If ds.Tables(0).Rows.Count > 0 Then
            Label6.Visible = True
            ComboBox1.Visible = True
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.DisplayMember = "comprobante"
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Else
            Label6.Visible = False
            ComboBox1.Visible = False
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Cobro.TextBox1.Text = TextBox5.Text
        Cobro.DetalleFac = 1
        Cobro.Show()
    End Sub
End Class