Imports CapaNE
Imports CapaLN
Public Class Compras
    Dim objCompraLN As New ComprasLN
    Dim objCompraNe As New ClaseCompras
    Private Sub Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objCompraLN.cargaGrilla()
        dgvCompra.DataSource = ds.Tables(0)

        inicio()
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        Button1.Enabled = False
        If XVN.Label3.Text = "Limitada" Then
            Button6.Enabled = False

        End If
    End Sub
    Sub inicio()
        For Each dgv As DataGridViewRow In dgvCompra.Rows
            If dgv.Cells(7).Value = 1 Then
                dgv.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
        dgvCompra.Columns(6).Visible = False
        dgvCompra.Columns(7).Visible = False
        dgvCompra.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompra.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        RegistrarCompra.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim objCompraLN As New ComprasLN
        Dim objCompraNe As New ClaseCompras
        Dim idCompra As Integer
        Dim numFAct As Long
        Dim ds As New DataSet
        Dim dsItem As New DataSet
        If dgvCompra.CurrentRow.Selected = True Then
            idCompra = Me.dgvCompra.CurrentRow.Cells(6).Value
            ds = objCompraLN.buscaridCompra(idCompra)
            'busca bien id compra pero no trae ningun valor VER
            CompraDetalle.dtpFecIng.Text = ds.Tables(0).Rows(0).Item(0).ToString
            CompraDetalle.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
            CompraDetalle.TextBox1.Text = ds.Tables(0).Rows(0).Item(2).ToString
            CompraDetalle.txtNumDoc.Text = ds.Tables(0).Rows(0).Item(3).ToString
            CompraDetalle.TextBox2.Text = ds.Tables(0).Rows(0).Item(6).ToString
            numFAct = ds.Tables(0).Rows(0).Item(3).ToString()
            CompraDetalle.TextBox5.Text = ds.Tables(0).Rows(0).Item(4).ToString
            dsItem = objCompraLN.buscarNumFact(numFAct)
        End If

        CompraDetalle.DataGridView1.DataSource = dsItem.Tables(0)
        CompraDetalle.idCompraa = idCompra
        CompraDetalle.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim objComprLN As New ComprasLN
        Dim objComprkNe As New ClaseCompras
        Dim objComprkNe2 As New ClaseCompras
        Dim FechaIngreso1 As String
        Dim FechaIngreso As String
        FechaIngreso1 = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        FechaIngreso = DateTimePicker2.Value.ToString("yyyy-MM-dd")


        ds = objCompraLN.buscarFechasGrilla(FechaIngreso1, FechaIngreso)
        dgvCompra.DataSource = ds.Tables(0)
        inicio()


    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Dim ds As DataSet
        Dim objComprLN As New ComprasLN
        Dim objComprkNe As New ClaseStock

        If CboCampo.SelectedItem = "Nombre/Razón Social" And TxtBuscar.Text <> "" Then

            ds = objCompraLN.buscarNomdeProvGrilla(TxtBuscar.Text)
            dgvCompra.DataSource = ds.Tables(0)
            inicio()

        End If
        If CboCampo.SelectedItem = "N° de Factura" And TxtBuscar.Text <> "" Then

            ds = objCompraLN.buscarNumFactGrilla(TxtBuscar.Text)
            dgvCompra.DataSource = ds.Tables(0)
            inicio()
        End If
        If CboCampo.SelectedItem = "CUIT" And TxtBuscar.Text <> "" Then

            ds = objCompraLN.buscarNumdeCuitGrilla(TxtBuscar.Text)
            dgvCompra.DataSource = ds.Tables(0)
            inicio()
        End If
     
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ds As New DataSet
        ds = objCompraLN.cargaGrilla()
        dgvCompra.DataSource = ds.Tables(0)
        'dgvCompra.Columns(4).Visible = False
        CboCampo.Text = "Seleccione"
        TxtBuscar.Clear()
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        TxtBuscar.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        inicio()
    End Sub

    Private Sub CboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCampo.SelectedIndexChanged
        If CboCampo.SelectedItem = "Fecha" Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
            TxtBuscar.Enabled = False
            Button1.Enabled = True
        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            TxtBuscar.Enabled = True
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim objCompraLN As New ComprasLN
        Dim objCompraNe As New ClaseCompras
        Dim idCompra As Integer
        Dim numFAct As Long
        Dim ds As New DataSet
        Dim dsItem As New DataSet
        Dim dsanulado As New DataSet
        idCompra = Me.dgvCompra.CurrentRow.Cells(6).Value
        dsanulado = objCompraLN.buscarAnulado(idCompra)

        If dgvCompra.CurrentRow.Selected = True Then
            idCompra = Me.dgvCompra.CurrentRow.Cells(6).Value
            ds = objCompraLN.buscaridCompra(idCompra)
            'busca bien id compra pero no trae ningun valor VER
            CompraDetalle.dtpFecIng.Text = ds.Tables(0).Rows(0).Item(0).ToString
            CompraDetalle.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
            CompraDetalle.TextBox1.Text = ds.Tables(0).Rows(0).Item(2).ToString
            CompraDetalle.txtNumDoc.Text = ds.Tables(0).Rows(0).Item(3).ToString
            CompraDetalle.TextBox2.Text = ds.Tables(0).Rows(0).Item(6).ToString
            numFAct = ds.Tables(0).Rows(0).Item(3).ToString()
            CompraDetalle.TextBox5.Text = ds.Tables(0).Rows(0).Item(4).ToString
            dsItem = objCompraLN.buscarNumFact(numFAct)
        End If

        CompraDetalle.DataGridView1.DataSource = dsItem.Tables(0)
        CompraDetalle.idCompraa = idCompra
        CompraDetalle.Show()
        If dsanulado.Tables(0).Rows(0).Item(0) = 1 Then
            MessageBox.Show("El comprobante se encuentra anulado")
        Else

            Dim resp As Integer
            resp = MessageBox.Show("¿Desea Anular el Comprobante?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = vbYes Then
                Dim objCSStockNE As New ClaseCorreccionStock
                Dim objCSStockLN As New StockLN

                Dim objStockNE As New ClaseStock

                For Each dgv As DataGridViewRow In CompraDetalle.DataGridView1.Rows
                    objCSStockNE.idarticulo = dgv.Cells(4).Value
                    objCSStockNE.Ingeso = 0
                    objCSStockNE.Egreso = (-dgv.Cells(1).Value)
                    objCSStockNE.Descripcion = "Egreso por Anulación de comprobante: " & CompraDetalle.txtNumDoc.Text & ", Proveedor " & CompraDetalle.txtNombre.Text
                    objCSStockNE.fechamodificacion = Now
                    objCSStockLN.InsertarCorreccionStock(objCSStockNE)
                Next
                For Each dgv As DataGridViewRow In CompraDetalle.DataGridView1.Rows
                    Dim stock2 As Integer
                    stock2 = (-dgv.Cells(1).Value)
                    Dim idarticulo As Integer
                    idarticulo = dgv.Cells(4).Value
                    objCompraLN.modificarStock(idarticulo, stock2)
                Next
                Dim comprasNE As New ClaseCompras
                Dim comprasLN As New ComprasLN
                objCompraNe.idCompra = idCompra
                objCompraLN.modificarAnulado(objCompraNe)

                Me.Close()
                Dim ds5 As New DataSet
                ds5 = objCompraLN.cargaGrilla()
                dgvCompra.DataSource = ds.Tables(0)
                dgvCompra.Columns(6).Visible = False
                dgvCompra.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvCompra.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        End If
    End Sub
End Class