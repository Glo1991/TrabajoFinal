Imports CapaNE
Imports CapaLN
Public Class Ventas
    Dim objVentasLN As New VentasLN
    Dim objVentasNe As New ClaseVentas
    Dim fechadesde As String
    Dim fechahasta As String
    Private Sub Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objVentasLN.cargaGrilla()
        dgvCompra.DataSource = ds.Tables(0)

        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        inicio()
        If XVN.Label3.Text = "Limitada" Then
            Button6.Enabled = False

        End If

    End Sub
    Sub inicio()
        For Each dgv As DataGridViewRow In dgvCompra.Rows
            If dgv.Cells(5).Value = 1 Then
                dgv.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
        dgvCompra.Columns(5).Visible = False
        dgvCompra.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        RegistrarVenta.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim objVentasLN As New VentasLN
        'Dim objVentasNe As New ClaseVentas
        Dim tipocom As String
        Dim numFAct As String
        Dim ds As New DataSet
        Dim dsItem As New DataSet
        If dgvCompra.CurrentRow.Selected = True Then
            tipocom = Me.dgvCompra.CurrentRow.Cells(1).Value
            numFAct = Me.dgvCompra.CurrentRow.Cells(2).Value
            ds = objVentasLN.buscaridVenta(tipocom, numFAct)
            'busca bien id compra pero no trae ningun valor VER
            DetalleVta.dtpFecIng.Text = ds.Tables(0).Rows(0).Item(5).ToString
            DetalleVta.txtNombre.Text = ds.Tables(0).Rows(0).Item(0).ToString
            DetalleVta.TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString
            DetalleVta.txtNumDoc.Text = ds.Tables(0).Rows(0).Item(3).ToString
            DetalleVta.TextBox2.Text = ds.Tables(0).Rows(0).Item(2).ToString
            DetalleVta.TextBox5.Text = ds.Tables(0).Rows(0).Item(4).ToString
            If ds.Tables(0).Rows(0).Item(6) = 1 Then
                DetalleVta.Label7.Visible = True
            Else
                DetalleVta.Label7.Visible = False
            End If
            dsItem = objVentasLN.buscarNumComprob(tipocom, numFAct)
        End If
        Dim ds2 As New DataSet
        Dim objc As New CobrosLN
        ds2 = objc.buscarpagado(Me.dgvCompra.CurrentRow.Cells(2).Value, Me.dgvCompra.CurrentRow.Cells(1).Value)
        'para ver o no el boton de cobros
        If (ds2.Tables(0).Rows(0).Item(0) = 1 Or ds.Tables(0).Rows(0).Item(6) = 1) Then
            DetalleVta.BtnNuevo.Visible = False
        Else
            DetalleVta.BtnNuevo.Visible = True
        End If
        DetalleVta.DataGridView1.DataSource = dsItem.Tables(0)
        'DetalleVta.idVentaa = idVenta
        DetalleVta.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim objVentasLN As New VentasLN
        Dim objVentasNe As New ClaseVentas
        Dim anulado As Integer = 0

        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        If CheckBox2.Checked = True Then
            anulado = 1
        Else
            anulado = 0
        End If
        If CheckBox1.Checked = True Then

            fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
            fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
            ds = objVentasLN.buscarFechasGrillaVta(fechadesde, fechahasta, ComboBox1.Text, TxtBuscar.Text, anulado)
            dgvCompra.DataSource = ds.Tables(0)
            inicio()
        Else

            fechadesde = ""
            fechahasta = ""
            ds = objVentasLN.buscarFechasGrillaVta(fechadesde, fechahasta, ComboBox1.Text, TxtBuscar.Text, anulado)
            dgvCompra.DataSource = ds.Tables(0)
            inicio()
        End If


    End Sub

    Private Sub CboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    If CboCampo.SelectedItem = "Fecha" Then
        '        DateTimePicker1.Enabled = True
        '        DateTimePicker2.Enabled = True
        '        TxtBuscar.Enabled = False
        '        Button1.Enabled = True
        '    Else
        '        DateTimePicker1.Enabled = False
        '        DateTimePicker2.Enabled = False
        '        TxtBuscar.Enabled = True
        '        Button1.Enabled = False
        '    End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Dim ds As DataSet
        Dim objVentasLN As New VentasLN


        'If CboCampo.SelectedItem = "Cliente" And TxtBuscar.Text <> "" Then

        '    ds = objVentasLN.buscarNomClienGrilla(TxtBuscar.Text)
        '    dgvCompra.DataSource = ds.Tables(0)


        'End If
        'If CboCampo.SelectedItem = "N° de Comprobante" And TxtBuscar.Text <> "" Then

        '    'ds = objVentasLN.buscarNumComprGrilla(TxtBuscar.Text)
        '    dgvCompra.DataSource = ds.Tables(0)

        'End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Dim ds As New DataSet
        'ds = objVentasLN.cargaGrilla()
        'dgvCompra.DataSource = ds.Tables(0)
        Dim ds As New DataSet
        ds = objVentasLN.cargaGrilla()
        dgvCompra.DataSource = ds.Tables(0)
        dgvCompra.Columns(5).Visible = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        inicio()
    End Sub

    Private Sub dgvCompra_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellDoubleClick
        Dim objVentasLN As New VentasLN
        'Dim objVentasNe As New ClaseVentas
        Dim tipocom As String
        Dim numFAct As String
        Dim ds As New DataSet
        Dim dsItem As New DataSet
        If dgvCompra.CurrentRow.Selected = True Then
            tipocom = Me.dgvCompra.CurrentRow.Cells(1).Value
            numFAct = Me.dgvCompra.CurrentRow.Cells(2).Value
            ds = objVentasLN.buscaridVenta(tipocom, numFAct)
            'busca bien id compra pero no trae ningun valor VER
            DetalleVta.dtpFecIng.Value = ds.Tables(0).Rows(0).Item(5).ToString
            DetalleVta.txtNombre.Text = ds.Tables(0).Rows(0).Item(0).ToString
            DetalleVta.TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString
            DetalleVta.txtNumDoc.Text = ds.Tables(0).Rows(0).Item(3).ToString
            DetalleVta.TextBox2.Text = ds.Tables(0).Rows(0).Item(2).ToString
            DetalleVta.TextBox5.Text = ds.Tables(0).Rows(0).Item(4).ToString
            If ds.Tables(0).Rows(0).Item(6) = 1 Then
                DetalleVta.Label7.Visible = True
            Else
                DetalleVta.Label7.Visible = False
            End If
            dsItem = objVentasLN.buscarNumComprob(tipocom, numFAct)
        End If
        Dim ds2 As New DataSet
        Dim objc As New CobrosLN
        ds2 = objc.buscarpagado(Me.dgvCompra.CurrentRow.Cells(2).Value, Me.dgvCompra.CurrentRow.Cells(1).Value)
        'para ver o no el boton de cobros
        If (ds2.Tables(0).Rows(0).Item(0) = 1 Or ds.Tables(0).Rows(0).Item(6) = 1) Then
            DetalleVta.BtnNuevo.Visible = False
        Else
            DetalleVta.BtnNuevo.Visible = True
        End If
        DetalleVta.DataGridView1.DataSource = dsItem.Tables(0)
        'DetalleVta.idVentaa = idVenta
        DetalleVta.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim dscobro As New DataSet
        Dim obVentasln As New VentasLN
        Dim objVentaNe As New VentasLN
        dscobro = objVentasLN.buscarCobroFactura(dgvCompra.CurrentRow.Cells(1).Value, Replace((dgvCompra.CurrentRow.Cells(2).Value), "-", ""))
        If dscobro.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("No es posible anular la factura ya que tiene un cobro registrado")
        Else
            If dgvCompra.CurrentRow.Cells(5).Value = 1 Then
                MessageBox.Show("El comprobante ya se encuentra anulado")
            Else

                Dim resp As Integer
                resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = vbYes Then

                    '-------------------modificar cabeza a Anulado--------------------------
                    Dim dsanulada As New DataSet
                    objVentasLN.modificarFacturaAnulada(dgvCompra.CurrentRow.Cells(1).Value, Replace((dgvCompra.CurrentRow.Cells(2).Value), "-", ""))
                    '-------------------modificar cabeza a Anulado--------------------------

                    '---------------------insertamos correccion de stock--------
                    Dim dsCSanula As New DataSet
                    dsCSanula = objVentasLN.buscarItemAnulCS(dgvCompra.CurrentRow.Cells(1).Value, Replace((dgvCompra.CurrentRow.Cells(2).Value), "-", ""))
                    For Each dgv As DataRow In dsCSanula.Tables(0).Rows
                        'If dgv.Cells(5).Value = "Artículo" Then

                            Dim objCSNE As New ClaseCorreccionStock
                            Dim objCSLN As New StockLN
                        objCSNE.idarticulo = dgv.Item(3)
                        If dgv.Item(0) Like "F?" Then
                            objCSNE.Egreso = 0
                            objCSNE.Ingeso = dgv.Item(2)
                            objCSNE.Descripcion = "Ingreso por Anulación de Comprobante: " & dgv.Item(0) & " " & (dgvCompra.CurrentRow.Cells(2).Value) & ", Cliente " & dgv.Item(4)
                        Else
                            objCSNE.Ingeso = 0
                            objCSNE.Egreso = -1 * dgv.Item(2)
                            objCSNE.Descripcion = "Egreso por Anulación de Comprobante: " & dgv.Item(0) & " " & (dgvCompra.CurrentRow.Cells(2).Value) & ", Cliente " & dgv.Item(4)
                        End If

                            objCSNE.fechamodificacion = Now
                            objCSLN.InsertarCorreccionStock(objCSNE)
                        'End If
                    Next
                    '---------------------insertamos correccion de stock--------


                    'restamos stock--------------------------------------------  
                    For Each dgv As DataRow In dsCSanula.Tables(0).Rows

                        Dim objStock As New ComprasLN 'en compras ln esta la modifiaccion de stock
                            Dim cantidad As Double
                        If dgv.Item(0) Like "F?" Then
                            cantidad = dgv.Item(2)
                        Else
                            cantidad = dgv.Item(2)
                        End If
                            Dim idarticulo As Integer
                        idarticulo = dgv.Item(3)
                        objStock.modificarStock(idarticulo, cantidad)

                    Next

                    'restamos stock-------------------------------------------- 

                    'Modificar Vinculo PR-----------------------------------------
                    Dim dsvincPR As New DataSet
                    dsvincPR = objVentasLN.buscarVinculosPRModif(dgvCompra.CurrentRow.Cells(1).Value, Replace((dgvCompra.CurrentRow.Cells(2).Value), "-", ""))
                    If dsvincPR.Tables(0).Rows.Count > 0 Then
                        objVentasLN.modificarvinculoPRactiv(dgvCompra.CurrentRow.Cells(1).Value, Replace((dgvCompra.CurrentRow.Cells(2).Value), "-", ""))

                        'Modificar  PR Facturado-----------------------------------------
                        For Each dgv As DataRow In dsvincPR.Tables(0).Rows

                            Dim modif As New VentasLN
                            modif.modificarPRFacturadoAnulado(dgv.Item(3))
                            'Modificar  PR Facturado-----------------------------------------
                        Next
                    End If
                    'Modificar Vinculo PR-----------------------------------------
                    Dim ds As New DataSet
                    ds = objVentasLN.cargaGrilla()
                    dgvCompra.DataSource = ds.Tables(0)
                    dgvCompra.Columns(5).Visible = False
                    inicio()
                    MessageBox.Show("Se anuló el comprobante")
                End If
                End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        Else
            DateTimePicker1.Value = Now
            DateTimePicker2.Value = Now
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub
End Class