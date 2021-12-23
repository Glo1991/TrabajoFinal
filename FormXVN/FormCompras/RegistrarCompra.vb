Imports CapaNE
Imports CapaLN

Public Class RegistrarCompra
    Public idStoock As Integer
    Public idAProv As Integer
    Dim numfac As String
    Dim cuit As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        BuscarProveedor.Show()
    End Sub

    Private Sub RegistrarCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox5.Enabled = False
        txtNombre.Enabled = False
        DataGridView1.AllowUserToAddRows = False
        'DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(0).Width = 250
        TextBox3.Select()

        parametros()
    End Sub
    Private Sub parametros()
        If txtNumDoc.Text = "" Then
            numfac = 0
        Else
            numfac = txtNumDoc.Text
        End If
        If TextBox1.Text = "" Then
            cuit = 0
        Else
            cuit = TextBox1.Text
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        BuscarProducto.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Seleccione un artículo")
        Else
            If NumericUpDown1.Value = 0 Then
                MessageBox.Show("Debe ingresar cantidad")
            Else
                If TextBox3.Text = "" Then
                    MessageBox.Show("Debe ingresar Precio")
                Else
                    DataGridView1.Rows.Add(TextBox2.Text, NumericUpDown1.Value, TextBox3.Text, Calculo_Importe, idStoock, idAProv, txtNumDoc.Text)
                    'DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(0).Width = 250
                    TextBox2.Clear()
                    NumericUpDown1.Value = 0
                    TextBox3.Clear()
                    Totalsuma()
                End If
            End If
        End If
    End Sub
    Function Calculo_Importe() As Double
        Dim Importe As Double
        Importe = NumericUpDown1.Value * TextBox3.Text
        Return Importe
    End Function
   
    Private Sub Totalsuma()
        Dim Total As Double
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            Total += Val(row.Cells(3).Value)
        Next
        Me.TextBox5.Text = Total.ToString("N2")
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar un Proveedor")
        Else

            If txtNumDoc.Text = "" Then
                MessageBox.Show("Debe ingresar un número de factura")
            Else

                If DataGridView1.RowCount < 1 Then
                        MessageBox.Show("Debe ingresarun artículo")
                    Else



                        Dim objCompraLN As New ComprasLN
                        Dim objCompaNe As New ClaseCompras

                        Dim objItemNe As New ClaseItem

                        Dim objStockLN As New StockLN
                        Dim objStockNE As New ClaseStock

                        Dim objPrecHistLN As New PreciosHistLN
                        Dim objPrecHistNe As New ClasePreciosHist

                        Dim objCSStockLN As New StockLN
                    Dim objCSStockNE As New ClaseCorreccionStock

                    Dim objArticuloLN As New ArticulosLN
                    Dim objarticuloNE As New ClaseArticulo

                    Dim idstock As Single
                        Dim stock2 As Single

                        Dim suma As Single

                        Dim resp As Integer
                        resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If resp = vbYes Then
                            'insertarCompras--Caabezacompras------------------------------
                            Dim idCompra As Integer
                            'objCompaNe = New ClaseCompras
                            objCompaNe.FechaIngreso = dtpFecIng.Value
                            objCompaNe.idProv = idAProv
                            objCompaNe.numFactura = txtNumDoc.Text
                            objCompaNe.total = TextBox5.Text
                        objCompaNe.tipoCom = ComboBox1.SelectedItem
                        objCompaNe.Anulado = 0

                        idCompra = objCompraLN.InsertarCompras(objCompaNe)
                        'Dim ds1 As New DataSet
                        'insertarCompras--Caabezacompras------------------------------

                        'insertarPrecioHistorico-------------------------------
                        For Each dvg As DataGridViewRow In DataGridView1.Rows

                            objPrecHistNe.PrecioHist = dvg.Cells(2).Value
                            objPrecHistNe.idProv = idAProv
                            objPrecHistNe.FechaPrecHist = dtpFecIng.Value
                            objPrecHistNe.idArticulo = dvg.Cells(4).Value
                            objPrecHistLN.InsertarPrecioHist(objPrecHistNe)

                        Next
                        'insertarPrecioHistorico-------------------------------

                        'InsertarITEM------------------------------------------------
                        For Each dvg As DataGridViewRow In DataGridView1.Rows
                                'agrega varios id de item asociado a un num de Factura
                                objItemNe.cantidad = dvg.Cells(1).Value
                                objItemNe.Precio = dvg.Cells(2).Value
                                objItemNe.Importe = dvg.Cells(3).Value
                                objItemNe.numFactura = txtNumDoc.Text
                                objItemNe.Articulo = dvg.Cells(4).Value
                                objItemNe.tipocomprobante = ComboBox1.SelectedItem
                                objCompraLN.InsertarItem(objItemNe)
                            Next
                            'InsertarITEM------------------------------------------------

                            'Actualizar costo----------------------------------------------
                            For Each dvg As DataGridViewRow In DataGridView1.Rows
                            If CheckBox1.Checked Then
                                objarticuloNE.idArticulo = dvg.Cells(4).Value
                                objarticuloNE.costo = dvg.Cells(2).Value
                                objArticuloLN.modificarCostoARt(objarticuloNE)

                            End If
                        Next
                        'Actualizar costo-------------------------------------------

                        'Actualizar Precio si TIPO PRECIO MARCA---------------------------
                        For Each dvg As DataGridViewRow In DataGridView1.Rows
                            If CheckBox1.Checked Then
                                objarticuloNE.idArticulo = dvg.Cells(4).Value
                                'objarticuloNE.costo = dvg.Cells(2).Value
                                objArticuloLN.ModificarCostoPRECIOArt(objarticuloNE)

                            End If
                        Next
                        'Actualizar Precio si TIPO PRECIO MARCA---------------------------

                        'metemos Correcciones de stock----------------------------------
                        For Each dgv As DataGridViewRow In DataGridView1.Rows
                            objCSStockNE.idarticulo = dgv.Cells(4).Value
                            If ComboBox1.Text Like "F?" Then
                                objCSStockNE.Ingeso = dgv.Cells(1).Value
                                objCSStockNE.Egreso = 0
                                objCSStockNE.Descripcion = "Ingreso por: " & ComboBox1.Text & " " & txtNumDoc.Text & ", Proveedor " & txtNombre.Text
                            Else
                                objCSStockNE.Ingeso = 0
                                objCSStockNE.Egreso = dgv.Cells(1).Value
                                objCSStockNE.Descripcion = "Egreso por: " & ComboBox1.Text & " " & txtNumDoc.Text & ", Proveedor " & txtNombre.Text

                            End If
                            objCSStockNE.fechamodificacion = Now
                            objCSStockLN.InsertarCorreccionStock(objCSStockNE)
                            Next
                        'metemos Correcciones de stock----------------------------------

                        'sumammos a stock------------------------------------------------
                        For Each dvg As DataGridViewRow In DataGridView1.Rows
                            Dim idarticulo As Integer
                            stock2 = dvg.Cells(1).Value
                            idArticulo = dvg.Cells(4).Value
                            'objStockNE.cantidad = suma + stock2
                            objCompraLN.modificarStock(idarticulo, stock2)
                        Next
                        'sumammos a stock------------------------------------------------

                        MsgBox("Los datos ingresados se guardaron Correctamente")
                            Dim ds As DataSet
                            Dim objComp As New ComprasLN

                            ds = objComp.cargaGrilla
                        Compras.dgvCompra.DataSource = ds.Tables(0)
                        Compras.dgvCompra.Columns(5).Visible = False
                        Compras.dgvCompra.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Compras.dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Compras.dgvCompra.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Me.Close()
                    End If

                End If
                End If
            End If


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Totalsuma()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtCel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoc.TextChanged
        txtNumDoc.MaxLength = 13
    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress, TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If
        End If
    End Sub

    Private Sub txtNumDoc_Leave(sender As Object, e As EventArgs) Handles txtNumDoc.Leave
        If txtNumDoc.TextLength < 13 Then
            MessageBox.Show("Debe ingresar un número de comprobante válido (5 dígitos para el punto de venta y 8 dígitos para el número de comprobante)")
            txtNumDoc.Clear()

        End If
        If txtNumDoc.TextLength = 13 Then
            Dim ds As New DataSet
            Dim obj As New ComprasLN
            parametros()
            ds = obj.ValidarNumComprobante(ComboBox1.Text, numfac, cuit)
            If ds.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("El comprobante ya fue cargado.")
                txtNumDoc.Clear()
            End If
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If ComboBox1.Text Like "F?" And NumericUpDown1.Value < 0 Then
            MsgBox("Debe ingresar una Cantidad válida para el tipo de comprobante")
            NumericUpDown1.Value = 0
        End If
        If ComboBox1.Text Like "NC?" And NumericUpDown1.Value > 0 Then
            MsgBox("Debe ingresar una Cantidad válida para el tipo de comprobante")
            NumericUpDown1.Value = 0
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        parametros()

        If ComboBox1.Text Like "NC?" Then
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
        Else
            CheckBox1.Enabled = True
        End If
        Dim ds As New DataSet
        Dim obj As New ComprasLN
        ds = obj.ValidarNumComprobante(ComboBox1.Text, numfac, cuit)
        If ds.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("El comprobante ya fue cargado.")
            txtNumDoc.Clear()
        End If
    End Sub
End Class