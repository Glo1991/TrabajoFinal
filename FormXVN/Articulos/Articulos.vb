Imports CapaLN
Imports CapaNE
Public Class Articulos
    Dim objArticulo As New ArticulosLN
    Dim objArticuloLN As New ArticulosLN
    Dim objArticulotNe As New ClaseCategoria
    Public idArticulo As Integer
    Public idMArca As Integer
    Public idcategoria As Integer
    Private Sub Articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        ds = objArticulo.cargaGrillaArt()
        dgvArticulos.DataSource = ds.Tables(0)
        dgvArticulos.Columns(0).Width = 70
        dgvArticulos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If XVN.Label3.Text = "Limitada" Then
            Button4.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NuevoArticulo.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim resp As Integer
        resp = MessageBox.Show("¿Desea modificar el Artículo?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            Dim objArtNE As New ClaseArticulo
            Dim objArtLN As New ArticulosLN
            Dim formModArt As New ModificarArticulo
            Dim idArticulo As Integer
            Dim idMArca As Integer
            Dim idCategoria As Integer
            Dim ds As New DataSet
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            If dgvArticulos.CurrentRow.Selected = True Then
                idArticulo = Me.dgvArticulos.CurrentRow.Cells(0).Value
                ds = objArtLN.buscaridArticulo(idArticulo)
                ModificarArticulo.txtCodigo.Text = ds.Tables(0).Rows(0).Item(0).ToString
                ModificarArticulo.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
                ModificarArticulo.idMArca = ds.Tables(0).Rows(0).Item(2)
                ModificarArticulo.idcategoria = ds.Tables(0).Rows(0).Item(3).ToString
                ModificarArticulo.txtSMin.Text = ds.Tables(0).Rows(0).Item(4).ToString
                ModificarArticulo.TextBox1.Text = ds.Tables(0).Rows(0).Item(5)
                ModificarArticulo.TextBox2.Text = ds.Tables(0).Rows(0).Item(6)
                ds2 = objArticuloLN.buscarmargen(ds.Tables(0).Rows(0).Item(2))
                ModificarArticulo.TextBox3.Text = ds2.Tables(0).Rows(0).Item(0)
                If ds.Tables(0).Rows(0).Item(7) = 1 Then
                    ModificarArticulo.CheckBox2.Checked = True
                    ModificarArticulo.CheckBox1.Checked = False
                Else
                    ModificarArticulo.CheckBox1.Checked = True
                    ModificarArticulo.CheckBox2.Checked = False
                End If
            End If
            ModificarArticulo.idArticulo = idArticulo
            ModificarArticulo.txtCodigo.Enabled = False
            ModificarArticulo.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "Seleccione" Then
            If CboCampo.Text = "Categoría" Then
                Dim ds As New DataSet
                ds = objArticuloLN.busquedaArtCateg(ComboBox1.SelectedValue, TextBox1.Text)
                dgvArticulos.DataSource = ds.Tables(0)
                dgvArticulos.Columns(0).Width = 70
                dgvArticulos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If CboCampo.Text = "Marca" Then
                Dim ds As New DataSet
                ds = objArticuloLN.busquedaArtMarca(ComboBox1.SelectedValue, TextBox1.Text)
                dgvArticulos.DataSource = ds.Tables(0)
                dgvArticulos.Columns(0).Width = 70
                dgvArticulos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Else
            If (CboCampo.Text = "Seleccione" And ComboBox1.Text = "Seleccione") Then
                Dim ds1 As New DataSet
                ds1 = objArticuloLN.busquedaArtDescripcion(TextBox1.Text)
                dgvArticulos.DataSource = ds1.Tables(0)
                dgvArticulos.Columns(0).Width = 70
                dgvArticulos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Else
                Dim ds As New DataSet
                ds = objArticulo.cargaGrillaArt()
                dgvArticulos.DataSource = ds.Tables(0)
                dgvArticulos.Columns(0).Width = 70
                dgvArticulos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
    Sub cargarComboMArcas()
        Dim ds As DataSet
        Dim objMarcaLN As New ArticulosLN
        Dim objMarcaNE As New ClaseMarca

        ds = New DataSet
        ds = objMarcaLN.cargarComboMarcas(objMarcaNE)
        ComboBox1.DataSource = ds.Tables("tabMarc")
        ComboBox1.DisplayMember = "Marca"
        ComboBox1.ValueMember = "idMarca"
        ComboBox1.Text = "Seleccione"
    End Sub

    Private Sub CboCampo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCampo.SelectedIndexChanged
        If CboCampo.Text = "Seleccione" Then

            ComboBox1.Text = "Seleccione"
        Else
            If CboCampo.Text = "Categoría" Then
                cargarComboCategoria()
            Else
                If CboCampo.Text = "Marca" Then
                    cargarComboMArcas()
                End If
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CboCampo.Text = "Seleccione"
        ComboBox1.Text = "Seleccione"
        TextBox1.Clear()
        Dim ds As New DataSet
        ds = objArticulo.cargaGrillaArt()
        dgvArticulos.DataSource = ds.Tables(0)
        dgvArticulos.Columns(0).Width = 70
        dgvArticulos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ds As New DataSet
        Dim objArtLN As New ArticulosLN
        Dim ds2 As New DataSet
        If dgvArticulos.CurrentRow.Selected = True Then
            idArticulo = Me.dgvArticulos.CurrentRow.Cells(0).Value
            ds = objArtLN.buscaridArticulo(idArticulo)
            VerdetalleArtículo.txtCodigo.Text = ds.Tables(0).Rows(0).Item(0).ToString
            VerdetalleArtículo.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
            VerdetalleArtículo.idMArca = ds.Tables(0).Rows(0).Item(2)
            VerdetalleArtículo.idcategoria = ds.Tables(0).Rows(0).Item(3).ToString
            VerdetalleArtículo.txtSMin.Text = ds.Tables(0).Rows(0).Item(4).ToString
            VerdetalleArtículo.TextBox1.Text = ds.Tables(0).Rows(0).Item(5)
            VerdetalleArtículo.TextBox2.Text = ds.Tables(0).Rows(0).Item(6)
            ds2 = objArticuloLN.buscarmargen(ds.Tables(0).Rows(0).Item(2))
            VerdetalleArtículo.TextBox3.Text = ds2.Tables(0).Rows(0).Item(0)
            If ds.Tables(0).Rows(0).Item(7) = 1 Then
                VerdetalleArtículo.CheckBox2.Checked = True
                VerdetalleArtículo.CheckBox1.Checked = False
            Else
                VerdetalleArtículo.CheckBox1.Checked = True
                VerdetalleArtículo.CheckBox2.Checked = False
            End If
        End If
        VerdetalleArtículo.idArticulo = idArticulo
        VerdetalleArtículo.txtCodigo.Enabled = False
        VerdetalleArtículo.Show()
    End Sub

    Private Sub dgvArticulos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvArticulos.MouseDoubleClick
        Dim ds As New DataSet
        Dim objArtLN As New ArticulosLN
        Dim ds2 As New DataSet
        If dgvArticulos.CurrentRow.Selected = True Then
            idArticulo = Me.dgvArticulos.CurrentRow.Cells(0).Value
            ds = objArtLN.buscaridArticulo(idArticulo)
            VerdetalleArtículo.txtCodigo.Text = ds.Tables(0).Rows(0).Item(0).ToString
            VerdetalleArtículo.txtNombre.Text = ds.Tables(0).Rows(0).Item(1).ToString
            VerdetalleArtículo.idMArca = ds.Tables(0).Rows(0).Item(2)
            VerdetalleArtículo.idcategoria = ds.Tables(0).Rows(0).Item(3).ToString
            VerdetalleArtículo.txtSMin.Text = ds.Tables(0).Rows(0).Item(4).ToString
            VerdetalleArtículo.TextBox1.Text = ds.Tables(0).Rows(0).Item(5)
            VerdetalleArtículo.TextBox2.Text = ds.Tables(0).Rows(0).Item(6)
            ds2 = objArticuloLN.buscarmargen(ds.Tables(0).Rows(0).Item(2))
            VerdetalleArtículo.TextBox3.Text = ds2.Tables(0).Rows(0).Item(0)
            If ds.Tables(0).Rows(0).Item(7) = 1 Then
                VerdetalleArtículo.CheckBox2.Checked = True
                VerdetalleArtículo.CheckBox1.Checked = False
            Else
                VerdetalleArtículo.CheckBox1.Checked = True
                VerdetalleArtículo.CheckBox2.Checked = False
            End If
        End If
        VerdetalleArtículo.idArticulo = idArticulo
        VerdetalleArtículo.txtCodigo.Enabled = False
        VerdetalleArtículo.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ListadoArticulos.Show()
    End Sub
End Class