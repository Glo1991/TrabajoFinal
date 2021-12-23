Imports CapaNE
Imports CapaLN
Public Class VerOrdenTRab
    Public idAlumnaaa As Integer
    Public idOrdTrabajoo As Integer
    Public tipoCompOT As String
    Dim objOrdTRLN As New OrdenDeTrabajoLN
    Private Sub VerOrdenTRab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label18.Visible = False
        ComboBox1.Visible = False
        Dim ds As New DataSet
        ds = objOrdTRLN.cargarGrillaCbioEstOT(idOrdTrabajoo)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(2).Width = 370
        tipoCompOT = "OT"
        Dim dsvinc As New DataSet
        Dim objPrLN As New PresupuestosLN
        dsvinc.Tables.Clear()
        dsvinc = objPrLN.CargarPresupuestoVinculoOT(idOrdTrabajoo)
        If dsvinc.Tables(0).Rows.Count > 0 Then
            Button2.Visible = False
            Button1.Visible = True
        Else
            Button2.Visible = True
            Button1.Visible = False

        End If
        Dim dsv As New DataSet
        Dim objOT As New OrdenDeTrabajoLN
        dsv = objOT.vinculoPROT(TextBox1.Text)
        If dsv.Tables(0).Rows.Count > 0 Then
            Label18.Visible = True
            ComboBox1.Visible = True
            ComboBox1.DataSource = dsv.Tables(0)
            ComboBox1.DisplayMember = "comprobante"
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Else
            Label18.Visible = False
            ComboBox1.Visible = False
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
        BuscarOrdTrab.CambioColorGRilla()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ds As New DataSet
        Dim objCliente As New OrdenDeTrabajoLN
        ds = objCliente.buscarIdCliene(idAlumnaaa)
        NuevoPresupuestos.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString + " " + ds.Tables(0).Rows(0).Item(2).ToString
        NuevoPresupuestos.TextBox1.Text = ds.Tables(0).Rows(0).Item(4).ToString
        NuevoPresupuestos.idOrdTrabajoo = idOrdTrabajoo
        NuevoPresupuestos.tipoCompOT = tipoCompOT
        NuevoPresupuestos.idAlumnaaa = idAlumnaaa
        NuevoPresupuestos.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        Dim objOTLN As New PresupuestosLN
        ds = objOTLN.CargarPresupuestoVinculoOT(idOrdTrabajoo)
        ds1 = objOTLN.CargarItemVinculoOT(ds.Tables(0).Rows(0).Item(2).ToString)
        DetallePresupuesto.txtNombre.Text = ds.Tables(0).Rows(0).Item(0).ToString + " " + ds.Tables(0).Rows(0).Item(1).ToString
        DetallePresupuesto.TextBox1.Text = ds.Tables(0).Rows(0).Item(4).ToString
        DetallePresupuesto.Label8.Text = ds.Tables(0).Rows(0).Item(2).ToString
        DetallePresupuesto.TextBox5.Text = ds.Tables(0).Rows(0).Item(3).ToString
        If ds.Tables(0).Rows(0).Item(6) = 1 Then
            DetallePresupuesto.Label6.Visible = True
        Else
            DetallePresupuesto.Label6.Visible = False
        End If
        'DetallePresupuesto.Label8.Text = ds.Tables(0).Rows(0).Item(4).ToString
        DetallePresupuesto.DataGridView1.DataSource = ds1.Tables(0)
        DetallePresupuesto.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ReportOT2.Show()
    End Sub
End Class