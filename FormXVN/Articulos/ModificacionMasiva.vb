Imports CapaLN
Imports CapaNE
Public Class ModificacionMasiva
    Dim objarticuloLN As New ArticulosLN
    Dim objarticuloNE As New ClaseArticulo
    Dim ds As New DataSet
    Private Sub ModificacionMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds = objarticuloLN.cargaGrillaArtMM()
        dgvArticulos.DataSource = ds.Tables(0)
        inicio()
        TextBox2.Enabled = False
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        ComboBox2.Enabled = False
        cargarComboCategoria()
        cargarComboCategoria2()
    End Sub
    Sub inicio()
        dgvArticulos.Columns(0).Width = 130
        dgvArticulos.Columns(1).Width = 130
        dgvArticulos.Columns(3).Width = 70
        dgvArticulos.Columns(4).Width = 90
        dgvArticulos.Columns(5).Width = 120
        dgvArticulos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        filas_sel.Clear()

        cargarComboCategoria2()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If
        End If
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        If RadioButton1.Checked = True Then
            TextBox2.Enabled = True
            RadioButton2.Checked = False
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            ComboBox2.Enabled = False
            RadioButton3.Checked = False
            cargarComboCategoria()
        End If
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        If RadioButton2.Checked = True Then
            TextBox2.Enabled = False
            RadioButton1.Checked = False
            CheckBox1.Enabled = True
            CheckBox2.Enabled = True
            ComboBox2.Enabled = False
            RadioButton3.Checked = False
            TextBox2.Clear()
            cargarComboCategoria()
        End If
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        If RadioButton3.Checked = True Then
            TextBox2.Enabled = False
            TextBox2.Clear()
            RadioButton2.Checked = False
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            ComboBox2.Enabled = True
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
        End If
    End Sub

    'Variable visible para toda la clase
    Dim filas_sel As New List(Of Integer)
    Private Sub DeseleccionarTodo_Click(sender As Object, e As EventArgs) Handles DeseleccionarTodo.Click
        Dim i As Integer = dgvArticulos.CurrentRow.Index
        dgvArticulos.ClearSelection()
        filas_sel.Clear()
    End Sub

    Private Sub SeleccionarTodo_Click(sender As Object, e As EventArgs) Handles SeleccionarTodo.Click
        dgvArticulos.SelectAll()
        filas_sel.Clear()
        Dim n As Integer
        For Each row As DataGridViewRow In dgvArticulos.Rows
            filas_sel.Add(row.Index)
        Next
    End Sub

    'Método para seleccionar una fila
    'Private Sub seleccionarFila(ByVal indice As Int32)
    '    'Me.dgvArticulos.Rows(indice).Selected = True
    '    dgvArticulos.Rows(indice).DefaultCellStyle.BackColor = Color.Red
    'End Sub
    
    Private Sub SeleccionarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarToolStripMenuItem.Click
        Dim i As Integer = dgvArticulos.CurrentRow.Index
        dgvArticulos.Rows(i).Selected = False
        If filas_sel.Contains(i) Then
            filas_sel.Remove(i)
        Else
            filas_sel.Add(i)
        End If
        For Each n As Int32 In filas_sel
            dgvArticulos.Rows(n).Selected = True

        Next
    End Sub
    Private Sub dgvArticulos_Click(sender As Object, e As EventArgs) Handles dgvArticulos.Click
        For Each n As Int32 In filas_sel
            dgvArticulos.Rows(n).Selected = True

        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ds = objarticuloLN.cargaGrillaArtMM()
        dgvArticulos.DataSource = ds.Tables(0)
        inicio()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If filas_sel.Count = 0 Then
            MessageBox.Show("No ha seleccionado ningún artículo")
        Else
            If RadioButton1.Checked = True Then
                If TextBox2.Text = "" Then
                    MessageBox.Show("Debe completar un Margen")
                Else
                    For Each i As Int32 In filas_sel
                        Dim ds As New DataSet
                        Dim obArtLN As New ArticulosLN
                        Dim obArtNE As New ClaseArticulo

                        obArtNE.idArticulo = dgvArticulos.Rows(i).Cells(3).Value
                        obArtLN.modificarPrecioProcentaje(obArtNE, TextBox2.Text)
                    Next

                    MessageBox.Show("Los cambios se realizaron correctamente")
                    ds = objarticuloLN.cargaGrillaArtMM()
                    dgvArticulos.DataSource = ds.Tables(0)
                    inicio()

                End If
            End If
            If RadioButton2.Checked = True Then
                If CheckBox1.Checked = False And CheckBox2.Checked = False Then
                    MessageBox.Show("Debe seleccionar un Tipo de Precio")
                Else
                    If CheckBox1.Checked = True Then
                        For Each i As Int32 In filas_sel
                            Dim ds As New DataSet
                            Dim obArtLN As New ArticulosLN
                            Dim obArtNE As New ClaseArticulo

                            obArtNE.idArticulo = dgvArticulos.Rows(i).Cells(3).Value
                            obArtLN.modificarTipoPrecioMANUAL(obArtNE)
                        Next
                        MessageBox.Show("Los cambios se realizaron correctamente")
                        ds = objarticuloLN.cargaGrillaArtMM()
                        dgvArticulos.DataSource = ds.Tables(0)
                        inicio()
                    End If

                    If CheckBox2.Checked = True Then
                        For Each i As Int32 In filas_sel
                            Dim ds As New DataSet
                            Dim obArtLN As New ArticulosLN
                            Dim obArtNE As New ClaseArticulo

                            obArtNE.idArticulo = dgvArticulos.Rows(i).Cells(3).Value
                            obArtLN.modificarTipoPrecioMARCA(obArtNE)
                        Next
                        MessageBox.Show("Los cambios se realizaron correctamente")
                        ds = objarticuloLN.cargaGrillaArtMM()
                        dgvArticulos.DataSource = ds.Tables(0)
                        inicio()
                    End If
                End If
            End If
            If RadioButton3.Checked = True Then
                If ComboBox2.Text = "Seleccione" Then
                    MessageBox.Show("Debe seleccionar una categoría")
                Else
                    For Each i As Int32 In filas_sel
                        Dim ds As New DataSet
                        Dim obArtLN As New ArticulosLN
                        Dim obArtNE As New ClaseArticulo
                        Dim objCateg As New ClaseCategoria

                        obArtNE.idArticulo = dgvArticulos.Rows(i).Cells(3).Value
                        objCateg.idCategoria = ComboBox2.SelectedValue
                        obArtLN.modificarMAsivCategoria(obArtNE, objCateg)
                    Next
                    MessageBox.Show("Los cambios se realizaron correctamente")
                    ds = objarticuloLN.cargaGrillaArtMM()
                    dgvArticulos.DataSource = ds.Tables(0)
                    inicio()
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "Seleccione" Then
            If CboCampo.Text = "Categoría" Then
                Dim ds As New DataSet
                ds = objarticuloLN.cargaGrillaArtMMCategoria(ComboBox1.SelectedValue, TextBox1.Text)
                dgvArticulos.DataSource = ds.Tables(0)
                inicio()
            End If

        Else
            If (CboCampo.Text = "Seleccione" And ComboBox1.Text = "Seleccione") Then
                Dim ds1 As New DataSet
                ds1 = objarticuloLN.cargaGrillaArtMMDescripcion(TextBox1.Text)
                dgvArticulos.DataSource = ds1.Tables(0)
                inicio()


            Else
                Dim ds As New DataSet
                ds = objarticuloLN.cargaGrillaArtMM()
                dgvArticulos.DataSource = ds.Tables(0)
                inicio()
            End If
        End If

    End Sub
    Sub cargarComboCategoria()
        Dim ds As DataSet
        Dim objCategLN As New ArticulosLN
        Dim objCategNE As New ClaseCategoria

        ds = New DataSet
        ds = objCategLN.cargarComboCategoria(objCategNE)
        ComboBox1.DataSource = ds.Tables("tabCate")
        ComboBox1.DisplayMember = "NomCategoria"
        ComboBox1.ValueMember = "idCategoria"
        ComboBox1.Text = "Seleccione"
    End Sub
    Sub cargarComboCategoria2()
        Dim ds As DataSet
        Dim objCategLN As New ArticulosLN
        Dim objCategNE As New ClaseCategoria

        ds = New DataSet
        ds = objCategLN.cargarComboCategoria(objCategNE)
        ComboBox2.DataSource = ds.Tables("tabCate")
        ComboBox2.DisplayMember = "NomCategoria"
        ComboBox2.ValueMember = "idCategoria"
        ComboBox2.Text = "Seleccione"
    End Sub
End Class