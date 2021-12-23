Imports CapaLN
Imports CapaNE
Public Class ModificarArticulo
    Dim objArticuloLN As New ArticulosLN
    Dim objArticulotNe As New ClaseCategoria
    Public idArticulo As Integer
    Public idMArca As Integer
    Public idcategoria As Integer
    Private Sub ModificarArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarComboMArcas()
        cargarComboCategoria()
    End Sub
    Sub cargarComboCategoria()
        Dim ds As DataSet
        Dim objCategLN As New ArticulosLN
        Dim objCategNE As New ClaseCategoria
        Dim ds1 As New DataSet
        ds1 = objArticuloLN.buscaridCate(idcategoria)

        ds = New DataSet
        ds = objCategLN.cargarComboCategoria(objCategNE)
        ComboCategoria.DataSource = ds.Tables("tabCate")
        ComboCategoria.DisplayMember = "NomCategoria"
        ComboCategoria.ValueMember = "idCategoria"
        ComboCategoria.Text = ds1.Tables(0).Rows(0).Item(1).ToString
    End Sub
    Sub cargarComboMArcas()
        Dim ds As DataSet
        Dim objMarcaLN As New ArticulosLN
        Dim objMarcaNE As New ClaseMarca
        Dim ds1 As New DataSet

        ds1 = objArticuloLN.buscaridMarca(idMArca)

        ds = New DataSet
        ds = objMarcaLN.cargarComboMarcas(objMarcaNE)
        cmbMarca.DataSource = ds.Tables("tabMarc")
        cmbMarca.DisplayMember = "Marca"
        cmbMarca.ValueMember = "idMarca"
        cmbMarca.Text = ds1.Tables(0).Rows(0).Item(1).ToString
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()

    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        Dim objArticuloLN As New ArticulosLN
        Dim objArticuloNe As New ClaseArticulo
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
                                    objArticuloNe.Descripcion = txtNombre.Text
                                    objArticuloNe.idMarca = cmbMarca.SelectedValue
                                    objArticuloNe.idCategoria = ComboCategoria.SelectedValue
                                    objArticuloNe.StockMin = txtSMin.Text
                                    objArticuloNe.idArticulo = txtCodigo.Text
                                    objArticuloNe.PrecioVenta = Trim(Str(TextBox2.Text))
                                    objArticuloNe.costo = Trim(Str(TextBox1.Text))
                                    If CheckBox1.Checked = True Then
                                        objArticuloNe.TipoPrecio = 0
                                    Else
                                        objArticuloNe.TipoPrecio = 1
                                    End If
                                    objArticuloLN.modificarArticulo(objArticuloNe)

                                    Me.Close()
                                    Dim ds As New DataSet

                                    'Dim frm As New Articulos
                                    ''Dim frm As New Clientes
                                    'frm.MdiParent = XVN
                                    ds = objArticuloLN.cargaGrillaArt()
                                    Articulos.dgvArticulos.DataSource = ds.Tables(0)

                                End If
                            End If
                        End If
                    End If
                End If
            End If
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