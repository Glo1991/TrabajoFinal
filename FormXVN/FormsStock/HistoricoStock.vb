Imports CapaLN
Imports CapaNE
Public Class HistoricoStock
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objCsstockln As New StockLN
        Dim objCSstockNE As New ClaseCorreccionStock
        Dim ds As New DataSet
        ds = objCsstockln.buscarCS(TextBox2.Text)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(0).Width = 400
        Dim resultado1 As String = StockArticulo(TextBox2.Text)
        If (resultado1 <> String.Empty) Then
            Label3.Text = resultado1.ToString
            Label3.Visible = True
            Dim resultado As String = Descripcionarticulo(TextBox2.Text)
            TextBox1.Text = resultado

        Else
            Label3.Text = 0
            Label3.Visible = True
            TextBox1.Clear()
            MessageBox.Show("El código de Articulo no existe")
        End If

    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If


        End If
        If (AscW(e.KeyChar) = 13) Then
            e.Handled = True ' Para que no suene el pitido al pulsar la tecla Enter.

            Dim resultado As String = Descripcionarticulo(TextBox2.Text)
            If (resultado <> String.Empty) Then
                TextBox1.Text = resultado
                Dim resultado1 As String = StockArticulo(TextBox2.Text)

                Label3.Text = resultado1.ToString
                Label3.Visible = True

            Else
                Label3.Text = 0
                Label3.Visible = True
                TextBox1.Clear()
                MessageBox.Show("El código de Articulo no existe")

            End If

        End If
    End Sub
    Private Function Descripcionarticulo(ByVal descripArt As String) As String
        Dim objCStockLN As New StockLN
        Dim obCstockNE As New ClaseArticulo
        Dim ds As New DataSet
        Dim resultado As String
        ds = objCStockLN.bDesArticulo(descripArt)
        If ds.Tables(0).Rows.Count < 1 Then
            resultado = ""
        Else
            resultado = ds.Tables(0).Rows(0).Item(0).ToString
        End If
        Return resultado

    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub HistoricoStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Visible = False

    End Sub

    Private Function StockArticulo(ByVal sArticulo As String) As String
        Dim resultado1 As String
        Dim objCsstockln As New StockLN
        Dim objCSstockNE As New ClaseStock
        Dim ds As New DataSet
        ds = objCsstockln.bStockArticulo(sArticulo)
        If ds.Tables(0).Rows.Count < 1 Then
            resultado1 = ""
        Else
            resultado1 = ds.Tables(0).Rows(0).Item(0).ToString
        End If
        Return resultado1

    End Function

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        If (AscW(e.KeyChar) = 13) Then
            e.Handled = True ' Para que no suene el pitido al pulsar la tecla Enter.

            Dim objstockLN As New StockLN
            Dim objstockNE As New ClaseArticulo
            Dim ds As New DataSet
            ds = objstockLN.seleccionArticulo(TextBox1.Text)

            SeleccionArticulo.DataGridView1.DataSource = ds.Tables(0)
            SeleccionArticulo.Show()

        End If
    End Sub
End Class