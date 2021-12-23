Imports CapaLN
Imports CapaNE
Public Class ListaDePreciosULim
    Dim PrecVtaLN As New PreciosVtaLN
    Dim PrecVtaNE As New ClasePreciosVta

    Private Sub ListaDePreciosULim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicio()

    End Sub
    Private Sub Inicio()
        Dim ds As New DataSet
        ds = PrecVtaLN.cargaGrilla()
        dgvPrecios.DataSource = ds.Tables(0)
        dgvPrecios.Columns(3).Width = 80
        dgvPrecios.Columns(4).Width = 150
        dgvPrecios.Columns(3).DefaultCellStyle.Alignment = ContentAlignment.MiddleRight
        dgvPrecios.Columns(4).DefaultCellStyle.Alignment = ContentAlignment.MiddleRight
        TxtBuscar.Clear()
        CboCampo.Text = "Seleccione"
        ComboBox1.Text = "Seleccione"
        cargarComboCategoria()
        cargarComboMArcas()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        If CboCampo.Text = "Seleccione" Then
            CboCampo.SelectedValue = 0
        End If
        If ComboBox1.Text = "Seleccione" Then
            ComboBox1.SelectedValue = 0
        End If

        ds = PrecVtaLN.buscarFechasGrilla(CboCampo.SelectedValue, ComboBox1.SelectedValue, TxtBuscar.Text)
        dgvPrecios.DataSource = ds.Tables(0)
        dgvPrecios.Columns(3).Width = 80
        dgvPrecios.Columns(4).Width = 150
        dgvPrecios.Columns(3).DefaultCellStyle.Alignment = ContentAlignment.MiddleRight
        dgvPrecios.Columns(4).DefaultCellStyle.Alignment = ContentAlignment.MiddleRight

    End Sub
    Sub cargarComboCategoria()
        Dim ds As DataSet
        Dim objCategLN As New ArticulosLN
        Dim objCategNE As New ClaseCategoria

        ds = New DataSet
        ds = objCategLN.cargarComboCategoria(objCategNE)
        CboCampo.DataSource = ds.Tables("tabCate")
        CboCampo.DisplayMember = "NomCategoria"
        CboCampo.ValueMember = "idCategoria"
        CboCampo.Text = "Seleccione"
        'CboCampo.Items.Add("Seleccione")
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
        'ComboBox1.Items.Add("Seleccione")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Inicio()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class