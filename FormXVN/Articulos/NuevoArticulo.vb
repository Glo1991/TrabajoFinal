Imports CapaLN
Imports CapaNE
Public Class NuevoArticulo
    Dim objArticuloLN As New ArticulosLN
    Dim objArticulotNe As New ClaseCategoria
    Private Sub NuevoArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objArticuloLN.NuevoCodArticulo()
        txtCodigo.Text = ds.Tables(0).Rows(0).Item(0).ToString
        cargarComboCategoria()
        cargarComboMArcas()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim objArticuloLN As New ArticulosLN
        Dim objArticulotNe As New ClaseArticulo
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar una Descripción")
        Else
            If cmbMarca.Text = "Seleccione" Or cmbMarca.Text = "" Then
                MessageBox.Show("Debe seleccionar una Marca")
            Else
                If ComboCategoria.Text = "Seleccione" Or ComboCategoria.Text = "" Then
                    MessageBox.Show("Debe seleccionar una categoría")
                Else
                    If TextBox1.Text = "" Then
                        MessageBox.Show("Debe ingresar un Costo")
                    Else
                        If txtSMin.Text = "" Then
                            MessageBox.Show("Debe ingresar Stock Mínimo")
                        Else
                            If CheckBox1.Checked = False And CheckBox2.Checked = False Then
                                MessageBox.Show("Debe Seleccionar un tipo de Precio de Venta")
                            Else
                                If TextBox2.Text = "" Then
                                    MessageBox.Show("Debe ingresar un precio")
                                Else
                                    Dim resp As Integer
                                    resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    If resp = vbYes Then

                                        Dim idArticulo As Integer
                                        objArticulotNe.CodArticulo = txtCodigo.Text
                                        objArticulotNe.Descripcion = txtNombre.Text
                                        objArticulotNe.idCategoria = ComboCategoria.SelectedValue
                                        objArticulotNe.idMarca = cmbMarca.SelectedValue
                                        objArticulotNe.costo = TextBox1.Text
                                        objArticulotNe.StockMin = txtSMin.Text

                                        objArticulotNe.PrecioVenta = TextBox2.Text


                                        If CheckBox2.Checked = True Then
                                            objArticulotNe.TipoPrecio = 1
                                        Else
                                            objArticulotNe.TipoPrecio = 0
                                        End If

                                        idArticulo = objArticuloLN.InsertArticulo(objArticulotNe)

                                        Dim objStockLN As New StockLN
                                            Dim objStockNE As New ClaseStock
                                            objStockNE.idArticulo = txtCodigo.Text
                                            objStockNE.idCategoris = ComboCategoria.SelectedValue
                                            objStockNE.cantidad = 0
                                            objStockNE.Producto = txtNombre.Text
                                            objStockLN.InsertarStock(objStockNE)
                                            Dim ds As DataSet
                                            ds = objArticuloLN.cargaGrillaArt
                                            Articulos.dgvArticulos.DataSource = ds.Tables(0)
                                            Me.Close()
                                        End If
                                    End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Sub cargarComboCategoria()
        Dim ds As DataSet
        Dim objCategLN As New ArticulosLN
        Dim objCategNE As New ClaseCategoria

        ds = New DataSet
        ds = objCategLN.cargarComboCategoria(objCategNE)
        ComboCategoria.DataSource = ds.Tables("tabCate")
        ComboCategoria.DisplayMember = "NomCategoria"
        ComboCategoria.ValueMember = "idCategoria"
        ComboCategoria.Text = "Seleccione"
    End Sub
    Sub cargarComboMArcas()
        Dim ds As DataSet
        Dim objMarcaLN As New ArticulosLN
        Dim objMarcaNE As New ClaseMarca

        ds = New DataSet
        ds = objMarcaLN.cargarComboMarcas(objMarcaNE)
        cmbMarca.DataSource = ds.Tables("tabMarc")
        cmbMarca.DisplayMember = "Marca"
        cmbMarca.ValueMember = "idMarca"
        cmbMarca.Text = "Seleccione"
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtSMin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSMin.KeyPress
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
    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False

        End If

    End Sub
    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
            Dim ds As New DataSet
            ds = objArticuloLN.buscaridMarca(cmbMarca.SelectedValue)
            If ds.Tables.Count > 0 And TextBox1.Text <> "" Then
                TextBox3.Text = ds.Tables(0).Rows(0).Item(2).ToString
                TextBox2.Text = ((TextBox1.Text * TextBox3.Text) / 100) + TextBox1.Text
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
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, txtSMin.KeyPress, TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If

        End If


    End Sub


    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If CheckBox2.Checked = True Then
            Dim ds As New DataSet
            ds = objArticuloLN.buscaridMarca(cmbMarca.SelectedValue)
            If ds.Tables.Count > 0 And TextBox1.Text <> "" Then

                TextBox3.Text = ds.Tables(0).Rows(0).Item(2).ToString
                TextBox2.Text = ((TextBox1.Text * TextBox3.Text) / 100) + TextBox1.Text
            End If
        End If
    End Sub

    Private Sub cmbMarca_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbMarca.SelectionChangeCommitted

        Dim ds As New DataSet
        ds = objArticuloLN.buscaridMarca(cmbMarca.SelectedValue)
        If ds.Tables.Count > 0 And TextBox1.Text <> "" Then

            TextBox3.Text = ds.Tables(0).Rows(0).Item(2).ToString
            'TextBox2.Text = ((TextBox1.Text * TextBox3.Text) / 100) + TextBox1.Text
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If CheckBox2.Checked = True Then
            TextBox2.Text = ((TextBox1.Text * TextBox3.Text) / 100) + TextBox1.Text
        End If
    End Sub
End Class