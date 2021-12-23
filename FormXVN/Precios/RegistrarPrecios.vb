Imports CapaNE
Imports CapaLN
Public Class RegistrarPrecios
    Dim objPrecLN As New PreciosLN
    Dim objPreckNe As New ClasePrecios
    Public idStoock As Integer
    Public idAProv As Integer
    Private Sub RegistrarPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarComboProveedores()
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        BuscarProductoPr.Show()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim objPrecLN As New PreciosLN
        Dim objPrecNe As New ClasePrecios
        Dim objPrecVtaLN As New PreciosVtaLN
        Dim objPrecVtaNe As New ClasePreciosVta

        Dim resp As Integer
        resp = MessageBox.Show("¿Confirma Guardar los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then

            Dim idPrec As Integer
            objPrecNe.idStock = idStoock
            objPrecNe.idProv = ComboBox1.SelectedValue
            objPrecNe.Precio = TextBox1.Text
            objPrecNe.Fecha = DateTimePicker1.Value

            idPrec = objPrecLN.InsertarPrecio(objPrecNe)
            Dim ds As New DataSet
            ds = objPrecLN.cargaGrilla()

            PreciosProveedor.dgvPrecios.DataSource = ds.Tables(0)
            PreciosProveedor.dgvPrecios.Columns(4).Visible = False
            PreciosProveedor.dgvPrecios.Columns(5).Visible = False
            PreciosProveedor.dgvPrecios.Columns(6).Visible = False

            'inserto en lista de precios de venta
            Dim PrecVtaLN As New PreciosVtaLN
            Dim PrecVtaNE As New ClasePreciosVta
            Dim idPrecVta As Integer
            Dim actual As Integer
            Dim dsAct As New DataSet
            dsAct = objPrecVtaLN.cargaActual()
            actual = dsAct.Tables(0).Rows(0).Item(0).ToString

            objPrecVtaNe.idStock = idStoock
            objPrecVtaNe.idProv = ComboBox1.SelectedValue
            objPrecVtaNe.Precio = (TextBox1.Text * actual / 100) + TextBox1.Text
            objPrecVtaNe.Fecha = DateTimePicker1.Value
            idPrecVta = objPrecVtaLN.InsertarPrecio(objPrecVtaNe)

        End If
        
        Me.Close()

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class