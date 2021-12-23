Imports CapaLN
Imports CapaNE
Public Class ActualizacionPrecios
    Dim objPrecLN As New PreciosLN
    Dim objPrecNe As New ClasePrecios
    Dim objPrecVtaLN As New PreciosVtaLN
    Dim objPrecVtaNe As New ClasePreciosVta
    Dim idProv As Integer
    Private Sub ActualizacionPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsActual As New DataSet
        dsActual = objPrecVtaLN.cargaActual()
        TextBox1.Text = dsActual.Tables(0).Rows(0).Item(0).ToString
        DateTimePicker1.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        cargarComboCategoria()
        cargarComboProveedores()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        
        If ChBxTodos.Checked = True Then
            objPrecVtaNe.Fecha = DateTimePicker1.Value
            objPrecVtaLN.modificarPrecioVta(objPrecVtaNe, TextBox1.Text)

        End If
        If CheckBoxProv.Checked = True And CheckBoxCat.Checked = False Then
            objPrecVtaNe.Fecha = DateTimePicker1.Value
            objPrecVtaLN.modificarPrecioProvVta(objPrecVtaNe, TextBox1.Text, ComboBox1.SelectedValue)

        End If
        If CheckBoxCat.Checked = True And CheckBoxProv.Checked = False And CheckBoxProd.Checked = False Then
            objPrecVtaNe.Fecha = DateTimePicker1.Value
            objPrecVtaLN.modificarPrecioCAtVta(objPrecVtaNe, TextBox1.Text, ComboBox2.SelectedValue)

        End If
        If CheckBoxCat.Checked = True And CheckBoxProv.Checked = False And CheckBoxProd.Checked = True Then
            objPrecVtaNe.Fecha = DateTimePicker1.Value
            objPrecVtaLN.modificarPrecioProdVta(objPrecVtaNe, TextBox1.Text, ComboBox2.SelectedValue, ComboBox3.Text)

        End If
        If CheckBoxCat.Checked = True And CheckBoxProv.Checked = True And CheckBoxProd.Checked = False Then
            objPrecVtaNe.Fecha = DateTimePicker1.Value
            objPrecVtaLN.modificarPrecioCatYProv(objPrecVtaNe, TextBox1.Text, ComboBox2.SelectedValue, ComboBox1.SelectedValue)

        End If
        If CheckBoxCat.Checked = True And CheckBoxProv.Checked = True And CheckBoxProd.Checked = True Then
            objPrecVtaNe.Fecha = DateTimePicker1.Value
            objPrecVtaLN.modificarPrecioCatProvProd(objPrecVtaNe, TextBox1.Text, ComboBox2.SelectedValue, ComboBox1.SelectedValue, ComboBox3.Text)

        End If
        Dim ds As New DataSet
        Dim prVtaLN As New PreciosVtaLN
        ds = prVtaLN.cargaGrilla()
        PreciosVentas.dgvPrecios.DataSource = ds.Tables(0)
        PreciosVentas.dgvPrecios.Columns(0).Width = 200
        PreciosVentas.dgvPrecios.Columns(3).Visible = False
        PreciosVentas.dgvPrecios.Columns(4).Visible = False
        PreciosVentas.dgvPrecios.Columns(5).Visible = False
        Me.Close()
    End Sub

    Private Sub ChBxTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBxTodos.CheckedChanged
        If ChBxTodos.Checked = True Then
            CheckBoxCat.Enabled = False
            CheckBoxProd.Enabled = False
            CheckBoxProv.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
        Else
            CheckBoxCat.Enabled = True
            CheckBoxProd.Enabled = True
            CheckBoxProv.Enabled = True
        End If
    End Sub
    Sub cargarComboProveedores()
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock

        ds = New DataSet
        ds = objStockLN.cargarComboProveedores(objStockNe)
        ComboBox1.DataSource = ds.Tables("tabProv")
        ComboBox1.DisplayMember = "NomRaz"
        ComboBox1.ValueMember = "idProv"
        ComboBox1.Text = "Seleccione"
    End Sub
    Sub cargarComboCategoria()
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock

        ds = New DataSet
        ds = objStockLN.cargarComboCategoria(objStockNe)
        ComboBox2.DataSource = ds.Tables("tabCat")
        ComboBox2.DisplayMember = "NomCategoria"
        ComboBox2.ValueMember = "idCategoria"
        ComboBox2.Text = "Seleccione"
    End Sub
    Sub cargarComboProducto()
        Dim ds As DataSet
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock

        ds = New DataSet
        ds = objStockLN.cargarComboProducto(objStockNe, ComboBox2.Text)
        ComboBox3.DataSource = ds.Tables("tabCat")
        ComboBox3.DisplayMember = "Producto"
        ComboBox3.ValueMember = "idStock"
        ComboBox3.Text = "Seleccione"
    End Sub
  
    Private Sub CheckBoxCat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCat.CheckedChanged
        If CheckBoxCat.Checked = True Then
            ComboBox2.Enabled = True
        Else
            ComboBox2.Enabled = False
        End If
        If CheckBoxCat.Checked = True Or CheckBoxProd.Checked = True Or CheckBoxProv.Checked = True Then
            ChBxTodos.Checked = False
            ChBxTodos.Enabled = False
           
        Else
            ChBxTodos.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxProd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxProd.CheckedChanged 
        If CheckBoxProd.Checked = True Then
            ComboBox3.Enabled = True
        Else
            ComboBox3.Enabled = False
        End If
        If CheckBoxCat.Checked = True Or CheckBoxProd.Checked = True Or CheckBoxProv.Checked = True Then
            ChBxTodos.Checked = False
            ChBxTodos.Enabled = False
          
        Else
            ChBxTodos.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxProv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxProv.CheckedChanged

        If CheckBoxProv.Checked = True Then
            ComboBox1.Enabled = True

        Else
            ComboBox1.Enabled = False
        End If
        If CheckBoxCat.Checked = True Or CheckBoxProd.Checked = True Or CheckBoxProv.Checked = True Then
            ChBxTodos.Checked = False
            ChBxTodos.Enabled = False
        Else
            ChBxTodos.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text <> "Seleccione" Then
            cargarComboProducto()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class