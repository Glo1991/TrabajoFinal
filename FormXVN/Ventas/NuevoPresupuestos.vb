Imports CapaLN
Imports CapaNE
Imports FormXVN
Public Class NuevoPresupuestos
    Public idAlumnaaa As Integer
    Public idOrdTrabajoo As Integer
    Public tipoCompOT As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Seleccione un Servicio")
        Else
            If NumericUpDown1.Value = 0 Then
                MessageBox.Show("Debe ingresar cantidad")
            Else
                If TextBox3.Text = "" Then
                    MessageBox.Show("Debe ingresar Precio para el servicio")
                Else
                    DataGridView1.Rows.Add(TextBox2.Text, NumericUpDown1.Value, TextBox3.Text, Calculo_Importe, TextBox4.Text, "Servicio")
                    'DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(0).Width = 250
                    TextBox2.Clear()
                    TextBox4.Clear()
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
    Function Calculo_ImporteArticulo() As Double
        Dim Importe As Double
        Importe = NumericUpDown2.Value * TextBox8.Text
        Return Importe
    End Function

    Private Sub Totalsuma()
        Dim Total As Double
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            Total += Val(row.Cells(3).Value)
        Next
        Me.TextBox5.Text = Total.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BuscarClientePresupuesto.Show()
    End Sub

    Private Sub NuevoPresupuestos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox4.Enabled = False
        TextBox7.Enabled = False
        TextBox6.Enabled = False
        TextBox5.Enabled = False
        'TextBox3.Enabled = False
        Dim ds As New DataSet
        Dim onjPreLN As New PresupuestosLN
        ds = onjPreLN.NuevoPresupuesto()
        Label8.Text = ds.Tables(0).Rows(0).Item(0).ToString

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Totalsuma()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SeleccionarServicio.Show()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If
        End If
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar un Cliente")
        Else
            If DataGridView1.RowCount < 1 Then
                MessageBox.Show("Debe ingresar un Servicio o Artículo para presupuestar")
            Else
                Dim objServicioLN As New ServiciosLN
                Dim ObjServicioNE As New ClaseServicios
                Dim objPresupuestoNE As New ClasePresupuestos
                Dim objPresupuestoLN As New PresupuestosLN
                Dim objItemPRNE As New ClaseItemPR

                Dim resp As Integer
                resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = vbYes Then
                    'insertaR RESUPUESTOS--CABEZAPRESUPUESTO------------------------------
                    Dim Presupuesto As Integer
                    'objCompaNe = New ClaseCompras
                    objPresupuestoNE.tipocomprobante = "PR"
                    objPresupuestoNE.Codgigocliente = idAlumnaaa
                    objPresupuestoNE.FechaIngreso = dtpFecIng.Value
                    objPresupuestoNE.Total = TextBox5.Text
                    objPresupuestoNE.Anulado = 0
                    objPresupuestoNE.facturado = 0


                    Presupuesto = objPresupuestoLN.InsertPresupuestos(objPresupuestoNE)
                    'insertaR RESUPUESTOS--CABEZAPRESUPUESTO------------------------------

                    'insertaR Item--cuerpoPRESUPUESTO------------------------------------
                    For Each dvg As DataGridViewRow In DataGridView1.Rows
                        Dim itemPR As Integer
                        'Dim i As Integer
                        objItemPRNE.idPresupuesto = Label8.Text
                        objItemPRNE.Codigo = dvg.Cells(4).Value
                        If dvg.Cells(5).Value = "Servicio" Then
                            objItemPRNE.esArticulo = 1
                        Else
                            objItemPRNE.esArticulo = 0
                        End If
                        objItemPRNE.cantidad = dvg.Cells(1).Value
                        objItemPRNE.Precio = dvg.Cells(2).Value
                        objItemPRNE.Total = (dvg.Cells(2).Value * dvg.Cells(1).Value)
                        objItemPRNE.tipocomprobante = "PR"
                        itemPR = objPresupuestoLN.InsertItemPR(objItemPRNE)
                    Next
                    'insertaR Item--cuerpoPRESUPUESTO------------------------------------

                    'insertaR Vinculo--Orden de trabajo------------------------------------
                    If idOrdTrabajoo > 0 Then
                        Dim objVinculoNe As New ClaseVinculo
                        Dim objPresuLN As New PresupuestosLN
                        objVinculoNe.TipoComAsociado = tipoCompOT
                        objVinculoNe.numeroComAsociado = idOrdTrabajoo
                        objVinculoNe.TipoComprobante = "PR"
                        objVinculoNe.numerocomprobante = Label8.Text
                        objVinculoNe.activo = 1
                        objPresuLN.InsertVinculoOT(objVinculoNe)
                        VerOrdenTRab.Button2.Visible = False
                    End If
                    'insertaR Vinculo--Orden de trabajo------------------------------------
                    Me.Close()
                    Dim ds As New DataSet
                    Dim objPrLN As New PresupuestosLN
                    ds = objPrLN.cargaGrilla()
                    PlanillaPresupuestos.dgvCompra.DataSource = ds.Tables(0)
                    PlanillaPresupuestos.dgvCompra.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    PlanillaPresupuestos.dgvCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    PlanillaPresupuestos.dgvCompra.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            End If

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        BuscarProducto.Show()
        BuscarProducto.numPR = Label8.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox6.Text = "" Then
            MessageBox.Show("Seleccione un Artículo")
        Else
            If NumericUpDown2.Value = 0 Then
                MessageBox.Show("Debe ingresar cantidad para el artículo")
            Else
                If TextBox8.Text = "" Then
                    MessageBox.Show("Debe ingresar Precio para el artículo")
                Else
                    Dim dscosto As New DataSet
                    Dim objVentaln As New VentasLN
                    dscosto = objVentaln.BuscarCostoArticulo(TextBox7.Text)
                    If dscosto.Tables.Count > 0 Then
                        If dscosto.Tables(0).Rows(0).Item(0) > TextBox8.Text Then
                            MessageBox.Show("El Costo del artículo es mayor al precio de Venta. Verificar por favor")
                        Else
                            DataGridView1.Rows.Add(TextBox6.Text, NumericUpDown2.Value, TextBox8.Text, Calculo_ImporteArticulo, TextBox7.Text, "Artículo")
                            'DataGridView1.Columns(4).Visible = False
                            DataGridView1.Columns(0).Width = 250
                            TextBox6.Clear()
                            TextBox7.Clear()
                            NumericUpDown2.Value = 0
                            TextBox8.Clear()
                            Totalsuma()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Class