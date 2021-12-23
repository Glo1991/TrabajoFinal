Imports CapaLN
Imports CapaNE
Public Class Cobro
    Public regFac As Integer
    Public DetalleFac As Integer
    Private Sub Cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox3.Enabled = False
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
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
        Dim resp As Integer
        If TextBox2.Text = "" Then
            MessageBox.Show("Debe ingresar el monto a Cobrar")
        Else
            If ((Convert.ToDecimal(TextBox2.Text) < Convert.ToDecimal(TextBox1.Text) And RegistrarVenta.ComboBox1.Text Like "F?") Or (Convert.ToDecimal(TextBox2.Text) <> Convert.ToDecimal(TextBox1.Text) And RegistrarVenta.ComboBox1.Text Like "NC?")) Or
                ((Convert.ToDecimal(TextBox2.Text) < Convert.ToDecimal(TextBox1.Text) And DetalleVta.TextBox2.Text Like "F?") Or (Convert.ToDecimal(TextBox2.Text) <> Convert.ToDecimal(TextBox1.Text) And DetalleVta.TextBox2.Text Like "NC?")) Then

                MessageBox.Show("Debe ingresar un monto a cobrar correcto")
            Else

                resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = vbYes Then
                    If regFac = 1 Then
                        '-------------------Cabeza ventas--------------------------
                        Dim idVenta As Integer
                        objVentaNe.Fecha = RegistrarVenta.dtpFecIng.Value
                        objVentaNe.idCliente = RegistrarVenta.TextBox1.Text
                        objVentaNe.numFactura = RegistrarVenta.MaskedTextBox1.Text
                        objVentaNe.tipofactura = RegistrarVenta.ComboBox1.Text
                        objVentaNe.total = RegistrarVenta.TextBox5.Text
                        objVentaNe.pagado = 0
                        objVentaNe.anulada = 0

                        idVenta = objVentaLN.InsertarVentas(objVentaNe)
                        '-------------------Cabeza ventas--------------------------


                        '-------------------Cuerpo ventas--------------------------

                        For Each dvg As DataGridViewRow In RegistrarVenta.DataGridView1.Rows

                            objItemVtaNe.cantidad = dvg.Cells(1).Value
                            objItemVtaNe.Precio = dvg.Cells(2).Value
                            objItemVtaNe.Total = dvg.Cells(3).Value
                            objItemVtaNe.numFactura = RegistrarVenta.MaskedTextBox1.Text
                            objItemVtaNe.tipofactura = RegistrarVenta.ComboBox1.Text
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
                        For Each dgv As DataGridViewRow In RegistrarVenta.DataGridView1.Rows
                            If dgv.Cells(5).Value = "Artículo" Then
                                Dim objCSNE As New ClaseCorreccionStock
                                Dim objCSLN As New StockLN
                                objCSNE.idarticulo = dgv.Cells(4).Value
                                If RegistrarVenta.ComboBox1.Text Like "F?" Then
                                    objCSNE.Egreso = -1 * dgv.Cells(1).Value
                                    objCSNE.Ingeso = 0
                                    objCSNE.Descripcion = "Egreso por: " & RegistrarVenta.ComboBox1.Text & " " & RegistrarVenta.MaskedTextBox1.Text & ", Cliente " & RegistrarVenta.txtNombre.Text
                                Else
                                    objCSNE.Ingeso = -1 * dgv.Cells(1).Value
                                    objCSNE.Egreso = 0
                                    objCSNE.Descripcion = "Ingreso por: " & RegistrarVenta.ComboBox1.Text & " " & RegistrarVenta.MaskedTextBox1.Text & ", Cliente " & RegistrarVenta.txtNombre.Text
                                End If

                                objCSNE.fechamodificacion = Now
                                objCSLN.InsertarCorreccionStock(objCSNE)
                            End If
                        Next
                        '---------------------insertamos correccion de stock--------


                        'restamos stock--------------------------------------------  
                        For Each dvg As DataGridViewRow In RegistrarVenta.DataGridView1.Rows
                            If dvg.Cells(5).Value = "Artículo" Then
                                Dim objStock As New ComprasLN 'en compras ln esta la modifiaccion de stock
                                Dim cantidad As Double
                                If RegistrarVenta.ComboBox1.Text Like "F?" Then
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
                        If RegistrarVenta.listaPR.Count > 0 Then
                            For Each n As Int32 In RegistrarVenta.listaPR.Distinct
                                Dim objVPR As New ClaseVinculo
                                Dim objPR As New PresupuestosLN
                                'objVPR.Fecha = Now
                                objVPR.TipoComAsociado = "PR"
                                objVPR.numeroComAsociado = n
                                objVPR.TipoComprobante = RegistrarVenta.ComboBox1.Text
                                objVPR.numerocomprobante = RegistrarVenta.MaskedTextBox1.Text
                                objVPR.activo = 1
                                objPR.InsertVinculoOT(objVPR)
                                Dim modif As New VentasLN
                                modif.modificarPRFacturado(n)
                            Next
                        End If
                        'insertar vinculo PR-------------------------------------------

                        'insertar Cobro-------------------------------------------
                        Dim objCobro As New CobrosLN
                        Dim objCobroNE As New ClaseCobro
                        objCobroNE.Tipocomproabnte = RegistrarVenta.ComboBox1.Text
                        objCobroNE.NumComrpobante = RegistrarVenta.MaskedTextBox1.Text
                        objCobroNE.Total = TextBox1.Text
                        objCobroNE.anulado = 0
                        objCobroNE.Fecha = Now
                        objCobro.InsertarCobro(objCobroNE)
                        'insertar Cobro-------------------------------------------

                        'Modificar pagado en Factura-------------------------------
                        Dim objC As New CobrosLN
                        objC.modificarCobroFactura(RegistrarVenta.MaskedTextBox1.Text, RegistrarVenta.ComboBox1.Text)

                        'Modificar pagado en Factura-------------------------------

                        MsgBox("Los datos ingresados se guardaron Correctamente")
                        Dim ds As DataSet
                        Dim objVta As New VentasLN
                        ds = objVta.cargaGrilla()
                        Ventas.dgvCompra.DataSource = ds.Tables(0)
                        Me.Close()
                        RegistrarVenta.Close()
                    End If
                    If DetalleFac = 1 Then
                        'insertar Cobro-------------------------------------------
                        Dim objCobro As New CobrosLN
                        Dim objCobroNE As New ClaseCobro
                        objCobroNE.NumComrpobante = Replace(DetalleVta.txtNumDoc.Text, "-", "")
                        objCobroNE.Tipocomproabnte = DetalleVta.TextBox2.Text
                        objCobroNE.Total = TextBox1.Text
                        objCobroNE.anulado = 0
                        objCobroNE.Fecha = Now
                        objCobroNE.esanulacion = 0
                        objCobro.InsertarCobro(objCobroNE)
                        'insertar Cobro-------------------------------------------

                        'Modificar pagado en Factura-------------------------------
                        Dim objC As New CobrosLN
                        objC.modificarCobroFactura(Replace(DetalleVta.txtNumDoc.Text, "-", ""), DetalleVta.TextBox2.Text)

                        'Modificar pagado en Factura-------------------------------

                        MsgBox("Los datos ingresados se guardaron Correctamente")
                        Dim ds As DataSet
                        Dim objVta As New VentasLN
                        ds = objVta.cargaGrilla()
                        Ventas.dgvCompra.DataSource = ds.Tables(0)
                        Me.Close()
                        DetalleVta.Close()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If
            If Asc(e.KeyChar) = 45 Then
                e.Handled = False   ' <<< Para que admita el signo negativo.
            End If

        End If
        Diferencia()
    End Sub
    Public Sub Diferencia()
        Dim dife As Double = 0
        If TextBox2.Text <> "" And TextBox2.Text <> "-" Then

            dife = TextBox2.Text - TextBox1.Text
        End If

        TextBox3.Text = dife.ToString("N2")
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        Diferencia()
    End Sub

    Private Sub TextBox2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TextBox2.PreviewKeyDown
        Diferencia()
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        Diferencia()
    End Sub
End Class