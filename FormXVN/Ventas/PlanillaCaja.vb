Imports CapaLN
Imports CapaNE
Public Class PlanillaCaja
    Dim fechadesde As String
    Dim fechahasta As String
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Private Sub PlanillaCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCompra.Columns(5).Visible = False
        TextBox5.Enabled = False
        Dim ds As New DataSet
        Dim objCobro As New CobrosLN
        ds = objCobro.cargargrilla()
        Dim Saldo As Double
        For dv As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim totalES As Double
            totalES = ds.Tables(0).Rows(dv).Item(2) + ds.Tables(0).Rows(dv).Item(3)
            Saldo = Saldo + totalES

            dgvCompra.Rows.Add(ds.Tables(0).Rows(dv).Item(0), ds.Tables(0).Rows(dv).Item(1), ds.Tables(0).Rows(dv).Item(2), ds.Tables(0).Rows(dv).Item(3), Saldo.ToString("N2"), ds.Tables(0).Rows(dv).Item(4))

        Next
        Dim contador As Integer
        For dv As Integer = 0 To dgvCompra.Rows.Count - 1

            contador += 1
        Next
        TextBox5.Text = "$ " & dgvCompra.Rows(contador - 1).Cells(4).Value

        If XVN.Label3.Text = "Limitada" Then
            Button6.Enabled = False

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'insertar Cobro-------------------------------------------
        Dim objCobro As New CobrosLN
        Dim objCobroNE As New ClaseCobro
        Dim dscobro As New DataSet
        Dim resp As Integer
        dscobro = objCobro.buscarcobro(dgvCompra.CurrentRow.Cells(5).Value)
        If dscobro.Tables(0).Rows.Count <= 0 Then
            MessageBox.Show("No es posible  Anular, el cobro se encuentra anulado o es una corrección por anulación")
        Else
            resp = MessageBox.Show("¿Confirma la ANulación del cobro?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = vbYes Then
                dscobro = objCobro.buscarcobro(dgvCompra.CurrentRow.Cells(5).Value)
                objCobroNE.NumComrpobante = dscobro.Tables(0).Rows(0).Item(2)
                objCobroNE.Tipocomproabnte = dscobro.Tables(0).Rows(0).Item(1)
                objCobroNE.Total = -1 * dscobro.Tables(0).Rows(0).Item(3)
                objCobroNE.anulado = 1
                objCobroNE.Fecha = Now
                objCobroNE.esanulacion = 1
                objCobro.InsertarCobro(objCobroNE)
                'insertar Cobro-------------------------------------------

                'Modificar pagado en Factura-------------------------------
                Dim objC As New CobrosLN
                objC.modificarCobroANULFactura(dscobro.Tables(0).Rows(0).Item(2), dscobro.Tables(0).Rows(0).Item(1))

                'Modificar pagado en Factura-------------------------------


                'Modificar anulado en Cobro-------------------------------
                objCobro.modificarCobroANUladoCOBRO(dgvCompra.CurrentRow.Cells(5).Value)
                'Modificar anulado en Cobro--------------------------------


                Dim ds As New DataSet
                Dim objCobro1 As New CobrosLN
                dgvCompra.Rows.Clear()
                ds = objCobro1.cargargrilla()
                Dim Saldo As Double
                For dv As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim totalES As Double
                    totalES = ds.Tables(0).Rows(dv).Item(2) + ds.Tables(0).Rows(dv).Item(3)
                    Saldo = Saldo + totalES

                    dgvCompra.Rows.Add(ds.Tables(0).Rows(dv).Item(0), ds.Tables(0).Rows(dv).Item(1), ds.Tables(0).Rows(dv).Item(2), ds.Tables(0).Rows(dv).Item(3), Saldo.ToString("N2"), ds.Tables(0).Rows(dv).Item(4))

                Next
                Dim contador As Integer
                For dv As Integer = 0 To dgvCompra.Rows.Count - 1

                    contador += 1
                Next
                TextBox5.Text = "$ " & dgvCompra.Rows(contador - 1).Cells(4).Value
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        dgvCompra.Columns(5).Visible = False
        TextBox5.Enabled = False
        Dim ds As New DataSet
        Dim objCobro As New CobrosLN
        ds = objCobro.buscarfechacobro(fechadesde, fechahasta)
        dgvCompra.Rows.Clear()
        Dim Saldo As Double
        For dv As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim totalES As Double
            totalES = ds.Tables(0).Rows(dv).Item(2) + ds.Tables(0).Rows(dv).Item(3)
            Saldo = Saldo + totalES

            dgvCompra.Rows.Add(ds.Tables(0).Rows(dv).Item(0), ds.Tables(0).Rows(dv).Item(1), ds.Tables(0).Rows(dv).Item(2), ds.Tables(0).Rows(dv).Item(3), Saldo.ToString("N2"), ds.Tables(0).Rows(dv).Item(4))

        Next
        Dim contador As Integer
        For dv As Integer = 0 To dgvCompra.Rows.Count - 1

            contador += 1
        Next
        If dgvCompra.Rows.Count = 0 Then
            TextBox5.Text = "$ 0"
        Else

            TextBox5.Text = "$ " & dgvCompra.Rows(contador - 1).Cells(4).Value
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        dgvCompra.Columns(5).Visible = False
        TextBox5.Enabled = False
        Dim ds As New DataSet
        Dim objCobro As New CobrosLN
        ds = objCobro.cargargrilla()
        dgvCompra.Rows.Clear()
        Dim Saldo As Double
        For dv As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim totalES As Double
            totalES = ds.Tables(0).Rows(dv).Item(2) + ds.Tables(0).Rows(dv).Item(3)
            Saldo = Saldo + totalES

            dgvCompra.Rows.Add(ds.Tables(0).Rows(dv).Item(0), ds.Tables(0).Rows(dv).Item(1), ds.Tables(0).Rows(dv).Item(2), ds.Tables(0).Rows(dv).Item(3), Saldo, ds.Tables(0).Rows(dv).Item(4))

        Next
        Dim contador As Integer
        For dv As Integer = 0 To dgvCompra.Rows.Count - 1

            contador += 1
        Next
        TextBox5.Text = "$ " & dgvCompra.Rows(contador - 1).Cells(4).Value
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
    End Sub
End Class