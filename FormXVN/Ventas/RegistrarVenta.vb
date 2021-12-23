Imports CapaNE
Imports CapaLN
Public Class RegistrarVenta
    Public idStoock As Integer
    Public idCliente As Integer
    Public esFactura As Integer = 1
    Public listaPR As New List(Of Integer)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        BuscarProducto.Show()
        BuscarProducto.numFactura = esFactura
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        BuscarClientePresupuesto.Show()
        BuscarClientePresupuesto.esfactura = 1

    End Sub

    Private Sub RegistrarVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox5.Enabled = False
        txtNombre.Enabled = False
        TextBox8.Enabled = False
        TextBox7.Enabled = False
        TextBox4.Enabled = False
        Dim ds As New DataSet
        Dim objV As New VentasLN
        ds = objV.puntoporDefecto()
        If ds.Tables(0).Rows.Count > 0 Then
            Dim ds2 As New DataSet
            ds2 = objV.MAXnumFactptoxdef

            MaskedTextBox1.Text = ds2.Tables(0).Rows(0).Item(0).ToString
        Else
            Dim ds3 As New DataSet
            ds3 = objV.MAXnumFactpto
            MaskedTextBox1.Text = ds3.Tables(0).Rows(0).Item(0).ToString
        End If


    End Sub
    Private Sub txtCel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.MaxLength = 13
    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'Condicional que evalua que la tecla pulsada sea un número 
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
            MessageBox.Show("Introduzca sólo valores númericos")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox8.Text = "" Then
            MessageBox.Show("Seleccione un Artículo")
        Else
            If NumericUpDown1.Value = 0 Then
                MessageBox.Show("Debe ingresar cantidad para el artículo")
            Else
                If TextBox3.Text = "" Then
                    MessageBox.Show("Debe ingresar Precio para el artículo")
                Else
                    Dim dscosto As New DataSet
                    Dim objVentaln As New VentasLN
                    dscosto = objVentaln.BuscarCostoArticulo(TextBox8.Text)
                    If dscosto.Tables.Count > 0 Then
                        If dscosto.Tables(0).Rows(0).Item(0) > TextBox3.Text Then
                            MessageBox.Show("El Costo del artículo es mayor al precio de Venta. Verificar por favor")
                        Else
                            DataGridView1.Rows.Add(TextBox2.Text, NumericUpDown1.Value, TextBox3.Text, Calculo_Importe, TextBox8.Text, "Artículo")
                            'DataGridView1.Columns(4).Visible = False
                            DataGridView1.Columns(0).Width = 250
                            TextBox2.Clear()
                            NumericUpDown1.Value = 0
                            TextBox3.Clear()
                            TextBox8.Clear()
                            Totalsuma()
                        End If

                    End If
                End If
            End If
        End If
    End Sub
    Function Calculo_Importe() As Double
        Dim Importe As Double
        Importe = NumericUpDown1.Value * TextBox3.Text
        Return Importe
    End Function

    Public Sub Totalsuma()
        Dim Total As Double
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            Total += Val(row.Cells(3).Value)
        Next
        Me.TextBox5.Text = Total.ToString("N2")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Totalsuma()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim objVentaLN As New VentasLN
        Dim objVentaNe As New ClaseVentas
        Dim objItemVtaNe As New ClaseItemVenta
        Dim objStockLN As New StockLN
        Dim objStockNE As New ClaseStock
        'aqui agregaamos los datos del precio
        '-----------------------------------
        Dim objPrecLN As New PreciosLN
        Dim objPrecNe As New ClasePrecios
        Dim objPrecHistLN As New PreciosHistLN
        Dim objPrecHistNe As New ClasePreciosHist
        '---------------------------------
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe seleccionar un Cliente")
        Else
            If MaskedTextBox1.Text = 0 Then
                MessageBox.Show("Debe ingresar un Número de comprobante")
            Else

                If MaskedTextBox1.Text < 100000000 Then
                    MessageBox.Show("Debe ingresar un Número de comprobante válido")


                Else
                    If DataGridView1.Rows.Count = 0 Then
                        MessageBox.Show("Debe agregar artículos/servicios ")
                    Else


                        Dim resp As Integer
                        resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If resp = vbYes Then
                            If CheckBox1.Checked = False Then
                                '-------------------Cabeza ventas--------------------------
                                Dim idVenta As Integer
                                objVentaNe.Fecha = dtpFecIng.Value
                                objVentaNe.idCliente = TextBox1.Text
                                objVentaNe.numFactura = MaskedTextBox1.Text
                                objVentaNe.tipofactura = ComboBox1.Text
                                objVentaNe.total = TextBox5.Text
                                objVentaNe.pagado = 0
                                objVentaNe.anulada = 0

                                idVenta = objVentaLN.InsertarVentas(objVentaNe)
                                '-------------------Cabeza ventas--------------------------


                                '-------------------Cuerpo ventas--------------------------

                                For Each dvg As DataGridViewRow In DataGridView1.Rows

                                    objItemVtaNe.cantidad = dvg.Cells(1).Value
                                    objItemVtaNe.Precio = dvg.Cells(2).Value
                                    objItemVtaNe.Total = dvg.Cells(3).Value
                                    objItemVtaNe.numFactura = MaskedTextBox1.Text
                                    objItemVtaNe.tipofactura = ComboBox1.Text
                                    objItemVtaNe.idArticulo = dvg.Cells(4).Value
                                    If dvg.Cells(5).Value = "Servicio" Then
                                        objItemVtaNe.esarticulo = 1
                                        objItemVtaNe.costo = dvg.Cells(2).Value
                                    Else
                                        objItemVtaNe.esarticulo = 0
                                        Dim ds1 As New DataSet
                                        Dim objIcosto As New VentasLN
                                        ds1 = objIcosto.BuscarCostoArticulo(dvg.Cells(4).Value)
                                        objItemVtaNe.costo = ds1.Tables(0).Rows(0).Item(0).ToString
                                    End If

                                    objVentaLN.InsertarItemVenta(objItemVtaNe)

                                Next
                                '-------------------Cuerpo ventas--------------------------

                                '---------------------insertamos correccion de stock--------
                                For Each dgv As DataGridViewRow In DataGridView1.Rows
                                    If dgv.Cells(5).Value = "Artículo" Then
                                        Dim objCSNE As New ClaseCorreccionStock
                                        Dim objCSLN As New StockLN
                                        objCSNE.idarticulo = dgv.Cells(4).Value
                                        If ComboBox1.Text Like "F?" Then
                                            objCSNE.Egreso = -1 * dgv.Cells(1).Value
                                            objCSNE.Ingeso = 0
                                            objCSNE.Descripcion = "Egreso por: " & ComboBox1.Text & " " & MaskedTextBox1.Text & ", Cliente " & txtNombre.Text
                                        Else
                                            objCSNE.Ingeso = -1 * dgv.Cells(1).Value
                                            objCSNE.Egreso = 0
                                            objCSNE.Descripcion = "Ingreso por: " & ComboBox1.Text & " " & MaskedTextBox1.Text & ", Cliente " & txtNombre.Text
                                        End If

                                        objCSNE.fechamodificacion = Now
                                        objCSLN.InsertarCorreccionStock(objCSNE)
                                    End If
                                Next
                                '---------------------insertamos correccion de stock--------


                                'restamos stock--------------------------------------------  
                                For Each dvg As DataGridViewRow In DataGridView1.Rows
                                    If dvg.Cells(5).Value = "Artículo" Then
                                        Dim objStock As New ComprasLN 'en compras ln esta la modifiaccion de stock
                                        Dim cantidad As Double
                                        If ComboBox1.Text Like "F?" Then
                                            cantidad = -1 * dvg.Cells(1).Value
                                        Else
                                            cantidad = -1 * dvg.Cells(1).Value
                                        End If
                                        Dim idarticulo As Integer
                                        idarticulo = dvg.Cells(4).Value
                                        objStock.modificarStock(idarticulo, cantidad)
                                    End If
                                Next

                                'restamos stock-------------------------------------------- 

                                'insertar vinculo PR-----------------------------------------
                                If listaPR.Count > 0 Then
                                    For Each n As Int32 In listaPR.Distinct
                                        Dim objVPR As New ClaseVinculo
                                        Dim objPR As New PresupuestosLN
                                        'objVPR.Fecha = Now
                                        objVPR.TipoComAsociado = "PR"
                                        objVPR.numeroComAsociado = n
                                        objVPR.TipoComprobante = ComboBox1.Text
                                        objVPR.numerocomprobante = MaskedTextBox1.Text
                                        objVPR.activo = 1
                                        objPR.InsertVinculoOT(objVPR)
                                        Dim modif As New VentasLN
                                        modif.modificarPRFacturado(n)
                                    Next
                                End If
                                'insertar vinculo PR-------------------------------------------
                                MsgBox("Los datos ingresados se guardaron Correctamente")
                                Dim ds As DataSet
                                Dim objVta As New VentasLN
                                ds = objVta.cargaGrilla()
                                Ventas.dgvCompra.DataSource = ds.Tables(0)
                                Me.Close()
                            Else
                                'Pagado en Factura-------------------------------------------
                                If CheckBox1.Checked = True Then
                                    Cobro.regFac = 1
                                    Cobro.TextBox1.Text = TextBox5.Text
                                    Cobro.Show()

                                End If

                                'Pagado en Factura-------------------------------------------
                            End If


                        End If
                        End If
                End If
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SeleccionarServicio.Show()
        SeleccionarServicio.esfactura = esFactura
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox4.Text = "" Then
            MessageBox.Show("Seleccione un Servicio")
        Else
            If NumericUpDown2.Value = 0 Then
                MessageBox.Show("Debe ingresar cantidad")
            Else
                If TextBox6.Text = "" Then

                    MessageBox.Show("Debe ingresar Precio para el servicio")
                Else
                    DataGridView1.Rows.Add(TextBox7.Text, NumericUpDown2.Value, TextBox6.Text, Calculo_Importe2, TextBox4.Text, "Servicio")
                    'DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(0).Width = 250
                    NumericUpDown2.Value = 0
                    TextBox7.Clear()
                    TextBox4.Clear()
                    TextBox6.Clear()
                    Totalsuma()
                End If
            End If
        End If

    End Sub
    Function Calculo_Importe2() As Double
        Dim Importe As Double
        Importe = NumericUpDown2.Value * TextBox6.Text
        Return Importe
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ds As DataSet
        Dim objVenta As New VentasLN
        ds = objVenta.buscarcabecerapresupuesto(TextBox1.Text)
        If ds.Tables.Count > 0 Then
            BuscarPresupuestos.DataGridView1.DataSource = ds.Tables(0)
            BuscarPresupuestos.TextBox1.Text = TextBox1.Text
            BuscarPresupuestos.TextBox2.Text = txtNombre.Text
            BuscarPresupuestos.BFACTURA = 1
            BuscarPresupuestos.Show()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If TextBox1.Text <> "" Then
            If ComboBox1.Text Like "F?" Then
                Dim ds1 As DataSet
                Dim objVenta As New VentasLN
                ds1 = objVenta.buscarPresupuesto(TextBox1.Text)
                If ds1.Tables.Count > 0 Then
                    Button5.Visible = True
                Else
                    Button5.Visible = False
                End If
            Else
                Button5.Visible = False
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

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If ComboBox1.Text Like "F?" And NumericUpDown2.Value < 0 Then
            MsgBox("Debe ingresar una Cantidad válida para el tipo de comprobante")
            NumericUpDown2.Value = 0
        End If
        If ComboBox1.Text Like "NC?" And NumericUpDown2.Value > 0 Then
            MsgBox("Debe ingresar una Cantidad válida para el tipo de comprobante")
            NumericUpDown2.Value = 0
        End If
    End Sub
    Private Sub MaskedTextBox1_Leave(sender As Object, e As EventArgs) Handles MaskedTextBox1.Leave
        Dim ds As New DataSet
        Dim objv As New VentasLN
        ds = objv.buscarfactura(ComboBox1.Text, Replace(MaskedTextBox1.Text, "-", ""))
        If ds.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("El número de factura ya se encuentra cargada")
            Dim ds1 As New DataSet
            Dim objVe As New VentasLN
            ds1 = objv.puntoporDefecto()
            If ds1.Tables(0).Rows.Count > 0 Then
                Dim ds2 As New DataSet
                ds2 = objVe.MAXnumFactptoxdef

                MaskedTextBox1.Text = ds2.Tables(0).Rows(0).Item(0).ToString
            Else
                Dim ds3 As New DataSet
                ds3 = objVe.MAXnumFactpto
                MaskedTextBox1.Text = ds3.Tables(0).Rows(0).Item(0).ToString
            End If
        End If
        Dim ds4 As New DataSet
        ds4 = objv.PuntoVentaValido()
        Dim contador As Integer = 0
        For Each dt As DataRow In ds4.Tables(0).Rows

            If CDbl(Replace(MaskedTextBox1.Text, "-", "")) > dt.Item(0) And CDbl(Replace(MaskedTextBox1.Text, "-", "")) < dt.Item(1) Then
                contador += 1
            End If
        Next
        If contador < 1 Then
            MessageBox.Show("No es un punto de venta válido o se encuentra inactivo")
            'Else
            Dim ds1 As New DataSet
            Dim objVe As New VentasLN
            ds1 = objv.puntoporDefecto()
            If ds1.Tables(0).Rows.Count > 0 Then
                Dim ds2 As New DataSet
                ds2 = objVe.MAXnumFactptoxdef

                MaskedTextBox1.Text = ds2.Tables(0).Rows(0).Item(0).ToString
            Else
                Dim ds3 As New DataSet
                ds3 = objVe.MAXnumFactpto
                MaskedTextBox1.Text = ds3.Tables(0).Rows(0).Item(0).ToString
            End If
        End If
    End Sub
End Class