Imports CapaLN
Imports CapaNE
Public Class VerdetalleArtículo
    Dim objArticuloLN As New ArticulosLN
    Public idArticulo As Integer
    Public idMArca As Integer
    Public idcategoria As Integer
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub VerdetalleArtículo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigo.Enabled = False
        txtNombre.Enabled = False
        txtSMin.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboCategoria.Enabled = False
        cmbMarca.Enabled = False
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        cargarComboCategoria()
        cargarComboMArcas()
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
End Class