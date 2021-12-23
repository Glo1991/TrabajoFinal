Imports CapaNE
Imports CapaLN
Public Class RegistrarStock
    Dim objStockLN As New StockLN
    Dim objStockNe As New ClaseStock
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Private Sub RegistrarStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarComboCategoria()
        cargarComboProveedores()

    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim objStockLN As New StockLN
        Dim objStockNe As New ClaseStock

        Dim resp As Integer
        resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then

            Dim idstock As Integer
            objStockNe.idCategoris = ComboBox2.SelectedValue
            objStockNe.Producto = txtProducto.Text
            objStockNe.idProv = ComboBox1.SelectedValue
            objStockNe.cantidad = NumericUpDown1.Value

            idstock = objStockLN.InsertarStock(objStockNe)
            Dim ds As DataSet
            Dim objetoSt As New StockLN
            Dim form As New Sotck
            ds = objStockLN.cargaGrilla
            form.dgvStock.DataSource = ds.Tables(0)
        End If
     
        Me.Close()
        Dim dsform As New DataSet
        dsform = objStockLN.cargaGrilla()
        Sotck.dgvStock.DataSource = dsform.Tables(0)
        Sotck.dgvStock.Columns(0).Width = 150
        Sotck.dgvStock.Columns(1).Width = 200
        Sotck.dgvStock.Columns(2).Width = 120
        Sotck.dgvStock.Columns(3).Width = 80
        Sotck.TextBox1.Enabled = False
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
End Class